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
    /// Interaction logic for BookFlightPassenger.xaml
    /// </summary>
    public partial class BookFlightPassenger : Window
    {

        User user;
        Flight flight;
        public Seat SelectedSeat { get; set; }
        public EClass clas { get; set; }

        public BookFlightPassenger(Flight flight, User user)
        {
            InitializeComponent();
            this.user = user;
            this.flight = flight;


            if (user != null)
            {
                txtFlight.IsEnabled = false;
                txtName.IsEnabled = false;
                txtSeat.IsEnabled = false;
                txtGender.IsEnabled = false;
                txtSurname.IsEnabled = false;
                txtAddress.IsEnabled = false;


                txtName.Text = user.Name;
                txtSurname.Text = user.Surname;
                txtGender.Text = user.Gender.ToString();
                txtAddress.Text = user.Address;

            }
            this.txtSeat.DataContext = SelectedSeat;
            this.cbClass.DataContext = SelectedSeat;
            this.txtPrice.DataContext = flight;

            this.txtName.DataContext = user;
            this.txtSurname.DataContext = user;
            this.txtGender.DataContext = user;
            this.txtAddress.DataContext = user;

            this.txtFlight.DataContext = flight;


            cbClass.ItemsSource = Enum.GetValues(typeof(EClass));
           
            txtPrice.Text = flight.OneWayTicketPrice.ToString();
            
        }

        private void BtnBook_Click(object sender, RoutedEventArgs e)
        {
            Tickets ticket = new Tickets();
            if (user != null)
            {
                ticket.FlightNum = flight;
                ticket.SeatClass = (EClass)cbClass.SelectedItem;
                ticket.SeatNum = SelectedSeat;
                ticket.CurrentUser = user.Username;
                ticket.Gate = "A5";
                ticket.TicketPrice = flight.OneWayTicketPrice;
                if (SelectedSeat.SeatClass.Equals(EClass.BUSINESS))
                {
                    ticket.TicketPrice = flight.OneWayTicketPrice * (decimal)5.0;
                }
            }
            else
            {
                ticket.FlightNum = flight;
                ticket.SeatClass = (EClass)cbClass.SelectedItem;
                ticket.SeatNum = SelectedSeat;
                ticket.CurrentUser = txtName.Text + " " + txtSurname.Text;
                ticket.Gate = "A5";
                ticket.TicketPrice = flight.OneWayTicketPrice;
                if (SelectedSeat.SeatClass.Equals(EClass.BUSINESS))
                {
                    ticket.TicketPrice = flight.OneWayTicketPrice * (decimal)5.0;
                }
            }
            ticket.SaveTicket();
            this.Close();
        }

        private void BtnSeat_Click(object sender, RoutedEventArgs e)
        {
            if (cbClass.SelectedIndex > -1)
            {
                clas = (EClass)cbClass.SelectedItem;
                PickSeatWindow ps = new PickSeatWindow(flight, clas);
                if (ps.ShowDialog() == true)
                {
                    SelectedSeat = ps.SelectedSeat;
                }
                
            }
            else
            {
                MessageBox.Show("You must select a class");
            }
        }


    }
}
