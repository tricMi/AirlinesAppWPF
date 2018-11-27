
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AirlineTickets.Database
{
    class Data
    {
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Airport> Airports { get; set; }
        public ObservableCollection<Flight> Flights { get; set; }
        public ObservableCollection<Aircompany> Aircompanies { get; set; }
        public ObservableCollection<Seats> Seats { get; set; }

        public String LoggedUser { get; set; }

        private Data()
        {
            LoggedUser = String.Empty;
            Users = new ObservableCollection<User>();
            Airports = new ObservableCollection<Airport>();
            Flights = new ObservableCollection<Flight>();
            Aircompanies = new ObservableCollection<Aircompany>();
            Seats = new ObservableCollection<Seats>();
            LoadAllAirports();
            LoadAllFlights();
            LoadAllUsers();
            LoadAllAircompanies();
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

        public void LoadAllFlights()
        {
            Flights.Add(new Flight
            {
                FlightNumber = "111",
                DepartureTime = new DateTime(2018, 12, 2, 11, 10, 33),
                ArrivalTime = new DateTime(2018, 12, 2, 15, 30, 11),
                DeparturePlace = "Belgrade",
                Destination = "Paris",
                OneWayTicketPrice = 2500,
                Active = false
            });

            Flights.Add(new Flight
            {
                FlightNumber = "222",
                DepartureTime = new DateTime(2018, 10, 7, 09, 16, 37),
                ArrivalTime = new DateTime(2018, 10, 7, 13, 38, 16),
                DeparturePlace = "New York",
                Destination = "Amsterdam",
                OneWayTicketPrice = 5700,
                Active = false
            });

            Flights.Add(new Flight
            {
                FlightNumber = "333",
                DepartureTime = new DateTime(2018, 1, 1, 19, 50, 00),
                ArrivalTime = new DateTime(2018, 1, 1, 22, 40, 07),
                DeparturePlace = "London",
                Destination = "Belgrade",
                OneWayTicketPrice = 3200,
                Active = false
            });
        }

        public void LoadAllUsers()
        {
            Users.Add(new User
            {
                Name = "Petar",
                Surname = "Petrovic",
                Password = "pera123",
                Username = "pera",
                Gender = EGender.MALE,
                Address = "Novi Sad 1",
                UserType = EUserType.PASSENGER,
                Active = false
            });

            Users.Add(new User
            {
                Name = "Mina",
                Surname = "Minic",
                Password = "minna",
                Username = "mina",
                Gender = EGender.FEMALE,
                Address = "Paris 21",
                UserType = EUserType.ADMIN,
                Active = false
            });

            Users.Add(new User
            {
                Name = "Milan",
                Surname = "Milanovic",
                Password = "milance11",
                Username = "milance",
                Gender = EGender.MALE,
                Address = "Belgrade 12",
                UserType = EUserType.UNREGISTERED,
                Active = false
            });
        }

        //public ObservableCollection<Flight> F { get; set; }

        public void LoadAllAircompanies()

        {
            Aircompany A = new Aircompany();
            Flight F = new Flight();
            F.FlightNumber = "111";
            F.DepartureTime = new DateTime(2018, 1, 1, 19, 50, 00);
            F.ArrivalTime = new DateTime(2018, 1, 1, 22, 40, 07);
            F.DeparturePlace = "London";
            F.Destination = "Belgrade";
            F.OneWayTicketPrice = 3200;
            A.CompanyPassword = "675";
            A.FlightList.Add(F);
            A.Active = false;
            //Trace.WriteLine(F);
            Aircompanies.Add(A);
            
        }


        public void LoadAllSeats()
        {

        }
        

    }
}

