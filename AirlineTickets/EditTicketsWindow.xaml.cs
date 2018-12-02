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
    /// Interaction logic for EditTicketsWindow.xaml
    /// </summary>
    public partial class EditTicketsWindow : Window
    {
        public enum Option { ADD, EDIT }
        Tickets ticket;
        Option option;

        public EditTicketsWindow(Tickets ticket, Option option = Option.ADD)
        {
            InitializeComponent();
            this.ticket = ticket;
            this.option = option;

            this.DataContext = ticket;
            this.TxtSeat.DataContext = ticket;

            CbFlNum.ItemsSource = Data.Instance.Flights.Select(x => x.FlightNumber);
            CbUser.ItemsSource = Data.Instance.Users.Select(u => u.Username);
        }

        private void BtnPickSeat_Click(object sender, RoutedEventArgs e)
        {
            PickSeatWindow s = new PickSeatWindow();
            if (s.ShowDialog() == true)
            {
                ticket.SeatNum = s.SelectedSeat;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (option.Equals(Option.ADD) && !TicketExists(ticket.CurrentUser))
            {
                Data.Instance.Tickets.Add(ticket);
            }
        }

        private void BtnDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        


        private bool TicketExists(string user)
        {
            return Data.Instance.Tickets.ToList().Find(a => a.CurrentUser.Equals(user)) != null ? true : false;
        }
    }
}
