using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTickets.Models
{
    public class Airport : INotifyPropertyChanged, ICloneable

    {
        public const String CONNECTION_STRING = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=AirlineApp;Integrated Security=true";

        public int Id { get; set; }

        private String airportID;

        public String AirportID
        {
            get { return airportID; }
            set { airportID = value; OnPropertyChanged("AirportID"); }
        }

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private String city;

        public String City
        {
            get { return city; }
            set { city = value; OnPropertyChanged("City"); }
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
            
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public object Clone()
        {
            Airport newAirport = new Airport
            {
                Id = this.Id,
                AirportID = this.AirportID,
                Name = this.Name,
                City = this.City,
                Active = this.Active

            };

            return newAirport;
        }


        public override string ToString()
        {
            return $"{City}";
        }

        public void Save()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO AIRPORT( AirportID, Name, City, Active)" +
               " VALUES (@AirportID, @Name, @City, @Active)";

                command.Parameters.Add(new SqlParameter("@AirportID", this.AirportID));
                command.Parameters.Add(new SqlParameter("@Name", this.Name));
                command.Parameters.Add(new SqlParameter("@City", this.City));
                command.Parameters.Add(new SqlParameter("@Active", false));

                command.ExecuteNonQuery(); 

            }

            Database.Data.Instance.LoadAirport();
        }

        public void Change()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"UPDATE AIRPORT set AirportID = @AirportID, Name = @Name, City = @City, Active = @Active WHERE @Id = Id";

                command.Parameters.Add(new SqlParameter("@Id", this.Id));
                command.Parameters.Add(new SqlParameter("@AirportID", this.AirportID));
                command.Parameters.Add(new SqlParameter("@Name", this.Name));
                command.Parameters.Add(new SqlParameter("@City", this.City));
                command.Parameters.Add(new SqlParameter("@Active", this.Active));

                command.ExecuteNonQuery(); 

            }

            Database.Data.Instance.LoadAirport();
        }


    }
}
