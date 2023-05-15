using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyszamjatek
{
    internal class Program
    {
        static List<Adatok> list = new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("egyszamjatek1.txt");
            while (!sr.EndOfStream)
            {
                Adatok adatok=new Adatok(sr.ReadLine());
                list.Add(adatok);
            }
            sr.Close();
            Feladat3();
            Feladat4();
            Feladat5();

            Console.ReadKey();
        }

        public static void Feladat3()
        {
            Console.WriteLine($"3. feladat: {list.Count()} db játékos vett részt");
        }

        static int input = 0;
        public static void Feladat4()
        {
            Console.Write("4. feladat: Kérem adja meg egy forsuló számát: ");
            input =int.Parse(Console.ReadLine());
        }

        public static void Feladat5()
        {
            double ossz = 0;
            for (int i = 0; i < list.Count; i++)
            {
                ossz += list[i].fordulo[input - 1];
            }

            double atlag=ossz/list.Count;
            Console.WriteLine($"5. feladat: A {input}. forduló tippjeinek átlaga: {atlag:N1}");
        }
    }
}
