using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelsinkiCLI
{
    public  class Program
    {
        static List<Adatok> list =new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("helsinki.txt");
            while(!sr.EndOfStream)
            {
                Adatok adatok=new Adatok(sr.ReadLine());
                list.Add(adatok);
            }
            sr.Close();
            Feladat3();
            Console.WriteLine($"A maygar olimpikonon az 1952-es Helsinki olimpián {Feladat4(5)} pontszerző helyezést értek el");
            int tornapontok = 0;
            foreach (var item in list)
            {
                if (item.sportag=="torna")
                {
                    tornapontok=Feladat4(item.helyezes);
                }
            }
            Console.WriteLine($"A maygar olimpikonon az 1952-es Helsinki olimpián {tornapontok} pontszerző helyezést értek el torna sportágban");
            Feladat7();

            Console.ReadKey();
        }

        public static void Feladat3()
        {
            Console.WriteLine($"A magyar olimpikonok az 1952-es Helsinki olimpián {list.Count()} pontszerző helyezést értek el.");
        }

        public static int Feladat4(int szam)
        {
            switch (szam)
            {
                case 1:
                    return 7;
                case 2:
                    return 5;
                case 3:
                    return 4;
                case 4:
                    return 3;
                case 5:
                    return 2;
                case 6:
                    return 1;
                default: return 0;
            }
        }

        public static void Feladat7()
        {
            StreamWriter sw = new StreamWriter("etterem.txt", false, encoding: Encoding.UTF8);
            int sportolokszama = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sportolokszama += list[i].sporotolok;
            }
            sw.WriteLine($"Szeretnék asztalt foglalni {sportolokszama} főre!");
            sw.Close();
        }
    }
}
