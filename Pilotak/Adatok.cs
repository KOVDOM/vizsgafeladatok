using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Pilotak
{
    internal class Adatok
    {
        public string nev { get; private set; }
        public DateTime szul_datum { get; private set; }
        public string nemzet { get; private set; }
        public int rajtszam { get; private set; }

        public Adatok(string nev, DateTime szul_datum, string nemzet, int rajtszam)
        {
            this.nev = nev;
            this.szul_datum = szul_datum;
            this.nemzet = nemzet;
            this.rajtszam = rajtszam;
        }

        public Adatok (string sor)
        {
            string[] darabok= sor.Split(';');
            nev= darabok[0];
            szul_datum = Convert.ToDateTime(darabok[1]);
            nemzet = darabok[2];
            if (!string.IsNullOrEmpty(darabok[3]))
            {
                this.rajtszam = int.Parse(darabok[3]);
            }
        }
    }
}
