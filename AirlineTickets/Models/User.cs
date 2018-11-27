using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTickets.Models
{
    public class User : INotifyPropertyChanged, ICloneable
    {
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private String surname;

        public String Surname
        {
            get { return surname; }
            set { surname = value; OnPropertyChanged("Surname"); }
        }

        private String password;

        public String Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }

        private String username;

        public String Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged("Username"); }
        }

        private EGender gender;

        public EGender Gender
        {
            get { return gender; }
            set { gender = value; OnPropertyChanged("Gender"); }
        }

        private String address;

        public String Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged("Address"); }
        }

        private EUserType userType;

        public EUserType UserType
        {
            get { return userType; }
            set { userType = value; OnPropertyChanged("UserType"); }
        }

        private bool active;

        public bool Active
        {
            get { return active; }
            set { active = value; OnPropertyChanged("Active"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String name)
        {
            
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public object Clone()
        {
            User newUser = new User
            {
                Name = this.Name,
                Surname = this.Surname,
                Password = this.Password,
                Username = this.Username,
                Gender = this.Gender,
                Address = this.Address,
                UserType = this.UserType,
                Active = this.Active
            };

            return newUser;
        }


        public override string ToString()
        {
            return $"Name: {Name} Surname: {Surname} Username: {Username} User type: {UserType} Gender: {Gender} \n";
        }
    }
}
