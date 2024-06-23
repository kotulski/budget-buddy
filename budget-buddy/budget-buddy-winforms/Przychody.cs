using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace budget_buddy_winforms
{
    public partial class Przychody : BaseForm
    {
        private float income;
        private string date;

        public Przychody(string name, float budget, float dayL, float weekL, float monthL, float yearL, List<List<object>> lOT)
            : base(name, budget, dayL, weekL, monthL, yearL, lOT)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (float.TryParse(textBox1.Text, out income) && income > 0.009)
            {
                userBudget += income;
                date = DateTime.Now.ToString("dd/MM/yyyy");
                listOfTransactions.Add(new List<object> { "Przychód", income, date });
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

        
    }
}
