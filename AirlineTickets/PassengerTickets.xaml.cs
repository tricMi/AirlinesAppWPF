using AirlineTickets.Database;
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for PassengerTickets.xaml
    /// </summary>
    public partial class PassengerTickets : Window
    {
        ICollectionView view;
        private User user;
        private ObservableCollection<Tickets> tickets = new ObservableCollection<Tickets>();

        public PassengerTickets(User user)
        {
            InitializeComponent();
            this.user = user;

            foreach(Tickets t in Data.Instance.Tickets)
            {
                if(t.CurrentUser.Equals(user.Username))
                {
                    tickets.Add(t);
                }
            }

            view = CollectionViewSource.GetDefaultView(tickets);
            view.Filter = CustomFilter;
            DGPassengerTicket.ItemsSource = view;
            DGPassengerTicket.IsReadOnly = true;
            DGPassengerTicket.IsSynchronizedWithCurrentItem = true;
            DGPassengerTicket.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            view.Refresh();
        }

        private bool CustomFilter(object obj)
        {
            Tickets ticket = obj as Tickets;
            return !ticket.Active;
        }
    }
}
