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
    public partial class Main : BaseForm
    {

        public Main(string name, float budget, float dayL, float weekL, float monthL, float yearL, List<List<object>> lOT)
            : base(name, budget, dayL, weekL, monthL, yearL, lOT)
        {
            InitializeComponent();
            this.Shown += new EventHandler(Main_Shown);
            UpdateLabels();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (userBudget < 0)
            {
                MessageBox.Show("Uwaga! Masz dług!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NavigateToForm(new Wydatki(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NavigateToForm(new Przychody(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NavigateToForm(new Limity(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text file (*.txt)|*.txt",
                DefaultExt = ".txt",
                FileName = "raport.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveReport(saveFileDialog.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UpdateLabels()
        {
            label3.Text = userName;
            label4.Text = $"{userBudget:0.00} zł";
        }

        private void SaveReport(string filePath)
        {
            string fileContent = "Raport z wydatków i przychodów:\n\n";

            foreach (var transaction in listOfTransactions)
            {
                fileContent += transaction[0].ToString() == "Wydatek"
                    ? $"Wydatek: {transaction[1]} zł - {transaction[2]} - {transaction[3]}\n----------------------------------------\n"
                    : $"Przychód: {transaction[1]} zł - {transaction[2]}\n----------------------------------------\n";
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
}
