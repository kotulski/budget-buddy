using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budget_buddy_winforms
{
    internal class LimityKlasa
    {
        private float dayLimit;
        private float weekLimit;
        private float monthLimit;
        private float yearLimit;

        public LimityKlasa(float dayLimit, float weekLimit, float monthLimit, float yearLimit)
        {
            this.dayLimit = dayLimit;
            this.weekLimit = weekLimit;
            this.monthLimit = monthLimit;
            this.yearLimit = yearLimit;
        }

        public float DayLimit
        {
            get { return dayLimit; }
            set { dayLimit = value; }
        }

        public float WeekLimit
        {
            get { return weekLimit; }
            set { weekLimit = value; }
        }

        public float MonthLimit
        {
            get { return monthLimit; }
            set { monthLimit = value; }
        }

        public float YearLimit
        {
            get { return yearLimit; }
            set { yearLimit = value; }
        }
    }
}
