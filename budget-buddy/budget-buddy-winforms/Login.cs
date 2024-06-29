using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace budget_buddy_winforms
{
    public partial class Login : BaseForm
    {
        private string name;
        private float budget;
        private Main mainFormInstance;
        private List<UserData> users;

        public Login()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                UserData existingUser = users.FirstOrDefault(u => u.Name == name);
                if (existingUser != null)
                {
                    budget = existingUser.Budget;
                }
                else
                {
                    float.TryParse(textBox2.Text, out budget);
                }

                mainFormInstance = new Main(name, budget, existingUser?.DayLimit ?? -1, existingUser?.WeekLimit ?? -1, existingUser?.MonthLimit ?? -1, existingUser?.YearLimit ?? -1, existingUser?.Transactions);
                SaveUserData(name, budget, existingUser?.DayLimit ?? -1, existingUser?.WeekLimit ?? -1, existingUser?.MonthLimit ?? -1, existingUser?.YearLimit ?? -1, existingUser?.Transactions);

                UpdateMainForm(name, budget);
                NavigateToForm(mainFormInstance);
            }
            else
            {
                MessageBox.Show("Upewnij siê, ¿e wpisa³eœ swoje imiê i poda³eœ prawid³ow¹ kwotê.");
            }
        }

        private bool ValidateInput()
        {
            return !string.IsNullOrEmpty(name) &&
                   (float.TryParse(textBox2.Text, out budget) && Math.Abs(budget * 100) % 1 == 0 || string.IsNullOrEmpty(textBox2.Text));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;

            UserData existingUser = users.FirstOrDefault(u => u.Name == name);
            if (existingUser != null)
            {
                budget = existingUser.Budget;
                textBox2.Text = budget.ToString("F2");
            }
            else
            {
                textBox2.Clear();
            }
        }

        private void SaveUserData(string name, float budget, float dayLimit, float weekLimit, float monthLimit, float yearLimit, List<List<object>> transactions = null)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDirectory, "userdata.json");

            bool isNewUser = false;
            UserData existingUser = users.FirstOrDefault(u => u.Name == name);
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
                    Transactions = transactions ?? new List<List<object>>()
                };
                users.Add(newUser);
                isNewUser = true;
            }

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, json);

            if (isNewUser)
            {
                MessageBox.Show($"Dane u¿ytkownika s¹ zapisane w: {filePath}", "Informacja");
            }

            UpdateMainForm(name, budget);
        }

        private void UpdateMainForm(string name, float budget)
        {
            if (mainFormInstance != null)
            {
                mainFormInstance.UpdateUserData(name, budget);
            }
        }

        private void LoadUserData()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDirectory, "userdata.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                users = JsonConvert.DeserializeObject<List<UserData>>(json) ?? new List<UserData>();

                // Przypisanie transakcji do odpowiedniego u¿ytkownika, jeœli istniej¹
                foreach (var user in users)
                {
                    // Sprawdzenie, czy u¿ytkownik ma zapisane transakcje
                    if (user.Transactions != null && user.Transactions.Any())
                    {
                        // Przyk³ad: wyœwietlenie liczby transakcji dla u¿ytkownika
                        Console.WriteLine($"Liczba transakcji dla u¿ytkownika {user.Name}: {user.Transactions.Count}");
                    }
                }
            }
            else
            {
                users = new List<UserData>();
            }
        }
    }
}
