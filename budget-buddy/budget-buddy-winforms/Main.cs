using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace budget_buddy_winforms
{
    public partial class Main : BaseForm
    {
        private bool warningShown;

        public Main(string name, float budget, float dayL, float weekL, float monthL, float yearL, List<List<object>> lOT)
            : base(name, budget, dayL, weekL, monthL, yearL, lOT)
        {
            InitializeComponent();
            LoadUserData();
            UpdateLabels();

            this.Shown += new EventHandler(Main_Shown);
            this.Activated += new EventHandler(Main_Activated);
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            ShowDebtWarningIfNeeded();
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            warningShown = false;
        }

        private void ShowDebtWarningIfNeeded()
        {
            if (userBudget < 0 && !warningShown)
            {
                warningShown = true;
                MessageBox.Show("Uwaga! Masz dług!");
            }
        }

        public void UpdateUserData(string name, float budget)
        {
            userName = name;
            userBudget = budget;
            dayLimit = -1;
            weekLimit = -1; 
            monthLimit = -1;
            yearLimit = -1; 
            listOfTransactions = LoadTransactions();
            UpdateLabels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NavigateToForm(new Wydatki(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NavigateToForm(new Przychody(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NavigateToForm(new Limity(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text file (*.txt)|*.txt",
                DefaultExt = ".txt",
                FileName = "raport.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveReport(saveFileDialog.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveUserData(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
            Application.Exit();
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
                    Transactions = transactions ?? new List<List<object>>()
                };
                users.Add(newUser);
            }
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        private void UpdateLabels()
        {
            label3.Text = userName;
            label4.Text = $"{userBudget:0.00} zł";
        }

        private void SaveReport(string filePath)
        {
            string fileContent = $"Raport dla użytkownika: {userName}\n\n";
            fileContent += $"Aktualny budżet: {userBudget:0.00} zł\n\n";
            fileContent += "Limity:\n";
            fileContent += $"\tDzienny: {(dayLimit == -1 ? "-" : $"{dayLimit:0.00} zł")}\n";
            fileContent += $"\tTygodniowy: {(weekLimit == -1 ? "-" : $"{weekLimit:0.00} zł")}\n";
            fileContent += $"\tMiesięczny: {(monthLimit == -1 ? "-" : $"{monthLimit:0.00} zł")}\n";
            fileContent += $"\tRoczny: {(yearLimit == -1 ? "-" : $"{yearLimit:0.00} zł")}\n\n";

            fileContent += "Transakcje:\n\n";

            foreach (var transaction in listOfTransactions)
            {
                if (transaction[0].ToString() == "Wydatek")
                {
                    fileContent += $"Wydatek: {transaction[1]} zł - {transaction[2]} - {transaction[3]}\n";
                }
                else if (transaction[0].ToString() == "Przychód")
                {
                    fileContent += $"Przychód: {transaction[1]} zł - {transaction[2]}\n";
                }
                fileContent += "----------------------------------------\n";
            }

            try
            {
                File.WriteAllText(filePath, fileContent);
                MessageBox.Show($"Plik został zapisany jako {filePath}", "Sukces");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zapisywania pliku: {ex.Message}", "Błąd");
            }
        }

        private List<List<object>> LoadTransactions()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDirectory, "userdata.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var users = JsonConvert.DeserializeObject<List<UserData>>(json);
                if (users != null)
                {
                    var user = users.FirstOrDefault(u => u.Name == userName);
                    if (user != null)
                    {
                        return user.Transactions ?? new List<List<object>>();
                    }
                }
            }
            return new List<List<object>>();
        }

        private void LoadUserData()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDirectory, "userdata.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var users = JsonConvert.DeserializeObject<List<UserData>>(json);
                if (users != null)
                {
                    var user = users.FirstOrDefault(u => u.Name == userName);
                    if (user != null)
                    {
                        userName = user.Name;
                        userBudget = user.Budget;
                        dayLimit = user.DayLimit;
                        weekLimit = user.WeekLimit;
                        monthLimit = user.MonthLimit;
                        yearLimit = user.YearLimit;
                        listOfTransactions = user.Transactions ?? new List<List<object>>();
                    }
                }
            }
        }
    }
}
