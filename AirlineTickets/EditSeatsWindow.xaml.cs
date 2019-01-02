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
    /// Interaction logic for EditSeatsWindow.xaml
    /// </summary>
    public partial class EditSeatsWindow : Window
    {

        ICollectionView view;
       
        Seats seats;
       

        public EditSeatsWindow(Seats seats)
        {
            InitializeComponent();
            this.seats = seats;
           

            this.DataContext = seats;
            view = CollectionViewSource.GetDefaultView(seats.AllSeats);
            DGSeat.ItemsSource = view;
            DGSeat.IsReadOnly = true;
            DGSeat.IsSynchronizedWithCurrentItem = true;
            DGSeat.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            view.Filter = CustomFilter;

        }

        private bool CustomFilter(object obj)
        {
            Seat seat = obj as Seat;
            return !seat.Active;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Seat seat = DGSeat.SelectedItem as Seat;
            if (SelectedSeat(seat))
            {
                if (MessageBox.Show("Are you sure that you want to delete airport?", "Confirm", MessageBoxButton.YesNo).Equals(MessageBoxResult.Yes))
                {
                    int index = IndexOfSelectedSeat(seat.SeatLabel);
                 //   Data.Instance.Seat[index].Active = true;
                    view.Refresh();
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Seat seat = DGSeat.SelectedItem as Seat;
            if (SelectedSeat(seat))
            {
                Seat oldSeat = seat.Clone() as Seat;
                EditSeatWindow esw = new EditSeatWindow(seat, EditSeatWindow.Option.EDIT);
              
                if (esw.ShowDialog() != true)
                {
                    int index = IndexOfSelectedSeat(oldSeat.SeatLabel);
                  //  Data.Instance.Seat[index] = oldSeat;
                    
                }
            }
            view.Refresh();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            EditSeatWindow esw = new EditSeatWindow(new Seat(), EditSeatWindow.Option.ADD);
            esw.ShowDialog();
        }

        private int IndexOfSelectedSeat(String seatLable)
        {
            var index = -1;
            for (int i = 0; i < Data.Instance.SeatAvailable.Count; i++)
            {
                if (Data.Instance.SeatAvailable[i].SeatLabel.Equals(seatLable))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private bool SelectedSeat(Seat seat)
        {
            if (seat == null)
            {
                MessageBox.Show("You haven't selected any seat!");
                return false;
            }
            return true;
        }


      
    }
}
