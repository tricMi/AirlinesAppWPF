using AirlineTickets.Database;
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    /// Interaction logic for FlightsWindow.xaml
    /// </summary>
    public partial class FlightsWindow : Window
    {
        ICollectionView view;

        public FlightsWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Data.Instance.Flights);
            DGFlights.ItemsSource = view;
            view.Filter = CustomFilter;
            DGFlights.IsReadOnly = true;
            DGFlights.IsSynchronizedWithCurrentItem = true;
            DGFlights.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
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
                return !fl.Active && fl.FlightNumber.Contains(txtSearch.Text.Trim()) ;
              
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

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Flight selectedFlight = (Flight)DGFlights.SelectedItem;
            if (SelectedFlight(selectedFlight))
            {
                if (MessageBox.Show("Are you sure that you want to delete this flight?", "Confirm", MessageBoxButton.YesNo).Equals(MessageBoxResult.Yes))
                {
                    int index = IndexOfSelectedFlight(selectedFlight.FlightNumber);
                    selectedFlight.Active = true;
                    selectedFlight.ChangeFlight();
                    Data.Instance.Flights[index].Active = true;
                    view.Refresh();
                }
            }
            
            
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Flight selectedFlight = DGFlights.SelectedItem as Flight;
            if (SelectedFlight(selectedFlight))
            {
                Flight oldFlight = selectedFlight.Clone() as Flight;
                EditFlightsWindow efw = new EditFlightsWindow(selectedFlight, EditFlightsWindow.Option.EDIT);
                if(efw.ShowDialog() != true)
                {
                    int index = IndexOfSelectedFlight(oldFlight.FlightNumber);
                    Data.Instance.Flights[index] = oldFlight;
                }
                else
                {
                    selectedFlight.ChangeFlight();
                }
            }

        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFlightsWindow efw = new EditFlightsWindow(new Flight(), EditFlightsWindow.Option.ADDING);
            efw.ShowDialog();
        }

        private int IndexOfSelectedFlight(String flightNumber)
        {
            var index = -1;
            for (int i = 0; i < Data.Instance.Flights.Count; i++)
            {
                if (Data.Instance.Flights[i].FlightNumber.Equals(flightNumber))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private bool SelectedFlight(Flight flight)
        {
            if (flight == null)
            {
                MessageBox.Show("You haven't selected any flight!");
                return false;
            }
            return true;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            view.Filter = RangeFilter;
        }

        private void BtnFilterPrice_Click(object sender, RoutedEventArgs e)
        {
            view.Filter = PriceFilter;
            view.Refresh();
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

        private void BtnFilterDate_Click(object sender, RoutedEventArgs e)
        {
            view.Filter = DateFilter;
        }

        private bool DateFilter(object obj)
        {
            Flight fl = obj as Flight;
            if (txtFromDate.Text.Equals(String.Empty) || txtToDate.Text.Equals(String.Empty))
            {
                return !fl.Active;
            }
            else
            {
                DateTime start = Convert.ToDateTime(txtFromDate.Text);
                DateTime end = Convert.ToDateTime(txtToDate.Text);

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

        private void TxtFromDate_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void TxtToDate_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void BtnSort_Click(object sender, RoutedEventArgs e)
        {
            view.SortDescriptions.Add(new SortDescription("OneWayTicketPrice", ListSortDirection.Ascending));
        }
    }
}
