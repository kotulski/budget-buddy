using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace budget_buddy_winforms
{
    public partial class Wydatki : BaseForm
    {
        private float expense;
        private string category;
        private string date;

        public Wydatki(string name, float budget, float dayL, float weekL, float monthL, float yearL, List<List<object>> lOT)
            : base(name, budget, dayL, weekL, monthL, yearL, lOT)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Wybierz.Text))
            {
                MessageBox.Show("Proszę wybrać kategorię.");
                return;
            }

            if (float.TryParse(textBox1.Text, out expense) && expense > 0.009)
            {
                userBudget -= expense;
                category = Wybierz.Text;
                date = DateTime.Now.ToString("dd/MM/yyyy");
                listOfTransactions.Add(new List<object> { "Wydatek", expense, date, category });
                LimitCheck();
                NavigateToMain();
            }
            else
            {
                MessageBox.Show("Upewnij się, że wpisałeś prawidłową dodatnią kwotę.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NavigateToMain();
        }

        private void LimitCheck()
        {
            var limits = new[]
            {
                new { Limit = dayLimit, Start = DateTime.Today.Date, End = DateTime.Today.Date.AddDays(1).AddSeconds(-1) },
                new { Limit = weekLimit, Start = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek), End = DateTime.Today.AddDays(7-(int)DateTime.Today.DayOfWeek).AddSeconds(-1) },
                new { Limit = monthLimit, Start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), End = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddSeconds(-1) },
                new { Limit = yearLimit, Start = new DateTime(DateTime.Today.Year, 1, 1), End = new DateTime(DateTime.Today.Year, 1, 1).AddYears(1).AddSeconds(-1) }
            };

            foreach (var limit in limits)
            {
                if (limit.Limit != -1 && listOfTransactions
                    .Where(t => t[0].ToString() == "Wydatek" && DateTime.Parse(t[2].ToString()).Date >= limit.Start && DateTime.Parse(t[2].ToString()).Date <= limit.End)
                    .Sum(t => float.Parse(t[1].ToString())) > limit.Limit)
                {
                    MessageBox.Show($"Przekroczono limit wynoszący {limit.Limit} zł.");
                }
            }
        }
    }
}
