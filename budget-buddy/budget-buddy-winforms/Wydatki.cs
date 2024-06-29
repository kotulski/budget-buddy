using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace budget_buddy_winforms
{
    public partial class Wydatki : BaseForm
    {
        private float expense;
        private string category;
        private string date;

        public Wydatki(string name, float budget, float dayL, float weekL, float monthL, float yearL, List<List<object>> lOT)
            : base(name, budget, dayL, weekL, monthL, yearL, lOT)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Wybierz.Text))
            {
                MessageBox.Show("Proszę wybrać kategorię.");
                return;
            }

            if (float.TryParse(textBox1.Text, out expense) && expense > 0.009)
            {
                userBudget -= expense;
                category = Wybierz.Text;
                date = DateTime.Now.ToString("dd/MM/yyyy");

                if (listOfTransactions == null)
                {
                    listOfTransactions = new List<List<object>>();
                }

                listOfTransactions.Add(new List<object> { "Wydatek", expense, date, category });
                SaveUserData(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
                LimitCheck();
                NavigateToMain();
            }
            else
            {
                MessageBox.Show("Upewnij się, że wpisałeś prawidłową dodatnią kwotę.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NavigateToMain();
        }

        private void LimitCheck()
        {
            var limits = new[]
            {
                new { Limit = dayLimit, Start = DateTime.Today, End = DateTime.Today.AddDays(1).AddSeconds(-1) },
                new { Limit = weekLimit, Start = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek), End = DateTime.Today.AddDays(7 - (int)DateTime.Today.DayOfWeek).AddSeconds(-1) },
                new { Limit = monthLimit, Start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), End = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddSeconds(-1) },
                new { Limit = yearLimit, Start = new DateTime(DateTime.Today.Year, 1, 1), End = new DateTime(DateTime.Today.Year + 1, 1, 1).AddSeconds(-1) }
            };

            foreach (var limit in limits)
            {
                var expenses = listOfTransactions
                    .Where(t => t[0].ToString() == "Wydatek" && DateTime.TryParseExact(t[2]?.ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime transactionDate) && transactionDate >= limit.Start && transactionDate <= limit.End)
                    .Sum(t => float.Parse(t[1].ToString()));

                if (limit.Limit != -1 && expenses > limit.Limit)
                {
                    MessageBox.Show($"Przekroczono limit wynoszący {limit.Limit} zł.");
                }
            }
        }

        private void SaveUserData(string name, float budget, float dayLimit, float weekLimit, float monthLimit, float yearLimit, List<List<object>> transactions)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDirectory, "userdata.json");

            List<UserData> users = new List<UserData>();
            if (File.Exists(filePath))
            {
                string existingJson = File.ReadAllText(filePath);
                users = JsonConvert.DeserializeObject<List<UserData>>(existingJson) ?? new List<UserData>();
            }

            var existingUser = users.FirstOrDefault(u => u.Name == name);
            if (existingUser != null)
            {
                existingUser.Budget = budget;
                existingUser.DayLimit = dayLimit;
                existingUser.WeekLimit = weekLimit;
                existingUser.MonthLimit = monthLimit;
                existingUser.YearLimit = yearLimit;
                existingUser.Transactions = transactions;
            }
            else
            {
                var newUser = new UserData
                {
                    Name = name,
                    Budget = budget,
                    DayLimit = dayLimit,
                    WeekLimit = weekLimit,
                    MonthLimit = monthLimit,
                    YearLimit = yearLimit,
                    Transactions = transactions
                };
                users.Add(newUser);
            }
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
