
namespace budget_buddy_winforms
{
    public partial class Main : Form
    {
        private string userName;
        private float userBudget;

        public Main(string name, float budget)
        {
            InitializeComponent();
            userName = name;
            userBudget = budget;

            label3.Text = userName;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Witaj, " + userName + "!");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
