using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balkezesek
{
    internal class Adatok
    {
        public string nev { get; set; }
        public DateTime elso { get; set; }
        public DateTime utolso { get; set; }
        public int suly { get; set; }
        public int magassag { get; set; }

        public Adatok(string sor)
        {
            string[] arr = sor.Split(';');
            nev = arr[0];
            elso = DateTime.Parse(arr[1]);
            utolso = DateTime.Parse(arr[2]);
            suly = int.Parse(arr[3]);
            magassag = int.Parse(arr[4]);
        }
    }
}
