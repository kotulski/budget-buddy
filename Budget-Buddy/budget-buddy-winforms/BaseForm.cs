using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.IO;

namespace budget_buddy_winforms
{
    public class BaseForm : Form
    {
        protected string userName;
        protected float userBudget;
        protected float dayLimit;
        protected float weekLimit;
        protected float monthLimit;
        protected float yearLimit;
        protected List<List<object>> listOfTransactions;

        protected static Main mainFormInstance;

        protected void SaveUserData(string name, float budget, float dayLimit, float weekLimit, float monthLimit, float yearLimit, List<List<object>> transactions)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDirectory, "userdata.json");

            List<UserData> users;
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                users = JsonConvert.DeserializeObject<List<UserData>>(json) ?? new List<UserData>();
            }
            else
            {
                users = new List<UserData>();
            }

            var existingUser = users.FirstOrDefault(u => u.Name == name);
            if (existingUser != null)
            {
                existingUser.Budget = budget;
                existingUser.DayLimit = dayLimit;
                existingUser.WeekLimit = weekLimit;
                existingUser.MonthLimit = monthLimit;
                existingUser.YearLimit = yearLimit;
                existingUser.Transactions = listOfTransactions;
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
                    Transactions = listOfTransactions
                };
                users.Add(newUser);
            }

            string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }

        public BaseForm()
        {
            listOfTransactions = new List<List<object>>();
        }
        public BaseForm(string name, float budget, float dayL, float weekL, float monthL, float yearL, List<List<object>> lOT)
        {
            userName = CapitalizeFirstLetter(name);
            userBudget = budget;
            dayLimit = dayL;
            weekLimit = weekL;
            monthLimit = monthL;
            yearLimit = yearL;
            listOfTransactions = lOT ?? new List<List<object>>();
        }

        protected string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        public void NavigateToForm(Form form)
        {
            form.Show();
            this.Hide();
        }

        public void NavigateToMain()
        {
            if (mainFormInstance == null)
            {
                mainFormInstance = new Main(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
            }
            else
            {
                mainFormInstance.UpdateUserData(userName, userBudget);
            }

            NavigateToForm(mainFormInstance);
        }

        protected void LoadUserData()
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