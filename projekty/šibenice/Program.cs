namespace šibenice
{
    using System;
    using System.IO;
    using System.Linq;

    class Sibenice
    {
        static void Main()
        {
            // Načíst všechna slova z textového souboru
            string[] slova = File.ReadAllLines("text.txt");

            // Vybrat náhodné slovo
            Random rnd = new Random();
            string tajneSlovo = slova[rnd.Next(slova.Length)].ToLower(); // Slovo bude malé písmeno

            char[] hadaneSlovo = new string('_', tajneSlovo.Length).ToCharArray(); // Pole pro hráčovy pokusy
            int zbyvajiciPokusy = 6; // Počet pokusů (hlavy, tělo, ruce, nohy - celkem 6)
            bool vyhra = false;
            string spatneTipy = "";

            Console.WriteLine("Vítejte ve hře Šibenice!");

            while (zbyvajiciPokusy > 0 && !vyhra)
            {
                // Ukázat hráči současný stav hádání
                Console.WriteLine($"\nTvoje slovo: {new string(hadaneSlovo)}");
                Console.WriteLine($"Zbývající pokusy: {zbyvajiciPokusy}");
                Console.WriteLine($"Špatné tipy: {spatneTipy}");

                // Hráč zadá svůj tip
                Console.Write("Tipněte si písmeno: ");
                char tip = Console.ReadLine().ToLower()[0];

                if (tajneSlovo.Contains(tip))
                {
                    // Pokud tipované písmeno je ve slově, doplníme ho do správných pozic
                    for (int i = 0; i < tajneSlovo.Length; i++)
                    {
                        if (tajneSlovo[i] == tip)
                        {
                            hadaneSlovo[i] = tip;
                        }
                    }
                }
                else
                {
                    // Pokud písmeno není ve slově, odebereme pokus
                    zbyvajiciPokusy--;
                    spatneTipy += tip + " ";
                }

                // Zkontrolovat, zda hráč uhodl celé slovo
                if (!hadaneSlovo.Contains('_'))
                {
                    vyhra = true;
                }
            }

            // Výsledek hry
            if (vyhra)
            {
                Console.WriteLine($"\nGratuluji! Uhodl jsi slovo: {tajneSlovo}");
            }
            else
            {
                Console.WriteLine($"\nProhrál jsi! Tajné slovo bylo: {tajneSlovo}");
            }
        }
    }


}
