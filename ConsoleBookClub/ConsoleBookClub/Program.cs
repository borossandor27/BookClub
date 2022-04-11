using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleBookClub
{
    class Program
    {
        static List<Tag> tagok = new List<Tag>();
        //static Dictionary<int, Tag> tagok = new Dictionary<int, Tag>();
        static void Main(string[] args)
        {
            Beolvasas();
            //-- Az egyes befizetők legmagasabb összegű befizetései
            Console.WriteLine("A tagok befizetései:");
            var ln = tagok.Select(a => new { nev = a.Nev, max = a.Befizetes.Max(b => b.Osszeg) });
            foreach (var item in ln.OrderBy(a => a.nev))
            {
                Console.WriteLine($"\t{item.nev}:\t{item.max.ToString("#,##0")} Ft");
            }

            //-- A legrégebben alkalmazott dolgozó ---
            DateTime lr = tagok.Min(a => a.Belepett);
            Tag lrtag = tagok.Find(a => a.Belepett == lr);
            Console.WriteLine($"\nLegrégebben itt dolgozó: {lrtag.Id}. {lrtag.Nev} ({lrtag.Belepett.ToString("yyyy-MM-dd")}) ");

            //-- Férfiak és Nők létszáma -------------------
            var gr = tagok.GroupBy(a => a.Nem).Select(b => new { nem = b.Key, letszam = b.Count() });
            foreach (var item in gr)
            {
                Console.WriteLine($"\t{item.nem}\t{item.letszam} fő");
            }
            Console.WriteLine("\nProgram vége...");
            Console.ReadLine();
        }

        private static void Beolvasas()
        {
            Console.WriteLine("Adatok beolvasása...");
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.Database = "bookclub";
            sb.UserID = "root";
            sb.Password = "";
            sb.CharacterSet = "utf8";
            MySqlConnection connection = new MySqlConnection(sb.ConnectionString);
            MySqlCommand sql = connection.CreateCommand();
            try
            {
                connection.Open();
                //-- tagok tábla beolvasása -----------------------------------
                sql.CommandText = "SELECT `id`, `csaladnev`, `utonev`, `nem`, `szuletett`, `belepett` FROM `tagok` WHERE 1";
                using (MySqlDataReader dr=sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int id = dr.GetInt32("id");
                        Tag uj = new Tag(id, dr.GetString("csaladnev"), dr.GetString("utonev"), dr.GetString("nem"), dr.GetDateTime("szuletett"), dr.GetDateTime("belepett"));
                        tagok.Add(uj);
                    }
                }    
                //-- befizetések tábla 2021-es adatainak a beolvasása -----------------
                sql.CommandText = "SELECT `id`, `datum`, `befizetes` FROM `befizetes` WHERE YEAR(`datum`) = 2021; ";
                using (MySqlDataReader dr=sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Befizetes uj = new Befizetes(dr.GetDateTime("datum"), dr.GetInt32("befizetes"));
                        tagok.Find(a => a.Id==dr.GetInt32("id")).Befizetes.Add(uj);
                    }
                }

                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }
    }
}
