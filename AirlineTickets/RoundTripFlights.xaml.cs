using AirlineTickets.Database;
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for RoundTripFlights.xaml
    /// </summary>
    public partial class RoundTripFlights : Window
    {
        public User user;
        public Flight SelectedFlight { get; set; }
        public EFlightType type;
        ICollectionView view;
        public ObservableCollection<Flight> roundtripFlights = new ObservableCollection<Flight>();
        public ObservableCollection<Flight> aircompanyFlights = new ObservableCollection<Flight>();

        public RoundTripFlights(Flight SelectedFlight, User user, EFlightType type)
        {
            InitializeComponent();

            this.user = user;

            foreach (Flight f in Data.Instance.Flights)
            {
                if (SelectedFlight.DeparturePlace.City.Equals(f.Destination.City) && SelectedFlight.Destination.City.Equals(f.DeparturePlace.City))
                {
                    roundtripFlights.Add(f);
                }
            }

            foreach (Flight f in Data.Instance.Flights)
            {
                if (SelectedFlight.DeparturePlace.City.Equals(f.Destination.City) && SelectedFlight.Destination.City.Equals(f.DeparturePlace.City) && SelectedFlight.CompanyPassword.CompanyPassword.Equals(f.CompanyPassword.CompanyPassword))
                {
                    aircompanyFlights.Add(f);
                }
            }

            view = CollectionViewSource.GetDefaultView(roundtripFlights);
            DgRoundtrip.ItemsSource = view;
            DgRoundtrip.IsReadOnly = true;
            DgRoundtrip.IsSynchronizedWithCurrentItem = true;
            DgRoundtrip.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                


        }

        private void BtnPickFlight_Click(object sender, RoutedEventArgs e)
        {
            SelectedFlight = DgRoundtrip.SelectedItem as Flight;
            BookFlightPassenger bf = new BookFlightPassenger(SelectedFlight, user, EFlightType.ONEWAY );
            bf.ShowDialog();
            this.Close();
        }

        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {

            view = CollectionViewSource.GetDefaultView(aircompanyFlights);
            DgRoundtrip.ItemsSource = view;
            DgRoundtrip.IsReadOnly = true;
            DgRoundtrip.IsSynchronizedWithCurrentItem = true;
            DgRoundtrip.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
    }
}
