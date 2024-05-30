namespace budget_buddy_winforms
{
    public partial class Login : Form
    {
        // Zmienna cz³onkowska do przechowywania imienia
        private string name;

        // Zmienna cz³onkowska do przechowywania bud¿etu
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
                MessageBox.Show("Upewnij siê, ¿e wpisa³eœ swoje imiê i poda³eœ prawid³ow¹ kwotê.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text; // Przechowywanie imienia w zmiennej cz³onkowskiej
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox2.Text, out budget))
            {
                // Bud¿et jest poprawn¹ liczb¹ zmiennoprzecinkow¹ i jest przechowywany w zmiennej cz³onkowskiej
            }
            else
            {
                budget = 0; // Wartoœæ domyœlna, gdy tekst nie jest liczb¹
            }
        }
    }
}
