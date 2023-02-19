using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace vizsgateszt
{
    public class Program
    {
        static List<haromszog> list=new List<haromszog>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("haromszogek.csv");
            while(!sr.EndOfStream)
            {
                haromszog haromszogek = new haromszog(sr.ReadLine());
                list.Add(haromszogek);
            }
            sr.Close();
            Feladat10();
            Feladat11();

            Console.ReadKey();
        }

        public static void Feladat10()
        {
            Console.WriteLine("A,B,C oldal: ");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.a}, {item.b}, {item.c}");
            }
        }

        public static void Feladat11()
        {
            int legnagyobb = 0;
            haromszog legnagyobbhsz = list[0];
            foreach (var item in list)
            {
                if (Derekszog(legnagyobbhsz))
                {
                    if (legnagyobb<item.a*item.b/2)
                    {
                        legnagyobb = item.a * item.b / 2;
                        legnagyobbhsz = item;
                    }
                }
            }
            Console.WriteLine("A legnagyobb területű derékszögűháromszög adatai:");
            Console.WriteLine(legnagyobb);
            Console.WriteLine($"a: {legnagyobbhsz.a} b: {legnagyobbhsz.b} c: {legnagyobbhsz.c}");
        }

        public static bool Derekszog(haromszog haromszog)
        {
            if (haromszog.a*haromszog.a+haromszog.b*haromszog.b==haromszog.c*haromszog.c)
            {
                return true;
            }

            return false;
        }
    }
}
