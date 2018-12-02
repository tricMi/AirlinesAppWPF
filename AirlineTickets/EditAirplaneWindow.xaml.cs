using AirlineTickets.Database;
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Interaction logic for EditAirplaneWindow.xaml
    /// </summary>
    public partial class EditAirplaneWindow : Window


    {
        public enum Option { ADDING, EDIT }
        Airplane airplane;
        Option option;
        ICollectionView view;


        public EditAirplaneWindow(Airplane airplane, Option option = Option.ADDING)
        {
            InitializeComponent();

            this.airplane = airplane;
            this.option = option;
           

            this.DataContext = airplane;

            view = CollectionViewSource.GetDefaultView(Data.Instance.SeatB);
            view.Filter = CustomFilter;
            DGBSeats.ItemsSource = view;
            view = CollectionViewSource.GetDefaultView(Data.Instance.SeatE);
            DGBSeats.IsReadOnly = true;
            DGESeats.ItemsSource = view;
            DGESeats.IsReadOnly = true;
            DGBSeats.IsSynchronizedWithCurrentItem = true;
            DGESeats.IsSynchronizedWithCurrentItem = true;
            DGBSeats.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            DGESeats.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);


            CBFlightNum.ItemsSource = Data.Instance.Flights.Select(f => f.FlightNumber);

          
            

        }

        private bool CustomFilter(object obj)
        {
            Seat seat = obj as Seat;
            return !seat.Active;
        }

        
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (option.Equals(Option.ADDING) && !airplaneExists(airplane.Pilot))
            {
                Data.Instance.Airplanes.Add(airplane);
            }
        }

        private bool airplaneExists(string Pilot)
        {
            return Data.Instance.Airplanes.ToList().Find(a => a.Pilot.Equals(Pilot)) != null ? true : false;
        }
    

        private void BtnDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private int IndexOfSelectedSeat(String seatLable)
        {
            var index = -1;
            for (int i = 0; i < Data.Instance.Seat.Count; i++)
            {
                if (Data.Instance.Seat[i].SeatLabel.Equals(seatLable))
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

        private void BtnAddB_Click(object sender, RoutedEventArgs e)
        {
            AddAirplane a = new AddAirplane();
            if (a.ShowDialog() == true)
            {
                Data.Instance.SeatB.Add(a.seat);
            }
        }

        private void BtnDeleteB_Click(object sender, RoutedEventArgs e)
        {
            Seat seat = DGBSeats.SelectedItem as Seat;
            if (SelectedSeat(seat))
            {
                if (MessageBox.Show("Are you sure that you want to delete airport?", "Confirm", MessageBoxButton.YesNo).Equals(MessageBoxResult.Yes))
                {
                    int index = IndexOfSelectedSeat(seat.SeatLabel);
                    Data.Instance.Seat[index].Active = true;
                    view.Refresh();
                }
                
            }
           
        }

        private void BtnAddE_Click(object sender, RoutedEventArgs e)
        {
            AddAirplane a = new AddAirplane();
            if(a.ShowDialog() == true)
            {
                Data.Instance.SeatE.Add(a.seat);
            }
            
        }

        private void BtnDeleteE_Click(object sender, RoutedEventArgs e)
        {
            Seat seat = DGESeats.SelectedItem as Seat;
            if (SelectedSeat(seat))
            {
                if (MessageBox.Show("Are you sure that you want to delete airport?", "Confirm", MessageBoxButton.YesNo).Equals(MessageBoxResult.Yes))
                {
                    int index = IndexOfSelectedSeat(seat.SeatLabel);
                    Data.Instance.Seat[index].Active = true;
                    view.Refresh();
                }
               
            }
           
        }
    }
}
