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
    }
}