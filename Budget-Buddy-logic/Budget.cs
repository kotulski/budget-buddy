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

        public Budget(string name, float amount)
        {
            _name = name;
            _budget = amount;
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
            Console.WriteLine("Co chciałbyś wygenerować raport? (Przychód, Wydatki, Oba): ");
            string reportType = Console.ReadLine().ToLower();
            Console.WriteLine();

            string period = null;
            if (reportType != "przychód")
            {
                Console.Write("Jaki okres czasowy ma obejmować raport? (Dzień, Tydzień, Miesiąc, Kwartał, Pół Roku, Rok, Bez ograniczeń): ");
                period = periodCheck();
                Console.WriteLine();
            }

            switch (reportType)
            {
                case "przychód":
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

        //public void ManageBudget()
        //{
        //    Console.WriteLine("Co chciałbyś zrobić? (Zmień nazwę, Zmień kwotę, Usuń budżet): ");
        //    string choice = Console.ReadLine().ToLower();
        //    Console.WriteLine();

        //    switch (choice)
        //    {
        //        case "zmień nazwę":
        //            Console.Write("Podaj nową nazwę: ");
        //            _name = Console.ReadLine();
        //            Console.WriteLine("Nazwa została zmieniona.");
        //            break;
        //        case "zmień kwotę":
        //            Console.Write("Podaj nową kwotę: ");
        //            try
        //            {
        //                _budget = float.Parse(Console.ReadLine());
        //                Console.WriteLine("Kwota została zmieniona.");
        //            }
        //            catch (FormatException)
        //            {
        //                Console.WriteLine("Niepoprawny format kwoty. Spróbuj ponownie.");
        //                ManageBudget();
        //            }
        //            break;
        //        case "usuń budżet":
        //            Console.WriteLine("Czy na pewno chcesz usunąć budżet? (Tak/Nie): ");
        //            string answer = Console.ReadLine().ToLower();
        //            if (answer == "tak")
        //            {
        //                _budget = 0;
        //                Console.WriteLine("Budżet został usunięty.");
        //            }
        //            else if (answer == "nie")
        //            {
        //                Console.WriteLine("Budżet nie został usunięty.");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Niepoprawna odpowiedź. Spróbuj ponownie.");
        //                ManageBudget();
        //            }
        //            break;
        //        default:
        //            Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
        //            break;
        //    }
        //}
    }
}
