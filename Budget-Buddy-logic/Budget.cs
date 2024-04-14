using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Buddy_logic
{
    internal class Budget
    {
        private string _name;
        private float _amount;

        public Budget(string name, float amount)
        {
            _name = name;
            _amount = amount;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public float Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public void Display()
        {
            Console.WriteLine($"Witaj {_name}! Twój aktualny budżet wynosi {_amount} zł.");
        }   
    }
}
