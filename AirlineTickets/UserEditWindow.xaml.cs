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
            if (Validation() == true)
            {
                BtnSave.IsEnabled = true;
                if (!System.Windows.Controls.Validation.GetHasError(txtName))
                {
                    this.DialogResult = true;
                    if (option.Equals(Option.ADDING) && !userExists(user.Username))
                    {
                        user.SaveUsers();
                    }
                    else
                    {
                        MessageBox.Show("User with this username already exists, please pick another one");
                    }
                }
            }
        }

        private void BtnDiscard_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private bool userExists(string username)
        {
            return Data.Instance.Users.ToList().Find(a => a.Username.Equals(username)) != null ? true : false;
        }

        private Boolean Validation()
        {
            Boolean ok = true;
            if (txtName.Text.Equals(String.Empty))
            {
                ok = false;
                BtnSave.IsEnabled = false;
            }
            else if (txtSurname.Text.Equals(String.Empty))
            {
                ok = false;
                BtnSave.IsEnabled = false;
            }
            else if (txtUsername.Text.Equals(String.Empty))
            {
                ok = false;
                BtnSave.IsEnabled = false;
            }
            else if (txtEmail.Text.Equals(String.Empty))
            {
                ok = false;
                BtnSave.IsEnabled = false;
            }
            else if (txtPassword.Text.Equals(String.Empty))
            {
                ok = false;
                BtnSave.IsEnabled = false;
            }
            else if (txtAddress.Text.Equals(String.Empty))
            {
                ok = false;
                BtnSave.IsEnabled = false;
            }
            return ok;
        }
    }
}
