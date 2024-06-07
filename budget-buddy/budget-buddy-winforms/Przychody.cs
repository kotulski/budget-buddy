using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace budget_buddy_winforms
{
    public partial class Przychody : Form
    {
        private float userBudget;
        private string userName;
        private float dayLimit;
        private float weekLimit;
        private float monthLimit;
        private float yearLimit;
        private List<List<object>> listOfTransactions;
        private float income;
        private string date;

        public Przychody(string name, float budget, float dayL, float weekL, float monthL, float yearL, List<List<object>> lOT)
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
            if (!float.TryParse(textBox1.Text, out income) || income < 0)
            {
                MessageBox.Show("Proszę wpisać prawidłową dodatnią kwotę lub 0.");
                income = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (float.TryParse(textBox1.Text, out income) && income >= 0)
            {
                userBudget += income;
                date = DateTime.Now.ToString("dd/MM/yyyy");
                List<object> transaction = new List<object> { "Przychód", income, date };
                listOfTransactions.Add(transaction);
                Main main = new Main(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Upewnij się, że wpisałeś prawidłową dodatnią kwotę lub 0.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main main = new Main(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
            main.Show();
            this.Hide();
        }
    }
}
