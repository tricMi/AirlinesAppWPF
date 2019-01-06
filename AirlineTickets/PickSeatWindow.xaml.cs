using AirlineTickets.Database;
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for PickSeatWindow.xaml
    /// </summary>
    public partial class PickSeatWindow : Window
    {
        ICollectionView view;
        public Seat SelectedSeat = null;
        Flight flight;
        public ObservableCollection<Airplane> seats = new ObservableCollection<Airplane>();

        public EClass Clas { get; set; }

        public PickSeatWindow(Flight flight, EClass Clas)
        {
            InitializeComponent();
            this.flight = flight;

            foreach (Airplane a in Data.Instance.Airplanes)
            {
                if (a.Id == flight.AirplaneId.Id)
                {
                    seats.Add(a);
                    foreach(Airplane asc in seats)
                    {
                        if (Clas.Equals(EClass.BUSINESS))
                        {
                            view = CollectionViewSource.GetDefaultView(asc.BusinessClass);
                            LbBSeats.ItemsSource = view;
                        }
                        else
                        {
                            view = CollectionViewSource.GetDefaultView(asc.EconomyClass);
                            LbBSeats.ItemsSource = view;
                        }
                    }
                }
                
            }


        }

        private void BtnPick_Click(object sender, RoutedEventArgs e)
        {
            SelectedSeat = LbBSeats.SelectedItem as Seat;
            if (SelectedSeat.SeatState == false)
            {
                MessageBox.Show("Seat is already taken!");
            }
            else
            {
                SelectedSeat.SeatState = false;
                SelectedSeat.ChangeSeat();
                this.DialogResult = true;
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
