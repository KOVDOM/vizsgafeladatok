using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kemia_elemek
{
    internal class Program
    {
        static List<Adatok> list =new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("felfedezesek.csv");
            sr.ReadLine();
            while(!sr.EndOfStream)
            {
                Adatok adatok=new Adatok(sr.ReadLine());
                list.Add(adatok);
            }
            sr.Close();
            Feladat3();
            Feladat4();
            string vegyjel=Feladat5();
            Feladat6();
            Feladat7();
            Feladat8();

            Console.ReadLine();
        }

        public static void Feladat3()
        {
            Console.WriteLine($"3. feladat Elemek száma {list.Count()}");
        }

        public static void Feladat4()
        {
            Console.WriteLine($"4. feladat Felfedezések száma az ókorban: {list.Count(c => c.ev == "Ókor")}");
        }

        static string vegyjel;
        public static string Feladat5()
        {
            string Pattern = @"^[a-zA-Z]+$";
            Regex rx= new Regex(Pattern);
            Match match;
            do
            {
                Console.WriteLine("5. feladat Kérek egy vegyjelet:");
                vegyjel = Console.ReadLine();
                match = rx.Match(vegyjel);
            } while (!(vegyjel.Length == 1 || vegyjel.Length == 2) && match.Success);
                return vegyjel;
        }

        public static void Feladat6()
        {
            string talalt_ev = "";
            string talalt_elem = "";
            string talalt_vegyjel = "";
            int talalt_rendszam = 0;
            string talalt_felfedezo = "";
            bool vanevegyjel = false;
            do
            {
                Console.WriteLine("6. feladat");
                Console.WriteLine("Kérek egy vegyjelet:");
                vegyjel = Console.ReadLine();

                foreach (var adatok in list)
                {
                    if (vegyjel == adatok.vegyjel)
                    {
                        vanevegyjel = true;
                        talalt_ev = adatok.ev;
                        talalt_elem = adatok.elem;
                        talalt_vegyjel = adatok.vegyjel;
                        talalt_rendszam = adatok.rendszam;
                        talalt_felfedezo = adatok.felfedezo;
                    }
                }

                if (vanevegyjel)
                {
                    Console.WriteLine($"\tAz elem vegyjele: {talalt_vegyjel}");
                    Console.WriteLine($"\tAz elem neve: {talalt_elem}");
                    Console.WriteLine($"\tRendszáma: {talalt_rendszam}");
                    Console.WriteLine($"\tFelfedezés éve: {talalt_ev}");
                    Console.WriteLine($"\tFelfedező: {talalt_felfedezo}");
                }
                else
                {
                    Console.WriteLine("Nincs ilyen vegyjel az adatbázisban!");
                }
            } while (!vanevegyjel);
        }

        public static void Feladat7()
        {
            List<int> timeSpanList = new List<int>();
            int examinedDiscoverysYear = 0;
            int previousDiscoverysYear = 0;

            for (int i = 1; i < list.Count; i++)
            {
                if (int.TryParse(list[i].ev, out examinedDiscoverysYear) && int.TryParse(list[i - 1].ev, out previousDiscoverysYear))
                {
                    timeSpanList.Add(examinedDiscoverysYear - previousDiscoverysYear);
                }
            }

            int maxTimeSpan = 0;

            for (int i = 0; i < timeSpanList.Count; i++)
            {
                if (timeSpanList[i] > maxTimeSpan)
                {
                    maxTimeSpan = timeSpanList[i];
                }
            }
            Console.WriteLine($"7. feladat {maxTimeSpan} év volt a leghosszabb időszak két elem felfedezése között.");
        }

        public static void Feladat8()
        {
            Console.WriteLine("8. feladat Statisztika");
            list.GroupBy(h=>h.ev).Where(f=>f.Count()>3 && f.Key !="Ókor").ToList().ForEach(a=>Console.WriteLine($"\t{a.Key} {a.Count()} db"));
        }
    }
}
