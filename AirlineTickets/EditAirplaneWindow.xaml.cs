using AirlineTickets.Database;
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Aircompany> NameA = new ObservableCollection<Aircompany>();


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

            foreach (Aircompany a in Data.Instance.Aircompanies)
            {
                if (a.Active.Equals(false))
                {
                    NameA.Add(a);
                }
            }

            CbCompanyName.ItemsSource = NameA.Select(a => a);

            if(option.Equals(Option.EDIT))
            {
                TxtPilot.IsEnabled = false;
            }

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Validation() == true)

            {
                if (!System.Windows.Controls.Validation.GetHasError(TxtPilot))
                {

                    this.DialogResult = true;
                    if (option.Equals(Option.ADDING) && !airplaneExists(airplane.Pilot))
                    {

                        airplane.SaveAirplane();
                       
                    }
                }
                else
                {
                    MessageBox.Show("Pilot with that name already exists, please choose another pilot");
                }

                if (option.Equals(Option.ADDING))
                {
                    foreach (Seat s in Data.Instance.SeatsBusiness(airplane.RowNum, airplane.ColumnNum, airplane.Input).ToList())
                    {
                        s.AirplaneId = airplane.Pilot;
                        s.SaveSeat();

                    }

                    foreach (Seat ss in Data.Instance.SeatsEconomy(airplane.RowNum, airplane.ColumnNum, airplane.Input).ToList())
                    {
                        ss.AirplaneId = airplane.Pilot;
                        ss.SaveSeat();

                    }
                }

            }
        }

        private void BtnDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private Boolean Validation()
        {
            Boolean ok = true;
            
            if(Convert.ToInt32(txtInput.Text.Trim()) > 50)
            {
                ok = false;
                MessageBox.Show("Value for input can't be greater than 50");
            }
            else if(Convert.ToInt32(txtColumnNumber.Text.Trim()) == 0)
            {
                ok = false;
                MessageBox.Show("Wrong Column Format");
            }
            else if (Convert.ToInt32(txtRowNumber.Text.Trim()) == 0)
            {
                ok = false;
                MessageBox.Show("Wrong Row Format");
            }

            else if (Convert.ToInt32(txtColumnNumber.Text.Trim()) > Convert.ToInt32(txtRowNumber.Text.Trim()))
            {
                ok = false;
                MessageBox.Show("Value for column can't be greater than value for row");
            }
            else if(TxtPilot.Text.Equals(String.Empty))
            {
                ok = false;
                MessageBox.Show("Field can't be empty ");
            }

            return ok;
        }
    }
}
