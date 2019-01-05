using AirlineTickets.Database;
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            view = CollectionViewSource.GetDefaultView(Data.Instance.SeatsBusiness(airplane.RowNum, airplane.ColumnNum, airplane.Input));
            DGBSeats.ItemsSource = view;
            view = CollectionViewSource.GetDefaultView(Data.Instance.SeatsEconomy(airplane.RowNum, airplane.ColumnNum, airplane.Input));
            DGBSeats.IsReadOnly = true;
            DGESeats.ItemsSource = view;
            DGESeats.IsReadOnly = true;
            DGBSeats.IsSynchronizedWithCurrentItem = true;
            DGESeats.IsSynchronizedWithCurrentItem = true;
            DGBSeats.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            DGESeats.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);


       
            CbCompanyName.ItemsSource = Data.Instance.Aircompanies.Select(a => a);

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (option.Equals(Option.ADDING) && !airplaneExists(airplane.Pilot))
            {
     
                airplane.SaveAirplane();
                
            }
        }

        private void BtnDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private bool airplaneExists(string Pilot)
        {
            return Data.Instance.Airplanes.ToList().Find(a => a.Pilot.Equals(Pilot)) != null ? true : false;
        }

        private void DGESeats_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();
            if(headername == "AirplaneId")
            {
                e.Cancel = true;
            }
        }

        private void DGBSeats_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();
            if (headername == "AirplaneId")
            {
                e.Cancel = true;
            }
        }
    }
}
