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

namespace budget_buddy_winforms
{
    public partial class Wydatki : Form
    {

        private float userBudget;
        private string userName;
        private float expense;
        private string category;
        private string note;

        public Wydatki(string name, float budget)
        {
            InitializeComponent();
            userName = name;
            userBudget = budget;
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

        private void Wybierz_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
