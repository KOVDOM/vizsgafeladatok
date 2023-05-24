using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBowl
{
    internal class Adatok
    {
        public string Ssz { get; private set; }
        public DateTime datum { get; private set; }
        public string gyoztes { get; private set; }
        public string eredmeny { get; private set; }
        public string vesztes { get; private set; }
        public string helyszin { get; private set; }
        public string varosallam { get; private set; }
        public int nezoszam { get; private set; }
        public int gyoztespont => int.Parse(eredmeny.Split('-')[0]);
        public int vesztespont => int.Parse(eredmeny.Split('-')[1]);
        public int kulonbseg => gyoztespont - vesztespont;

        public Adatok(string sor)
        {
            string[] m = sor.Split(';');
            Ssz = m[0];
            datum = DateTime.Parse(m[1]);
            gyoztes = m[2];
            eredmeny = m[3];
            vesztes = m[4];
            helyszin = m[5];
            varosallam = m[6];
            nezoszam = int.Parse(m[7]);
        }
    }

    class RomaiSorszam
    {
        public string RomaiSsz { get; private set; }

        private static Dictionary<char, int> RomaiMap = new Dictionary<char, int>()
    {
        {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
    };

        public string ArabSsz
        {
            get
            {
                int ertek = 0;
                string romaiSzam = RomaiSsz.TrimEnd('.');
                for (int i = 0; i < romaiSzam.Length; i++)
                {
                    if (i + 1 < romaiSzam.Length &&
                        RomaiMap[romaiSzam[i]] < RomaiMap[romaiSzam[i + 1]])
                    {
                        ertek -= RomaiMap[romaiSzam[i]];
                    }
                    else
                    {
                        ertek += RomaiMap[romaiSzam[i]];
                    }
                }
                return $"{ertek}.";
            }
        }

        public RomaiSorszam(string romaiSsz)
        {
            RomaiSsz = romaiSsz.ToUpper();
        }
    }
}
