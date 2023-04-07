using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berek2020
{
    internal class Adatok
    {
        public string nev { get; set; }
        public string neme { get; set; }
        public string reszleg { get; set; }
        public int belepes { get; set; }
        public int ber { get; set; }

        public Adatok(string sor) 
        {
            string[] arr = sor.Split(';');
            nev= arr[0];
            neme= arr[1];
            reszleg= arr[2];
            belepes = int.Parse(arr[3]);
            ber = int.Parse(arr[4]);
        }
    }
}
