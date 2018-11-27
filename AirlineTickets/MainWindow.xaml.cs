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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirlineTickets
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAirport_Click(object sender, RoutedEventArgs e)
        {
            AirportWindow aw = new AirportWindow();
            aw.Show();
        }

        private void BtnFlights_Click(object sender, RoutedEventArgs e)
        {
            FlightsWindow fw = new FlightsWindow();
            fw.Show();
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            UserWindow uw = new UserWindow();
            uw.Show();
        }

        private void BtnAircompany_Click(object sender, RoutedEventArgs e)
        {
            AircompanyWindow arw = new AircompanyWindow();
            arw.ShowDialog();
        }
    }
}
