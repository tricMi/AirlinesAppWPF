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
using static AirlineTickets.Models.Seat;

namespace AirlineTickets
{
    /// <summary>
    /// Interaction logic for EditSeatWindow.xaml
    /// </summary>
    public partial class EditSeatWindow : Window
    {
        public enum Option { ADD, EDIT}
        Seat seat;
        Option option;

        public EditSeatWindow(Seat seat, Option option = Option.ADD)
        {
            InitializeComponent();
            this.seat = seat;
            this.option = option;

            this.DataContext = seat;
            CbSeatCls.ItemsSource = Enum.GetValues(typeof(EClass));
            TxtSeatState.Text = true.ToString();
            TxtSeatState.IsEnabled = false;
            seat.SeatState = true;

            if (option.Equals(Option.EDIT))
            {
                TxtSeatLabel.IsEnabled = false;
            }




        }

        private void BtnDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (option.Equals(Option.ADD) && !seatExists(seat.SeatLabel))
            {
                Data.Instance.SeatAvailable.Add(seat);
            }
        }

        private bool seatExists(string seatLabel)
        {
            return Data.Instance.SeatAvailable.ToList().Find(a => a.SeatLabel.Equals(seatLabel)) != null ? true : false;
        }
    }
}
