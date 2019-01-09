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



    }
}
