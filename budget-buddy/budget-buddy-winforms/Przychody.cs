﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace budget_buddy_winforms
{
    public partial class Przychody : Form, INavigation
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (float.TryParse(textBox1.Text, out income) && income > 0.009)
            {
                userBudget += income;
                date = DateTime.Now.ToString("dd/MM/yyyy");
                listOfTransactions.Add(new List<object> { "Przychód", income, date });
                NavigateToMain(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
            }
            else
            {
                MessageBox.Show("Upewnij się, że wpisałeś prawidłową dodatnią kwotę.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NavigateToMain(userName, userBudget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
        }

        public void NavigateToMain(string name, float budget, float dayLimit, float weekLimit, float monthLimit, float yearLimit, List<List<object>> listOfTransactions)
        {
            Main main = new Main(name, budget, dayLimit, weekLimit, monthLimit, yearLimit, listOfTransactions);
            main.Show();
            this.Hide();
        }
    }
}
