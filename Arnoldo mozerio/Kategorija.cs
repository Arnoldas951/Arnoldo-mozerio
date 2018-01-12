using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arnoldo_mozerio
{
    class Kategorija
    {
        public int kategorijosID;
        public string kategorijosPavadinimas;
        public List<Patiekalas> patiekaluSarasas;


        public Kategorija(int ID, string pavadinimas)
        {
            kategorijosID = ID;
            kategorijosPavadinimas = pavadinimas;
            patiekaluSarasas = new List<Patiekalas>();
        }
    }
}
