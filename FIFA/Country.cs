using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFA
{
    class Country
    {
        public string csapat;
        public int helyezes;
        public int valtozas;
        public int pontszam;

        public int CompareTo(object obj)
        {
            return valtozas.CompareTo(((Country)obj).valtozas);
        }
    }
}
