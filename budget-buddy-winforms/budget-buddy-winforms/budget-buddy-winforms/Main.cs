using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace budget_buddy_winforms
{
    public partial class Main : Form
    {
        private string userName;
        private float userBudget;
        private float dayLimit;
        private float weekLimit;
        private float monthLimit;
        private float yearLimit;
        private List<List<object>> listOfTransactions;

        public Main(string name, float budget, float dayL, float weekL, float monthL, float yearL, List<List<object>> lOT)
        {
            InitializeComponent();
            userName = CapitalizeFirstLetter(name);
            userBudget = budget;
            dayLimit = dayL;
            weekLimit = weekL;
            monthLimit = monthL;
            yearLimit = yearL;
            listOfTransactions = lOT;

            label3.Text = userName;
            label4.Text = $"{userBudget:0.00} zł";
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Wydatki wydatki = new Wydatki(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
            wydatki.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Przychody przychody = new Przychody(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
            przychody.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Limity limity = new Limity(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
            limity.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.FileName = "raport.txt";

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                string fileContent = "Raport z wydatków i przychodów:\n\n";

                for (int i = 0; i < listOfTransactions.Count; i++)
                {
                    if (listOfTransactions[i][0].ToString() == "Wydatek")
                    {
                        fileContent += $"Wydatek: {listOfTransactions[i][1]} zł - {listOfTransactions[i][2]} - {listOfTransactions[i][3]}\n----------------------------------------\n";
                    }
                    else
                    {
                        fileContent += $"Przychód: {listOfTransactions[i][1]} zł - {listOfTransactions[i][2]}\n----------------------------------------\n";
                    }
                }

                try
                {
                    File.WriteAllText(filePath, fileContent);

                    MessageBox.Show($"Plik został zapisany jako {filePath}", "Sukces");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas zapisywania pliku: {ex.Message}", "Błąd");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
}
