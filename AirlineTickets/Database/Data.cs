
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
        public ObservableCollection<Seat> SeatAvailable { get; set; }
        public ObservableCollection<Seats> Seats { get; set; }
        public ObservableCollection<Airplane> Airplanes { get; set; }
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
            SeatAvailable = new ObservableCollection<Seat>();
            Seats = new ObservableCollection<Seats>();
            Airplanes = new ObservableCollection<Airplane>();
            Tickets = new ObservableCollection<Tickets>();

            LoadAirport();
            LoadUsers();
            LoadAircompany();
            LoadFlights();
            LoadAirplane();
            LoadSeats();
            
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
                    flight.CompanyPassword = GetPass((string)row["CompanyPassword"]);
                    flight.Active = (bool)row["Active"];

                    Flights.Add(flight);
                }
            }
        }

        public ObservableCollection<Flight> LoadAircompanyFlights(string pass)
        {
            ObservableCollection<Flight> aircompanyFlight = new ObservableCollection<Flight>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * FROM CompanyFlights";

                SqlDataAdapter daCompanyFlights = new SqlDataAdapter();
                DataSet dsCompanyFlights = new DataSet();

                daCompanyFlights.SelectCommand = command;
                daCompanyFlights.Fill(dsCompanyFlights, "CompanyFlights");

                foreach (DataRow row in dsCompanyFlights.Tables["CompanyFlights"].Rows)
                {
                    String aircompanyPass = (string)row["CompanyPass"];
                    if(aircompanyPass.Equals(pass))
                    {
                        Flight fl = GetFlightNumber((string)row["FlightNum"]);
                        aircompanyFlight.Add(fl);

                    }
                }
            return aircompanyFlight;
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
                    aircompany.FlightList = GetFlightNum((string)row["FlightList"]);
                    aircompany.Active = (bool)row["Active"];

                    Aircompanies.Add(aircompany);

                }
            }
            
        }

        public void LoadAirplane()
        {
            Airplanes.Clear();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * FROM Airplane";

                SqlDataAdapter daAirplane = new SqlDataAdapter();
                DataSet dsAirplane = new DataSet();

                daAirplane.SelectCommand = command;
                daAirplane.Fill(dsAirplane, "Airplanes");

                foreach (DataRow row in dsAirplane.Tables["Airplanes"].Rows)
                {
                    Airplane airplane = new Airplane();

                    airplane.Id = (int)row["Id"];
                    airplane.Pilot = (string)row["Pilot"];
                    airplane.FlightNum = GetFlightNumber((string)row["CompanyPassword"]);
                    airplane.RowNum = (int)row["RowNum"];
                    airplane.ColumnNum =(int)row["ColumnNum"];
                    airplane.BusinessClass = SeatsBusiness((int)row["RowNum"],(int)row["ColumnNum"]);
                    airplane.EconomyClass = SeatsEconomy((int)row["RowNum"], (int)row["ColumnNum"]);
                    airplane.AircompanyName = GetCompanyName((string)row["AircompanyName"]);
                    airplane.Active = (bool)row["Active"];
                    Airplanes.Add(airplane);

                }
            }

        }


        public void LoadSeats()
        {
            SeatAvailable.Clear();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * FROM Seat";

                SqlDataAdapter daSeats = new SqlDataAdapter();
                DataSet dsSeats = new DataSet();

                daSeats.SelectCommand = command;
                daSeats.Fill(dsSeats, "Seats");

                foreach (DataRow row in dsSeats.Tables["Seats"].Rows)
                {
                    Seat seat = new Seat();

                    seat.Id = (int)row["Id"];
                    seat.RowNum = (int)row["RowNum"];
                    seat.ColumnNum = (int)row["ColumnNum"];
                    seat.SeatLabel = SeatLabel((int)row["RowNum"], (int)row["ColumnNum"]);
                    seat.SeatClass = (EClass)row["SeatClass"];
                    seat.SeatState = (bool)row["SeatState"];
                    seat.AirplaneId = GetAirplaneId((int)row["AirplaneId"]);
                    seat.Active = (bool)row["Active"];

                    SeatAvailable.Add(seat);

                }
            }

        }

        public ObservableCollection<Seat> AirplaneSeat(int id)
        {
            ObservableCollection<Seat> seatA = new ObservableCollection<Seat>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * FROM AirplaneSeat";

                SqlDataAdapter daAirplaneSeat = new SqlDataAdapter();
                DataSet dsAirplaneSeat = new DataSet();

                daAirplaneSeat.SelectCommand = command;
                daAirplaneSeat.Fill(dsAirplaneSeat, "AirplaneSeat");

                foreach (DataRow row in dsAirplaneSeat.Tables["AirplaneSeat"].Rows)
                {
                    int aId = (int)row["AirplaneId"];
                    if(aId.Equals(id))
                    {
                        Seat seatLabel = GetSeatLabel((string)row["SeatLabel"]);
                        seatA.Add(seatLabel);
                    }
                }

            }
                return seatA;
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

       public Aircompany GetPass(string pass)
        {
            foreach (Aircompany f in Aircompanies)
            {
                if (f.CompanyPassword.Equals(pass))
                {
                    return f;
                }
            }
            return null;
        }
      
       public ObservableCollection<Flight> GetFlightNum(string num)
        {
            ObservableCollection<Flight> fl = new ObservableCollection<Flight>();
            foreach(Flight f in Flights)
            {
                if(f.FlightNumber.Equals(num))
                {
                    fl.Add(f);
                }
            }
            return fl;
        }

        public Flight GetFlightNumber(string flnum)
        {
            foreach(Flight f in Flights)
            {
                if(f.FlightNumber.Equals(flnum))
                {
                    return f;
                }
            }
            return null;
        }
        
        public Aircompany GetCompanyName(string name)
        {
            foreach(Aircompany a in Aircompanies)
            {
                if(a.CompanyName.Equals(name))
                {
                    return a;
                }
            }

            return null;
        }

        public Airplane GetAirplaneId(int id)
        {
            foreach(Airplane a in Airplanes)
            {
                if(a.Id.Equals(id))
                {
                    return a;
                }
            }
            return null;
        }

        public Seat GetSeatLabel(string label)
        {
            foreach(Seat s in SeatAvailable)
            {
                if(s.SeatLabel.Equals(label))
                {
                    return s;
                }
            }
            return null;
        }


        public char[] ColumnLabel()
        {

            char[] characters = "ABCDEFGH".ToCharArray();
            return characters;

        }

        public List<string> SeatLabels(int rowNum, int colNum)
        {
            
            List<string> seatLabels = new List<string>();
            for (int i = 0; i < rowNum + 1; i++)
            {
                for(int j = 0; j < colNum + 1; j++)
                {
                    string s = ColumnLabel()[i].ToString() + j;
                    seatLabels.Add(s);
                }
            }
            return seatLabels;
        }

        public string SeatLabel(int rowNum, int colNum)
        {
            for (int i = 0; i < rowNum + 1; i++)
            {
                for (int j = 0; j < colNum + 1; j++)
                {
                    string s = ColumnLabel()[i].ToString() + j;
                    return s;
                }
            }
            return null;
        }



        public ObservableCollection<Seat> SeatsBusiness(int rowNum, int colNum)
        {
            ObservableCollection<Seat> seatB = new ObservableCollection<Seat>();
            for (int i = 0; i < SeatLabels(rowNum, colNum).Count; i++)
            {
                if (i < 10)
                {
                    Seat seat = new Seat();
                    seat.SeatLabel = SeatLabels(rowNum, colNum)[i];
                    seat.SeatClass = EClass.BUSINESS;
                    seat.SeatState = true;
                    seat.Active = false;
                    seatB.Add(seat);
                    SeatAvailable.Add(seat);

                }

            }
            return seatB;

        }

        public ObservableCollection<Seat> SeatsEconomy(int rowNum, int colNum)
        {
            ObservableCollection<Seat> seatE = new ObservableCollection<Seat>();
            for (int i = 0; i < SeatLabels(rowNum, colNum).Count; i++)
            {
                if (i >= 10)
                {
                    Seat seatEconomy = new Seat();
                    seatEconomy.SeatLabel = SeatLabels(rowNum, colNum)[i];
                    seatEconomy.SeatClass = EClass.ECONOMY;
                    seatEconomy.SeatState = true;
                    seatEconomy.Active = false;
                    seatE.Add(seatEconomy);
                    SeatAvailable.Add(seatEconomy);
                }

            }
            return seatE;

        }
    }
}
