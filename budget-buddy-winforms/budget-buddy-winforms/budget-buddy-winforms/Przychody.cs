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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace budget_buddy_winforms
{
    public partial class Przychody : Form
    {

        private float userBudget;
        private string userName;

        public Przychody(string name, float budget)
        {
            InitializeComponent();
            userName = name;
            userBudget = budget;
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
