using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kemia_elemek
{
    internal class Adatok
    {
        public string ev { get; private set; }
        public string elem { get; private set; }
        public string vegyjel { get; private set; }
        public int rendszam { get; private set; }
        public string felfedezo { get; private set; }

        public Adatok(string sor)
        {
            string[] adatok = sor.Split(';');
            this.ev= adatok[0];
            this.elem = adatok[1];
            this.vegyjel = adatok[2];
            this.rendszam = int.Parse(adatok[3]);
            this.felfedezo = adatok[4];
        }
    }
}
