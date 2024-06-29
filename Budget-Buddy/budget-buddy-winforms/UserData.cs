using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budget_buddy_winforms
{
    public class UserData
    {
        public string Name { get; set; }
        public float Budget { get; set; }
        public float DayLimit { get; set; }
        public float WeekLimit { get; set; }
        public float MonthLimit { get; set; }
        public float YearLimit { get; set; }
        public List<List<object>> Transactions { get; set; }
    }
}
