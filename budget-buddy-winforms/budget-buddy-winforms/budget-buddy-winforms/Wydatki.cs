using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

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
            expense = float.Parse(textBox1.Text);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (float.TryParse(textBox1.Text, out expense))
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
                MessageBox.Show("Upewnij się, że wpisałeś prawidłową kwotę.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main main = new Main(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
            main.Show();
            this.Hide();
        }

        private void Wybierz_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void limitCheck()
        {
            float periodExpense = 0;
            DateTime today = DateTime.Today;

            // Obliczamy początki i końce okresów dla różnych limitów
            DateTime startOfDay = today.Date;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime startOfYear = new DateTime(today.Year, 1, 1);

            // Obliczamy końce okresów dla różnych limitów
            DateTime endOfDay = startOfDay.AddDays(1).AddSeconds(-1);
            DateTime endOfWeek = startOfWeek.AddDays(7).AddSeconds(-1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddSeconds(-1);
            DateTime endOfYear = startOfYear.AddYears(1).AddSeconds(-1);

            foreach (var transaction in listOfTransactions)
            {
                DateTime transactionDate = DateTime.Parse(transaction[2].ToString()).Date;
                float amount = float.Parse(transaction[1].ToString());

                // Sprawdzamy, czy transakcja mieści się w danym okresie
                if ((dayLimit != 0 && transactionDate >= startOfDay && transactionDate <= endOfDay) ||
                    (weekLimit != 0 && transactionDate >= startOfWeek && transactionDate <= endOfWeek) ||
                    (monthLimit != 0 && transactionDate >= startOfMonth && transactionDate <= endOfMonth) ||
                    (yearLimit != 0 && transactionDate >= startOfYear && transactionDate <= endOfYear))
                {
                    periodExpense += amount;
                }
            }

            // Sprawdzamy przekroczenie limitu dla odpowiedniego okresu
            if (dayLimit != 0 && dayLimit < periodExpense)
            {
                MessageBox.Show("Przekroczono dzienny limit!");
            }
            else if (weekLimit != 0 && weekLimit < periodExpense)
            {
                MessageBox.Show("Przekroczono tygodniowy limit!");
            }
            else if (monthLimit != 0 && monthLimit < periodExpense)
            {
                MessageBox.Show("Przekroczono miesięczny limit!");
            }
            else if (yearLimit != 0 && yearLimit < periodExpense)
            {
                MessageBox.Show("Przekroczono roczny limit!");
            }
        }

    }
}
