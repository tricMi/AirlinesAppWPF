using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTickets.Models
{
    class Seats : INotifyPropertyChanged, ICloneable

    {
        public enum ESeatClass { BUSINESS, ECONOMY}

        private ObservableCollection<Seat> availableSeats;

        public ObservableCollection<Seat> AvailableSeats
        {
            get { return availableSeats; }
            set { availableSeats = value; OnPropertyChanged("AvailableSeats"); }
        }

        private ObservableCollection<Seat> takenSeats;

        public ObservableCollection<Seat> TakenSeats
        {
            get { return takenSeats; }
            set { takenSeats = value; OnPropertyChanged("TakenSeats"); }
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
                AvailableSeats = this.AvailableSeats,
                TakenSeats = this.TakenSeats,
                Active = this.Active
            };
            return newSeats;
        }
    }
}
