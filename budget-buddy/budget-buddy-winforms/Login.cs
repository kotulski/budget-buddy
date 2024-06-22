using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace budget_buddy_winforms
{
    public partial class Login : Form
    {
        private string name;
        private float budget;

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                List<List<object>> emptyListOfTransactions = new List<List<object>>();
                Main main = new Main(name, budget, -1, -1, -1, -1, emptyListOfTransactions);
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Upewnij siê, ¿e wpisa³eœ swoje imiê i poda³eœ prawid³ow¹ kwotê.");
            }
        }

        private bool ValidateInput()
        {
            return !string.IsNullOrEmpty(name) &&
                   (float.TryParse(textBox2.Text, out budget) && budget > 0.009 || string.IsNullOrEmpty(textBox2.Text));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }

        
    }
}
