using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Dapper;
namespace FleetManagementSystemClassLibrary
{
    public class Customer
    {
        public int Customer_ID
        {
            get; set;
        }
        public Customer(int Customer_ID,string CustomerFirstName, string CustomerLastName, string CustomerContactNumber, string CustomerEmail)
        {
            this.Customer_ID = Customer_ID;
            this.Customer_First_Name = CustomerFirstName;
            this.Customer_Last_Name = CustomerLastName;
            this.ContactNumber = CustomerContactNumber;
            this.Email = CustomerEmail;
        }
        public string Customer_First_Name
        {
            get; set;
        }
        public string Customer_Last_Name
        {
            get; set;
        }
        public string Email
        {
            get; set;
        }
        public string ContactNumber
        {
            get; set;
        }
        
        public static Customer GetCustomer(int Customer_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Customer>("CALL GetCustomer(@Customer_ID);", new {Customer_ID}).FirstOrDefault();
                return output;
            }
        }
        
        public static int GetCustomerID()
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = Convert.ToInt32(connection.Query<int>("CALL GetCustomerID();", new DynamicParameters()).First());
                return output;
            }
        }


        public static void AddCustomer(string CustomerFirstName, string CustomerLastName, string CustomerContactNumber, string CustomerEmail)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Execute("CALL AddCustomer(@CustomerFirstName, @CustomerLastName, @CustomerContactNumber, @CustomerEmail);", new {CustomerFirstName,  CustomerLastName, CustomerContactNumber, CustomerEmail });
            }
        }
        public static List<Customer> GetCustomers()
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Customer>("CALL GetCustomers();", new DynamicParameters()).ToList();
                return output;
            }
        }
        public void editCustomer()
        {
            throw new System.NotImplementedException();
        }
    }
}