using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTickets.Models
{
    public class Seats : INotifyPropertyChanged, ICloneable

    {
        private ObservableCollection<Seat> allSeats;

        public ObservableCollection<Seat> AllSeats
        {
            get { return allSeats; }
            set { allSeats = value; }
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
            Seats newSeats = new Seats
            {
                AllSeats = this.AllSeats,
                Active = this.Active
            };
            return newSeats;
        }

        public override string ToString()
        {
            return "Seat"+  AllSeats.ToString();

        }
    }
}
