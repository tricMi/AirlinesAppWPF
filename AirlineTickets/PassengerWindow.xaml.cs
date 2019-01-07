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
    /// Interaction logic for PassengerWindow.xaml
    /// </summary>
    public partial class PassengerWindow : Window
    {
        private User user;
        private EFlightType type;

        public PassengerWindow(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void BtnPassenger_Click(object sender, RoutedEventArgs e)
        {
            PassengerProfile pf = new PassengerProfile(user);
            pf.ShowDialog();
        }

        private void BtnTickets_Click(object sender, RoutedEventArgs e)
        {
            PassengerTickets pt = new PassengerTickets(user);
            pt.ShowDialog();
        }

        private void BtnFlights_Click(object sender, RoutedEventArgs e)
        {
            FilterFlightsWindow fw = new FilterFlightsWindow(user, type);
            fw.ShowDialog();
        }
    }
}
