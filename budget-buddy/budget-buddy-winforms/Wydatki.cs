using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace budget_buddy_winforms
{
    public partial class Wydatki : Form
    {
        private float userBudget;
        private string userName;
        private float dayLimit;
        private float weekLimit;
        private float monthLimit;
        private float yearLimit;
        private List<List<object>> listOfTransactions;
        private float expense;
        private string category;
        private string date;

        public Wydatki(string name, float budget, float dayL, float weekL, float monthL, float yearL, List<List<object>> lOT)
        {
            InitializeComponent();
            userName = name;
            userBudget = budget;
            dayLimit = dayL;
            weekLimit = weekL;
            monthLimit = monthL;
            yearLimit = yearL;
            listOfTransactions = lOT;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!float.TryParse(textBox1.Text, out expense) || expense < 0.01)
            {
                MessageBox.Show("Proszę wpisać prawidłową dodatnią kwotę.");
                expense = 0;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Wybierz.Text))
            {
                MessageBox.Show("Proszę wybrać kategorię.");
                return;
            }

            if (float.TryParse(textBox1.Text, out expense) && expense >= 0)
            {
                userBudget -= expense;
                category = Wybierz.Text;
                date = DateTime.Now.ToString("dd/MM/yyyy");
                List<object> transaction = new List<object> { "Wydatek", expense, date, category };
                listOfTransactions.Add(transaction);
                limitCheck();
                Main main = new Main(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Upewnij się, że wpisałeś prawidłową dodatnią kwotę.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main main = new Main(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
            main.Show();
            this.Hide();
        }



        private void limitCheck()
        {
            float periodExpense = 0;
            DateTime today = DateTime.Today;

            DateTime startOfDay = today.Date;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime startOfYear = new DateTime(today.Year, 1, 1);

            DateTime endOfDay = startOfDay.AddDays(1).AddSeconds(-1);
            DateTime endOfWeek = startOfWeek.AddDays(7).AddSeconds(-1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddSeconds(-1);
            DateTime endOfYear = startOfYear.AddYears(1).AddSeconds(-1);

            foreach (var transaction in listOfTransactions)
            {
                DateTime transactionDate = DateTime.Parse(transaction[2].ToString()).Date;
                float amount = float.Parse(transaction[1].ToString());

                if ((transactionDate >= startOfDay && transactionDate <= endOfDay) ||
                    (transactionDate >= startOfWeek && transactionDate <= endOfWeek) ||
                    (transactionDate >= startOfMonth && transactionDate <= endOfMonth) ||
                    (transactionDate >= startOfYear && transactionDate <= endOfYear))
                {
                    periodExpense += amount;
                }
            }

            if (dayLimit != -1 && dayLimit < periodExpense)
            {
                MessageBox.Show("Przekroczono dzienny limit wynoszący " + dayLimit + " zł.");
            }
            else if (weekLimit != -1 && weekLimit < periodExpense)
            {
                MessageBox.Show("Przekroczono tygodniowy limit wynoszący " + weekLimit + " zł.");
            }
            else if (monthLimit != -1 && monthLimit < periodExpense)
            {
                MessageBox.Show("Przekroczono miesięczny limit wynoszący " + monthLimit + " zł.");
            }
            else if (yearLimit != -1 && yearLimit < periodExpense)
            {
                MessageBox.Show("Przekroczono roczny limit wynoszący " + yearLimit + " zł.");
            }
        }

        private void Wybierz_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
