using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelsinkiGUI
{
    public class Adatok
    {
        public int helyezes { get; private set; }
        public int sporotolok { get; private set; }
        public string sportag { get; private set; }
        public string sportszam { get; private set; }

        public Adatok(int helyezes, int sporotolok, string sportag, string sportszam)
        {
            this.helyezes = helyezes;
            this.sporotolok = sporotolok;
            this.sportag = sportag;
            this.sportszam = sportszam;
        }

        public Adatok(string sor)
        {
            string[] h = sor.Split(' ');
            helyezes = int.Parse(h[0]);
            sporotolok = int.Parse(h[1]);
            sportag = h[2];
            sportszam = h[3];
        }
    }
}
