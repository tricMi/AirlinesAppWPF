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
    /// Interaction logic for AirportWindow.xaml
    /// </summary>
    public partial class AirportWindow : Window
    {
        ICollectionView view;

        public AirportWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Data.Instance.Airports);
            view.Filter = CustomFilter;
            DGAirport.ItemsSource = view;
            DGAirport.IsReadOnly = true;
            DGAirport.IsSynchronizedWithCurrentItem = true;
            DGAirport.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

        }

        private bool CustomFilter(object obj)
        {
            Airport airport = obj as Airport;
            if(TxtSearch.Text.Equals(String.Empty))
            {
                return !airport.Active;
            }
            else 
            {
                return !airport.Active && airport.Name.Contains(TxtSearch.Text);
            }
          
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            Airport airport = (Airport)DGAirport.SelectedItem;
            if (SelectedAirport(airport))
            {
                if (MessageBox.Show("Are you sure that you want to delete airport?", "Confirm", MessageBoxButton.YesNo).Equals(MessageBoxResult.Yes))
                {
                    int index = IndexOfSelectedAirport(airport.AirportID);
                    airport.Active = true;
                    airport.Change();
                    Data.Instance.Airports[index].Active = true;
                    view.Refresh();
                }
            }
            

        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            Airport selectedAirport = (Airport)DGAirport.SelectedItem;
            if (SelectedAirport(selectedAirport))
            {
                Airport oldAirport = selectedAirport.Clone() as Airport;
                EditAirportWindow eaw = new EditAirportWindow(selectedAirport, EditAirportWindow.Option.EDIT);
                if (eaw.ShowDialog() != true)
                {
                    int index = IndexOfSelectedAirport(oldAirport.AirportID);
                    Data.Instance.Airports[index] = oldAirport;
                }
                else
                {
                    selectedAirport.Change();
                }
            }
           
        } 

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            EditAirportWindow eaw = new EditAirportWindow(new Airport(), EditAirportWindow.Option.ADDING);
            eaw.ShowDialog();
        }

        private int IndexOfSelectedAirport(String airportID)
        {
            var index = -1;
            for (int i = 0; i < Data.Instance.Airports.Count; i++)
            {
                if (Data.Instance.Airports[i].AirportID.Equals(airportID))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private bool SelectedAirport(Airport airport)
        {
            if (airport == null)
            {
                MessageBox.Show("You haven't selected any airport!");
                return false;
            }
            return true;
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }
    }
}
