using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arnoldo_mozerio
{
    class Patiekalas
    {
        public int patiekaloID;
        public string patiekaloPavadinimas;
        public double patiekaloKaina;
        public string patiekaloAprasymas;
        public string patiekaloPaveikslelis;

        public Patiekalas(int ID, string pavadinimas, double kaina,
            string aprasymas, string paveikslelis)
        {
            patiekaloID = ID;
            patiekaloPavadinimas = pavadinimas;
            patiekaloKaina = kaina;
            patiekaloAprasymas = aprasymas;
            patiekaloPaveikslelis = paveikslelis;
        }
    }
}
