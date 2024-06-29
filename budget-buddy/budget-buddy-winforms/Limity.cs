using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace budget_buddy_winforms
{
    public partial class Limity : BaseForm
    {
        public Limity(string name, float budget, float dayL, float weekL, float monthL, float yearL, List<List<object>> lOT)
            : base(name, budget, dayL, weekL, monthL, yearL, lOT)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Wybierz.Text) || string.IsNullOrEmpty(Wybierz1.Text))
            {
                MessageBox.Show("Proszę wybrać akcję i okres.");
                return;
            }

            float limit = 0;
            if (Wybierz.Text != "Usuń Limit" && (!float.TryParse(textBox1.Text, out limit) || limit < 0))
            {
                MessageBox.Show("Proszę wpisać prawidłową wartość większą lub równą zero dla limitu.");
                return;
            }

            if (Wybierz.Text == "Usuń Limit")
            {
                limit = -1; // Upewnij się, że -1 jest poprawnie przypisywane
            }

            SetLimit(Wybierz1.Text, limit);

            // Zapisz wszystkie limity (łącznie z tygodniowym) do pliku
            SaveUserData(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);

            MessageBox.Show("Zmieniono limity.");
            NavigateToMain();
        }

        private void SaveUserData(string name, float budget, float dayLimit, float weekLimit, float monthLimit, float yearLimit, List<List<object>> transactions = null)
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
                if (transactions != null)
                {
                    existingUser.Transactions = transactions;
                }
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
                    Transactions = transactions ?? new List<List<object>>()
                };
                users.Add(newUser);
            }
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NavigateToMain();
        }

        private void SetLimit(string period, float value)
        {
            switch (period)
            {
                case "Dzień":
                    dayLimit = value;
                    break;
                case "Tydzień":
                    weekLimit = value;
                    break;
                case "Miesiąc":
                    monthLimit = value;
                    break;
                case "Rok":
                    yearLimit = value;
                    break;
            }
        }
    }
}
