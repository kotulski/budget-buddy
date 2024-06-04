using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace budget_buddy_winforms
{
    public partial class Przychody : Form
    {

        private float userBudget;
        private string userName;
        private float dayLimit;
        private float weekLimit;
        private float monthLimit;
        private float yearLimit;
        private List<List<object>> listOfTransactions;
        private float income;
        private string date;

        public Przychody(string name, float budget, float dayL, float weekL, float monthL, float yearL, List<List<object>> lOT)
        {
            InitializeComponent();
            userName = name;
            userBudget = budget;
            dayLimit = dayL;
            weekLimit = weekL;
            monthLimit = monthL;
            yearLimit = yearL;
            listOfTransactions = lOT;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            income = float.Parse(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (float.TryParse(textBox1.Text, out income))
            {
                userBudget += income;
                date = DateTime.Now.ToString("dd/MM/yyyy");
                List<object> transaction = new List<object> { "Przychód", income, date };
                listOfTransactions.Add(transaction);
                Main main = new Main(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Upewnij się, że wpisałeś prawidłową kwotę.");
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main main = new Main(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
            main.Show();
            this.Hide();
        }

        
    }
}
