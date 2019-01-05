using AirlineTickets.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTickets.Models
{
    public class Flight : INotifyPropertyChanged, ICloneable
    {
        public const String CONNECTION_STRING = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=AirlineApp;Integrated Security=true";

        public int Id { get; set; }

        private String flightNumber;

        public String FlightNumber
        {
            get { return flightNumber; }
            set { flightNumber = value; OnPropertyChanged("FlightNumber"); }
        }

        private Airplane airplaneId;

        public Airplane AirplaneId
        {
            get { return airplaneId; }
            set { airplaneId = value; }
        }


        private DateTime departureTime;

        public DateTime DepartureTime
        {
            get { return departureTime; }
            set { departureTime = value; OnPropertyChanged("DepartureTime"); }
        }

        private DateTime arrivalTime;

        public DateTime ArrivalTime
        {
            get { return arrivalTime; }
            set { arrivalTime = value; OnPropertyChanged("ArrivalTime"); }
        }

        private Airport departurePlace;

        public Airport DeparturePlace
        {
            get { return departurePlace; }
            set { departurePlace = value; OnPropertyChanged("DeparturePlace"); }
        }

        private Airport destination;

        public Airport Destination
        {
            get { return destination; }
            set { destination = value; OnPropertyChanged("Destination"); }
        }


        private double oneWayTicketPrice;

        public double OneWayTicketPrice
        {
            get { return oneWayTicketPrice; }
            set { oneWayTicketPrice = value; OnPropertyChanged("OneWayTicketPrice"); }
        }

        private Aircompany companyPassword;

        public Aircompany CompanyPassword
        {
            get { return companyPassword; }
            set { companyPassword = value; }
        }


        private bool active;

        public bool Active
        {
            get { return active; }
            set { active = value; OnPropertyChanged("Active"); }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String name)
        {

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public object Clone()
        {
            Flight newFlight = new Flight
            {
                Id = this.Id,
                FlightNumber = this.FlightNumber,
                AirplaneId = this.AirplaneId,
                DepartureTime = this.DepartureTime,
                ArrivalTime = this.ArrivalTime,
                DeparturePlace = this.DeparturePlace,
                Destination = this.Destination,
                OneWayTicketPrice = this.OneWayTicketPrice,
                CompanyPassword = this.CompanyPassword,
                Active = this.Active
            };

            return newFlight;
        }


        public override string ToString()
        {
            return $"{FlightNumber}";
        }

        public void SaveFlights()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO Flight( FlightNumber, AirplaneId, DepartureTime, ArrivalTime, DeparturePlace, Destination, OneWayTicketPrice, CompanyPassword, Active)" +
               " VALUES (@FlightNumber, @AirplaneId, @DepartureTime, @ArrivalTime, @DeparturePlace, @Destination, @OneWayTicketPrice, @CompanyPassword, @Active)";

                command.Parameters.Add(new SqlParameter("@FlightNumber", this.FlightNumber));
                command.Parameters.Add(new SqlParameter("@AirplaneId", this.AirplaneId.Id));
                command.Parameters.Add(new SqlParameter("@DepartureTime", this.DepartureTime));
                command.Parameters.Add(new SqlParameter("@ArrivalTime", this.ArrivalTime));
                command.Parameters.Add(new SqlParameter("@DeparturePlace", this.DeparturePlace.City));
                command.Parameters.Add(new SqlParameter("@Destination", this.Destination.City));
                command.Parameters.Add(new SqlParameter("@OneWayTicketPrice", this.OneWayTicketPrice));
                command.Parameters.Add(new SqlParameter("@CompanyPassword", this.CompanyPassword.CompanyPassword));
                command.Parameters.Add(new SqlParameter("@Active", false));

                command.ExecuteNonQuery();

            }

            Database.Data.Instance.LoadFlights();
        }

        public void ChangeFlight()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"UPDATE Flight SET FlightNumber = @FlightNumber, AirplaneId = @AirplaneId, DepartureTime= @DepartureTime, ArrivalTime = @ArrivalTime,DeparturePlace = @DeparturePlace,Destination = @Destination,OneWayTicketPrice = @OneWayTicketPrice, CompanyPassword = @CompanyPassword,Active = @Active WHERE @Id = Id";


                command.Parameters.Add(new SqlParameter("@Id", this.Id));
                command.Parameters.Add(new SqlParameter("@FlightNumber", this.FlightNumber));
                command.Parameters.Add(new SqlParameter("@AirplaneId", this.AirplaneId.Id));
                command.Parameters.Add(new SqlParameter("@DepartureTime", this.DepartureTime));
                command.Parameters.Add(new SqlParameter("@ArrivalTime", this.ArrivalTime));
                command.Parameters.Add(new SqlParameter("@DeparturePlace", this.DeparturePlace.City));
                command.Parameters.Add(new SqlParameter("@Destination", this.Destination.City));
                command.Parameters.Add(new SqlParameter("@OneWayTicketPrice", this.OneWayTicketPrice));
                command.Parameters.Add(new SqlParameter("@CompanyPassword", this.CompanyPassword.CompanyPassword));
                command.Parameters.Add(new SqlParameter("@Active", this.Active));

                command.ExecuteNonQuery();

            }

            Database.Data.Instance.LoadFlights();
        }

        public void SaveAircompanyFlights(string CompanyPass, string FlightNum)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO CompanyFlights(CompanyPass, FlightNum)" +
                                      " VALUES(@CompanyPass, @FlightNum)";

                command.Parameters.Add(new SqlParameter("@CompanyPass", CompanyPass));
                command.Parameters.Add(new SqlParameter("@FlightNum", FlightNum));

                command.ExecuteNonQuery();
                 
            }

            Data.Instance.LoadAircompanyFlights(FlightNum);
        }
    }
}
