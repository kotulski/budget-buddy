using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace budget_buddy_winforms
{
    public partial class Limity : Form
    {

        private float userBudget;
        private string userName;

        public Limity(string name, float budget)
        {
            InitializeComponent();
            userName = name;
            userBudget = budget;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Limity_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main main = new Main(userName, userBudget);
            main.Show();
            this.Hide();
        }
    }
}
