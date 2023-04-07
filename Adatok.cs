using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csudh
{
    internal class Adatok
    {
        public string domainname { get; private set; }
        public string ipcim { get; private set; }

        public Adatok(string sor)
        {
            string[] arr = sor.Split(';');
            domainname = arr[0];
            ipcim = arr[1];
        }
    }
}
