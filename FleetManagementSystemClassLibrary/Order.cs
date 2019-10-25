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
        public Order(Customer Customer, Trip Trip)
        {
            this.Trip = Trip;
            this.Customer = Customer;
         //   this.Cargo_Package = Cargo_Package;

        }
        public Order()
        {

        }
        public int Order_ID
        {
            get; set;
        }

        public Trip Trip
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

        public static int AddOrder(int Customer_ID, int Trip_ID)
        {
          
          //  int packageid = Cargo_Package_ID;
           
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<int>("CALL AddOrder(@Customer_ID, @Trip_ID);", new { Customer_ID, Trip_ID }).FirstOrDefault();
                return output;
            }
        }

         public static List<Order> GetAllOrderInfo(int Trip_ID)
        {
          //  List<string> orderInfo = new List<string>();
          //  int count = 0;
       
            
                using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
                {
                    var output = connection.Query<Order, Vehicle, Vehicle_Type,Trip, User, CargoConfiguration, Customer, Order>("CALL GetAllOrderInfo(@Trip_ID);",
                        map: (o, v, vt,t, u,cc,c) =>
                        {
                            o.Trip = t;
                            o.Customer = c;
                            v.Vehicle_Body_Type = cc;
                            v.Vehicle_Type = vt;
                            t.Vehicle = v;
                            t.Driver = u;
                            return o;
                        },
                        splitOn: "Order_ID,Vehicle_ID, Vehicle_Class, Trip_ID, First_Name, Description, CustomerFirstName",
                        param: new {Trip_ID}
                   ).ToList();
                    return output;
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