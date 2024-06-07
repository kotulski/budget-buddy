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
    public partial class Raport : Form
    {
        private float userBudget;
        private string userName;
        private float dayLimit;
        private float weekLimit;
        private float monthLimit;
        private float yearLimit;
        private List<List<object>> listOfTransactions;

        public Raport(string name, float budget, float dayL, float weekL, float monthL, float yearL, List<List<object>> lOT)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Main main = new Main(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
            main.Show();
            this.Hide();
        }

        
    }
}
