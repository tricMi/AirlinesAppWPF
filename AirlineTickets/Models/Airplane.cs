using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTickets.Models
{
    public class Airplane : INotifyPropertyChanged, ICloneable
    {
        private string pilot;

        public string Pilot
        {
            get { return pilot; }
            set { pilot = value; OnPropertyChanged("Pilot"); }
        }

        private String flightNum;

        public String FlightNum
        {
            get { return flightNum; }
            set { flightNum = value; OnPropertyChanged("FlightNum"); }
        }

        private Seats businessClass;

        public Seats BusinessClass
        {
            get { return businessClass; }
            set { businessClass = value; OnPropertyChanged("BusinessClass"); }
        }

        private Seats economyClass;

        public Seats EconomyClass
        {
            get { return economyClass; }
            set { economyClass = value; OnPropertyChanged("EconomyClass"); }
        }

        private string aircompanyName;

        public string AircompanyName
        {
            get { return aircompanyName; }
            set { aircompanyName = value; OnPropertyChanged("AircompanyName"); }
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
            Airplane newPlane = new Airplane
            {
                Pilot = this.Pilot,
                FlightNum = this.FlightNum,
                BusinessClass = this.BusinessClass,
                EconomyClass = this.EconomyClass,
                AircompanyName = this.AircompanyName,
                Active = this.Active
            };
            return newPlane;
        }
    }
}
