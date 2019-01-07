using AirlineTickets.Database;
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AirlineTickets
{
    /// <summary>
    /// Interaction logic for EditFlightsWindow.xaml
    /// </summary>
    public partial class EditFlightsWindow : Window
    {
        public enum Option {ADDING, EDIT}
        
        Flight flight;
        Option option;
        public ObservableCollection<Airplane> aId = new ObservableCollection<Airplane>();
        public ObservableCollection<Airport> City = new ObservableCollection<Airport>();
        public ObservableCollection<Aircompany> CompanyNum = new ObservableCollection<Aircompany>();

        public EditFlightsWindow(Flight flight, Option option= Option.ADDING)
        {
            InitializeComponent();
            this.flight = flight;
            this.option = option;

            this.DataContext = flight;
            foreach (Airplane a in Data.Instance.Airplanes)
            {
                if (a.Active.Equals(false))
                {
                    aId.Add(a);
                }
            }

            foreach (Airport a in Data.Instance.Airports)
            {
                if (a.Active.Equals(false))
                {
                    City.Add(a);
                }
            }

            foreach (Aircompany a in Data.Instance.Aircompanies)
            {
                if (a.Active.Equals(false))
                {
                    CompanyNum.Add(a);
                }
            }

            cbAirplaneId.ItemsSource = aId.Select(ar => ar);
            CbDepPlace.ItemsSource = City.Select(a => a);
            CbDestination.ItemsSource = City.Select(b => b);
            cbCompanyId.ItemsSource = CompanyNum.Select(c => c);

            if(option.Equals(Option.EDIT))
            {
                tbFlightNum.IsEnabled = false;
            }

        }

        private void BtnDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Validation() == true)

            {
                BtnSave.IsEnabled = true;
                if (!System.Windows.Controls.Validation.GetHasError(tbFlightNum))
                {
                    this.DialogResult = true;
                    if (option.Equals(Option.ADDING) && !flightExists(flight.FlightNumber))
                    {
                        flight.SaveFlights();
                        Aircompany pass = flight.CompanyPassword;
                        flight.SaveAircompanyFlights(pass.CompanyPassword, flight.FlightNumber);

                    }
                    else
                    {
                        MessageBox.Show("Flight with that number already exists, please choose another flight number");
                    }
                }
            }

        }
        
        private bool flightExists(string flightNumber)
        {
            return Data.Instance.Flights.ToList().Find(a => a.FlightNumber.Equals(flightNumber)) != null ? true : false;
        }

        private Boolean Validation()
        {
            Boolean ok = true;
            if(tbFlightNum.Text.Equals(String.Empty))
            {
                ok = false;
                BtnSave.IsEnabled = false;
            }
            if (tbOneWayTicketPrice.Text.Equals(String.Empty))
            {
                ok = false;
                BtnSave.IsEnabled = false;
            }
            return ok;
        }
    }
}
