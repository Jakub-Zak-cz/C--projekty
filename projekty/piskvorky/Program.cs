namespace piskvorky
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vítejte ve hře piškvorky, jste křížkem tak začněte - políčka jsou číslovaná od levého horního rohu do pravého spodního. Stačí napsat 1-9 ");

            string[] policko = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" }; // Políčka
            bool hraBezi = true; // Hra pokračuje, dokud není false
            Random rnd = new Random();

            while (hraBezi)
            {
                // Tah hráče
                Console.WriteLine("Vyberte políčko (1-9): ");
                int userChoice = int.Parse(Console.ReadLine());

                // Zkontrolovat, zda je políčko již obsazené
                if (policko[userChoice - 1] == "X" || policko[userChoice - 1] == "O")
                {
                    Console.WriteLine("Políčko je již obsazené! Vyberte jiné.");
                    continue;
                }

                // Označit tah hráče (křížek)
                policko[userChoice - 1] = "X";

                // Zkontrolovat, zda je hra vyhrána nebo remíza
                if (JeHraVyhrana(policko, "X"))
                {
                    Console.WriteLine("Vyhrál jste! Gratulujeme!");
                    break;
                }

                // Zkontrolovat, zda všechna políčka jsou obsazená (remíza)
                if (policko.All(p => p == "X" || p == "O"))
                {
                    Console.WriteLine("Hra skončila remízou!");
                    break;
                }

                // Tah bota
                int botIndex;
                do
                {
                    botIndex = rnd.Next(9); // Bot vybírá náhodné políčko
                }
                while (policko[botIndex] == "X" || policko[botIndex] == "O");

                // Označit tah bota (kolečko)
                policko[botIndex] = "O";
                Console.WriteLine($"Bot si vybral políčko: {botIndex + 1}");

                // Zkontrolovat, zda bot vyhrál
                if (JeHraVyhrana(policko, "O"))
                {
                    Console.WriteLine("Bot vyhrál! Příště to zvládnete.");
                    break;
                }

                // Zkontrolovat, zda všechna políčka jsou obsazená (remíza)
                if (policko.All(p => p == "X" || p == "O"))
                {
                    Console.WriteLine("Hra skončila remízou!");
                    break;
                }
            }
        }

        // Metoda, která kontroluje, zda je hra vyhrána
        static bool JeHraVyhrana(string[] policko, string hrac)
        {
            // Všechny možné výherní kombinace (řádky, sloupce, úhlopříčky)
            int[][] vyherniKombinace = new int[][]
            {
            new int[] { 0, 1, 2 }, // První řádek
            new int[] { 3, 4, 5 }, // Druhý řádek
            new int[] { 6, 7, 8 }, // Třetí řádek
            new int[] { 0, 3, 6 }, // První sloupec
            new int[] { 1, 4, 7 }, // Druhý sloupec
            new int[] { 2, 5, 8 }, // Třetí sloupec
            new int[] { 0, 4, 8 }, // První úhlopříčka
            new int[] { 2, 4, 6 }  // Druhá úhlopříčka
            };

            // Kontrola, zda některá výherní kombinace je splněna
            foreach (var kombinace in vyherniKombinace)
            {
                if (policko[kombinace[0]] == hrac && policko[kombinace[1]] == hrac && policko[kombinace[2]] == hrac)
                {
                    return true;
                }
            }

            return false;
        }
    }
    
}
