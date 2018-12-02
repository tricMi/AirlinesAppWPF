
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static AirlineTickets.Models.Seat;

namespace AirlineTickets.Database
{
    class Data
    {
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Airport> Airports { get; set; }
        public ObservableCollection<Flight> Flights { get; set; }
        public ObservableCollection<Aircompany> Aircompanies { get; set; }
        public ObservableCollection<Seats> Seats { get; set; }
        public ObservableCollection<Seat> Seat { get; set; }
        public ObservableCollection<Airplane> Airplanes { get; set; }
        public ObservableCollection<Seat> SeatB { get; set; }
        public ObservableCollection<Seat> SeatE { get; set; }
        public ObservableCollection<Tickets> Tickets { get; set; }

        public String LoggedUser { get; set; }

        private Data()
        {
            LoggedUser = String.Empty;
            Users = new ObservableCollection<User>();
            Airports = new ObservableCollection<Airport>();
            Flights = new ObservableCollection<Flight>();
            Aircompanies = new ObservableCollection<Aircompany>();
            Seat = new ObservableCollection<Seat>();
            Seats = new ObservableCollection<Seats>();
            SeatB = new ObservableCollection<Seat>();
            SeatE = new ObservableCollection<Seat>();
            Airplanes = new ObservableCollection<Airplane>();
            Tickets = new ObservableCollection<Tickets>();
            LoadAllAirports();
            LoadAllFlights();
            LoadAllUsers();
            LoadAllAircompanies();
            LoadSeat();
            LoadAllSeats();
            LoadAllAirplanes();
            SeatsBusiness();
            SeatsEconomy();
            

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

            Flights.Add(new Flight
            {
                FlightNumber = "444",
                DepartureTime = new DateTime(2018, 7, 9, 23, 50, 00),
                ArrivalTime = new DateTime(2018, 1, 1, 00, 10, 07),
                DeparturePlace = "Belgrade",
                Destination = "London",
                OneWayTicketPrice = 4200,
                Active = false
            });

            Flights.Add(new Flight
            {
                FlightNumber = "555",
                DepartureTime = new DateTime(2018, 3, 5, 03, 30, 00),
                ArrivalTime = new DateTime(2018, 3, 5, 06, 40, 07),
                DeparturePlace = "New York",
                Destination = "Paris",
                OneWayTicketPrice = 5000,
                Active = false
            });

            Flights.Add(new Flight
            {
                FlightNumber = "666",
                DepartureTime = new DateTime(2018, 10, 23, 18, 50, 00),
                ArrivalTime = new DateTime(2018, 1, 1, 21, 40, 07),
                DeparturePlace = "Amsterdam",
                Destination = "Belgrade",
                OneWayTicketPrice = 1200,
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

        public void LoadAllAircompanies()

        {
            Aircompany A = new Aircompany();
            Flight F = new Flight();
            A.CompanyPassword = "675";
            A.FlightList.Add(Flights[0]);
            A.Active = false;
            Aircompanies.Add(A);

            A = new Aircompany();
            F = new Flight();
            A.CompanyPassword = "743";
            A.FlightList.Add(Flights[1]);
            A.FlightList.Add(Flights[2]);
            A.Active = false;
            Aircompanies.Add(A);

            A = new Aircompany();
            F = new Flight();
            A.CompanyPassword = "821";
            A.FlightList.Add(Flights[3]);
            A.FlightList.Add(Flights[2]);
            A.Active = false;
            Aircompanies.Add(A);

            A = new Aircompany();
            F = new Flight();
            A.CompanyPassword = "313";
            A.FlightList.Add(Flights[5]);
            A.Active = false;
            Aircompanies.Add(A);

            A = new Aircompany();
            F = new Flight();
            A.CompanyPassword = "483";
            A.FlightList.Add(Flights[4]);
            A.FlightList.Add(Flights[3]);
            A.Active = false;
            Aircompanies.Add(A);

        }

        public void LoadSeat()
        {
            Seat.Add(new Seat
            {
                SeatLabel = "1A",
                SeatState = true,
                SeatClass = EClass.BUSINESS
            });

            Seat.Add(new Seat
            {
                SeatLabel = "1B",
                SeatState = true,
                SeatClass = EClass.BUSINESS,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "1C",
                SeatState = true,
                SeatClass = EClass.BUSINESS,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "1D",
                SeatState = true,
                SeatClass = EClass.BUSINESS,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "2A",
                SeatState = true,
                SeatClass = EClass.BUSINESS,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "2B",
                SeatState = true,
                SeatClass = EClass.BUSINESS,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "2C",
                SeatState = true,
                SeatClass = EClass.ECONOMY,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "2D",
                SeatState = true,
                SeatClass = EClass.ECONOMY,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "3A",
                SeatState = true,
                SeatClass = EClass.ECONOMY,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "3B",
                SeatState = true,
                SeatClass = EClass.ECONOMY,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "3C",
                SeatState = true,
                SeatClass = EClass.ECONOMY,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "3D",
                SeatState = true,
                SeatClass = EClass.ECONOMY,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "4A",
                SeatState = true,
                SeatClass = EClass.ECONOMY,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "4B",
                SeatState = true,
                SeatClass = EClass.ECONOMY,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "4C",
                SeatState = true,
                SeatClass = EClass.ECONOMY,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "4D",
                SeatState = true,
                SeatClass = EClass.ECONOMY,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "5A",
                SeatState = true,
                SeatClass = EClass.ECONOMY,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "5B",
                SeatState = true,
                SeatClass = EClass.ECONOMY,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "5C",
                SeatState = true,
                SeatClass = EClass.ECONOMY,
                Active = false
            });

            Seat.Add(new Seat
            {
                SeatLabel = "5D",
                SeatState = true,
                SeatClass = EClass.ECONOMY,
                Active = false
            });

        }


        public void LoadAllSeats()
        {
            Seats.Add(new Seats
            {
                AllSeats = Seat,
                Active = false

            });

        }


        public void LoadAllAirplanes()
        {
            Airplanes.Add(new Airplane
            {
                Pilot = "Milan",
                FlightNum = "111",
                AircompanyName = "New York Air",
                Active = false
                 
             });

            Airplanes.Add(new Airplane
            {
                Pilot = "Marko",
                FlightNum = "222",
                AircompanyName = "Air Serbia",
                Active = false

            });

            Airplanes.Add(new Airplane
            {
                Pilot = "Stefan",
                FlightNum = "333",
                AircompanyName = "Air France",
                Active = false

            });

            Airplanes.Add(new Airplane
            {
                Pilot = "Aleksandar",
                FlightNum = "444",
                AircompanyName = "KLM Royal Dutch Airlines",
                Active = false

            });
        }

        public Seats SeatsBusiness()
        {
            Seats s = new Seats();
            s.AllSeats = SeatB;
            foreach (Seat ss in Seat.Where(x => x.SeatClass == EClass.BUSINESS))
            {
                s.AllSeats.Add(ss);
             
            }
            return s;
            
        }

        public Seats SeatsEconomy()
        {
            
            Seats s = new Seats();
            s.AllSeats = SeatE;
            foreach (Seat ss in Seat.Where(y => y.SeatClass == EClass.ECONOMY))
            {
                s.AllSeats.Add(ss);
                

            }
            return s;


        }
    }
}
