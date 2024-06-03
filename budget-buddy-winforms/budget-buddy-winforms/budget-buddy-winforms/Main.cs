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

        public Main(string name, float budget)
        {
            InitializeComponent();
            userName = CapitalizeFirstLetter(name);  // Capitalize first letter
            userBudget = budget;

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
            Wydatki wydatki = new Wydatki(userName, userBudget);
            wydatki.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Przychody przychody = new Przychody(userName, userBudget);
            przychody.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Limity limity = new Limity(userName, userBudget);
            limity.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Raport raport = new Raport(userName, userBudget);
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
