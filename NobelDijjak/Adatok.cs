using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobelDijjak
{
    internal class Adatok
    {
        public int ev { get; private set; }
        public string nev { get; private set; }
        public string szuletesHalalozas { get; private set; }
        public string orszagkod { get; private set; }

        public Adatok(string sor)
        {
            string[] darabok = sor.Split(';');
            ev = int.Parse(darabok[0]);
            nev = darabok[1];
            szuletesHalalozas = darabok[2];
            orszagkod = darabok[3];
        }
    }
}
