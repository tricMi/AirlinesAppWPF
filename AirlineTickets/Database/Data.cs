
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AirlineTickets.Database
{
    class Data
    {
       // public List<Korisnik> Korisnici { get; set; }
        public List<Airport> Airports { get; set; }
        //public List<Let> Letovi { get; set; }

        public String LoggedUser { get; set; }
        private Data()
        {
            LoggedUser = String.Empty;
         //   Korisnici = new List<Korisnik>();
            Airports = new List<Airport>();
            LoadAllAirports();
         //   Letovi = new List<Let>();
        }

        private static Data _instance = null;

        public static Data Instance
        {
            get
            {
                if (_instance == null)

                    _instance = new Data();
                return _instance;

            }
        }



        public void LoadAllAirports()
        {
            XmlReader reader = XmlReader.Create("..//..//Data//Airports.xml");

            while (reader.Read())
            {
                if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("airport"))
                {
                    var airport = new Airport
                    {
                        AirportID = reader.GetAttribute("airportID"),
                        Name = reader.GetAttribute("name"),
                        City = reader.GetAttribute("city"),
                        Active = false
                    };

                    Airports.Add(airport);
                }
            }

            reader.Close();
        }

        public void SacuvajSveAerodrome()
        {
            XmlWriter writer = XmlWriter.Create("..//..//Data//Airports.xml");

            writer.WriteStartElement("airports");

            foreach (var airport in Airports)
            {
                writer.WriteStartElement("airport");
                writer.WriteAttributeString("airportId", airport.AirportID);
                writer.WriteAttributeString("name", airport.Name);
                writer.WriteAttributeString("city", airport.City);
                writer.WriteEndElement();
            }
            writer.WriteEndDocument();
            writer.Close();
        }

        /*
        public void UcitajSveKorisnike()
        {
            XmlReader reader = XmlReader.Create("..//..//Data//Korisnici.xml");

            while (reader.Read())
            {
                if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("korisnik"))
                {
                    var korisnik = new Korisnik
                    {
                        Ime = reader.GetAttribute("ime"),
                        Prezime = reader.GetAttribute("prezime"),
                        Lozinka = reader.GetAttribute("lozinka"),
                        KorisnickoIme = reader.GetAttribute("korisnickoIme"),
                        Pol = (reader.GetAttribute("pol").Equals("M") ? EPol.M : EPol.Z),
                        Adresa = reader.GetAttribute("adresa"),
                        TipKorisnika = (reader.GetAttribute("tipKorisnika");
                        
                    };

                    Korisnici.Add(korisnik);
                }
            }

            reader.Close();
        }

        */
    }
}

