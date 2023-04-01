using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pilotak
{
    internal class Program
    {
        static List<Adatok> list=new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("pilotak.csv");
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
            Feladat7();
            
            Console.ReadKey();
        }

        public static void Feladat3()
        {
            Console.WriteLine($"3. feladat {list.Count()}");
        }

        public static void Feladat4()
        {
            Console.WriteLine($"4. Feladat {list.Last().nev}");
        }

        public static void Feladat5()
        {
            Console.WriteLine($"5. feladat");
            list.Where(cx => cx.szul_datum < DateTime.Parse("1901.01.01")).ToList().ForEach(z => Console.WriteLine($"\t{z.nev} {z.szul_datum.ToShortDateString()})"));
        }

        public static void Feladat6()
        {
            Console.WriteLine($"6. Feladat {list.FindAll(v=>v.rajtszam > 0).OrderBy(e=>e.rajtszam).First().nemzet}");
        }

        public static void Feladat7()
        {
            Console.WriteLine($"7. feladat");
            list.GroupBy(r => r.rajtszam).Where(g => g.Count() > 1 && g.Key != 0).ToList().ForEach(t => Console.Write(t.Key + " "));
        }
    }
}
