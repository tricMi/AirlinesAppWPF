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
    /// Interaction logic for AirplaneWindow.xaml
    /// </summary>
    public partial class AirplaneWindow : Window
    {
        ICollectionView view;

        public AirplaneWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Data.Instance.Airplanes);
            DGAirplane.ItemsSource = view;
            view.Filter = CustomFilter;

            DGAirplane.IsReadOnly = true;
            DGAirplane.IsSynchronizedWithCurrentItem = true;
            DGAirplane.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private bool CustomFilter(object obj)
        {
            Airplane plane = obj as Airplane;
            if (TxtSearch.Text.Equals(string.Empty))
            {
                return !plane.Active;
            }
            else
            {
                return !plane.Active && plane.AircompanyName.CompanyName.Contains(TxtSearch.Text)
                    || (!plane.Active && plane.Pilot.Contains(TxtSearch.Text));
            }

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Airplane selectedPlane = (Airplane)DGAirplane.SelectedItem;
            if (SelectedAirplane(selectedPlane))
            {
                Airplane oldAirplane = selectedPlane.Clone() as Airplane;
                EditAirplaneWindow eda = new EditAirplaneWindow(selectedPlane, EditAirplaneWindow.Option.EDIT);
                if (eda.ShowDialog() != true)
                {
                    int index = IndexOfSelectedAirplane(selectedPlane.Pilot);
                    selectedPlane.Active = true;
                    selectedPlane.ChangeAirplane();
                    Data.Instance.Airplanes[index] = oldAirplane;
                    view.Refresh();
                }


            }
            view.Refresh();
        }

        

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Airplane selectedPlane = (Airplane)DGAirplane.SelectedItem;
            if (SelectedAirplane(selectedPlane))
            {
                if (MessageBox.Show("Are you sure that you want to delete airplane?", "Confirm", MessageBoxButton.YesNo).Equals(MessageBoxResult.Yes))
                {
                    foreach(var seat in Data.Instance.SeatAvailable.ToList())
                    {
                        if(seat.AirplaneId.Equals(selectedPlane.Pilot))
                        {
                            seat.Active = true;
                            seat.ChangeSeat();
                            view.Refresh();
                        }
                    }
                    int index = IndexOfSelectedAirplane(selectedPlane.Pilot);
                    Data.Instance.Airplanes[index].Active = true;
                    view.Refresh();
                }
                else
                {
                    selectedPlane.ChangeAirplane();
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            EditAirplaneWindow eda = new EditAirplaneWindow(new Airplane(), EditAirplaneWindow.Option.ADDING);
            eda.ShowDialog();
        }

        private int IndexOfSelectedAirplane(String pilot)
        {
            var index = -1;
            for (int i = 0; i < Data.Instance.Airplanes.Count; i++)
            {
                if (Data.Instance.Airplanes[i].Pilot.Equals(pilot))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private bool SelectedAirplane(Airplane plane)
        {
            if (plane == null)
            {
                MessageBox.Show("You haven't selected any airplane!");
                return false;
            }
            return true;
        }

        private void DGAirplane_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();

            if (headername == "BusinessClass")
            {
                e.Cancel = true;
            }

            if (headername == "EconomyClass")
            {
                e.Cancel = true;
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }
    }
}
