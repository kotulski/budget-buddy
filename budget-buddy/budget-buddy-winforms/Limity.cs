using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace budget_buddy_winforms
{
    public partial class Limity : BaseForm
    {

        public Limity(string name, float budget, float dayL, float weekL, float monthL, float yearL, List<List<object>> lOT)
            : base(name, budget, dayL, weekL, monthL, yearL, lOT)
        {
            InitializeComponent();
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
                    dayLimit = value;
                    break;
                case "Tydzień":
                    weekLimit = value;
                    break;
                case "Miesiąc":
                    monthLimit = value;
                    break;
                case "Rok":
                    yearLimit = value;
                    break;
            }
        }

    }
}
