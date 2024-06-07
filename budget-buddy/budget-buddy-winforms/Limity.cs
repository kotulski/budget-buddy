using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace budget_buddy_winforms
{
    public partial class Limity : Form
    {
        private float userBudget;
        private string userName;
        private List<List<object>> listOfTransactions;

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

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Wybierz.Text))
            {
                MessageBox.Show("Proszę wybrać akcję.");
                return;
            }

            if (string.IsNullOrEmpty(Wybierz1.Text))
            {
                MessageBox.Show("Proszę wybrać okres.");
                return;
            }

            if (Wybierz.Text == "Usuń Limit")
            {
                switch (Wybierz1.Text)
                {
                    case "Dzień":
                        DayLimit = -1;
                        break;
                    case "Tydzień":
                        WeekLimit = -1;
                        break;
                    case "Miesiąc":
                        MonthLimit = -1;
                        break;
                    case "Rok":
                        YearLimit = -1;
                        break;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(textBox1.Text) || !float.TryParse(textBox1.Text, out float limit) || limit < 0)
                {
                    MessageBox.Show("Proszę wpisać prawidłową wartość większą lub równą zero dla limitu.");
                    return;
                }

                switch (Wybierz1.Text)
                {
                    case "Dzień":
                        DayLimit = limit;
                        break;
                    case "Tydzień":
                        WeekLimit = limit;
                        break;
                    case "Miesiąc":
                        MonthLimit = limit;
                        break;
                    case "Rok":
                        YearLimit = limit;
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

    }
}
