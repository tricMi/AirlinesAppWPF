using AirlineTickets.Database;
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            return !fl.Active;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Flight selectedFlight = (Flight)DGFlights.SelectedItem;
            if (SelectedFlight(selectedFlight))
            {
                if (MessageBox.Show("Are you sure that you want to delete this flight?", "Confirm", MessageBoxButton.YesNo).Equals(MessageBoxResult.Yes))
                {
                    int index = IndexOfSelectedFlight(selectedFlight.FlightNumber);
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
    }
}
