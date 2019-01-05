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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void BtnAirport_Click(object sender, RoutedEventArgs e)
        {
            AirportWindow aw = new AirportWindow();
            aw.ShowDialog();
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            
            UserWindow uw = new UserWindow();
            uw.ShowDialog();
        }

        private void BtnFlights_Click(object sender, RoutedEventArgs e)
        {
            FlightsWindow fw = new FlightsWindow();
            fw.ShowDialog(); ;
        }

        private void BtnSeats_Click(object sender, RoutedEventArgs e)
        {
           
            SeatsWindow sw = new SeatsWindow();
            sw.ShowDialog();
        }

        private void BtnAircompany_Click(object sender, RoutedEventArgs e)
        {
            AircompanyWindow arw = new AircompanyWindow();
            arw.ShowDialog();
        }

        private void BtnAirplane_Click(object sender, RoutedEventArgs e)
        {
            AirplaneWindow apw = new AirplaneWindow();
            apw.ShowDialog();
        }

        private void BtnTickets_Click(object sender, RoutedEventArgs e)
        {
            //TicketsWindow tw = new TicketsWindow();
            //tw.ShowDialog();
        }
    }
}
