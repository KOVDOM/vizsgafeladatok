using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifavilágranglista
{
    internal class Program
    {
        static List<Adatok> list = new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("fifa.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Adatok adatok = new Adatok(sr.ReadLine());
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
            Console.WriteLine($"3. feladat: A világranglistán {list.Count} csapat szerepel");
        }

        public static void Feladat4()
        {
            Console.WriteLine($"4. feladat: A csapatok átlagos pontszáma: {list.Sum(cx=>cx.pontszam)/list.Count()} pont");
        }

        public static void Feladat5()
        {            
            Console.WriteLine($"5. feladat: A legtöbbet javító csapat:\n\tHelyezés: {list.OrderBy(cx => cx.valtozas).ToList().Last().helyezes}\n\tCsapat: {list.OrderBy(cx => cx.valtozas).ToList().Last().csapat}\n\tPontszám: {list.OrderBy(cx => cx.valtozas).ToList().Last().pontszam}");
        }

        public static void Feladat6()
        {
            bool szerepel = false;
            foreach (var item in list)
            {
                if (item.csapat=="Magyarország")
                {
                    szerepel = true;
                }
            }
            if (szerepel)
            {
                Console.WriteLine("6. feladat: Magyarország szerepel a csapatok között");
            }
            else
            {
                Console.WriteLine("6. feladat: A csapatok között nincs Magyarország");
            }
            
            //ugyanez linq-val
            bool szerepel = list.Any(item => item.csapat == "Magyarország");

            if (szerepel)
            {
                Console.WriteLine("6. feladat: Magyarország szerepel a csapatok között");
            }
            else
            {
                Console.WriteLine("6. feladat: A csapatok között nincs Magyarország");
            }
        }

        public static void Feladat7()
        {
            Console.WriteLine("7. feladat: Statisztika");
            list.GroupBy(cx => cx.valtozas).Where(f=>f.Count()>1).ToList().ForEach(x => Console.WriteLine($"\t{x.Key} helyet változott: {x.Count()} csapat"));
        }
    }
}
