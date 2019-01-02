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
    /// Interaction logic for PickSeatWindow.xaml
    /// </summary>
    public partial class PickSeatWindow : Window
    {
        ICollectionView view;
        public Seat SelectedSeat = null;
        public PickSeatWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Data.Instance.SeatAvailable);
            DgSeat.ItemsSource = view;
            DgSeat.IsReadOnly = true;
            DgSeat.IsSynchronizedWithCurrentItem = true;
            DgSeat.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
          //  view.Filter = CustomFilter;
        }

        private void BtnPick_Click(object sender, RoutedEventArgs e)
        {
            SelectedSeat = DgSeat.SelectedItem as Seat;
            if (SelectedSeat.SeatState == false)
            {
                MessageBox.Show("Seat is already taken!");
            }
            else
            {
                SelectedSeat.SeatState = false;
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
