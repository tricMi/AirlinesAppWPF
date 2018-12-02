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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        ICollectionView view; 

        public UserWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Data.Instance.Users);
            DGUser.ItemsSource = view;
            view.Filter = CustomFilter;
            DGUser.IsReadOnly = true;
            DGUser.IsSynchronizedWithCurrentItem = true;
            DGUser.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            
        }

        private bool CustomFilter(object obj)
        {
            User user = obj as User;
            return !user.Active;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = DGUser.SelectedItem as User;
            if(SelectedUser(selectedUser))
            {
                if(MessageBox.Show("Are you sure that you want to delete this user?", "Confirm", MessageBoxButton.YesNo).Equals(MessageBoxResult.Yes))
                {
                    int index = IndexOfSelectedUser(selectedUser.Username);
                    Data.Instance.Users[index].Active = true;
                    view.Refresh();
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = DGUser.SelectedItem as User;
            if (SelectedUser(selectedUser))
            {
                User oldUser = selectedUser.Clone() as User;
                UserEditWindow uew = new UserEditWindow(selectedUser, UserEditWindow.Option.EDIT);
                if(uew.ShowDialog() != true)
                    {
                        int index = IndexOfSelectedUser(selectedUser.Name);
                        Data.Instance.Users[index] = oldUser;
                    }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            UserEditWindow uew = new UserEditWindow(new User(), UserEditWindow.Option.ADDING);
            uew.ShowDialog();
        }

        private int IndexOfSelectedUser(String name)
        {
            var index = -1;
            for (int i = 0; i < Data.Instance.Users.Count; i++)
            {
                if (Data.Instance.Users[i].Name.Equals(name))
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
