using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karacsonyCLI
{
    internal class Program
    {
        static List<NapiMunka> list=new List<NapiMunka>();
        static void Main(string[] args)
        {
            AdatBeolvas();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Feladat8();

            Console.ReadLine();
        }

        public static void AdatBeolvas()
        {
            StreamReader sr = new StreamReader("diszek.txt");
            while(!sr.EndOfStream)
            {
                NapiMunka napiMunka = new NapiMunka(sr.ReadLine());
                list.Add( napiMunka );
            }
            sr.Close();
        }

        public static void Feladat4()
        {
            Console.WriteLine($"4. feladat: Összesen {NapiMunka.KeszultDb} darab dísz készült.");
        }

        static string valasz = "";
        static bool vane = false;
        public static void Feladat5()
        {
            foreach (var item in list)
            {
                if (item.HarangKesz+item.FenyofaKesz+item.AngyalkaKesz==0)
                {
                    vane = true;
                    break;
                }
            }
            if (vane)
            {
                valasz = "5. feladat: Volt olyan nap, amikor egyetlen dísz sem készült.";
            }
            else
            {
                valasz = "5. feladat: Nem volt olyan nap, amikor egyetlen dísz sem készült.";
            }
            Console.WriteLine(valasz);
        }

        static int beker = 0;
        static bool vanetalalat = false;
        public static void Feladat6()
        {
            int talalatangyal = 0;
            int talalatfenyo = 0;
            int talalatharang = 0;
            do
            {
                Console.Write("Adja meg a keresett napot [1 ... 40]: ");
                beker=int.Parse(Console.ReadLine());
                foreach (var item in list)
                {
                    if (beker == item.Nap)
                    {
                        vanetalalat = true;
                        talalatangyal = item.AngyalkaKesz - item.AngyalkaEladott;
                        talalatfenyo = item.FenyofaKesz - item.FenyofaEladott;
                        talalatharang = item.HarangKesz - item.HarangEladott;
                    }
                }
                if (vanetalalat)
                {
                    Console.WriteLine($"\tA(z) {beker}. napon {talalatharang} harang, {talalatangyal} angyalka, {talalatfenyo} fenyőfa maradt készleten.");
                }
            }while(!vanetalalat);
        }

        public static void Feladat7()
        {
            var elhar = (from sor in list select -sor.HarangEladott).Sum();
            var elamgy = (from sor in list select -sor.AngyalkaEladott).Sum();
            var elfenyo = (from sor in list select -sor.FenyofaEladott).Sum();

            var eladasok = new List<(int, string)>()
            {
                (elhar, "Harang"),
                (elamgy, "Angyalka"),
                (elfenyo, "Fenyőfa")
            };
            var legtobb = eladasok.Max().Item1;
            Console.WriteLine($"7. feladat: Legtöbbet eladoot dísz : {legtobb} darab");
            foreach (var item in eladasok)
            {
                if (item.Item1==legtobb)
                {
                    Console.WriteLine($"\t{item.Item2}");
                }
            }
        }

        public static void Feladat8()
        {
            StreamWriter sw=new StreamWriter("bevetel.txt", false, Encoding.UTF8);
            int napok = 0;
            foreach (var item in list)
            {
                if (item.NapiBevetel()>=10000)
                {
                    napok++;
                    sw.WriteLine($"{item.Nap}: {item.NapiBevetel()}");
                }
            }
            sw.WriteLine($"{napok} napon volt legalább 10000 Ft a bevétel.");
            sw.Close();
        }
    }
}
