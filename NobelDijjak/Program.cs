using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobelDijjak
{
    internal class Program
    {
        static List<Adatok> list=new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("orvosi_nobeldijak.txt");
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

            Console.ReadLine();
        }

        public static void Feladat3()
        {
            Console.WriteLine($"3. feladat: Díjazottak száma: {list.Count} fő");
        }

        public static void Feladat4()
        {
            Console.WriteLine($"4. feladat: Utolsó év: {list.OrderBy(x=>x.ev).Last().ev}");
        }

        public static void Feladat5()
        {
            int t_ev = 0;
            string t_nev = "";
            string t_szulHal = "";
            bool vanetalalt=false;
            do
            {
                Console.Write("5. feladat: Kérem adja meg egy ország kódját: ");
                string beker=Console.ReadLine();
                foreach (var item in list)
                {
                    if (beker==item.orszagkod)
                    {
                        vanetalalt = true;
                        t_ev = item.ev;
                        t_nev = item.nev;
                        t_szulHal = item.szuletesHalalozas;
                    }
                }
                if (vanetalalt)
                {
                    Console.WriteLine("\tA megadott ország díjazottja:");
                    Console.WriteLine($"\tNév: {t_nev}");
                    Console.WriteLine($"\tÉv: {t_ev}");
                    Console.WriteLine($"\tSz/H: {t_szulHal}");
                }
                else
                {
                    Console.WriteLine("A megadott országból nincs díjazott");
                }
            } while (!vanetalalt);
        }

        public static void Feladat6()
        {
            Console.WriteLine("6. Statisztika");
            list.GroupBy(cx=>cx.orszagkod).Where(f=>f.Count()>5).ToList().ForEach(f => Console.WriteLine($"\t{f.Key} - {f.Count()}"));
        }

        public static void Feladat7()
        {
            double szum = 0;
            int db = 0;
            foreach (var item in list)
            {
                Elethossz eh = new Elethossz(item.szuletesHalalozas);
                if (eh.IsmertAzElethossz)
                {
                    szum += eh.ElethosszEvekben;
                    db++;
                }
            }
            Console.WriteLine($"7. feladat: A keresett átlag: {szum/db:N1} év");
        }
    }
}
