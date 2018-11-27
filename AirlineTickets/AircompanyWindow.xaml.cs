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
    /// Interaction logic for AircompanyWindow.xaml
    /// </summary>
    public partial class AircompanyWindow : Window
    {
        ICollectionView view;

        public AircompanyWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Data.Instance.Aircompanies);
            DGAircompany.ItemsSource = view;
            view.Filter = CustomFilter;
           
            DGAircompany.IsReadOnly = true;
            DGAircompany.IsSynchronizedWithCurrentItem = true;
            DGAircompany.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            
        }

        private bool CustomFilter(object obj)
        {
            Aircompany company = obj as Aircompany;
            return !company.Active;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Aircompany selectedCompany = (Aircompany)DGAircompany.SelectedItem;
            if (SelectedAircompany(selectedCompany))
            {
                if (MessageBox.Show("Are you sure that you want to delete aircompany?", "Confirm", MessageBoxButton.YesNo).Equals(MessageBoxResult.Yes))
                {
                    int index = IndexOfSelectedAircompany(selectedCompany.CompanyPassword);
                    Data.Instance.Aircompanies[index].Active = true;
                    view.Refresh();
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Aircompany selectedCompany = (Aircompany)DGAircompany.SelectedItem;
            if(SelectedAircompany(selectedCompany))
            {
                Aircompany oldAircompany = selectedCompany.Clone() as Aircompany;
                EditAircompanyWindow edw = new EditAircompanyWindow(selectedCompany, EditAircompanyWindow.Option.EDIT);
                if(edw.ShowDialog() != true)
                {
                    int index = IndexOfSelectedAircompany(selectedCompany.CompanyPassword);
                    Data.Instance.Aircompanies[index] = oldAircompany;
                }


            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            EditAircompanyWindow edw = new EditAircompanyWindow(new Aircompany(), EditAircompanyWindow.Option.ADDING);
            edw.ShowDialog();
        }

        private int IndexOfSelectedAircompany(String companyPassword)
        {
            var index = -1;
            for (int i = 0; i < Data.Instance.Aircompanies.Count; i++)
            {
                if (Data.Instance.Aircompanies[i].CompanyPassword.Equals(companyPassword))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private bool SelectedAircompany(Aircompany company)
        {
            if (company == null)
            {
                MessageBox.Show("You haven't selected any aircompany!");
                return false;
            }
            return true;
        }

        private void DGAircompany_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();

            if(headername == "FlightList")
            {
                e.Cancel = true;
            }
        }


    }
}
