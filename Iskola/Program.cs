using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola
{
    public class Program
    {
        static List<Tanulok> list = new List<Tanulok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("nevek.txt", Encoding.UTF8);
            while(!sr.EndOfStream)
            {
                Tanulok tanulok = new Tanulok(sr.ReadLine());
                list.Add(tanulok);
            }
            sr.Close();
            Feladat3();
            Feladat4();
            Feladat6();
            Console.ReadKey();
        }

        public static void Feladat3()
        {
            Console.WriteLine("3. Feladat:");
            foreach (Tanulok tanulok in list)
            {
                Console.WriteLine($"{tanulok.kezdEv} {tanulok.osztaly} {tanulok.nev}");
            }
            Console.WriteLine($"Tanulók száma: {list.Count}");
        }

        public static void Feladat4()
        {
            int counter = 0;
            foreach (var item in list)
            {
                if (counter == 0)
                {
                    Console.WriteLine(item.Egyedikulcs());
                    counter++;
                }
                else if(counter > 0)
                {
                    counter++;
                    if (list.Count == counter)
                    {
                        Console.WriteLine(item.Egyedikulcs());
                    }
                }
            }
        }

        public static void Feladat6()
        {
            StreamWriter sw=new StreamWriter("azonositok.txt", false, encoding: Encoding.UTF8);
            foreach(var item in list)
            {
                sw.WriteLine($"{item.nev} {item.Egyedikulcs()}");
            }
            sw.Close();
        }
    }
}
