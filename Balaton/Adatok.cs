using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balaton
{
    internal class Adatok
    {
        public int adoszam { get; private set; }
        public string utcaneve { get; private set; }
        public string hazszam { get; private set; }
        public string adosav { get; private set; }
        public int alapterulet { get; private set; }

        public Adatok(int adoszam, string utcaneve, string hazszam, string adosav, int alapterulet)
        {
            this.adoszam = adoszam;
            this.utcaneve = utcaneve;
            this.hazszam = hazszam;
            this.adosav = adosav;
            this.alapterulet = alapterulet;
        }

        public Adatok(string sor)
        {
            string[] b=sor.Split(' ');
            adoszam = int.Parse(b[0]);
            utcaneve = b[1];
            hazszam = b[2];
            adosav = b[3];
            alapterulet= int.Parse(b[4]);
        }
    }
}
