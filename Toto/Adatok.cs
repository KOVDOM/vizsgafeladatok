using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toto
{
    internal class Adatok
    {
        public int ev { get; private set; }
        public int het { get; private set; }
        public int fordulo { get; private set; }
        public int T13p1 { get; private set; }
        public int Ny13p1 { get; private set; }
        public string eredmeny { get; private set; }

        public Adatok(string sor)
        {
            string[] a=sor.Split(';');
            ev = int.Parse(a[0]);
            het = int.Parse(a[1]);
            fordulo = int.Parse(a[2]);
            T13p1 = int.Parse(a[3]);
            Ny13p1 = int.Parse(a[4]);
            eredmeny = a[5];
        }
    }
}
