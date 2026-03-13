using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Bérek2020
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Dolgozo> dolgozoLista = fajlNyit();

            Console.WriteLine($"3. feladat: Dolgozók száma: {dolgozoLista.Count()} fő");

;
            Console.WriteLine($"4. feladat: Bérek átlaga: {Math.Round(dolgozoLista.Average(d => d.Ber) / 1000.0, 1)} eFt");

            // 6. Feladat: bekérés a minta szerint, majd a megadott részlegen a legnagyobb bérű dolgozó kiírása
            Console.Write("5. Feladat: Kérem egy részleg nevét: ");
            string keresettReszleg = Console.ReadLine() ?? string.Empty;

            var reszlegDolgozok = dolgozoLista
                .Where(d => d.Reszleg.Equals(keresettReszleg, StringComparison.CurrentCultureIgnoreCase))
                .ToList();

            if (!reszlegDolgozok.Any())
            {
                Console.WriteLine("6. Feladat: A megadott részleg nem létezik a cégnél!");
            }
            else
            {
                var legnagyobbBeru = reszlegDolgozok.OrderByDescending(d => d.Ber).First();
                Console.WriteLine("6. Feladat: A legtöbbet kereső dolgozó a megadott részlegen");
                Console.WriteLine($"\tNév: {legnagyobbBeru.Nev}");
                Console.WriteLine($"\tNeme: {legnagyobbBeru.Nem}");
                Console.WriteLine($"\tRészleg: {legnagyobbBeru.Reszleg}");
                Console.WriteLine($"\tBelépés: {legnagyobbBeru.Belepes}");
            }

            Console.WriteLine("7. Feladat: Statisztika:");
            var reszlegStat = dolgozoLista
                .GroupBy(d => d.Reszleg)
                .Select(g => new { Reszleg = g.Key, Db = g.Count() });

            foreach (var r in reszlegStat)
            {
                Console.WriteLine($"\t{r.Reszleg} - {r.Db} fő");
            }
        }


        public static List<Dolgozo> fajlNyit()
        {
            List<Dolgozo> buh = new();

            using (StreamReader sr = new StreamReader("berek2020.txt"))
            {
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    buh.Add(new Dolgozo(sr.ReadLine().Split(';')));
                }
            }

            return buh;
        }
    }
}

