using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utasszallitok
{
    internal class Adatok
    {
        public string tipus { get; private set; }
        public int ev { get; private set; }
        public string utas { get; private set; }
        public string szemelyzet { get; private set; }
        public int utazosebesseg { get; private set; }
        public int feltomeg { get; private set; }
        public double fesztav { get; private set; }
        public string SebKategotia { get; set; }

        public Adatok(string sor)
        {
            string[] darab=sor.Split(';');
            tipus= darab[0];
            ev = int.Parse(darab[1]);
            utas= darab[2];
            szemelyzet= darab[3];
            utazosebesseg = int.Parse(darab[4]);
            feltomeg = int.Parse(darab[5]);
            fesztav = double.Parse(darab[6]);
            SebKategotia = new Sebessegkategoria(utazosebesseg).Kategorianev;
        }

        public int MaxUtas=> utas.Split('-').Length==1 ? int.Parse(utas) : int.Parse(utas.Split('-')[1]);

        public int MaxSzemelyzet => szemelyzet.Split('-').Length == 1 ? int.Parse(szemelyzet) : int.Parse(szemelyzet.Split('-')[1]);

        public int fesztavlab => (int)Math.Round(fesztav * 3.2808);
        public int feltomegtonna => (int)Math.Round(feltomeg / 1000.0);
    }
}
