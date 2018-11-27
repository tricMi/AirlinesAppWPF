using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTickets.Models
{
    public class Aircompany : INotifyPropertyChanged, ICloneable
    {

        private String companyPassword;

        public String CompanyPassword
        {
            get { return companyPassword; }
            set { companyPassword = value; OnPropertyChanged("CompanyPassword"); }
        }

        private ObservableCollection<Flight> flightList;

        public ObservableCollection<Flight> FlightList
        {
            get { return flightList; }
           set { flightList = value; OnPropertyChanged("FlightList"); }
        }

        

        private bool active;

        public bool Active
        {
            get { return active; }
            set { active = value; OnPropertyChanged("Active"); }
        }

        public Aircompany()
        {
           FlightList = new ObservableCollection<Flight>();
        }

        public Aircompany(String companyPassword)
        {
            this.CompanyPassword = CompanyPassword;
            FlightList = new ObservableCollection<Flight>();
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
            Aircompany newAircompany = new Aircompany
            {
                CompanyPassword = this.CompanyPassword,
                FlightList = this.FlightList,
                Active = this.Active
            };

            return newAircompany;
        }

      

        public override string ToString()
        {
            return $"Aircompany password: {CompanyPassword} Flight list: {FlightList} \n";
        }
    }
}
