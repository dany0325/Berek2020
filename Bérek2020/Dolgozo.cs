using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bérek2020
{
    internal class Dolgozo
    {
        string nev, nem, reszleg;
        int belepes, ber;

        public string Nev { get => nev; }
        public string Nem { get => nem; }
        public string Reszleg { get => reszleg; }
        public int Belepes { get => belepes; }
        public int Ber { get => ber; }

        public Dolgozo(string[] sor)
        {
            nev = sor[0];
            nem = sor[1];
            reszleg = sor[2];
            belepes = int.Parse(sor[3]);
            ber = int.Parse(sor[4]);
        }
    }
}
