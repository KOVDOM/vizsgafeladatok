using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace interfacesTeszt
{
    //Adott egy tömb, amelyben minden szám kétszer szerepel, kivéve egy számot.Keressük meg azt a számot, amely csak egyszer szerepel a tömbben!

    //Az adott szám számjegyeit adjuk össze egymás után addig, amíg egyetlen egyjegyű számot nem kapunk.Írjunk függvényt, amely visszaadja a kapott egyjegyű számot!

    //Adott két string, ellenőrizzük, hogy a második string előfordul-e az első string-ben!

    //Adott egy string, amely csak zárójeleket tartalmaz (például: "(()()()())"). Írjunk függvényt, amely ellenőrzi, hogy a zárójelek helyes sorrendben vannak-e!

    //Adott egy számokat tartalmazó tömb.Írjunk függvényt, amely visszaadja a tömb legnagyobb és legkisebb számát, valamint a számok átlagát és mediánját!

    //Adott egy számokat tartalmazó lista.Írjunk függvényt, amely visszaadja a lista összes számának átlagát!

    //Adott egy számokat tartalmazó lista.Írjunk függvényt, amely visszaadja a lista legnagyobb és legkisebb számának különbségét!

    //Adott egy számokat tartalmazó lista.Írjunk függvényt, amely visszaadja a lista mediánját!

    //Adott egy string, amely tartalmaz kis- és nagybetűket.Írjunk függvényt, amely visszaadja a stringben található összes nagybetűt!

    //Adott egy string, amely tartalmaz kis- és nagybetűket, valamint számokat és speciális karaktereket.Írjunk függvényt, amely visszaadja a stringben található összes számjegyet!

    //Adott egy számokat tartalmazó lista.Írjunk függvényt, amely visszaadja a lista összes számjának négyzetét!

    //Adott egy számokat tartalmazó lista.Írjunk függvényt, amely visszaadja a lista összes páros számjának átlagát!

    //Adott egy számokat tartalmazó lista.Írjunk függvényt, amely visszaadja a lista összes számjának harmadik hatványát!

    internal class Program
    {
        public interface IMegfordul
        {
            void Megfordul();
        }

        public class Kocsi : IMegfordul 
        {
            public void Megfordul()
            {
                Console.WriteLine("A kocsi megfordult!");
            }
        }

        public class Ember : IMegfordul
        {
            public void Megfordul()
            {
                Console.Write("Kérem az ember nevét: ");
                string nev=Console.ReadLine();
                Console.WriteLine($"{nev} megfordult!");
            }
        }

        public class Teherauto : IMegfordul
        {
            public void Megfordul()
            {
                Console.WriteLine("A teherautó megfordult!");
            }
        }

        public static void Forgat(IMegfordul auto)
        {
            auto.Megfordul();
        }

        public class Motor : IMegfordul
        {
            public void Megfordul()
            {
                Console.WriteLine("A motor megfordult!");
            }
        }

        static void Main(string[] args)
        {
            IMegfordul kocsi = new Kocsi();
            IMegfordul teherauto= new Teherauto();
            IMegfordul motor= new Motor();
            IMegfordul ember = new Ember();

            Forgat(kocsi);
            Forgat(teherauto);
            Forgat(motor);
            Forgat(ember);

            //szöveg bekérős betű számláló feladat
            Console.Write("Kérek egy szövet: ");
            string beker=Console.ReadLine();
            //var res = beker.Select(x => new string(x, 1)).ToArray();
            Dictionary<char, int> szotar=new Dictionary<char, int>();
            foreach(char c in beker)
            {
                if (szotar.ContainsKey(c))
                {
                    szotar[c]++;
                }
                else
                {
                    szotar.Add(c, 1);
                }
            }

            char max=szotar.OrderByDescending(x=>x.Value).FirstOrDefault().Key;

            Console.WriteLine($"{max} a legtöbbször előforduló karakter {szotar[max]} darab");

            //tömbös feladat
            int[] tomb = { 1, 1, 2, 2, 3, 4, 4, 5, 5, 6, 6 };
            Dictionary<int, int> szotartomb= new Dictionary<int, int>();
            foreach (var c in tomb)
            {
                if(szotartomb.ContainsKey(c)) 
                {
                    szotartomb[c]++; 
                }
                else 
                { 
                    szotartomb.Add(c, 1); 
                }
            }

            foreach (var item in szotartomb)
            {
                if (item.Value==1)
                {
                    Console.WriteLine($"A tömbben egy elem van amiből egy van {item.Key}");
                    break;
                }
            }

            //számos feladat
            OsszeadEgyjegyuig(12345);

            //string a stringben feladat
            string string1 = "asdasdffff";
            string string2 = "asdasd";
            string ures = "";
            if(string1.Contains(string2))
            {
                ures="string1 tartalmazza string2-et";
            }
            else
            {
                ures = "nem tartalmazza";
            }
            Console.WriteLine(ures);

            //(()()()()) feladat
            //string zarojel = "(()()()())";
            //if (zarojel == "(()()()())")
            //{
            //    Console.WriteLine("megyegyezik");
            //}
            //else
            //{
            //    Console.WriteLine("nem egyezik");
            //}

            string input = "(()()()())";
            bool helyes = HelyesZarojelek(input);
            Console.WriteLine($"A(z) '{input}' zárójelei {(helyes ? "helyesek" : "helytelenek")}.");

            //második tömbös feladat
            int[] tomb2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int legnagyobb =tomb2.OrderByDescending(x => x).First();
            int legkisebb=tomb2.OrderByDescending(x=>x).Last();
            double atlag=tomb2.Average();
            Array.Sort(tomb2);

            int medianIndex = tomb2.Length / 2;
            double median = (tomb2.Length % 2 == 0) ?
                ((double)tomb2[medianIndex] + (double)tomb2[medianIndex - 1]) / 2 :
                (double)tomb2[medianIndex];
            Console.WriteLine($"Legnagyobb: {legnagyobb}\nLegkisebb: {legkisebb}\nÁtlag: {atlag}\nMedian: {median}");

            Console.ReadKey();
        }

        public static int OsszeadEgyjegyuig(int szam)
        {
            while (szam > 9)
            {
                int ujSzam = 0;
                while (szam != 0)
                {
                    ujSzam += szam % 10;
                    szam /= 10;
                }
                szam = ujSzam;
            }
            Console.WriteLine(szam);
            return szam;
        }

        public static bool HelyesZarojelek(string input)
        {
            Stack<char> verem = new Stack<char>();

            foreach (char c in input)
            {
                if (c=='(')
                {
                    verem.Push(c);
                }
                else if (c==')')
                {
                    if (verem.Count == 0 || verem.Pop() != '(')
                    {
                        return false;
                    }
                }
            }

            return verem.Count == 0;
        }

        public static void UresFuggveny()
        {
            Console.WriteLine("Ez egy üres függvény!");
        }
    }
}
