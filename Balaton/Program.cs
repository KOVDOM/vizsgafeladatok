using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balaton
{
    internal class Program
    {
        static List<Adatok> list = new List<Adatok>();
        static int adoA = 0;
        static int adoB = 0;
        static int adoC = 0;
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("utca.txt");
            var elsosor = sr.ReadLine();
            var splitValues = elsosor.Split(' ');
            adoA = int.Parse(splitValues[0]);
            adoB = int.Parse(splitValues[1]);
            adoC = int.Parse(splitValues[2]);
            while (!sr.EndOfStream)
            {
                Adatok adatok=new Adatok(sr.ReadLine());
                list.Add(adatok);
            }
            sr.Close();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();

            Console.ReadLine();
        }

        public static void Feladat2()
        {
            Console.WriteLine($"{list.Count()} darab telek adatai találhatóak az állományban!");
        }

        public static void Feladat3()
        {
            var utcaneve = "";
            var hazszam = "";
            bool joe = false;
            do
            {
            Console.Write("Kérem az adó azonosítóját: ");
            int beker = int.Parse( Console.ReadLine() );
            foreach (var item in list)
            {
                if (beker==item.adoszam)
                {
                    joe = true;
                    utcaneve=item.utcaneve;
                    hazszam = item.hazszam;
                }
            }
                    if (joe)
                    {
                        Console.WriteLine($"{utcaneve} {hazszam}");
                    }
                    else
                    {
                        Console.WriteLine("Nem szerepel az adatállományban.");
                    }

            } while (!joe);
        }

        static int fizetendoA = 0;
        static int fizetendoB = 0;
        static int fizetendoC = 0;
        public static void Feladat4()
        {
            foreach (var item in list)
            {
                if (item.adosav is "A")
                {
                    var itemA = list.Count(f=>f.adosav is "A");
                    fizetendoA = itemA * adoA;
                }
                if (item.adosav is "B")
                {
                    var itemB = list.Count(f => f.adosav is "B");
                    fizetendoB = itemB * adoB;
                }
                if (item.adosav is "C")
                {
                    var itemC = list.Count(f=>f.adosav is "C");
                    fizetendoC = itemC * adoC;
                }
            }
        }

        public static void Feladat5()
        {
            Console.WriteLine($"5. feladat");
            Console.WriteLine($"{adoA} sávba {list.Count(cx=>cx.adosav=="A")} telek esik, az adó értéke {fizetendoA} ft");
            Console.WriteLine($"{adoB} sávba {list.Count(cx => cx.adosav == "B")} telek esik, az adó értéke {fizetendoB} ft");
            Console.WriteLine($"{adoC} sávba {list.Count(cx => cx.adosav == "C")} telek esik, az adó értéke {fizetendoC} ft");
        }
    }
}
