using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BukkMaraton2019
{
    internal class Program
    {
        static List<Adatok> list =new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("bukkm2019.txt", Encoding.Default);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Adatok adatok=new Adatok(sr.ReadLine());
                list.Add(adatok);
            }
            sr.Close();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Feladat8();

            Console.Read();
        }

        public static void Feladat4()
        {
            Console.WriteLine($"4. feladat: Versenytávot nem teljesítők: {(1-list.Count/691.0)*100}%");
        }

        public static void Feladat5()
        {
            int darab = 0;
            foreach (var item in list)
            {
                if (item.noiversenyzo && item.tav=="Rövid")
                {
                    darab++;
                }
            }
            Console.WriteLine($"5. feladat: Női versenyzők száma a rövid távú versenyen: {darab}fő");
        }

        public static void Feladat6()
        {
            bool nagyobbhat=false;
            foreach (var item in list)
            {
                if (item.tobbminthat)
                {
                    nagyobbhat = true;
                    break;
                }
            }
            Console.WriteLine($"6. feladat: {(nagyobbhat ? "Volt" : "Nem volt")} ilyen versenyző");

            bool nagyobbhatlinq = list.Any(item => item.tobbminthat);
            Console.WriteLine($"6. feladat: {(nagyobbhatlinq ? "Volt" : "Nem volt")} ilyen versenyző");

        }

        public static void Feladat7() 
        {
            Console.WriteLine("7. feladat: A felnőtt férfi (ff) kategória győztese rövid távon");
            Adatok gyoztes = null;
            foreach (var item in list)
            {
                if(item.tav=="Rövid" && item.kategoria == "ff")
                {
                    if (gyoztes == null) gyoztes = item;
                    else
                    {
                        if (item.ido<gyoztes.ido)
                        {
                            gyoztes = item;
                        }
                    }
                }
            }
            Console.WriteLine($"\tRajtszam: {gyoztes.rajtszam}");
            Console.WriteLine($"\tNév: {gyoztes.nev}");
            Console.WriteLine($"\tEgyesület: {gyoztes.egyesulet}");
            Console.WriteLine($"\tIdő: {gyoztes.ido}");

            var gyozteslinq = list.Where(item => item.tav == "Rövid" && item.kategoria == "ff")
                  .OrderBy(item => item.ido)
                  .FirstOrDefault();

            if (gyozteslinq != null)
            {
                Console.WriteLine($"7. feladat: A felnőtt férfi (ff) kategória győztese rövid távon");
                Console.WriteLine($"\tRajtszam: {gyozteslinq.rajtszam}");
                Console.WriteLine($"\tNév: {gyozteslinq.nev}");
                Console.WriteLine($"\tEgyesület: {gyozteslinq.egyesulet}");
                Console.WriteLine($"\tIdő: {gyozteslinq.ido}");
            }
        }

        public static void Feladat8()
        {
            Console.WriteLine("8. feladat: Statisztika");
            Dictionary<string, int> stat=new Dictionary<string, int>();
            foreach (var item in list)
            {
                if (stat.ContainsKey(item.kategoria)) stat[item.kategoria]++;
                else stat.Add(item.kategoria, 1);
            }
            foreach (var item in stat) Console.WriteLine($"\t{item.Key} - {item.Value}");

            list.GroupBy(cx=>cx.kategoria).ToList().ForEach(x => Console.WriteLine($"\t{x.Key} - {x.Count()}"));
        }
    }
}
