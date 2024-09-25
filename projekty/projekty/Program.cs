namespace projekty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] choices = { "kámen", "nůžky", "papír" };
            Random random = new Random();

            Console.WriteLine("Zvolte: 0 - kámen, 1 - nůžky, 2 - papír");
            int userChoice = int.Parse(Console.ReadLine());

            if (userChoice < 0 || userChoice > 2)
            {
                Console.WriteLine("Neplatná volba!");
                return;
            }

            int computerChoice = random.Next(0, 3);
            Console.WriteLine($"Počítač zvolil: {choices[computerChoice]}");

            // Vyhodnocení výsledku
            if (userChoice == computerChoice)
            {
                Console.WriteLine("Remíza!");
            }
            else if ((userChoice == 0 && computerChoice == 1) ||
                     (userChoice == 1 && computerChoice == 2) ||
                     (userChoice == 2 && computerChoice == 0))
            {
                Console.WriteLine("Vyhráli jste!");
            }
            else
            {
                Console.WriteLine("Prohráli jste!");
            }
        }

    }
}
