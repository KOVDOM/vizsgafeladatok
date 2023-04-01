using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleKocsi
{
    public class Jarat
    {
        public string indulas { get; private set; }
        public string cel { get; private set; }
        public string rendszam { get; private set; }
        public string telefonszam { get; private set; }
        public int ferohely { get; private set; }

        public Jarat(string sor)
        {
            string[] arr = sor.Split(';');
            indulas = arr[0];
            cel = arr[1];
            rendszam = arr[2];
            telefonszam = arr[3];
            ferohely = int.Parse(arr[4]);
        }
    }

    public class Igeny
    {
        public string azonosito { get; set; }
        public string indulas { get; set; }
        public string cel { get; set; }
        public int szemelyek { get; set; }

        public Igeny(string sor)
        {
            string[] arr = sor.Split(';');
            azonosito = arr[0];
            indulas = arr[1];
            cel = arr[2];
            szemelyek = Int32.Parse(arr[3]);
        }
    }
}
