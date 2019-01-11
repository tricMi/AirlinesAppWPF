using AirlineTickets.Database;
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public List<string> gate = new List<string>();
        public EFlightType type;

        public BookFlightPassenger(Flight flight, User user, EFlightType type)
        {
            InitializeComponent();
            this.user = user;
            this.flight = flight;
            this.type = type;

            if (user != null)
            {
                txtFlight.IsEnabled = false;
                txtName.IsEnabled = false;
                txtSeat.IsEnabled = false;
                CbGender.IsEnabled = false;
                txtSurname.IsEnabled = false;
                txtAddress.IsEnabled = false;
                txtEmail.IsEnabled = false;


                txtName.Text = user.Name;
                txtSurname.Text = user.Surname;
                txtEmail.Text = user.Email;
                CbGender.SelectedItem = user.Gender;
                txtAddress.Text = user.Address;
                

            }

            this.txtSeat.DataContext = SelectedSeat;
            this.cbClass.DataContext = SelectedSeat;
            this.txtPrice.DataContext = flight;

            this.txtName.DataContext = user;
            this.txtSurname.DataContext = user;
            this.txtEmail.DataContext = user;
            this.CbGender.DataContext = user;
            this.txtAddress.DataContext = user;

            this.txtFlight.DataContext = flight;

            CbGender.ItemsSource = Enum.GetValues(typeof(EGender));
            cbClass.ItemsSource = Enum.GetValues(typeof(EClass));
 
            
            txtPrice.Text = flight.OneWayTicketPrice.ToString();

            gate.Add("A5");
            gate.Add("B4");
            gate.Add("D5");

            CbGate.ItemsSource = gate;

        }

        private void BtnBook_Click(object sender, RoutedEventArgs e)
        {
                if (Validation() == true)
                {
                    Tickets ticket = new Tickets();

                    if (user != null)
                    {
                        ticket.FlightNum = flight;
                        ticket.SeatClass = (EClass)cbClass.SelectedItem;
                        ticket.SeatNum = SelectedSeat;
                        ticket.CurrentUser = user.Username;
                        if (CbGate.SelectedIndex > -1)
                        {
                            ticket.Gate = CbGate.SelectedItem.ToString();
                        }
                        else
                        {
                            MessageBox.Show("You must select a gate");
                        }
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
                        if (CbGate.SelectedIndex > -1)
                        {
                            ticket.Gate = CbGate.SelectedItem.ToString();
                        }
                        else
                        {
                            MessageBox.Show("You must select a gate");
                        }
                        ticket.TicketPrice = flight.OneWayTicketPrice;
                        if (SelectedSeat.SeatClass.Equals(EClass.BUSINESS))
                        {
                            ticket.TicketPrice = flight.OneWayTicketPrice * (decimal)5.0;
                        }


                    }

                    ticket.SaveTicket();

                    RoundTripFlights fw = new RoundTripFlights(flight, user, type);
                    if (type.Equals(EFlightType.ROUNDTRIP))
                    {

                        fw.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            

        }

        private void BtnSeat_Click(object sender, RoutedEventArgs e)
        {
            if (cbClass.SelectedIndex > -1)
            {
                clas = (EClass)cbClass.SelectedItem;
                if (clas.Equals(EClass.BUSINESS))
                {
                    txtPrice.Text = (flight.OneWayTicketPrice * (decimal)5.0).ToString();
                }

                PickSeatWindow ps = new PickSeatWindow(flight, clas);
                if (ps.ShowDialog() == true)
                {
                    SelectedSeat = ps.SelectedSeat;
                    txtSeat.Text = SelectedSeat.SeatLabel.ToString();
                }
                BtnSeat.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("You must select a class");
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private Boolean Validation()
        {
            Boolean ok = true;
            if(txtName.Text.Equals(String.Empty))
            {
                ok = false;
                MessageBox.Show("You must enter a value");
            }
            else if (txtSurname.Text.Equals(String.Empty))
            {
                ok = false;
                MessageBox.Show("You must enter a value");
            }
            else if (txtAddress.Text.Equals(String.Empty))
            {
                ok = false;
                MessageBox.Show("You must enter a value");
            }
            else if (txtEmail.Text.Equals(String.Empty))
            {
                ok = false;
                MessageBox.Show("You must enter a value");
            }
            else if (txtSeat.Text.Equals(String.Empty))
            {
                ok = false;
                MessageBox.Show("You must enter a value");
            }
            else if (CbGate.SelectedIndex < -1)
            {
                ok = false;
                MessageBox.Show("You must select a gate");
            }
            return ok;
        }
    }
}
