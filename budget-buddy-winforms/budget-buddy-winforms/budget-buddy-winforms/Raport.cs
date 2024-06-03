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

        public Raport(string name, float budget)
        {
            InitializeComponent();
            userName = name;
            userBudget = budget;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main main = new Main(userName, userBudget);
            main.Show();
            this.Hide();
        }
    }
}
