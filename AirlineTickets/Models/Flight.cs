using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTickets.Models
{
    class Flight
    {
        public String FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public String DeparturePlace { get; set; }
        public String Destination { get; set; }
        public Double OneWayTicketPrice { get; set; }

        public Flight()
        {

        }

        public Flight(String FlightNumber, DateTime DepartureTime, DateTime ArrivalTime, String DeparturePlace, String Destination, Double OneWayTicketPrice)
        {
            this.FlightNumber = FlightNumber;
            this.DepartureTime = DepartureTime;
            this.ArrivalTime = ArrivalTime;
            this.DeparturePlace = DeparturePlace;
            this.Destination = Destination;
            this.OneWayTicketPrice = OneWayTicketPrice;
        }
        public override string ToString()
        {
            return "Flight number: " + FlightNumber + " Departure time: " + DepartureTime + " Arrival time "
                + ArrivalTime + " Destination place: " + DeparturePlace + " Destination: "
                + Destination + " Ticket price: " + OneWayTicketPrice; 
        }
    }
}
