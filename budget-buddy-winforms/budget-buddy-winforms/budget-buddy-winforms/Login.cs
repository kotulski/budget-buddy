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
            if (!string.IsNullOrEmpty(textBox1.Text) && (float.TryParse(textBox2.Text, out budget) || string.IsNullOrEmpty(textBox2.Text)))
            {
                name = textBox1.Text;

                // Inicjalizacja pustej listy
                List<List<object>> emptyListOfTransactions = new List<List<object>>();

                // Przekazanie pustej listy do konstruktora Main
                Main main = new Main(name, budget, 0, 0, 0, 0, emptyListOfTransactions);
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
                // Bud�et jest poprawn� liczb� zmiennoprzecinkow� i jest przechowywany w zmiennej cz�onkowskiej
            }
            else
            {
                budget = 0; // Warto�� domy�lna, gdy tekst nie jest liczb�
            }
        }
    }
}
