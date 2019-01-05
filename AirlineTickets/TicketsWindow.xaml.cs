using AirlineTickets.Database;
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AirlineTickets
{
    /// <summary>
    /// Interaction logic for TicketsWindow.xaml
    /// </summary>
    public partial class TicketsWindow : Window
    {
        ICollectionView view;

        public TicketsWindow()
        {
            InitializeComponent();
           // view = CollectionViewSource.GetDefaultView(Data.Instance.Tickets);
            DGTickets.ItemsSource = view;
            view.Filter = CustomFilter;
            DGTickets.IsReadOnly = true;
            DGTickets.IsSynchronizedWithCurrentItem = true;
            DGTickets.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

        }

        private bool CustomFilter(object obj)
        {
            Tickets ticket = obj as Tickets;
            return !ticket.Active;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Tickets selectedTicket = DGTickets.SelectedItem as Tickets;
            //if (SelectedTicket(selectedTicket))
            //{
            //    if (MessageBox.Show("Are you sure that you want to delete this ticket?", "Confirm", MessageBoxButton.YesNo).Equals(MessageBoxResult.Yes))
            //    {
            //        int index = IndexOfSelectedTicket(selectedTicket.CurrentUser);
            //        Data.Instance.Tickets[index].Active = true;
            //        view.Refresh();
            //    }
            //}
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            //Tickets selectedTicket = DGTickets.SelectedItem as Tickets;
            //if (SelectedTicket(selectedTicket))
            //{
            //    Tickets oldTicket = selectedTicket.Clone() as Tickets;
            //    EditTicketsWindow esw = new EditTicketsWindow(selectedTicket, EditTicketsWindow.Option.EDIT);

            //    if (esw.ShowDialog() != true)
            //    {
            //        int index = IndexOfSelectedTicket(oldTicket.CurrentUser);
            //        Data.Instance.Tickets[index] = oldTicket;

            //    }
            //}
            //view.Refresh();

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            EditTicketsWindow edw = new EditTicketsWindow(new Tickets(), EditTicketsWindow.Option.ADD);
            edw.ShowDialog();
        }

        private int IndexOfSelectedTicket(String user)
        {
            var index = -1;
            for (int i = 0; i < Data.Instance.Tickets.Count; i++)
            {
                if (Data.Instance.Tickets[i].CurrentUser.Equals(user))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private bool SelectedTicket(Tickets user)
        {
            if (user == null)
            {
                MessageBox.Show("You haven't selected any ticket!");
                return false;
            }
            return true;
        }
    }
}
