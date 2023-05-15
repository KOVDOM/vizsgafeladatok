using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyszamjatekGUI
{
    internal class Adatok
    {
        public string nev { get; set; }
        public List<int> tipp { get; set; }

        public Adatok(string sor)
        {
            string[] parts = sor.Trim().Split(' ');
            nev= parts[0];
            int db = parts.Length - 1;
            tipp=new List<int>();
            foreach(var item in parts.Skip(1))
            {
                tipp.Add(int.Parse(item));
            }
        }
    }
}
