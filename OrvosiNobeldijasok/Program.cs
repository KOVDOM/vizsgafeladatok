using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OrvosiNobeldijasok
{
    class Elethossz
    {
        private int Tol { get; set; }
        private int Ig { get; set; }
        public int ElethosszEvekben => Tol == -1 || Ig == -1 ? -1 : Ig - Tol;

        public bool IsmertAzElethossz => ElethosszEvekben != -1;

        public Elethossz(string SzuletesHalalozas)
        {
            string[] m = SzuletesHalalozas.Split('-');
            try
            {
                Tol = int.Parse(m[0]);
            }
            catch (Exception)
            {
                Tol = -1;
            }
            try
            {
                Ig = int.Parse(m[1]);
            }
            catch (Exception)
            {
                Ig = -1;
            }
        }
    }

    internal class Program
    {
        static List<Adatok> list=new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("orvosi_nobeldijak.txt", Encoding.Default);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Adatok adatok=new Adatok(sr.ReadLine());
                list.Add(adatok);
            }
            sr.Close();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();

            Console.Read();
        }

        public static void Feladat3()
        {
            Console.WriteLine($"3. feladat: Díjazottak száma: {list.Count} fő");
        }

        public static void Feladat4()
        {
            Console.WriteLine($"4. feladat: Utolsó év: {list.OrderByDescending(cx => cx.ev).First().ev}");
        }

        public static void Feladat5()
        {
            string input = "";
            bool vane = false;
            do
            {
                Console.Write("5. feladat: Kérem adja meg egy ország kódját: ");
                input = Console.ReadLine();
                var talalt=list.Where(cx=>cx.orzsgakod==input).ToList();
                int talaltszam = talalt.Count();
                if ( talaltszam==1)
                {
                    vane = true;
                    var talatok=talalt.First();
                    Console.WriteLine("\tA megadott ország díjjazottja:");
                    Console.WriteLine($"\tNév: {talatok.nev}");
                    Console.WriteLine($"\tÉv: {talatok.ev}");
                    Console.WriteLine($"\tSz/H: {talatok.SzulHal}");
                }
                else if (talaltszam > 1)
                {
                    vane = true;
                    Console.WriteLine($"\tA megadott országból {talaltszam} fő díjazott volt");
                }
                else
                {
                    Console.WriteLine("\tA megadott országból nem volt díjazott!");
                }
            } while (!vane);
        }

        public static void Feladat6()
        {
            Console.WriteLine("6. feladat: Statisztika:");
            list.GroupBy(cx=>cx.orzsgakod).Where(f=>f.Count()>5).ToList().ForEach(x=>Console.WriteLine($"\t{x.Key} - {x.Count()}"));
        }

        public static void Feladat7()
        {
            double szum = list.Where(cx => new Elethossz(cx.SzulHal).IsmertAzElethossz).Sum(cx => new Elethossz(cx.SzulHal).ElethosszEvekben);
            int db = list.Count(cx => new Elethossz(cx.SzulHal).IsmertAzElethossz);

            Console.WriteLine($"7. feladat: A keresett átlag: {szum/db:N1} év");
        }
    }
}
