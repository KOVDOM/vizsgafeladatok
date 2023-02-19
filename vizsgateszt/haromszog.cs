using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vizsgateszt
{
    public class haromszog
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }

        public haromszog(string h) 
        {
            string[] sor=h.Split(' ');
            this.a = int.Parse(sor[0]);
            this.b = int.Parse(sor[1]);
            this.c= int.Parse(sor[2]);
        }
    }
}
