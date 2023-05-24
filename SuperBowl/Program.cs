using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBowl
{
    internal class Program
    {
        static List<Adatok> list = new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("SuperBowl.txt", Encoding.Default);
            sr.ReadLine();
            while(!sr.EndOfStream)
            {
                Adatok adatok=new Adatok(sr.ReadLine());
                list.Add(adatok);
            }
            sr.Close();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();

            Console.Read();
        }

        public static void Feladat4()
        {
            Console.WriteLine($"4. feladat: Döntők száma: {list.Count}");
        }

        public static void Feladat5()
        {
            Console.WriteLine($"5. feladat: Átlagos pontkülönbség: {Math.Round(list.Average(cx => cx.kulonbseg),1)}");
        }

        public static void Feladat6()
        {
            Console.WriteLine("6. feladat: Legmagasabb nézőszám a döntők során:");
            Console.WriteLine($"\tSorszám (dátum): {list.OrderByDescending(cx => cx.nezoszam).First().Ssz}.({list.OrderByDescending(cx => cx.nezoszam).First().datum})");
            Console.WriteLine($"\tGyőztes csapat: {list.OrderByDescending(cx => cx.nezoszam).First().gyoztes}, szerzett pontok: {list.OrderByDescending(cx => cx.nezoszam).First().gyoztespont}");
            Console.WriteLine($"\tVesztes csapat: {list.OrderByDescending(cx => cx.nezoszam).First().vesztes}, szerzett pontok: {list.OrderByDescending(cx => cx.nezoszam).First().vesztespont}");
            Console.WriteLine($"\tVáros, állam: {list.OrderByDescending(cx => cx.nezoszam).First().varosallam}");

            Console.WriteLine($"\tNézőszám: {list.OrderByDescending(cx => cx.nezoszam).First().nezoszam}");
        }

        public static void Feladat7()
        {
            StreamWriter sw = new StreamWriter("SuperBowlNew.txt", false, Encoding.UTF8);
            sw.WriteLine("Ssz;Dátum;Győztes;Eredmény;Vesztes;Nézőszám");
            int gycsapat = 0;
            int vcsapat = 0;
            foreach(var item in list)
            {
                if (item.gyoztes.Contains(item.gyoztes))
                {
                    gycsapat++;
                }
                if (item.vesztes.Contains(item.vesztes))
                {
                    vcsapat++;
                }
                sw.WriteLine($"{item.Ssz};{item.datum};{item.gyoztes} ({gycsapat});{item.eredmeny};{item.vesztes} ({vcsapat});{item.nezoszam}");
            }
            sw.Close();
        }
    }
}
