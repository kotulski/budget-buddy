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
            if (!string.IsNullOrEmpty(textBox1.Text) &&
                (float.TryParse(textBox2.Text, out budget) && budget >= 0 || string.IsNullOrEmpty(textBox2.Text)))
            {
                name = textBox1.Text;

                // Inicjalizacja pustej listy
                List<List<object>> emptyListOfTransactions = new List<List<object>>();

                // Przekazanie pustej listy do konstruktora Main
                Main main = new Main(name, budget, -1, -1, -1, -1, emptyListOfTransactions);
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Upewnij si�, �e wpisa�e� swoje imi� i poda�e� prawid�ow� kwot�.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox2.Text, out budget))
            {
                if (budget < 0)
                {
                    MessageBox.Show("Bud�et musi by� liczb� dodatni� lub r�wn� zero.");
                    textBox2.Text = "";
                    budget = 0;
                }
                // Bud�et jest poprawn� liczb� zmiennoprzecinkow� i jest przechowywany w zmiennej cz�onkowskiej
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                budget = 0; // Warto�� domy�lna, gdy pole jest puste
            }
            else
            {
                MessageBox.Show("Upewnij si�, �e wpisa�e� swoje imi� i poda�e� prawid�ow� kwot�.");
            }
        }
    }
}
