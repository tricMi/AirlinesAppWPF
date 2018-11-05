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
    /// Interaction logic for EditAirportWindow.xaml
    /// </summary>
    public partial class EditAirportWindow : Window

    {
        public enum Option {ADDING, EDIT }
        Airport airport;
        Option option;

        public EditAirportWindow(Airport airport, Option option)
        {
            InitializeComponent();
            this.airport = airport;
            this.option = option;

            TxtAirportID.Text = airport.AirportID;
            TxtName.Text = airport.Name;
            TxtCity.Text = airport.City;

            if (option.Equals(Option.EDIT))
            {
                TxtAirportID.IsEnabled = false;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDiscard_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
