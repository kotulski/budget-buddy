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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace budget_buddy_winforms
{
    public partial class Przychody : Form
    {

        private float userBudget;
        private string userName;
        private float income;
        private string note;

        public Przychody(string name, float budget)
        {
            InitializeComponent();
            userName = name;
            userBudget = budget;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            income = float.Parse(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (float.TryParse(textBox1.Text, out income))
            {
                userBudget += income;
                Main main = new Main(userName, userBudget);
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
            Main main = new Main(userName, userBudget);
            main.Show();
            this.Hide();
        }

        
    }
}
