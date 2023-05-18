using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BukkMaraton2019
{
    internal class Adatok
    {
        public string rajtszam { get; private set; }
        public string kategoria { get; private set; }
        public string nev { get; private set; }
        public string egyesulet { get; private set; }
        public TimeSpan ido { get; private set; }

        public string tav { get; private set; }
        public bool noiversenyzo => kategoria.Last() == 'n';
        public bool tobbminthat => ido > new TimeSpan(6, 0, 0);

        public Adatok(string sor)
        {
            string[] m= sor.Split(';');
            rajtszam= m[0];
            kategoria= m[1];
            nev= m[2];
            egyesulet= m[3];
            int ora = int.Parse(m[4].Split(':')[0]);
            int perc = int.Parse(m[4].Split(':')[1]);
            int mp = int.Parse(m[4].Split(':')[2]);
            ido=new TimeSpan(ora, perc, mp);
            tav = new Versenytav(rajtszam).Tav;
        }
    }
}
