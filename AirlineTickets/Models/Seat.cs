using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTickets.Models
{
    public class Seat : INotifyPropertyChanged, ICloneable
    {
        public enum EClass {BUSINESS, ECONOMY}

        private String seatLabel;

        public String SeatLabel
        {
            get { return seatLabel; }
            set { seatLabel = value; }
        }

        private bool seatState;

        public bool SeatState
        {
            get { return seatState; }
            set { seatState = value; }
        }

        private EClass seatClass;

        public EClass SeatClass
        {
            get { return seatClass; }
            set { seatClass = value; }
        }

        private bool active;

        public bool Active
        {
            get { return active; }
            set { active = value; OnPropertyChanged("Active"); }
        }

        public Seat() { }

        public Seat(String seatLabel)
        {
            seatLabel = SeatLabel;
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
            Seat newSeat = new Seat
            {
                SeatLabel = this.SeatLabel,
                SeatState = this.SeatState,
                SeatClass = this.SeatClass,
                Active = this.Active
            };
            return newSeat;
        }

        public override string ToString()
        {
            return "Sediste " + SeatLabel + " Klasa " + SeatClass;
        }

    }
}
