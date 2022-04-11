using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub_konzol
{
    class Tag
    {
        public List<Befizetes> befizetes = new List<Befizetes>();
        DateTime belepett;
        string csaladnev;
        int id;
        string nem;
        DateTime szuletett;
        string utonev;

        public Tag(int id, string csaladnev, string utonev, string nem, DateTime szuletett, DateTime belepett)
        {
            this.Id = id;
            this.Csaladnev = csaladnev;
            this.Utonev = utonev;
            this.Nem = nem;
            this.Szuletett = szuletett;
            this.Belepett = belepett;
        }

        public string Nev { get => this.Csaladnev + " " + this.Utonev; }
        public DateTime Belepett { get => belepett; set => belepett = value; }
        public string Csaladnev { get => csaladnev; set => csaladnev = value; }
        public int Id { get => id; set => id = value; }
        public string Nem { get => nem; set => nem = value; }
        public DateTime Szuletett { get => szuletett; set => szuletett = value; }
        public string Utonev { get => utonev; set => utonev = value; }
    }
}
