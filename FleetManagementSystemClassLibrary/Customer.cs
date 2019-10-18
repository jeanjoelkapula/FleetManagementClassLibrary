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
        public Customer(string Customer_First_Name, string Customer_Last_Name, string ContactNumber, string Email)
        {
            this.Customer_First_Name = Customer_First_Name;
            this.Customer_Last_Name = Customer_Last_Name;
            this.ContactNumber = ContactNumber;
            this.Email = Email;
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

        public static void AddCustomer(string Customer_First_Name, string Customer_Last_Name, string Customer_Email, string Customer_Contact_Number)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Execute("CALL AddCustomer(@CustomerFirstName, @CustomerLastName, @CustomerContactEmail, @CustomerEmail);", new {Customer_First_Name, Customer_Last_Name, Customer_Email,Customer_Contact_Number });
            }
        }

        public void editCustomer()
        {
            throw new System.NotImplementedException();
        }
    }
}