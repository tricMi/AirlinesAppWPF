
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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

        public const String CONNECTION_STRING = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=AirlineApp;Integrated Security=true";
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

           // LoadAllFlights();

            //LoadAllAircompanies();
            //LoadSeat();
            //LoadAllSeats();
            //LoadAllAirplanes();
            //SeatsBusiness();
            //SeatsEconomy();

            LoadAirport();
            LoadUsers();
            LoadFlights();
            LoadAircompany();
            
            
            
            
            // SeatLabels();
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

        public void LoadUsers()
        {
            Users.Clear();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * FROM Users";

                SqlDataAdapter daUser = new SqlDataAdapter();
                DataSet dsUser = new DataSet();

                daUser.SelectCommand = command;
                daUser.Fill(dsUser, "User");

                foreach(DataRow row in dsUser.Tables["User"].Rows)
                {
                    User user = new User();

                    user.Id = (int)row["Id"];
                    user.Name = (string)row["Name"];
                    user.Surname = (string)row["Surname"];
                    user.Password = (string)row["Password"];
                    user.Username = (string)row["Username"];
                    user.Gender = (EGender)row["Gender"];
                    user.Address = (string)row["Address"];
                    user.UserType = (EUserType)row["UserType"];
                    user.Active = (bool)row["Active"];

                    Users.Add(user);
                }
            }
        }

        public User LoginUser(String username, String password)
        {
            foreach(User u in Users)
            {
                if (u.Username.Equals(username) && u.Password.Equals(password))
                {
                    return u;
                }
            }
            return null;
        }

       

        public void LoadAirport()
        {
            Airports.Clear();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * FROM Airport";

                SqlDataAdapter daAirport = new SqlDataAdapter();
                DataSet dsAirport = new DataSet();

                daAirport.SelectCommand = command;
                daAirport.Fill(dsAirport, "Airports");

                foreach (DataRow row in dsAirport.Tables["Airports"].Rows)
                {
                    Airport airport = new Airport();

                    airport.Id = (int)row["Id"];
                    airport.AirportID = (string)row["AirportID"];
                    airport.Name = (string)row["Name"];
                    airport.City = (string)row["City"];
                    airport.Active = (bool)row["Active"];

                    Airports.Add(airport);
                }
            }
        }

        public void LoadFlights()
        {
            Flights.Clear();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * FROM Flight";

                SqlDataAdapter daFlight = new SqlDataAdapter();
                DataSet dsFlight = new DataSet();

                daFlight.SelectCommand = command;
                daFlight.Fill(dsFlight, "Flights");

                foreach(DataRow row in dsFlight.Tables["Flights"].Rows)
                {
                    Flight flight = new Flight();

                    flight.Id = (int)row["Id"];
                    flight.FlightNumber = (string)row["FlightNumber"];
                    flight.DepartureTime = (DateTime)row["DepartureTime"];
                    flight.ArrivalTime = (DateTime)row["ArrivalTime"];
                    flight.DeparturePlace = AirportCity((string)row["DeparturePlace"]);
                    flight.Destination = AirportCity((string)row["Destination"]);
                    flight.OneWayTicketPrice = (int)row["OneWayTicketPrice"];
                    flight.CompanyId = GetId((int)row["CompanyId"]);
                    flight.Active = (bool)row["Active"];

                    Flights.Add(flight);
                }
            }
        }

        public void LoadAircompany()
        {
            Aircompanies.Clear();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * FROM Aircompany";

                SqlDataAdapter daAircompany = new SqlDataAdapter();
                DataSet dsAircompany = new DataSet();

                daAircompany.SelectCommand = command;
                daAircompany.Fill(dsAircompany, "Aircompanies");

                foreach (DataRow row in dsAircompany.Tables["Aircompanies"].Rows)
                {
                    Aircompany aircompany = new Aircompany();

                    aircompany.Id = (int)row["Id"];
                    aircompany.CompanyName = (string)row["CompanyName"];
                    aircompany.CompanyPassword = (string)row["CompanyPassword"];
                    aircompany.FlightList = GetFlightId((int)row["Id"]);
                    aircompany.Active = (bool)row["Active"];

                    Aircompanies.Add(aircompany);

                }
            }
            
        }

       

        public Airport AirportCity(String city)
        {
            foreach(Airport a in Airports)
            {
                if(a.City.Equals(city) && a.Active == false)
                {
                    return a;
                }
            }
            return null;
        }

       public Aircompany GetId(int id)
        {
            foreach (Aircompany f in Aircompanies)
            {
                if (f.Id.Equals(id))
                {
                    return f;
                }
            }
            return null;
        }
      
       public ObservableCollection<Flight> GetFlightId(int id)
        {
            ObservableCollection<Flight> fl = new ObservableCollection<Flight>();
            foreach(Flight f in Flights)
            {
                if(f.Id.Equals(id))
                {
                    fl.Add(f);
                }
            }
            return fl;
        }


        //public void LoadAllFlights()
        //{
        //    Flights.Add(new Flight
        //    {
        //        FlightNumber = "111",
        //        DepartureTime = new DateTime(2018, 12, 2, 11, 10, 33),
        //        ArrivalTime = new DateTime(2018, 12, 2, 15, 30, 11),
        //        DeparturePlace = "Belgrade",
        //        Destination = "Paris",
        //        OneWayTicketPrice = 2500,
        //        Active = false
        //    });

        //    Flights.Add(new Flight
        //    {
        //        FlightNumber = "222",
        //        DepartureTime = new DateTime(2018, 10, 7, 09, 16, 37),
        //        ArrivalTime = new DateTime(2018, 10, 7, 13, 38, 16),
        //        DeparturePlace = "New York",
        //        Destination = "Amsterdam",
        //        OneWayTicketPrice = 5700,
        //        Active = false
        //    });

        //    Flights.Add(new Flight
        //    {
        //        FlightNumber = "333",
        //        DepartureTime = new DateTime(2018, 1, 1, 19, 50, 00),
        //        ArrivalTime = new DateTime(2018, 1, 1, 22, 40, 07),
        //        DeparturePlace = "London",
        //        Destination = "Belgrade",
        //        OneWayTicketPrice = 3200,
        //        Active = false
        //    });

        //    Flights.Add(new Flight
        //    {
        //        FlightNumber = "444",
        //        DepartureTime = new DateTime(2018, 7, 9, 23, 50, 00),
        //        ArrivalTime = new DateTime(2018, 1, 1, 00, 10, 07),
        //        DeparturePlace = "Belgrade",
        //        Destination = "London",
        //        OneWayTicketPrice = 4200,
        //        Active = false
        //    });

        //    Flights.Add(new Flight
        //    {
        //        FlightNumber = "555",
        //        DepartureTime = new DateTime(2018, 3, 5, 03, 30, 00),
        //        ArrivalTime = new DateTime(2018, 3, 5, 06, 40, 07),
        //        DeparturePlace = "New York",
        //        Destination = "Paris",
        //        OneWayTicketPrice = 5000,
        //        Active = false
        //    });

        //    Flights.Add(new Flight
        //    {
        //        FlightNumber = "666",
        //        DepartureTime = new DateTime(2018, 10, 23, 18, 50, 00),
        //        ArrivalTime = new DateTime(2018, 1, 1, 21, 40, 07),
        //        DeparturePlace = "Amsterdam",
        //        Destination = "Belgrade",
        //        OneWayTicketPrice = 1200,
        //        Active = false
        //    });
        //}

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

        //public void LoadAllAircompanies()

        //{
        //    Aircompany A = new Aircompany();
        //    Flight F = new Flight();
        //    A.CompanyPassword = "675";
        //    A.FlightList.Add(Flights[0]);
        //    A.Active = false;
        //    Aircompanies.Add(A);

        //    A = new Aircompany();
        //    F = new Flight();
        //    A.CompanyPassword = "743";
        //    A.FlightList.Add(Flights[1]);
        //    A.FlightList.Add(Flights[2]);
        //    A.Active = false;
        //    Aircompanies.Add(A);

        //    A = new Aircompany();
        //    F = new Flight();
        //    A.CompanyPassword = "821";
        //    A.FlightList.Add(Flights[3]);
        //    A.FlightList.Add(Flights[2]);
        //    A.Active = false;
        //    Aircompanies.Add(A);

        //    A = new Aircompany();
        //    F = new Flight();
        //    A.CompanyPassword = "313";
        //    A.FlightList.Add(Flights[5]);
        //    A.Active = false;
        //    Aircompanies.Add(A);

        //    A = new Aircompany();
        //    F = new Flight();
        //    A.CompanyPassword = "483";
        //    A.FlightList.Add(Flights[4]);
        //    A.FlightList.Add(Flights[3]);
        //    A.Active = false;
        //    Aircompanies.Add(A);

        //}

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

        public void SeatLabels()
        {
            Seat s = new Seat();
            int[] row = { 1, 2, 3, 4, 5 };
            int[] column = { 1, 2, 3, 4, 5, 6 };
            for(int i = 0; i < row.GetLength(0) - 1; i++)
            {
                for(int j = 0; j< column.GetLength(0)-1; j++)
                {
                   // Trace.WriteLine(i + j);
                    s.SeatLabel = i.ToString() + j.ToString();
                    Trace.WriteLine(s.SeatLabel);
                }
            }
        }
    }
}
