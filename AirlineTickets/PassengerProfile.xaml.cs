using AirlineTickets.Database;
using AirlineTickets.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PassengerProfile.xaml
    /// </summary>
    public partial class PassengerProfile : Window
    {
        private User user;
        ICollectionView view;
        public ObservableCollection<User> us = new ObservableCollection<User>();

        public PassengerProfile(User user)
        {

            InitializeComponent();
            this.user = user;

            foreach (User u in Data.Instance.Users)
            {
                if (u.Username.Equals(user.Username))
                {
                    us.Add(u);

                }
            }

            view = CollectionViewSource.GetDefaultView(us);
            DGPassenger.ItemsSource = view;
            DGPassenger.IsReadOnly = true;
            DGPassenger.IsSynchronizedWithCurrentItem = true;
            DGPassenger.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);


        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = DGPassenger.SelectedItem as User;
            if (SelectedUser(selectedUser))
            {
                User oldUser = selectedUser.Clone() as User;
                PassengerProfileEdit pfw = new PassengerProfileEdit(selectedUser);
                if (pfw.ShowDialog() != true)
                {
                    int index = IndexOfSelectedUser(selectedUser.Username);
                    Data.Instance.Users[index] = oldUser;
                }
                else
                {
                    selectedUser.ChangeUsers();
                }
            }
        }

        private int IndexOfSelectedUser(String username)
        {
            var index = -1;
            for (int i = 0; i < Data.Instance.Users.Count; i++)
            {
                if (Data.Instance.Users[i].Username.Equals(username))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private bool SelectedUser(User user)
        {
            if (user == null)
            {
                MessageBox.Show("You haven't selected any user!");
                return false;
            }
            return true;
        }
    }
}
