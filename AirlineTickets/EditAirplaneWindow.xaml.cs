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
        public Seat seat { get; set; }


        public EditAirplaneWindow(Airplane airplane, Option option = Option.ADDING)
        {
            InitializeComponent();

            this.airplane = airplane;
            this.option = option;
            seat = new Seat("");

            this.DataContext = airplane;
            view = CollectionViewSource.GetDefaultView(airplane.BusinessClass);
            DGBSeats.ItemsSource = view;
            view = CollectionViewSource.GetDefaultView(airplane.EconomyClass);
            DGBSeats.IsReadOnly = true;
            DGESeats.ItemsSource = view;
            DGESeats.IsReadOnly = true;
            DGBSeats.IsSynchronizedWithCurrentItem = true;
            DGESeats.IsSynchronizedWithCurrentItem = true;
            DGBSeats.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            DGESeats.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);


            CBFlightNum.ItemsSource = Data.Instance.Flights.Select(f => f);

            CbCompanyName.ItemsSource = Data.Instance.Aircompanies.Select(a => a);

        }

       

        
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (option.Equals(Option.ADDING) && !airplaneExists(airplane.Pilot))
            {
                int row = int.Parse(txtRowNumber.Text);
                int column = int.Parse(txtColumnNumber.Text);

              //  airplane.RowNum = row;
               // airplane.ColumnNum = column;
                airplane.BusinessClass = Data.Instance.SeatsBusiness(row, column);
                airplane.EconomyClass = Data.Instance.SeatsEconomy(row, column);
                airplane.SaveAirplane();
                //Seat seat = (Seat)airplane.BusinessClass.Select(b => b.SeatLabel);
                //airplane.SaveAirplaneSeats(seat.SeatLabel, airplane.Id);
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

        private void BtnAddB_Click(object sender, RoutedEventArgs e)
        {
            AddAirplane a = new AddAirplane();
            if (a.ShowDialog() == true)
            {
                Data.Instance.SeatAvailable.Add(a.seat);
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
                    
                    Data.Instance.SeatAvailable[index].Active = true;
                    view.Refresh();
                }
                
            }
           
        }

        private void BtnAddE_Click(object sender, RoutedEventArgs e)
        {
            seat.SaveSeat();
        }

        private void BtnDeleteE_Click(object sender, RoutedEventArgs e)
        {
            Seat seat = DGESeats.SelectedItem as Seat;
            if (SelectedSeat(seat))
            {
                if (MessageBox.Show("Are you sure that you want to delete airport?", "Confirm", MessageBoxButton.YesNo).Equals(MessageBoxResult.Yes))
                {
                    int index = IndexOfSelectedSeat(seat.SeatLabel);
                    Data.Instance.SeatAvailable[index].Active = true;
                    view.Refresh();
                }
               
            }
           
        }
    }
}
