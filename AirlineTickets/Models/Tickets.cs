using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTickets.Models
{
    public class Tickets : INotifyPropertyChanged, ICloneable
    {
        private String flightNum;

        public String FlightNum
        {
            get { return flightNum; }
            set { flightNum = value; OnPropertyChanged("FlightNum"); }
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

        private double ticketPrice;

        public double TicketPrice
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
                FlightNum = this.FlightNum,
                SeatNum = this.SeatNum,
                CurrentUser = this.CurrentUser,
                Gate = this.Gate,
                TicketPrice = this.TicketPrice,
                Active = this.Active
            };
            return newTickets;
        }
    }
}
