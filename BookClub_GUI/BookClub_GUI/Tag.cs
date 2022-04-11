using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookClub_GUI
{
    class Tag
    {
        readonly int id;
        readonly string csaladnev;
        readonly string utonev;
 

        public string Nev => this.Csaladnev + " " + this.Utonev;

        public int Id => id;

        public string Csaladnev => csaladnev;

        public string Utonev => utonev;

         public Tag(int id, string csaladnev, string utonev)
        {
            this.id = id;
            this.csaladnev = csaladnev;
            this.utonev = utonev;
        }
        public override string ToString()
        {
            return Nev;
        }
    }
}
