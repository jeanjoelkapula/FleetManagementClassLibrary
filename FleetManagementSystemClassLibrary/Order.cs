using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Dapper;
namespace FleetManagementSystemClassLibrary
{
    public class Order
    {
        public Order(Customer Customer, Cargo_Package Cargo_Package)
        {
            this.Customer = Customer;
            this.Cargo_Package = Cargo_Package;

        }
        public int Order_ID
        {
            get; set;
        }

        public DateTime Order_Date
        {
            get; set;
        }

        public Customer Customer
        {
            get; set;
        }

        public Cargo_Package Cargo_Package
        {
            get; set;
        }

        public static void AddOrder(Customer Customer, Cargo_Package Cargo_Package)
        {
            int customerid = Customer.Customer_ID;
            int packageid = Cargo_Package.Cargo_Package_ID;

            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Execute("CALL AddOrder);", new { customerid, packageid });
            }
        }

        public static Order getOrder(int Order_ID)
        {
            throw new System.NotImplementedException();
        }

        public static List<Order> getAllOrders()
        {
            throw new System.NotImplementedException();
        }

        public static void postOrder()
        {
            throw new System.NotImplementedException();
        }
    }
}