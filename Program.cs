using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuvar
{
    internal class Program
    {
        static List<Adatok> list=new List<Adatok>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("fuvar.csv");
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
            Feladat8();

            Console.ReadKey();
        }

        public static void Feladat3()
        {
            Console.WriteLine($"3. feladat {list.Count()} fuvar");
        }

        public static void Feladat4()
        {
            var fuvar=list.Where(x=>x.taxi_id==6185).ToList();
            Console.WriteLine($"4. feladat {fuvar.Count()} fuvar alatt: {list.Where(v=>v.taxi_id==6185).Sum(z=>z.viteldij)}");
        }

        public static void Feladat5()
        {
            Console.WriteLine("5. feladat");
            list.GroupBy(x=>x.fizetes).ToList().ForEach(z=>Console.WriteLine($"\t{z.Key}: {z.Count()} fuvar"));
        }

        public static void Feladat6()
        {
            Console.WriteLine($"6. feladat {list.Sum(t => Math.Round(t.tavolasg * 1.6, 2))} km");
        }

        public static void Feladat7()
        {
            Console.WriteLine("7. feladat");
            Console.WriteLine($"\tFuvar hossza: {list.OrderBy(o=>o.idotartam).Last().idotartam} másodperc");
            Console.WriteLine($"\tTaxi azonosító: {list.OrderBy(o=>o.idotartam).Last().taxi_id}");
            Console.WriteLine($"\tMegtett távolság: {list.OrderBy(o=>o.idotartam).Last().tavolasg} km");
            Console.WriteLine($"\tViteldíj: {list.OrderBy(o=>o.idotartam).Last().viteldij}$");
        }

        public static void Feladat8()
        {
            List<Adatok> hibak=list.OrderBy(u=>u.indulas).ToList();
            StreamWriter sw=new StreamWriter("hibak.txt",false,encoding: Encoding.UTF8);
            sw.WriteLine("taxi_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja");
            for (int i = 0; i < hibak.Count; i++)
            {
                if (hibak[i].tavolasg==0 && (hibak[i].tavolasg>0 || hibak[i].viteldij>0))
                {
                    sw.WriteLine(hibak[i].taxi_id + ";"+ hibak[i].indulas + ";"+ hibak[i].idotartam + ';'+ hibak[i].tavolasg + ";"+ hibak[i].viteldij + ";"+ hibak[i].borravalo + ";"+ hibak[i].fizetes + ";");
                }
            }
            sw.Close();
            Console.WriteLine("8. feladat hibak.txt");
        }
    }
}
