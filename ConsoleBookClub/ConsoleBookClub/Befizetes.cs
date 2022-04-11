using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBookClub
{
    class Befizetes
    {
        readonly DateTime datum;
        readonly int osszeg;

        public DateTime Datum => datum;

        public int Osszeg => osszeg;

        public Befizetes(DateTime datum, int osszeg)
        {
            this.datum = datum;
            this.osszeg = osszeg;
        }
    }
}
