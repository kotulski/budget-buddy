namespace Budget_Buddy_logic
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            (string name, float initialBudget) = CreateBudget();
            Budget budget = new Budget(name, initialBudget);
            budget.Greeting();
            int choice = 0;
            while (choice != 6)
            {
                choice = DisplayMenu(budget);
            }
        }

        public static (string, float) CreateBudget()
        {
            Console.Write("Podaj swoje imię: ");
            string name = Console.ReadLine();
            char[] nameArray = name.ToCharArray();
            nameArray[0] = char.ToUpper(nameArray[0]);
            name = new string(nameArray);
            Console.Write("Podaj swój aktualny budżet (format 0,00): ");
            try
            {
                float initialBudget = float.Parse(Console.ReadLine());
                return (name, initialBudget);
            }
            catch (FormatException)
            {
                Console.WriteLine("Niepoprawny format kwoty. Spróbuj ponownie.");
                return CreateBudget();
            }
        }

        public static int DisplayMenu(Budget budget)
        {
            Console.WriteLine("Co chcesz teraz zrobić?");
            Console.WriteLine("1. Wyświetl aktualny budżet.");
            Console.WriteLine("2. Dodaj wydatek.");
            Console.WriteLine("3. Dodaj przychód.");
            Console.WriteLine("4. Zarządzaj budżetem.");
            Console.WriteLine("5. Wygeneruj raport.");
            Console.WriteLine("6. Zakończ program.\n");
            string choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    budget.Display();
                    break;
                case "2":
                    budget.AddExpense();
                    break;
                case "3":
                    budget.AddIncome();
                    break;
                //case "4":
                //    budget.ManageBudget();
                //    break;
                case "5":
                    budget.GenerateReport();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                    break;
            }
            Console.WriteLine();
            return int.Parse(choice);
        }
    }
}

