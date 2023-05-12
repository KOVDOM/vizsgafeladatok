using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Toto
{
    internal class Program
    {
        static List<Adatok> list=new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("toto.txt");
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
            Feladat8();

            Console.ReadKey();
        }

        public static void Feladat3()
        {
            Console.WriteLine($"3. feladat: Fordulók száma: {list.Count()}");
        }

        public static void Feladat4()
        {
            Console.WriteLine($"4. feladat: Telitalálatos szelvények száma: {list.Sum(cx=>cx.T13p1)} db");
        }

        public static void Feladat5()
        {
            var atlagnyer = (from sor in list select sor.Ny13p1 * sor.T13p1).Average();
            Console.WriteLine($"5. feladat: Átlag: {atlagnyer:.} FT");
        }

        public static void Feladat6()
        {
            var maxnyer=list.OrderBy(cx=>cx.Ny13p1).Where(cv=>cv.T13p1>0).Last();
            var minnyer=list.OrderBy(cx=>cx.T13p1).Last();
            Console.WriteLine($"6.feladat:\n\tLegnagyobbb:\n\tÉv: {maxnyer.ev}\n\tHét: {maxnyer.het}.\n\tForduló: {maxnyer.fordulo}.\n\tTelitalálat: {maxnyer.T13p1} db\n\tNyeremény: {maxnyer.Ny13p1} Ft\n\tEredmények: {maxnyer.eredmeny}\n\n\tLegkisebb:\n\tÉv: {minnyer.ev}\n\tHét: {minnyer.het}.\n\tForduló: {minnyer.fordulo}.\n\tTelitalálat: {minnyer.T13p1} db\n\tNyeremény: {minnyer.Ny13p1} Ft\n\tEredmények: {minnyer.eredmeny}");
        }

        public static void Feladat8()
        {
            bool vane = true;
            foreach(var item in list)
            {
                if(new EredmenyElemzo(item.eredmeny).NemvoltDontetlenMerkozes)
                {
                    vane = false;
                    break;
                }
            }
            if (!vane)
            {
                Console.WriteLine("8. feladat: Volt döntetlen nélküli forduló!");
            }
            else
            {
                Console.WriteLine("8. feladat: Nem volt döntetlen nélküli forduló!");
            }
        }
    }
}
