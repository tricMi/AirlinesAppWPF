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
    /// Interaction logic for PassengerProfileEdit.xaml
    /// </summary>
    public partial class PassengerProfileEdit : Window
    {
        User user;

        public PassengerProfileEdit(User user)
        {
            InitializeComponent();
            this.user = user;

            CbGender.ItemsSource = Enum.GetValues(typeof(EGender));
            CbUserType.ItemsSource = Enum.GetValues(typeof(EUserType));

            this.DataContext = user;


        }

        private void BtnDiscard_Click(object sender, RoutedEventArgs e)
        {
            if (!System.Windows.Controls.Validation.GetHasError(txtName))
            {
                this.DialogResult = true;
                if (!userExists(user.Name))
                {
                    user.SaveUsers();
                }
                else
                {
                    MessageBox.Show("User with this username already exists, please pick another one");
                }
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool userExists(string username)
        {
            return Data.Instance.Users.ToList().Find(a => a.Username.Equals(username)) != null ? true : false;
        }
    }
}
