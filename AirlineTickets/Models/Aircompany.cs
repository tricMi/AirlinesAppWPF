using AirlineTickets.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTickets.Models
{
    public class Aircompany : INotifyPropertyChanged, ICloneable
    {
        public const String CONNECTION_STRING = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=AirlineApp;Integrated Security=true";
        public int Id { get; set; }

        private string companyName;

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; OnPropertyChanged("CompanyName"); }
        }


        private string companyPassword;

        public string CompanyPassword
        {
            get { return companyPassword; }
            set { companyPassword = value; OnPropertyChanged("CompanyPassword"); }
        }

        private ObservableCollection<Flight> flightList;

        public ObservableCollection<Flight> FlightList
        {
            get { return flightList; }
            set { flightList = value; OnPropertyChanged("FlightList"); }
        }



        private bool active;

        public bool Active
        {
            get { return active; }
            set { active = value; OnPropertyChanged("Active"); }
        }

        public Aircompany()
        {
            FlightList = new ObservableCollection<Flight>();
        }

        public Aircompany(String companyPassword)
        {
            this.CompanyPassword = CompanyPassword;
            FlightList = new ObservableCollection<Flight>();
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
            Aircompany newAircompany = new Aircompany
            {
                Id = this.Id,
                CompanyName = this.companyName,
                CompanyPassword = this.CompanyPassword,
                FlightList = this.FlightList,
                Active = this.Active
            };

            return newAircompany;
        }

      

        public override string ToString()
        {
            return $"{CompanyPassword} {CompanyName}";
        }

        public void Save()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO Aircompany(CompanyName, CompanyPassword, Active)" +
               " VALUES (@CompanyName, @CompanyPassword, @Active)";



                command.Parameters.Add(new SqlParameter("@CompanyName", this.CompanyName));
                command.Parameters.Add(new SqlParameter("@CompanyPassword", this.CompanyPassword));
                command.Parameters.Add(new SqlParameter("@Active", false));

                command.ExecuteNonQuery();

            }

            Database.Data.Instance.LoadAircompany();
        }

        public void Change()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"UPDATE Aircompany set CompanyName = @CompanyName, CompanyPassword = @CompanyPassword, Active = @Active WHERE @Id = Id";


                command.Parameters.Add(new SqlParameter("@Id", this.Id));
                command.Parameters.Add(new SqlParameter("@CompanyName", this.CompanyName));
                command.Parameters.Add(new SqlParameter("@CompanyPassword", this.CompanyPassword));
                command.Parameters.Add(new SqlParameter("@Active", this.Active));

                command.ExecuteNonQuery();

            }

            Database.Data.Instance.LoadAircompany();
        }
    }
}
