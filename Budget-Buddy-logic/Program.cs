namespace Budget_Buddy_logic
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Podaj swoje imię: ");
            string name = Console.ReadLine();
            Console.Write("Podaj swój aktualny budżet (format 0,00): ");
            float initialBudget = float.Parse(Console.ReadLine());
            Budget budget = new Budget(name, initialBudget);
            budget.Display();
        }
    }
}
