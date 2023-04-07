using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Berek2020
{
    internal class Program
    {
        static List<Adatok> list = new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("berek2020.txt");
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

            Console.ReadKey();
        }

        public static void Feladat3()
        {
            Console.WriteLine($"3. feladat: Dolgozók száma: {list.Count()} fő");
        }

        public static void Feladat4()
        {
            Console.WriteLine($"4. Feladat: Bérek átlaga: {list.Sum(cx => cx.ber) / list.Count} eft");
        }

        static string beker = "";
        static string maxkeresonev = "";
        static string maxkeresoneme = "";
        static int maxkeresobelepes = 0;
        static int maxkeresober = 0;
        public static void Feladat5()
        {
            bool joe = false;
            do
            {
                Console.Write("5. feladat: Kérem eg yrészleg nevét: ");
                beker=Console.ReadLine();
                foreach(var item in list)
                {
                    if (item.reszleg==beker)
                    {
                        joe= true;
                    }
                }
                    if (joe)
                    {
                        maxkeresonev=list.OrderBy(cx=>cx.ber).Where(y=>y.reszleg==beker).Last().nev;
                        maxkeresoneme = list.OrderBy(cx => cx.ber).Where(y => y.reszleg == beker).Last().neme;
                        maxkeresobelepes=list.OrderBy(cx=>cx.ber).Where(y => y.reszleg == beker).Last().belepes;
                        maxkeresober=list.OrderBy(cx=>cx.ber).Where(y => y.reszleg == beker).Last().ber;
                    }
                    else
                    {
                        Console.WriteLine("Nincs ilyen részleg a cégnél");
                    }

                
            } while (!joe);
        }

        public static void Feladat6()
        {
            Console.WriteLine($"6. feladat\n\tNév: {maxkeresonev}\n\tNeme: {maxkeresoneme}\n\tBelépés: {maxkeresobelepes}\n\tBér: {maxkeresober}");
        }

        public static void Feladat7()
        {
            Console.WriteLine($"7. feladat: Statisztika\n");
            list.GroupBy(x => x.reszleg).ToList().ForEach(x => Console.WriteLine($"\t{x.Key} - {x.Count()}"));
        }
    }
}
