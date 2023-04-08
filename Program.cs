using Microsoft.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EUtagallamok
{
    internal class Program
    {
        static List<Adatok> list=new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("EUcsatlakozas.txt");
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
            Feladat8();

            Console.ReadKey();
        }

        public static void Feladat3()
        {
            Console.WriteLine($"3. feladat: EU tagállamainak száma: {list.Count()} db");
        }

        public static void Feladat4()
        {
            Console.WriteLine($"4. feladat: 2007-ben {list.Where(cx=>cx.csatlakozas.Year==2007).Count()} ország csatlakozott");
        }

        public static void Feladat5()
        {
            var csat="";
            foreach (var item in list)
            {
                if (item.orszag=="Magyarország")
                {
                    csat += item.csatlakozas;
                }
            }
            Console.WriteLine($"5. feladat: Magyarország csatlakozásának dátuma: {csat}");
        }

        public static void Feladat6()
        {
            bool joe = false;
            foreach (var item in list)
            {
                if (item.csatlakozas.Month==05)
                {
                    joe = true;
                }
            }
            if (joe)
            {
                Console.WriteLine("6. feladat: Májusban volt csatlakozás!");
            }
            else
            {
                Console.WriteLine("6. feladat: Nem májusban volt csatlakozás!");
            }
        }

        public static void Feladat7()
        {
            var utolso=list.OrderBy(cx=>cx.csatlakozas.Year).ToList().Last().orszag;
            Console.WriteLine($"7. feladat: Legutoljára csatlakozott ország: {utolso}");
        }

        public static void Feladat8()
        {
            Console.WriteLine("8. feladat: Statisztika");
            list.GroupBy(f=>f.csatlakozas.Year).ToList().ForEach(a=>Console.WriteLine($"\t{a.Key} {a.Count()}"));
        }
    }
}
