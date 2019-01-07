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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirlineTickets
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        private EFlightType type;

        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            l.ShowDialog();
    
        }

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            FilterFlightsWindow fw = new FilterFlightsWindow(null, type);
            fw.ShowDialog();
        }
    }
}
