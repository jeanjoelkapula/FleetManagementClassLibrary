using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FleetManagementSystemClassLibrary
{
    public class Order
    {
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

        public List<Cargo> Cargo
        {
            get; set;
        }

        public static Order getOrder()
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