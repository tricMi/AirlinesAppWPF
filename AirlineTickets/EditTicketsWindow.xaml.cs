using AirlineTickets.Database;
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for EditTicketsWindow.xaml
    /// </summary>
    public partial class EditTicketsWindow : Window
    {
        public enum Option { ADD, EDIT }
        Tickets ticket;
        Option option;
        Flight flight;
        public EClass clas;
        public ObservableCollection<Flight> fl = new ObservableCollection<Flight>();
        public ObservableCollection<User> us = new ObservableCollection<User>();
        public List<string> gate = new List<string>();

        public EditTicketsWindow(Tickets ticket, Option option = Option.ADD)
        {
            InitializeComponent();
            this.ticket = ticket;
            this.option = option;

            this.DataContext = ticket;
            this.TxtSeat.DataContext = ticket;

            foreach(Flight f in Data.Instance.Flights)
            {
                if(f.Active.Equals(false))
                {
                    fl.Add(f);
                }
            }

            foreach (User u in Data.Instance.Users)
            {
                if (u.Active.Equals(false))
                {
                    us.Add(u);
                }
            }
            CbFlNum.ItemsSource = fl;
            CbUser.ItemsSource = us.Select(u => u.Username);
            CbSeatClass.ItemsSource = Enum.GetValues(typeof(EClass));

            //TxtPrice.Text = flight.OneWayTicketPrice.ToString();

            gate.Add("A4");
            gate.Add("B4");
            gate.Add("D5");

            CbGate.ItemsSource = gate;

        }

        private void BtnPickSeat_Click(object sender, RoutedEventArgs e)
        {
            if(Validation() == true)
            {
                BtnPickSeat.IsEnabled = true;
                flight = CbFlNum.SelectedItem as Flight;
                clas = (EClass)CbSeatClass.SelectedItem;

                PickSeatWindow s = new PickSeatWindow(flight, clas);
                if (s.ShowDialog() == true)
                {
                    ticket.SeatNum = s.SelectedSeat;
                }
            }
            BtnPickSeat.IsEnabled = false;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationSave() == true)
            {
                Flight fly = CbFlNum.SelectedItem as Flight;
                User use = CbUser.SelectedItem as User;
                BtnSave.IsEnabled = true;
                this.DialogResult = true;
                if (option.Equals(Option.ADD))
                {
                    ticket.CurrentUser = CbUser.SelectedItem.ToString();
                    ticket.FlightNum = fly;
                    ticket.Gate = CbGate.SelectedItem.ToString();
                    ticket.SeatClass = (EClass)CbSeatClass.SelectedItem;
                    if(CbSeatClass.SelectedItem.Equals(EClass.BUSINESS))
                    {
                        ticket.TicketPrice = fly.OneWayTicketPrice * (decimal)5.0;
                    }
                    ticket.TicketPrice = fly.OneWayTicketPrice;
                    
                    ticket.SaveTicket();
                }
            }
        }

        private void BtnDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        


        //private bool TicketExists(string user)
        //{
        //    return Data.Instance.Tickets.ToList().Find(a => a.CurrentUser.Equals(user)) != null ? true : false;
        //}

        private Boolean ValidationSave()
        {
            Boolean ok = true;

            if(CbGate.SelectedIndex <= -1)
            {
                ok = false;
                BtnSave.IsEnabled = false;
            }
            else if(CbUser.SelectedIndex <= -1)
            {
                ok = false;
                BtnSave.IsEnabled = false;
            }
            return ok;
        }

        private Boolean Validation()
        {
            Boolean ok = true;
            if (CbFlNum.SelectedIndex <= -1)
            {
                ok = false;
                BtnPickSeat.IsEnabled = false;
            }
            else if (CbSeatClass.SelectedIndex <= -1)
            {
                ok = false;
                BtnPickSeat.IsEnabled = false;
            }
            return ok;
        }
    }
}
