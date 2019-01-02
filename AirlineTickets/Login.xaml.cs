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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        

        public Login()
        {
            InitializeComponent();
            
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            String us = txtUsername.Text.Trim();
            String pass = pswPassword.Password.Trim();

            if(us.Equals("") || pass.Equals(""))
            {
                MessageBox.Show("You haven't entered all data");
            }
            else
            {
                User u = Data.Instance.LoginUser(us, pass);
                if (u.UserType == EUserType.ADMIN)
                {
                    AdminWindow aw = new AdminWindow();
                    aw.ShowDialog();
                    this.Close();
                    
                }
                else if(u.UserType == EUserType.PASSENGER)
                {
                    PassengerWindow pw = new PassengerWindow();
                    pw.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There is not user with that username or password");
                }
            }
            
        }

        
    }
}
