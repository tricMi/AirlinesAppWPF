using AirlineTickets.Database;
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Interaction logic for FilterFlightsWindow.xaml
    /// </summary>
    public partial class FilterFlightsWindow : Window
    {
 
        User user;
        ICollectionView view;
        public Flight SelectedFlight { get; set; }

        public FilterFlightsWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            BtnPickFlight.IsEnabled = false;
        }



        public bool RangeFilter(object obj2)
        {
            Flight fl = obj2 as Flight;
            if (txtFromRange.Text.Equals(String.Empty) || txtToRange.Equals(String.Empty))
            {
               
                return !fl.Active;
            }
            else
            {
                int start = Convert.ToInt32(txtFromPrice.Text);
                int end = Convert.ToInt32(txtToPrice.Text);

                DateTime startTime = Convert.ToDateTime(DD.Text);
                DateTime endTime = Convert.ToDateTime(AD.Text);


                return (!fl.Active && fl.DeparturePlace.ToString().Contains(txtFromRange.Text) && fl.Destination.ToString().Contains(txtToRange.Text)) &&
                    (fl.OneWayTicketPrice >= start && fl.OneWayTicketPrice <= end) &&
                    (fl.DepartureTime >= startTime && fl.ArrivalTime <= endTime);

            }

        }

        private Boolean Validation()
        {
            Boolean ok = true;
            
            if(txtFromRange.Text.Equals(String.Empty))
            {
                ok = false;
                MessageBox.Show("Field can't be empty");
            }
            else if(txtToRange.Text.Equals(String.Empty))
            {
                ok = false;
                MessageBox.Show("Field can't be empty");
            }
            else if(txtFromPrice.Text.Equals(String.Empty))
            {
                ok = false;
                MessageBox.Show("Field can't be empty");
            }
            else if(txtToPrice.Text.Equals(String.Empty))
            {
                ok = false;
                MessageBox.Show("Field can't be empty");
            }
            else if(DD.Text.Equals(String.Empty))
            {
                ok = false;
                MessageBox.Show("Field can't be empty");
            }
            else if (AD.Text.Equals(String.Empty))
            {
                ok = false;
                MessageBox.Show("Field can't be empty");
            }
            return ok;
        }

        

        private void BtnPickSeat_Click(object sender, RoutedEventArgs e)
        {
            SelectedFlight = DGFlights.SelectedItem as Flight;
            BookFlightPassenger bf = new BookFlightPassenger(SelectedFlight, user);
            bf.ShowDialog();
            
        }

        private void BtnShowFlights_Click(object sender, RoutedEventArgs e)
        {
            
            if (Validation() == true)
            {
                view = CollectionViewSource.GetDefaultView(Data.Instance.Flights);
                DGFlights.ItemsSource = view;
                view.Filter = RangeFilter;
                DGFlights.IsReadOnly = true;
                DGFlights.IsSynchronizedWithCurrentItem = true;
                DGFlights.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                BtnPickFlight.IsEnabled = true;
                view.SortDescriptions.Add(new SortDescription("OneWayTicketPrice", ListSortDirection.Descending));
            }

        }
    }
}
