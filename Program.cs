using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csudh
{
    internal class Program
    {
        static List<Adatok> list = new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("csudh.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Adatok adatok = new Adatok(sr.ReadLine());
                list.Add(adatok);
            }
            sr.Close();
            Feladat3();
            Feladat5();
            Feladat6();

            Console.ReadKey();
        }

        public static void Feladat3()
        {
            Console.WriteLine($"3. feladat: Domainek száma: {list.Count()}");
        }

        public static string Feladat4(string domain, int szint)
        {
            string[] p = domain.Split('.');
            try { return p[p.Length - szint]; }
            catch { return "nincs"; }
        }

        public static void Feladat5()
        {
            Console.WriteLine("5. feladat");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("\t{0}. szint: {1}", i, Feladat4(list[0].domainname, i));
            }
        }

        public static void Feladat6()
        {
            StreamWriter sw = new StreamWriter("table.html");
            sw.WriteLine("<table>");
            sw.WriteLine("<tr>");
            sw.WriteLine("<th style='text-algin: left'>Ssz</th>");
            sw.WriteLine("<th style='text-algin: left'>Host domain neve</th>");
            sw.WriteLine("<th style='text-algin: left'>Host IP cím</th>");
            sw.WriteLine("<th style='text-algin: left'>1. szint</th>");
            sw.WriteLine("<th style='text-algin: left'>2. szint</th>");
            sw.WriteLine("<th style='text-algin: left'>3. szint</th>");
            sw.WriteLine("<th style='text-algin: left'>4. szint</th>");
            sw.WriteLine("<th style='text-algin: left'>5. szint</th>");
            sw.WriteLine("</tr>"); int i = 1;
            foreach (var item in list)
            {
                sw.WriteLine("<tr>\r\n<th style='text-align: left'>{0}.</th>\r\n", i);
                sw.WriteLine("<td>{0}</td>\r\n", item.domainname);
                sw.WriteLine("<td>{0}</td>\r\n", item.ipcim);
                for (int j = 1; j <= 5; j++) { sw.WriteLine("<td>{0}</td>\r\n", Feladat4(item.domainname, j)); }
                sw.WriteLine("</tr>"); i++;
            }

            sw.Close();
            Console.WriteLine("6. feladat table.html");
        }
    }
}
