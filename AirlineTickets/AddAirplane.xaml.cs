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
using static AirlineTickets.Models.Seat;

namespace AirlineTickets
{
    /// <summary>
    /// Interaction logic for AddAirplane.xaml
    /// </summary>
    public partial class AddAirplane : Window
    {
       
        public Seat seat { get; set; }
        

        public AddAirplane()
        {
            InitializeComponent();
            seat = new Seat("");
            

            this.DataContext = seat;
            
            CbClass.ItemsSource = Enum.GetValues(typeof(EClass));
            seat.SeatState = true;
            TxtState.IsEnabled = false;
        }

        private void BtnDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = true;
            this.Close();
        }
    }
}
