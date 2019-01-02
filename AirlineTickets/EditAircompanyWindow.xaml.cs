using AirlineTickets.Database;
using AirlineTickets.Models;
using System;
using System.Collections;
using System.Collections.Generic;
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
    /// Interaction logic for EditAircompanyWindow.xaml
    /// </summary>
    public partial class EditAircompanyWindow : Window
    {
        public enum Option { ADDING, EDIT}
        Aircompany aircompany;
        Option option;
        
        

        public EditAircompanyWindow(Aircompany aircompany, Option option = Option.ADDING)
        {
            InitializeComponent();
            this.aircompany = aircompany;
            this.option = option;

            this.DataContext = aircompany;

         
            DgFlights.ItemsSource = Data.Instance.LoadAircompanyFlights(aircompany.CompanyPassword);

            DgFlights.IsReadOnly = true;

            if (option.Equals(Option.EDIT))
            {
                TxtCompanyPass.IsEnabled = false;
            }
        }

       


        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if(option.Equals(Option.ADDING) && !aircompanyExists(aircompany.Id))
            {
                aircompany.Save();
            }
        }

        private void BtnDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        

        private bool aircompanyExists(int companyId)
        {
            return Data.Instance.Aircompanies.ToList().Find(a => a.Id.Equals(companyId)) != null ? true : false;
        }

    }
}
