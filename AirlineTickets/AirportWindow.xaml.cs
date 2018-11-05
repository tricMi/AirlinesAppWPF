using AirlineTickets.Database;
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
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
        public AirportWindow()
        {
            InitializeComponent();
            Reload(); 
        }

        private void Reload()
        {
            if (LbAirport.HasItems)
                LbAirport.Items.Clear();
            foreach (var airport in Data.Instance.Airports)
            {
                if (!airport.Active)
                {
                    LbAirport.Items.Add(airport); 
                }
            }
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            Airport airport = (Airport)LbAirport.SelectedItem;
            if (SelectedAirport(airport))
            {
                if (MessageBox.Show("Are you sure that you want to delete airport?", "Confirm", MessageBoxButton.YesNo).Equals(MessageBoxResult.Yes))
                {
                    var index = IndexOfSelectedAirport(airport.AirportID);
                    Data.Instance.Airports[index].Active = true;
                    Reload();
                }
            }
            

        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            Airport airport = (Airport)LbAirport.SelectedItem;
            if (SelectedAirport(airport))
            {
                EditAirportWindow eaw = new EditAirportWindow(airport, EditAirportWindow.Option.EDIT);
                if (eaw.ShowDialog() == true)
                {
                    Reload();
                }
            }
           
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            EditAirportWindow eaw = new EditAirportWindow(new Airport(), EditAirportWindow.Option.ADDING);
            if (eaw.ShowDialog() == true)
            {
                Reload();
            }
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
    }
}
