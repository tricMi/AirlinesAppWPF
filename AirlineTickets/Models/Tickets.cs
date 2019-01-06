using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AirlineTickets.Models.Seat;

namespace AirlineTickets.Models
{
    public class Tickets : INotifyPropertyChanged, ICloneable
    {
        public const String CONNECTION_STRING = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=AirlineApp;Integrated Security=true";

        public int Id { get; set; }

        private Flight flightNum;

        public Flight FlightNum
        {
            get { return flightNum; }
            set { flightNum = value; OnPropertyChanged("FlightNum"); }
        }

        private EClass seatClass;

        public EClass SeatClass
        {
            get { return seatClass; }
            set { seatClass = value; OnPropertyChanged("SeatClass"); }
        }


        private Seat seatNum;

        public Seat SeatNum
        {
            get { return seatNum; }
            set { seatNum = value; OnPropertyChanged("SeatNum"); }
        }

        private String currentUser;

        public String CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; OnPropertyChanged("CurrentUser"); }
        }


        private string gate;

        public string Gate
        {
            get { return gate; }
            set { gate = value; OnPropertyChanged("Gate"); }
        }

        private decimal ticketPrice;

        public decimal TicketPrice
        {
            get { return ticketPrice; }
            set { ticketPrice = value; OnPropertyChanged("TicketPrice"); }
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
            Tickets newTickets = new Tickets
            {
                Id = this.Id,
                FlightNum = this.FlightNum,
                SeatNum = this.SeatNum,
                CurrentUser = this.CurrentUser,
                Gate = this.Gate,
                TicketPrice = this.TicketPrice,
                Active = this.Active
            };
            return newTickets;
        }

        public void SaveTicket()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO Tickets(FlightNum, SeatClass, SeatNum, CurrentUser, Gate, TicketPrice, Active)" +
                    " VALUES(@FlightNum, @SeatClass, @SeatNum, @CurrentUser, @Gate, @TicketPrice, @Active)";

                command.Parameters.Add(new SqlParameter("@FlightNum", this.FlightNum.FlightNumber));
                command.Parameters.Add(new SqlParameter("@SeatClass", this.SeatClass));
                command.Parameters.Add(new SqlParameter("@SeatNum", this.SeatNum.SeatLabel));
                command.Parameters.Add(new SqlParameter("@CurrentUser", this.CurrentUser));
                command.Parameters.Add(new SqlParameter("@Gate", this.Gate));
                command.Parameters.Add(new SqlParameter("@TicketPrice", this.TicketPrice));
                command.Parameters.Add(new SqlParameter("@Active", false));

                command.ExecuteNonQuery();
                
            }

            Database.Data.Instance.LoadTickets();
        }

        public void ChangeTicket()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"UPDATE Tickets SET FlightNum = @FlightNum, 
                SeatClass = @SeatClass, SeatNum = @SeatNum, CurrentUser = @CurrentUser, Gate = @Gate, 
                TicketPrice = @TicketPrice, Active = @Active WHERE @Id = Id";

                command.Parameters.Add(new SqlParameter("@Id", this.Id));
                command.Parameters.Add(new SqlParameter("@FlightNum", this.FlightNum.FlightNumber));
                command.Parameters.Add(new SqlParameter("@SeatClass", this.SeatClass));
                command.Parameters.Add(new SqlParameter("@SeatNum", this.SeatNum.SeatLabel));
                command.Parameters.Add(new SqlParameter("@CurrentUser", this.CurrentUser));
                command.Parameters.Add(new SqlParameter("@Gate", this.Gate));
                command.Parameters.Add(new SqlParameter("@TicketPrice", this.TicketPrice));
                command.Parameters.Add(new SqlParameter("@Active", this.Active));

                command.ExecuteNonQuery();

            }

            Database.Data.Instance.LoadTickets();
        }
    }
}
