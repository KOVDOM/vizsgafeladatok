using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackieStewart
{
    internal class Program
    {
        static List<Adatok> list = new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("jackie.txt");
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

            Console.ReadKey();
        }

        public static void Feladat3()
        {
            Console.WriteLine($"3. feladat: {list.Count()}");
        }

        public static void Feladat4()
        {
            Console.WriteLine($"4. feladat: {list.OrderBy(cx=>cx.races).Last().year}");
        }

        public static void Feladat5()
        {
            int elott = 0;
            int utan = 0;
            foreach (var item in list) 
            {
                if (item.year<1970)
                {
                    elott+=item.wins;
                }
                else
                {
                    utan+=item.wins;
                }
            }
            Console.WriteLine($"5. feladat\n\t70es évek: {utan} megnyert verseny\n\t60-as évek: {elott} megnyert verseny");

            Console.WriteLine($"\t70-es évek: {list.Where(x=>x.year>= 1970 && x.year<1980).Sum(y=>y.wins)} megnyert verseny");
            Console.WriteLine($"\t60-as évek: {list.Where(x=>x.year>=1960 && x.year<1970).Sum(y=>y.wins)} megnyert verseny");
        }

        public static void Feladat6()
        {
            StreamWriter sw = new StreamWriter("jackie.html");
            sw.WriteLine("<!doctype html>");
            sw.WriteLine("<html>");
            sw.WriteLine("<head></head>");
            sw.WriteLine("<style>td {border:1px solid black}</style>");
            sw.WriteLine("<body>");
            sw.WriteLine("<h1>Jackie Stewrt</h1>");
            sw.WriteLine("<table>");
            foreach (var item in list)
            {
                sw.WriteLine($"<tr><td>{item.year}</td><td>{item.races}</td><td>{item.wins}</td></tr>");
            }
            sw.WriteLine("</table>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");
            sw.Close();
            Console.WriteLine("6. feladat jackie.html");
        }
    }
}
