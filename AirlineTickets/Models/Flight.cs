using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTickets.Models
{
    public class Flight : INotifyPropertyChanged, ICloneable
    {

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
    }
}
