using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuvar
{
    internal class Adatok
    {
        public int taxi_id { get; set; }
        public DateTime indulas { get; set; }
        public int idotartam { get; set; }
        public double tavolasg { get; set; }
        public double viteldij { get; set; }
        public double borravalo { get; set; }
        public string fizetes { get; set; }

        public Adatok(string sor)
        {
            string[] arr = sor.Split(';');
            taxi_id = int.Parse(arr[0]);
            indulas = DateTime.Parse(arr[1]);
            idotartam = int.Parse(arr[2]);
            tavolasg = double.Parse(arr[3]);
            viteldij = double.Parse(arr[4]);
            borravalo = double.Parse(arr[5]);
            fizetes= arr[6];
        }
    }
}
