﻿using AirlineTickets.Database;
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

namespace AirlineTickets
{
    /// <summary>
    /// Interaction logic for EditFlightsWindow.xaml
    /// </summary>
    public partial class EditFlightsWindow : Window
    {
        public enum Option {ADDING, EDIT}
        Flight flight;
        Option option;

        public EditFlightsWindow(Flight flight, Option option= Option.ADDING)
        {
            InitializeComponent();
            this.flight = flight;
            this.option = option;

            this.DataContext = flight;

            CbDepPlace.ItemsSource = Data.Instance.Airports.Select(a => a.AirportID);
            CbDestination.ItemsSource = Data.Instance.Airports.Select(a => a.AirportID);

            if(option.Equals(Option.EDIT))
            {
                tbFlightNum.IsEnabled = false;
            }

        }

        private void BtnDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (option.Equals(Option.ADDING) && !flightExists(flight.FlightNumber))
            {
                Data.Instance.Flights.Add(flight);
                this.Close();
            }
        }

        private bool flightExists(string flightNumber)
        {
            return Data.Instance.Flights.ToList().Find(a => a.FlightNumber.Equals(flightNumber)) != null ? true : false;
        }
    }
}