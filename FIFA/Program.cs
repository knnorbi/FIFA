using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFA
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Country> countries = new List<Country>();

            string[] input = File.ReadAllLines("fifa.txt");

            for (int i = 1; i < input.Length; i++)
            {
                string[] adatok = input[i].Split(';');

                countries.Add(new Country()
                {
                    csapat = adatok[0],
                    helyezes = int.Parse(adatok[1]),
                    valtozas= int.Parse(adatok[2]),
                    pontszam = int.Parse(adatok[3])
                });
            }

            Console.WriteLine(countries.Count);
            Console.WriteLine(Math.Round(countries.Average(c => c.pontszam), 2));

            Country legjobb = countries[0];
            for (int i = 1; i < countries.Count; i++)
            {
                if (countries[i].valtozas > legjobb.valtozas)
                {
                    legjobb = countries[i];
                }
            }
            Console.WriteLine(legjobb.csapat);

            //Console.WriteLine(countries.Max().csapat);
            Console.WriteLine(countries.OrderByDescending(x => x.valtozas).First().csapat);

            //int idx = 0;
            //while (idx < countries.Count && countries[idx].csapat != "Magyarország")
            //{
            //    idx++;
            //}
            //if (idx < countries.Count)
            //{
            //    Console.WriteLine("Van");
            //}
            //else
            //{
            //    Console.WriteLine("Nincs");
            //}
            Console.WriteLine(countries.Count(x => x.csapat == "Magyarország") > 0 ? "Van" : "Nincs");
            
            #region 7. feladat (Dicitonary-vel)
            Dictionary<int, int> valtozasok = new Dictionary<int, int>();

            foreach (var item in countries)
            {
                if (!valtozasok.ContainsKey(item.valtozas))
                {
                    valtozasok.Add(item.valtozas, 0);
                }
                valtozasok[item.valtozas]++;
            }
            foreach (var item in valtozasok)
            {
                if(item.Value > 1)
                {
                    Console.WriteLine($"{item.Key}:\t{item.Value}");
                }
            }
            #endregion
            #region 7. feladat két külön listával/tömbbel 
            //List<int> valtozasok = new List<int>();
            //foreach (var item in conutries)
            //{
            //    if(valtozasok.Where(x => x == item.valtozas).Count() == 0)
            //    {
            //        valtozasok.Add(item.valtozas);
            //    }
            //}

            //int[] darabok = new int[valtozasok.Count];
            //for (int i = 0; i < valtozasok.Count; i++)
            //{
            //    foreach (var item in conutries)
            //    {
            //        if(item.valtozas == valtozasok[i])
            //        {
            //            darabok[i]++;
            //        }
            //    }
            //}

            //for (int i = 0; i < valtozasok.Count; i++)
            //{
            //    if (darabok[i] > 1)
            //    {
            //        Console.WriteLine($"{valtozasok[i]}:\t{darabok[i]}");
            //    }
            //}
            #endregion
            Console.ReadKey();
        }
    }
}
