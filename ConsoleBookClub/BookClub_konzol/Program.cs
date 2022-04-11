using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BookClub_konzol
{
    class Program
    {
        static List<Tag> tagok = new List<Tag>();
        static void Main(string[] args)
        {
            Beolvas();
            befizetesek();
            regebbi();
            nemek();
            Console.WriteLine("\nProgram vége!");
            Console.ReadLine();
        }

        private static void nemek()
        {
            foreach (var item in tagok.GroupBy(a => a.Nem).Select(b => new {nem=b.Key, fo=b.Count() }))
            {
                Console.WriteLine($"\t{item.nem}\t{item.fo} fő");
            }
        }

        private static void regebbi()
        {
            //-- Legrégebbi dolgozó
            DateTime legelso = tagok.Min(a => a.Belepett);
            Tag tag = tagok.Find(a => a.Belepett == legelso);
            Console.WriteLine($"{tag.Id} {tag.Nev} ({tag.Belepett.ToString("yyyy-MM-dd")})");
        }

        private static void befizetesek()
        {
            //-- Az egyes tagok befizetései
            foreach (Tag item in tagok)
            {
                int osszeg = item.befizetes.Sum(a => a.Osszeg);
                Console.WriteLine($"\t{item.Nev}:\t{osszeg.ToString("#,##0")} Ft");
            }
        }

        private static void Beolvas()
        {
            //-- adatok beolvasása az adatbázisból
            //-- paraméterek beállítása
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.UserID = "root";
            sb.Password = "";
            sb.Database = "bookclub";
            MySqlConnection connection = new MySqlConnection(sb.ConnectionString);
            try
            {
                connection.Open();
                MySqlCommand sql = connection.CreateCommand();
                sql.CommandText = "SELECT `id`, `csaladnev`, `utonev`, `nem`, `szuletett`, `belepett` FROM `tagok` WHERE 1";
                using (MySqlDataReader dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Tag tag = new Tag(dr.GetInt32("id"), dr.GetString("csaladnev"), dr.GetString("utonev"), dr.GetString("nem"), dr.GetDateTime("szuletett"), dr.GetDateTime("belepett"));
                        tagok.Add(tag);
                    }
                }                
                //-- befizetések beolvasása
                sql.CommandText = "SELECT `id`, `datum`, `befizetes` FROM `befizetes` WHERE year(`datum`)=2021; ";
                using (MySqlDataReader dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Befizetes befizetes = new Befizetes(dr.GetDateTime("datum"), dr.GetInt32("befizetes"));
                        int id = dr.GetInt32("id");
                        tagok.Find(a => a.Id == id).befizetes.Add(befizetes);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
}
