using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyszamjatek
{
    internal class Adatok
    {
        public string nev { get; private set; }
        public int[] fordulo { get; private set; }

        public Adatok(string sor)
        {
            string[] s = sor.Split(' ');
            nev = s[0];
            fordulo = new int[s.Length-1];
            for(int i = 1; i < fordulo.Length; i++)
            {
                fordulo[i] = int.Parse(s[i+1]);
            }
        }
    }
}
