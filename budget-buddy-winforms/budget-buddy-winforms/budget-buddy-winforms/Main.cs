using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budget_buddy_winforms
{
    public partial class Main : Form
    {
        private string userName;
        private float userBudget;
        private float dayLimit;
        private float weekLimit;
        private float monthLimit;
        private float yearLimit;
        private List<List<object>> listOfTransactions;

        public Main(string name, float budget, float dayL, float weekL, float monthL, float yearL, List<List<object>> lOT)
        {
            InitializeComponent();
            userName = CapitalizeFirstLetter(name);  // Capitalize first letter
            userBudget = budget;
            dayLimit = dayL;
            weekLimit = weekL;
            monthLimit = monthL;
            yearLimit = yearL;
            listOfTransactions = lOT;

            label3.Text = userName;
            // Format the number with two decimal places
            label4.Text = $"{userBudget:0.00} zł";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Wydatki wydatki = new Wydatki(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
            wydatki.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Przychody przychody = new Przychody(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
            przychody.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Limity limity = new Limity(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
            limity.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Raport raport = new Raport(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
            raport.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
}
