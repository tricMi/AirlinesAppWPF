using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTickets.Models
{
    public class Airport : INotifyPropertyChanged, ICloneable

    {
        private String airportID;

        public String AirportID
        {
            get { return airportID; }
            set { airportID = value; OnPropertyChanged("AirportID"); }
        }

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private String city;

        public String City
        {
            get { return city; }
            set { city = value; OnPropertyChanged("City"); }
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
            
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public object Clone()
        {
            Airport newAirport = new Airport
            {
                AirportID = this.AirportID,
                Name = this.Name,
                City = this.City,
                Active = this.Active

            };

            return newAirport;
        }


        public override string ToString()
        {
            return $"Airport ID: {AirportID} Name: {Name} City: {City}\n";
        }
    }
}
