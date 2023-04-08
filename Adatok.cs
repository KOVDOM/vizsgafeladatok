using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifavilágranglista
{
    internal class Adatok
    {
        public string csapat { get; private set; }
        public int helyezes { get; private set; }
        public int valtozas { get; private set; }
        public int pontszam { get; private set; }

        public Adatok(string sor)
        {
            string[] arr=sor.Split(';');
            csapat = arr[0];
            helyezes = int.Parse(arr[1]);
            valtozas = int.Parse(arr[2]);
            pontszam = int.Parse(arr[3]);
        }
    }
}
