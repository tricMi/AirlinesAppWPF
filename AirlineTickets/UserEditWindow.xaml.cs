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

namespace AirlineTickets
{
    /// <summary>
    /// Interaction logic for UserEditWindow.xaml
    /// </summary>
    public partial class UserEditWindow : Window
    {
        public enum Option { ADDING, EDIT }
        User user;
        Option option;

        public UserEditWindow(User user, Option option = Option.ADDING)
        {
            InitializeComponent();
            this.user = user;
            this.option = option;

            CbGender.ItemsSource = Enum.GetValues(typeof(EGender));
            CbUserType.ItemsSource = Enum.GetValues(typeof(EUserType));

            this.DataContext = user;

            if(option.Equals(Option.EDIT))
            {
                txtUsername.IsEnabled = false;
            }
            
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if(option.Equals(Option.ADDING) && !userExists(user.Name))
            {
                user.SaveUsers();
            }

        }

        private void BtnDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private bool userExists(string name)
        {
            return Data.Instance.Users.ToList().Find(a => a.Name.Equals(name)) != null ? true : false;
        }
    }
}
