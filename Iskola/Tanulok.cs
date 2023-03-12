using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola
{
    public class Tanulok
    {
        public int kezdEv { get; private set; }
        public string osztaly { get;private set; }
        public string nev { get; private set; }

        public Tanulok(string t)
        {
            string[] sor=t.Split(';');
            this.kezdEv = int.Parse(sor[0]);
            this.osztaly = sor[1];
            this.nev = sor[2];
        }

        public string Egyedikulcs()
        {
            string kulcs = "";
            kulcs += (kezdEv % 10).ToString();
            kulcs += osztaly.ToString();
            kulcs += nev.Substring(0, 3);
            kulcs += nev.Split(' ')[1].Substring(0, 3);
            return kulcs.ToLower();
        }
    }
}
