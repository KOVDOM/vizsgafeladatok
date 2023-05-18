using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utasszallitok
{
    internal class Program
    {
        static List<Adatok> list= new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("utasszallitok.txt", Encoding.Default);
            sr.ReadLine();
            while(!sr.EndOfStream)
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
            Console.WriteLine($"4. feladat: Adatsorok száma: {list.Count}");
        }

        public static void Feladat5()
        {
            Console.WriteLine($"5. feladatok: Boeing típusok száma: {list.Count(cx=>cx.tipus.Contains("Boeing"))}");
        }

        public static void Feladat6()
        {
            Adatok MaxUtasRepulo=list.First();
            foreach (var item in list)
            {
                if (item.MaxUtas>MaxUtasRepulo.MaxUtas)
                {
                    MaxUtasRepulo = item;
                }
            }
            Console.WriteLine("6. feladat: A legtöbb utas utast szállító repülőgéptípus");
            Console.WriteLine($"\tTípus: {MaxUtasRepulo.tipus}");
            Console.WriteLine($"\tElső felszállás: {MaxUtasRepulo.ev}");
            Console.WriteLine($"\tUtasok száma: {MaxUtasRepulo.utas}");
            Console.WriteLine($"\tSzemélyzet: {MaxUtasRepulo.szemelyzet}");
            Console.WriteLine($"\tUtazósebesség: {MaxUtasRepulo.utazosebesseg}");
        }

        public static void Feladat7()
        {
            Console.WriteLine("7. Feladat");
            string kiir = "";
            Dictionary<string, int> stat=new Dictionary<string, int>();
            stat.Add("Alacsony sebességű", 0);
            stat.Add("Szubszonikus", 0);
            stat.Add("Transzszonikus", 0);
            stat.Add("Szuperszonikus", 0);
            foreach (var item in list)
            {
                stat[item.SebKategotia]++;
            }
            if (stat.Values.Contains(0))
            {
                foreach (var item in stat)
                {
                    if (item.Value==0)
                    {
                        kiir=($"\t{item.Key}");
                    }
                }
            }
            else
            {
                kiir=("\tMinden sebességtípusból van repülőgéptípus.");
            }
            Console.WriteLine(kiir);
        }

        public static void Feladat8()
        {
            StreamWriter sw=new StreamWriter("utasszallitok_new.txt", false, Encoding.UTF8);
            sw.WriteLine("típus;év;utas;személyzet;utazósebesség;felszállótömeg;fesztáv");
            foreach (var item in list)
            {
                sw.WriteLine($"{item.tipus};{item.ev};{item.MaxUtas};{item.MaxSzemelyzet};{item.utazosebesseg};{item.feltomegtonna};{item.fesztavlab}");
            }
            sw.Close();
        }
    }
}
