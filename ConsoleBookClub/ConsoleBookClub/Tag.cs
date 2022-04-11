using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBookClub
{
    class Tag
    {
        readonly int id;
        readonly string csaladnev;
        readonly string utonev;
        readonly string nem;
        readonly DateTime szuletett;
        readonly DateTime belepett;
        List<Befizetes> befizetes;



        public string Nev => this.Csaladnev + " " + this.Utonev;

        public int Id => id;

        public string Csaladnev => csaladnev;

        public string Utonev => utonev;

        public string Nem => nem;

        public DateTime Szuletett => szuletett;

        public DateTime Belepett => belepett;

        public List<Befizetes> Befizetes { get => befizetes; set => befizetes = value; }

        public Tag(int id, string csaladnev, string utonev, string nem, DateTime szuletett, DateTime belepett)
        {
            this.id = id;
            this.csaladnev = csaladnev;
            this.utonev = utonev;
            this.nem = nem;
            this.szuletett = szuletett;
            this.belepett = belepett;
            this.befizetes = new List<Befizetes>();
        }
    }
}
