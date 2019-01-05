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

            view = CollectionViewSource.GetDefaultView(Data.Instance.Flights);
            DGFlights.ItemsSource = view;
            view.Filter = CustomFilter;
            DGFlights.IsReadOnly = true;
            DGFlights.IsSynchronizedWithCurrentItem = true;
            DGFlights.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            view.SortDescriptions.Add(new SortDescription("OneWayTicketPrice", ListSortDirection.Descending));

            


        }

        private bool CustomFilter(object obj)
        {
            Flight fl = obj as Flight;
            if (txtSearch.Text.Equals(String.Empty))
            {
                return !fl.Active;
            }
            else
            {
                return !fl.Active && fl.FlightNumber.Contains(txtSearch.Text.Trim());

            }
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

                return !fl.Active && fl.DeparturePlace.ToString().Contains(txtFromRange.Text) && fl.Destination.ToString().Contains(txtToRange.Text);

            }

        }

        private bool PriceFilter(object obj3)
        {
            Flight fl = obj3 as Flight;
            if (txtFromPrice.Text.Equals(String.Empty) || txtToPrice.Equals(String.Empty))
            {
                return !fl.Active;
            }
            else
            {

                int start = Convert.ToInt32(txtFromPrice.Text);
                int end = Convert.ToInt32(txtToPrice.Text);

                return fl.OneWayTicketPrice >= start && fl.OneWayTicketPrice <= end;

            }

        }

        private bool DateFilter(object obj)
        {
            Flight fl = obj as Flight;
            if (DD.Text.Equals(String.Empty) || AD.Text.Equals(String.Empty))
            {
                return !fl.Active;
            }
            else
            {
                DateTime start = Convert.ToDateTime(DD.Text);
                DateTime end = Convert.ToDateTime(AD.Text);

                return fl.DepartureTime >= start && fl.ArrivalTime <= end;
            }
        }

        private void TxtFromPrice_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void TxtToPrice_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }


        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void TxtFromRange_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void TxtToRange_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

  

        private void DateTimePicker_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            view.Refresh();
        }

        private void DateTimePicker_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            view.Refresh();
        }

        private void BtnFilterDate_Click(object sender, RoutedEventArgs e)
        {
            view.Filter = DateFilter;
        }

        

        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {
            view.Filter = RangeFilter;
        }

        private void BtnFilterPrice_Click(object sender, RoutedEventArgs e)
        {
            view.Filter = PriceFilter;
        }

        private void BtnPickSeat_Click(object sender, RoutedEventArgs e)
        {
            SelectedFlight = DGFlights.SelectedItem as Flight;
            BookFlightPassenger bf = new BookFlightPassenger(SelectedFlight, user);
            bf.ShowDialog();
            
        }


    }
}
