using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balkezesek
{
    internal class Program
    {
        static List<Adatok> list=new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("balkezesek.csv");
            sr.ReadLine();
            while(!sr.EndOfStream)
            {
                Adatok adatok=new Adatok(sr.ReadLine());
                list.Add(adatok);
            }
            sr.Close();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();

            Console.ReadKey();
        }

        public static void Feladat3()
        {
            Console.WriteLine($"3. feladat {list.Count()}");
        }

        public static void Feladat4()
        {
            Console.WriteLine("4. feladat");
            list.Where(x => x.utolso.ToString("yyyy-MM").Contains("1999-10")).ToList().ForEach(x => Console.WriteLine($"\t{x.nev} {Math.Round(x.magassag * 2.54, 1)} cm"));
        }

        static int bekertev = 0;
        public static void Feladat5()
        {
            bool joe = false;
            do
            {
                Console.Write("Kérek egy 1990 és 1999 közötti évszámot: ");
                bekertev=int.Parse(Console.ReadLine());
                if (bekertev>=1990 && bekertev<=1999)
                {
                    joe= true;
                    Console.WriteLine("Jó az évszám!");
                }
                else
                {
                    Console.WriteLine("Hibás évszám!");
                }
            } while (!joe);
        }

        public static void Feladat6()
        {
            double Osszsuly = 0;
            double darab = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (bekertev >= list[i].elso.Year && bekertev <= list[i].utolso.Year)
                {
                    Osszsuly += list[i].suly;
                    darab++;
                }
            }
            double atlag=Osszsuly/darab;
            Console.WriteLine($"6. feladat {Math.Round(atlag, 2)}");
        }
    }
}
