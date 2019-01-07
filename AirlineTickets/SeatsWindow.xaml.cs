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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AirlineTickets
{
    /// <summary>
    /// Interaction logic for SeatsWindow.xaml
    /// </summary>
    public partial class SeatsWindow : Window
    {
        ICollectionView view;

        public SeatsWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Data.Instance.SeatAvailable);
            LbBSeats.ItemsSource = view;
           
        }

        private bool CustomFilter(object obj)
        {
            Seat seat = obj as Seat;
            return !seat.Active;
        }

        

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Seat seat = LbBSeats.SelectedItem as Seat;
            if (SelectedSeat(seat))
            {
                Seat oldSeat = seat.Clone() as Seat;
                EditSeatWindow esw = new EditSeatWindow(seat, EditSeatWindow.Option.EDIT);

                if (esw.ShowDialog() != true)
                {
                    int index = IndexOfSelectedSeat(oldSeat.SeatLabel);
                    Data.Instance.SeatAvailable[index] = oldSeat;

                }
                else
                {
                    seat.ChangeSeat();
                }
            }
           
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
