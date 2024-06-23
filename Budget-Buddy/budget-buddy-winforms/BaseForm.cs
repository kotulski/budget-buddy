using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace budget_buddy_winforms
{
    public abstract class BaseForm : Form
    {
        protected string userName;
        protected float userBudget;
        protected float dayLimit;
        protected float weekLimit;
        protected float monthLimit;
        protected float yearLimit;
        protected List<List<object>> listOfTransactions;

        public BaseForm()
        {

        }
        public BaseForm(string name, float budget, float dayL, float weekL, float monthL, float yearL, List<List<object>> lOT)
        {
            userName = CapitalizeFirstLetter(name);
            userBudget = budget;
            dayLimit = dayL;
            weekLimit = weekL;
            monthLimit = monthL;
            yearLimit = yearL;
            listOfTransactions = lOT;
        }

        protected string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        public void NavigateToForm(Form form)
        {
            form.Show();
            this.Hide();
        }

        public void NavigateToMain()
        {
            Main main = new Main(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
            NavigateToForm(main);
        }
    }
}