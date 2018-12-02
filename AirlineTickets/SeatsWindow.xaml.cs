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
            view = CollectionViewSource.GetDefaultView(Data.Instance.Seats);
            DGSeats.ItemsSource = view;
            DGSeats.IsReadOnly = true;
            DGSeats.IsSynchronizedWithCurrentItem = true;
            DGSeats.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            view.Filter = CustomFilter;
        }

        private bool CustomFilter(object obj)
        {
            Seats seats = obj as Seats;
            return !seats.Active;
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            Seats seat = DGSeats.SelectedItem as Seats;
            EditSeatsWindow ew = new EditSeatsWindow(seat);
            ew.ShowDialog();
        }

        private void DGSeats_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();

            if (headername == "AllSeats")
            {
                e.Cancel = true;
            }
        }
    }
}
