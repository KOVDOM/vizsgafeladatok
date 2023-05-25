using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrvosiNobeldijasok
{
    internal class Adatok
    {
        public int ev { get; private set; }
        public string nev { get; private set; }
        public string SzulHal { get; private set; }
        public string orzsgakod { get; private set; }

        public Adatok(string sor)
        {
            string[] darabok=sor.Split(';');
            ev = int.Parse(darabok[0]);
            nev = darabok[1];
            SzulHal = darabok[2];
            orzsgakod = darabok[3];
        }
    }
}
