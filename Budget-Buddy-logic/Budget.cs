using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget_Buddy_logic
{
    internal class Budget
    {
        private static List<Transaction> transactions = new List<Transaction>();

        private string[] categories = { "żywność", "mieszkanie", "transport", "rozrywka", "opieka medyczna", "chemia", "edukacja", "inne" };

        private string _name;
        private float _budget;
        private float _dayLimit;
        private float _weekLimit;
        private float _monthLimit;
        private float _yearLimit;

        public Budget(string name, float amount)
        {
            _name = name;
            _budget = amount;
            _dayLimit = 0;
            _weekLimit = 0;
            _monthLimit = 0;
            _yearLimit = 0;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public float Amount
        {
            get { return _budget; }
            set { _budget = value; }
        }

        public void Greeting()
        {
            Console.WriteLine($"Witaj {_name}!");
        }

        public void Display()
        {
            Console.WriteLine($"Twój aktualny budżet wynosi {_budget.ToString("0.00")} zł.");
        }

        public void AddExpense()
        {
            Console.Write("Podaj kwotę wydatku: ");
            try
            {
                float expense = float.Parse(Console.ReadLine());
                if (expense < 0)
                {
                    Console.WriteLine("Kwota nie może być ujemna.");
                }
                else
                {
                    Console.Write("Podaj kategorię wydatku (Żywność, Mieszkanie, Transport, Rozrywka, Opieka Medyczna, Chemia, Edukacja, Inne): ");
                    string category = Console.ReadLine().ToLower();
                    if (categories.Contains(category))
                    {
                        Console.Write("Dodaj notatkę do wydatku (opcjonalne, jeśli nie chcesz kliknij enter): ");
                        string note = Console.ReadLine();
                        if (note == "")
                        {
                            note = "Brak";
                        }

                        _budget -= expense;
                        category = char.ToUpper(category[0]) + category.Substring(1);
                        Console.WriteLine($"Dodano wydatek: {expense};\nKategoria: {category};\nNotatka: {note}.");
                        Transaction transaction = new Transaction("Wydatek", DateTime.Now.ToString("dd/MM/yyyy"), category, expense, note);
                        transactions.Add(transaction);

                        CheckExpenseLimits(expense);
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawna kategoria. Spróbuj ponownie.");
                        AddExpense();
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Niepoprawny format kwoty. Spróbuj ponownie.");
                AddExpense();
            }
        }

        private void CheckExpenseLimits(float expense)
        {
            if (_dayLimit > 0 && GetTotalExpensesForPeriod("dzień") > _dayLimit)
            {
                Console.WriteLine($"Przekroczono limit dzienny ({_dayLimit} zł)!");
            }
            if (_weekLimit > 0 && GetTotalExpensesForPeriod("tydzień") > _weekLimit)
            {
                Console.WriteLine($"Przekroczono limit tygodniowy ({_weekLimit} zł)!");
            }
            if (_monthLimit > 0 && GetTotalExpensesForPeriod("miesiąc") > _monthLimit)
            {
                Console.WriteLine($"Przekroczono limit miesięczny ({_monthLimit} zł)!");
            }
            if (_yearLimit > 0 && GetTotalExpensesForPeriod("rok") > _yearLimit)
            {
                Console.WriteLine($"Przekroczono limit roczny ({_yearLimit} zł)!");
            }
        }

        private float GetTotalExpensesForPeriod(string period)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;

            switch (period)
            {
                case "dzień":
                    startDate = DateTime.Today;
                    endDate = startDate.AddDays(1).AddSeconds(-1);
                    break;
                case "tydzień":
                    startDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                    endDate = startDate.AddDays(7).AddSeconds(-1);
                    break;
                case "miesiąc":
                    startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    endDate = startDate.AddMonths(1).AddSeconds(-1);
                    break;
                case "rok":
                    startDate = new DateTime(DateTime.Today.Year, 1, 1);
                    endDate = startDate.AddYears(1).AddSeconds(-1);
                    break;
            }

            float totalExpenses = 0;

            foreach (Transaction transaction in transactions)
            {
                if (transaction.Type == "Wydatek" && DateTime.ParseExact(transaction.Date, "dd/MM/yyyy", null) >= startDate && DateTime.ParseExact(transaction.Date, "dd/MM/yyyy", null) <= endDate)
                {
                    totalExpenses += transaction.Amount;
                }
            }

            return totalExpenses;
        }

        public void AddIncome()
        {
            Console.Write("Podaj kwotę przychodu: ");
            try
            {
                float income = float.Parse(Console.ReadLine());
                if (income < 0)
                {
                    Console.WriteLine("Kwota nie może być ujemna.");
                }
                else
                {
                    Console.Write("Dodaj notatkę do przychodu (opcjonalne, jeśli nie chcesz kliknij enter): ");
                    string note = Console.ReadLine();
                    if (note == "")
                    {
                        note = "Brak";
                    }
                    _budget += income;
                    Console.WriteLine($"Dodano przychód: {income};\nNotatka: {note}.");
                    Transaction transaction = new Transaction("Przychód", DateTime.Now.ToString("dd/MM/yyyy"), "Przychód", income, note);
                    transactions.Add(transaction);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Niepoprawny format kwoty. Spróbuj ponownie.");
                AddIncome();
            }
        }

        public void GenerateReport()
        {
            Console.WriteLine("Co chciałbyś wygenerować raport? (Przychody, Wydatki, Oba): ");
            string reportType = Console.ReadLine().ToLower();
            Console.WriteLine();

            string period = null;
                Console.Write("Jaki okres czasowy ma obejmować raport? (Dzień, Tydzień, Miesiąc, Kwartał, Pół Roku, Rok, Bez ograniczeń): ");
                period = periodCheck();
                Console.WriteLine();

            switch (reportType)
            {
                case "przychody":
                    GenerateIncomeReport(period);
                    break;
                case "wydatki":
                    GenerateExpenseReport(period);
                    break;
                case "oba":
                    GenerateBothReport(period);
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                    break;
            }
        }

        private void GenerateExpenseReport(string period)
        {
            Console.WriteLine($"RAPORT - WYDATKI ({GetPeriodTitle(period)})");

            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;

            switch (period)
            {
                case "dzień":
                    startDate = DateTime.Today;
                    endDate = startDate.AddDays(1).AddSeconds(-1);
                    break;
                case "tydzień":
                    startDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                    endDate = startDate.AddDays(7).AddSeconds(-1);
                    break;
                case "miesiąc":
                    startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    endDate = startDate.AddMonths(1).AddSeconds(-1);
                    break;
                case "kwartał":
                    startDate = new DateTime(DateTime.Today.Year, (DateTime.Today.Month - 1) / 3 * 3 + 1, 1);
                    endDate = startDate.AddMonths(3).AddSeconds(-1);
                    break;
                case "pół roku":
                    startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month <= 6 ? 1 : 7, 1);
                    endDate = startDate.AddMonths(6).AddSeconds(-1);
                    break;
                case "rok":
                    startDate = new DateTime(DateTime.Today.Year, 1, 1);
                    endDate = startDate.AddYears(1).AddSeconds(-1);
                    break;
                case "bez ograniczeń":
                    startDate = DateTime.MinValue;
                    endDate = DateTime.MaxValue;
                    break;
            }

            float totalExpenses = 0;

            Console.WriteLine($"Wydatki (Data - Kwota - Kategoria - Notatka):");
            foreach (Transaction transaction in transactions)
            {
                if (transaction.Type == "Wydatek" && DateTime.ParseExact(transaction.Date, "dd/MM/yyyy", null) >= startDate && DateTime.ParseExact(transaction.Date, "dd/MM/yyyy", null) <= endDate)
                {
                    Console.WriteLine($"  {transaction.Date} - {transaction.Amount.ToString("0.00")} - {transaction.Category} - {transaction.Note};");
                    totalExpenses += transaction.Amount;
                }
            }

            Console.WriteLine($"\nSuma wydatków w tym okresie: {totalExpenses.ToString("0.00")} zł");
            Console.WriteLine();
        }

        private void GenerateIncomeReport(string period)
        {
            Console.WriteLine($"RAPORT - PRZYCHODY ({GetPeriodTitle(period)})");

            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;

            switch (period)
            {
                case "dzień":
                    startDate = DateTime.Today;
                    endDate = startDate.AddDays(1).AddSeconds(-1);
                    break;
                case "tydzień":
                    startDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                    endDate = startDate.AddDays(7).AddSeconds(-1);
                    break;
                case "miesiąc":
                    startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    endDate = startDate.AddMonths(1).AddSeconds(-1);
                    break;
                case "kwartał":
                    startDate = new DateTime(DateTime.Today.Year, (DateTime.Today.Month - 1) / 3 * 3 + 1, 1);
                    endDate = startDate.AddMonths(3).AddSeconds(-1);
                    break;
                case "pół roku":
                    startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month <= 6 ? 1 : 7, 1);
                    endDate = startDate.AddMonths(6).AddSeconds(-1);
                    break;
                case "rok":
                    startDate = new DateTime(DateTime.Today.Year, 1, 1);
                    endDate = startDate.AddYears(1).AddSeconds(-1);
                    break;
                case "bez ograniczeń":
                    startDate = DateTime.MinValue;
                    endDate = DateTime.MaxValue;
                    break;
            }

            float totalIncomes = 0;

            Console.WriteLine($"Przychody (Data - Kwota - Notatka):");
            foreach (Transaction transaction in transactions)
            {
                if (transaction.Type == "Przychód" && DateTime.ParseExact(transaction.Date, "dd/MM/yyyy", null) >= startDate && DateTime.ParseExact(transaction.Date, "dd/MM/yyyy", null) <= endDate)
                {
                    Console.WriteLine($"  {transaction.Date} - {transaction.Amount.ToString("0.00")} - {transaction.Note};");
                    totalIncomes += transaction.Amount;
                }
            }

            Console.WriteLine($"\nSuma przychodów w tym okresie: {totalIncomes.ToString("0.00")} zł");
            Console.WriteLine();
        }

        private void GenerateBothReport(string period)
        {
            GenerateIncomeReport(period);
            GenerateExpenseReport(period);
        }

        private string periodCheck()
        {
            string period = Console.ReadLine().ToLower();
            if (period == "dzień" || period == "tydzień" || period == "miesiąc" || period == "kwartał" || period == "pół roku" || period == "rok" || period == "bez ograniczeń")
            {
                return period;
            }
            else
            {
                Console.WriteLine("Niepoprawny okres czasowy. Spróbuj ponownie.");
                return periodCheck();
            }
        }

        private string GetPeriodTitle(string period)
        {
            switch (period)
            {
                case "dzień":
                    return "RAPORT - DZISIEJSZY DZIEŃ";
                case "tydzień":
                    return "RAPORT - BIEŻĄCY TYDZIEŃ";
                case "miesiąc":
                    return "RAPORT - BIEŻĄCY MIESIĄC";
                case "kwartał":
                    return "RAPORT - BIEŻĄCY KWARTAŁ";
                case "pół roku":
                    return "RAPORT - BIEŻĄCE PÓŁROCZE";
                case "rok":
                    return "RAPORT - BIEŻĄCY ROK";
                default:
                    return "RAPORT - BEZ OKREŚLONEGO OKRESU";
            }
        }

        public void ManageBudget()
        {
            Console.WriteLine("Co chciałbyś zrobić? (Ustaw limit, Zmień limit, Usuń limit): ");
            string choice = Console.ReadLine().ToLower();
            Console.WriteLine();

            switch (choice)
            {
                case "ustaw limit":
                    SetLimit();
                    break;
                case "zmień limit":
                    ChangeLimit();
                    break;
                case "usuń limit":
                    DeleteLimit();
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                    break;
            }
        }

        public void SetLimit()
        {
            Console.WriteLine("Na jaki okres czasowy chcesz ustawić limit? (Dzień, Tydzień, Miesiąc, Rok): ");
            string period = Console.ReadLine().ToLower();
            Console.WriteLine();
            switch (period)
            {
                case "dzień":
                    Console.Write("Podaj kwotę limitu na dzień: ");
                    _dayLimit = float.Parse(Console.ReadLine());
                    break;
                case "tydzień":
                    Console.Write("Podaj kwotę limitu na tydzień: ");
                    _weekLimit = float.Parse(Console.ReadLine());
                    break;
                case "miesiąc":
                    Console.Write("Podaj kwotę limitu na miesiąc: ");
                    _monthLimit = float.Parse(Console.ReadLine());
                    break;
                case "rok":
                    Console.Write("Podaj kwotę limitu na rok: ");
                    _yearLimit = float.Parse(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Niepoprawny okres czasowy. Spróbuj ponownie.");
                    SetLimit();
                    break;
            }
        }

        public void ChangeLimit()
        {
            Console.WriteLine("Który limit chciałbyś zmienić? (Dzień, Tydzień, Miesiąc, Rok): ");
            string period = Console.ReadLine().ToLower();
            Console.WriteLine();

            switch (period)
            {
                case "dzień":
                    Console.Write("Podaj nową kwotę limitu na dzień: ");
                    _dayLimit = float.Parse(Console.ReadLine());
                    Console.WriteLine("Limit dzienny został zmieniony.");
                    break;
                case "tydzień":
                    Console.Write("Podaj nową kwotę limitu na tydzień: ");
                    _weekLimit = float.Parse(Console.ReadLine());
                    Console.WriteLine("Limit tygodniowy został zmieniony.");
                    break;
                case "miesiąc":
                    Console.Write("Podaj nową kwotę limitu na miesiąc: ");
                    _monthLimit = float.Parse(Console.ReadLine());
                    Console.WriteLine("Limit miesięczny został zmieniony.");
                    break;
                case "rok":
                    Console.Write("Podaj nową kwotę limitu na rok: ");
                    _yearLimit = float.Parse(Console.ReadLine());
                    Console.WriteLine("Limit roczny został zmieniony.");
                    break;
                default:
                    Console.WriteLine("Niepoprawny okres czasowy. Spróbuj ponownie.");
                    ChangeLimit();
                    break;
            }
        }

        public void DeleteLimit()
        {
            Console.WriteLine("Który limit chciałbyś usunąć? (Dzień, Tydzień, Miesiąc, Rok): ");
            string period = Console.ReadLine().ToLower();
            Console.WriteLine();

            switch (period)
            {
                case "dzień":
                    _dayLimit = 0;
                    Console.WriteLine("Limit dzienny został usunięty.");
                    break;
                case "tydzień":
                    _weekLimit = 0;
                    Console.WriteLine("Limit tygodniowy został usunięty.");
                    break;
                case "miesiąc":
                    _monthLimit = 0;
                    Console.WriteLine("Limit miesięczny został usunięty.");
                    break;
                case "rok":
                    _yearLimit = 0;
                    Console.WriteLine("Limit roczny został usunięty.");
                    break;
                default:
                    Console.WriteLine("Niepoprawny okres czasowy. Spróbuj ponownie.");
                    DeleteLimit();
                    break;
            }
        }
    }
}