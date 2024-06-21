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
            if (string.IsNullOrEmpty(Wybierz.Text) || string.IsNullOrEmpty(Wybierz1.Text))
            {
                MessageBox.Show("Proszę wybrać akcję i okres.");
                return;
            }

            if (Wybierz.Text == "Usuń Limit")
            {
                SetLimit(Wybierz1.Text, -1);
            }
            else
            {
                if (!float.TryParse(textBox1.Text, out float limit) || limit < 0)
                {
                    MessageBox.Show("Proszę wpisać prawidłową wartość większą lub równą zero dla limitu.");
                    return;
                }

                SetLimit(Wybierz1.Text, limit);
            }

            MessageBox.Show("Zmieniono limity.");
            NavigateToMain();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NavigateToMain();
        }

        private void SetLimit(string period, float value)
        {
            switch (period)
            {
                case "Dzień":
                    DayLimit = value;
                    break;
                case "Tydzień":
                    WeekLimit = value;
                    break;
                case "Miesiąc":
                    MonthLimit = value;
                    break;
                case "Rok":
                    YearLimit = value;
                    break;
            }
        }

        private void NavigateToMain()
        {
            Main main = new Main(userName, userBudget, DayLimit, WeekLimit, MonthLimit, YearLimit, listOfTransactions);
            main.Show();
            this.Hide();
        }

    }
}
