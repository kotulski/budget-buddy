namespace budget_buddy_winforms
{
    public partial class Login : Form
    {
        // Zmienna cz�onkowska do przechowywania imienia
        private string name;

        // Zmienna cz�onkowska do przechowywania bud�etu
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
                Main main = new Main(name, budget);
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
            name = textBox1.Text; // Przechowywanie imienia w zmiennej cz�onkowskiej
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
