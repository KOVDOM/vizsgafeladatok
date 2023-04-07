using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackieStewart
{
    internal class Adatok
    {
        public int year { get; private set; }
        public int races { get; private set; }
        public int wins { get; private set; }
        public int podiums { get; private set; }
        public int poles { get; private set; }
        public int fastests { get; private set; }

        public Adatok(string sor)
        {
            string[] arr = sor.Split('\t');
            year = int.Parse(arr[0]);
            races = int.Parse(arr[1]);
            wins = int.Parse(arr[2]);
            podiums = int.Parse(arr[3]);
            poles = int.Parse(arr[4]);
            fastests = int.Parse(arr[5]);
        }
    }
}
