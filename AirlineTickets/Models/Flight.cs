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

        private String departurePlace;

        public String DeparturePlace
        {
            get { return departurePlace; }
            set { departurePlace = value; OnPropertyChanged("DeparturePlace"); }
        }

        private String destination;

        public String Destination
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

        private bool active;

        public bool Active
        {
            get { return active; }
            set { active = value; OnPropertyChanged("Active"); }
        }

        public Flight() { }

        public Flight(String flightNumber)
        {
            flightNumber = FlightNumber;
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
                DepartureTime = this.DepartureTime,
                ArrivalTime = this.ArrivalTime,
                DeparturePlace = this.DeparturePlace,
                Destination = this.Destination,
                OneWayTicketPrice = this.OneWayTicketPrice,
                Active = this.Active
            };

            return newFlight;
        }

        
        public override string ToString()
        {
            return "Flight number: " + FlightNumber + " Departure time: " + DepartureTime + " Arrival time "
                + ArrivalTime + " Destination place: " + DeparturePlace + " Destination: "
                + Destination + " Ticket price: " + OneWayTicketPrice; 
        }

        public void SaveFlights()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO Flight( FlightNumber, DepartureTime, ArrivalTime, DeparturePlace, Destination, OneWayTicketPrice, Active)" +
               " VALUES (@FlightNumber, @DepartureTime, @ArrivalTime, @DeparturePlace, @Destination, @OneWayTicketPrice, @Active)";



                command.Parameters.Add(new SqlParameter("@FlightNumber", this.FlightNumber));
                command.Parameters.Add(new SqlParameter("@DepartureTime", this.DepartureTime));
                command.Parameters.Add(new SqlParameter("@ArrivalTime", this.ArrivalTime));
                command.Parameters.Add(new SqlParameter("@DeparturePlace", this.DeparturePlace));
                command.Parameters.Add(new SqlParameter("@Destination", this.Destination));
                command.Parameters.Add(new SqlParameter("@OneWayTicketPrice", this.OneWayTicketPrice));
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
                command.CommandText = @"UPDATE Flight SET FlightNumber = @FlightNumber, DepartureTime= @DepartureTime, ArrivalTime = @ArrivalTime,DeparturePlace = @DeparturePlace,Destination = @Destination,OneWayTicketPrice = @OneWayTicketPrice, Active = @Active WHERE @Id = Id";


                command.Parameters.Add(new SqlParameter("@Id", this.Id));
                command.Parameters.Add(new SqlParameter("@FlightNumber", this.FlightNumber));
                command.Parameters.Add(new SqlParameter("@DepartureTime", this.DepartureTime));
                command.Parameters.Add(new SqlParameter("@ArrivalTime", this.ArrivalTime));
                command.Parameters.Add(new SqlParameter("@DeparturePlace", this.DeparturePlace));
                command.Parameters.Add(new SqlParameter("@Destination", this.Destination));
                command.Parameters.Add(new SqlParameter("@OneWayTicketPrice", this.OneWayTicketPrice));
                command.Parameters.Add(new SqlParameter("@Active", this.Active));

                command.ExecuteNonQuery();

            }

            Database.Data.Instance.LoadFlights();
        }
    }
}
