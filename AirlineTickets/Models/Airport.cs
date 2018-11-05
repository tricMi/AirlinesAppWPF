using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTickets.Models
{
    public class Airport
    {
        public String AirportID { get; set; }
        public String Name { get; set; }
        public String City { get; set; }

        public Boolean Active { get; set; }

        public Airport()
        {

        }

        public Airport(String AirportID, String Name, String City)
        {
            this.AirportID = AirportID;
            this.Name = Name;
            this.City = City;
        }


        public override string ToString()
        {
            return $"Airport ID: {AirportID} Name: {Name} City: {City}\n";
        }
    }
}
