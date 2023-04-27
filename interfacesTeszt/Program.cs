using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace interfacesTeszt
{
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

            Console.ReadKey();
        }
    }
}
