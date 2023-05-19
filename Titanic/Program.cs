using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Titanic
{
    class Adatok
    {
        public string katnev { get; private set; }
        public int tulelo { get; private set; }
        public int eltunt { get; private set; }

        public Adatok(string sor)
        {
            string[] m = sor.Split(';');
            katnev = m[0];
            tulelo = int.Parse(m[1]);
            eltunt = int.Parse(m[2]);
        }

        public int upk { get { return tulelo + eltunt; } }
        public double aldozat { get { return (double)eltunt / upk * 100; } }
    }

    internal class Program
    {
        static List<Adatok> list=new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("titanic.txt", Encoding.Default);
            while (!sr.EndOfStream)
            {
                Adatok adatok = new Adatok(sr.ReadLine());
                list.Add(adatok);
            }
            sr.Close();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();

            Console.Read();
        }

        public static void Feladat2()
        {
            Console.WriteLine($"2. feladat: {list.Count()} db");
        }

        public static void Feladat3()
        {
            Console.WriteLine($"3. feladat: {list.Sum(cx => cx.tulelo) + list.Sum(cx => cx.eltunt)} fő");
        }

        static string input = "";
        public static void Feladat4()
        {
            bool vane = false;
            Console.Write("4. feladat: Kulcsszó: ");
            input=Console.ReadLine();
            foreach (var item in list)
            {
                if (item.katnev.Contains(input))
                {
                    vane = true;
                }
            }
            if (vane)
            {
                Console.WriteLine("\tVan találat!");
            }
            else
            {
                Console.WriteLine("\tNincs találat!");
            }

            bool vanelinq = list.Any(item => item.katnev.Contains(input));

            if (vanelinq)
            {
                Console.WriteLine("\tVan találat!");
            }
            else
            {
                Console.WriteLine("\tNincs találat!");
            }
        }

        public static void Feladat5()
        {
            string talalat = "";
            foreach (var item in list)
            {
                if (item.katnev.Contains(input))
                {
                    talalat += $"\t{item.katnev} {item.tulelo+item.eltunt} fő\n";
                }
            }
            Console.WriteLine($"5. feladat:\n{talalat}");
        }

        public static void Feladat6()
        {
            Console.WriteLine("6. feladat:");
            var eredmeny = list.Where(i => i.aldozat > 60).Select(i => i.katnev);

            foreach (var item in eredmeny)
            {
                Console.WriteLine($"\t{item}");
            }
        }

        public static void Feladat7()
        {
            Console.WriteLine($"7. feladat: {list.OrderBy(cx => cx.tulelo).Last().katnev}");
        }
    }
}
