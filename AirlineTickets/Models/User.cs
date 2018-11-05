using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTickets.Models
{
    class User
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Password { get; set; }
        public String Username { get; set; }
        public EGender Gender { get; set; }
        public String Address { get; set; }
        public EUserType UserType { get; set; }

        public Boolean Active { get; set; }

        public User()
        {

        }

        public User(String Name, String Surname, String Password, String Username, EGender Gender, String Address, EUserType UserType)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Password = Password;
            this.Username = Username;
            this.Gender = Gender;
            this.Address = Address;
            this.UserType = UserType;
        }
        public override string ToString()
        {
            return $"Name: {Name} Surname: {Surname} Username: {Username} User type: {UserType} Gender: {Gender} \n";
        }
    }
}
