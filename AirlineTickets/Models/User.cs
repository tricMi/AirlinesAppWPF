using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTickets.Models
{
    public class User : INotifyPropertyChanged, ICloneable
    {
        public const String CONNECTION_STRING = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=AirlineApp;Integrated Security=true";

        public int Id { get; set; }

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

        private String email;

        public String Email
        {
            get { return email; }
            set { email = value; }
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
                Id = this.Id,
                Name = this.Name,
                Surname = this.Surname,
                Password = this.Password,
                Username = this.Username,
                Email = this.Email,
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

        public void SaveUsers()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO Users(Name, Surname, Password, Username, Email, Gender, Address, UserType, Active)" +
                                        "VALUES(@Name, @Surname, @Password, @Username, @Email, @Gender, @Address, @UserType, @Active)";

                command.Parameters.Add(new SqlParameter("@Name", this.Name));
                command.Parameters.Add(new SqlParameter("@Surname", this.Surname));
                command.Parameters.Add(new SqlParameter("@Password", this.Password));
                command.Parameters.Add(new SqlParameter("@Username", this.Username));
                command.Parameters.Add(new SqlParameter("@Email", this.Email));
                command.Parameters.Add(new SqlParameter("@Gender", this.Gender));
                command.Parameters.Add(new SqlParameter("@Address", this.Address));
                command.Parameters.Add(new SqlParameter("@UserType", this.UserType));
                command.Parameters.Add(new SqlParameter("@Active", false));

                command.ExecuteNonQuery();
            }

            Database.Data.Instance.LoadUsers();
        }

        public void ChangeUsers()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"UPDATE Users SET Name = @Name, Surname = @Surname,Password = @Password,Username= @Username, Email = @Email, Gender= @Gender,Address= @Address,UserType= @UserType,Active= @Active WHERE @Id = Id";


                command.Parameters.Add(new SqlParameter("@Id", Id));
                command.Parameters.Add(new SqlParameter("@Name", this.Name));
                command.Parameters.Add(new SqlParameter("@Surname", this.Surname));
                command.Parameters.Add(new SqlParameter("@Password", this.Password));
                command.Parameters.Add(new SqlParameter("@Username", this.Username));
                command.Parameters.Add(new SqlParameter("@Email", this.Email));
                command.Parameters.Add(new SqlParameter("@Gender", this.Gender));
                command.Parameters.Add(new SqlParameter("@Address", this.Address));
                command.Parameters.Add(new SqlParameter("@UserType", this.UserType));
                command.Parameters.Add(new SqlParameter("@Active", this.active));

                command.ExecuteNonQuery();
            }

            Database.Data.Instance.LoadUsers();
        }
    }
}
