using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace budget_buddy_winforms
{
    public interface INavigation
    {
        void NavigateToMain(string name, float budget, float dayLimit, float weekLimit, float monthLimit, float yearLimit, List<List<object>> listOfTransactions);
    }
}
