using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EUtagallamok
{
    internal class Adatok
    {
        public string orszag { get; private set; }
        public DateTime csatlakozas { get; private set; }

        public Adatok(string sor)
        {
            string[] arr = sor.Split(';');
            orszag = arr[0];
            csatlakozas = Convert.ToDateTime(arr[1]);
        }
    }
}
