using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleKocsi
{
    internal class Program
    {
        public static List<Jarat> jaratList = new List<Jarat>();
        public static List<Igeny> igenyList= new List<Igeny>();
        static void Main(string[] args)
        {
            StreamReader srJarat = new StreamReader("autok.csv");
            srJarat.ReadLine();
            while (!srJarat.EndOfStream)
            {
                Jarat jarat=new Jarat(srJarat.ReadLine());
                jaratList.Add(jarat);
            }
            srJarat.Close();
            StreamReader srIgeny = new StreamReader("igenyek.csv");
            srIgeny.ReadLine();
            while(!srIgeny.EndOfStream)
            {
                Igeny igeny=new Igeny(srIgeny.ReadLine());
                igenyList.Add(igeny);
            }
            srIgeny.Close();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();

            Console.ReadKey();
        }

        public static void Feladat2()
        {
            Console.WriteLine($"2. feladat {jaratList.Count()} autós hirdetett fuvart");
        }

        static int ferohely = 0;
        public static void Feladat3()
        {
            ferohely = jaratList.Where(z => z.indulas == "Budapest" && z.cel == "Miskolc").Select(t => t.ferohely).Sum();
            Console.WriteLine($"3. feladat Összesen {ferohely} férőhelyet hirderttek az autósok Budapestről Miskolcra.");
        }

        public static void Feladat4()
        {
            var max=jaratList.OrderByDescending(a=>a.ferohely).First();
            Console.WriteLine($"4. feladat A legtöbb férőhelyet ({max.ferohely}-et) a {max.indulas}-{max.cel} útvonalon ajálották fel a hirdetők");

        }

        static Dictionary<Igeny, Jarat> match = new Dictionary<Igeny, Jarat>();
        public static void Feladat5()
        {
            foreach (var jarat in jaratList)
            {
                foreach (var igeny in igenyList)
                {
                    if (!(match.ContainsKey(igeny)) && (igeny.cel == jarat.cel && igeny.indulas == jarat.indulas && igeny.szemelyek <= jarat.ferohely))
                    {
                        match.Add(igeny, jarat);
                    }
                }
            }
            Console.WriteLine("5. feladat");
            foreach (var item in match)
            {
                Console.WriteLine($"\t{item.Key.azonosito} ---> {item.Value.rendszam}");
            }
        }

        public static void Feladat6()
        {
            StreamWriter sw=new StreamWriter("utasuzenetek.txt",false,encoding: Encoding.UTF8);
            foreach(var item in igenyList)
            {
                if (match.ContainsKey(item))
                {
                    sw.WriteLine($"{item.azonosito}: Rendszám: {match[item].rendszam} Telefonszám: {match[item].telefonszam}");
                }
                else
                {
                    sw.WriteLine("Sajnos nem sikerült ilyen autót találni!");
                }
            }
            sw.Close();
            Console.WriteLine("6. feladat utasuzenetek.txt");
        }
    }
}
