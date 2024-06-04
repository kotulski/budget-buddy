using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budget_buddy_winforms
{
    public partial class Limity : Form
    {
        private float userBudget;
        private string userName;
        private List<List<object>> listOfTransactions;

        // Deklarujesz właściwości do przechowywania limitów
        public float DayLimit { get; private set; }
        public float WeekLimit { get; private set; }
        public float MonthLimit { get; private set; }
        public float YearLimit { get; private set; }

        public Limity(string name, float budget, float dayL, float weekL, float monthL, float yearL, List<List<object>> lOT)
        {
            InitializeComponent();
            userName = name;
            userBudget = budget;
            DayLimit = dayL;
            WeekLimit = weekL;
            MonthLimit = monthL;
            YearLimit = yearL;
            listOfTransactions = lOT;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Limity_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Wybierz.Text == "Usuń Limit")
            {
                switch (Wybierz1.Text)
                {
                    case "Dzień":
                        DayLimit = 0;
                        break;
                    case "Tydzień":
                        WeekLimit = 0;
                        break;
                    case "Miesiąc":
                        MonthLimit = 0;
                        break;
                    case "Rok":
                        YearLimit = 0;
                        break;
                }
            }
            else
            {
                switch (Wybierz1.Text)
                {
                    case "Dzień":
                        DayLimit = float.Parse(textBox1.Text);
                        break;
                    case "Tydzień":
                        WeekLimit = float.Parse(textBox1.Text);
                        break;
                    case "Miesiąc":
                        MonthLimit = float.Parse(textBox1.Text);
                        break;
                    case "Rok":
                        YearLimit = float.Parse(textBox1.Text);
                        break;
                }
            }

            Main main = new Main(userName, userBudget, DayLimit, WeekLimit, MonthLimit, YearLimit, listOfTransactions);
            MessageBox.Show("Zmieniono limity.");
            main.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main main = new Main(userName, userBudget, DayLimit, WeekLimit, MonthLimit, YearLimit, listOfTransactions);
            main.Show();
            this.Hide();
        }

        private void Wybierz_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
