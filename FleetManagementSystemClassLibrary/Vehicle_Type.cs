using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FleetManagementSystemClassLibrary
{
    public class Vehicle_Type
    {
        public int Vehicle_Type_ID
        {
            get; set;
        }

        public string Vehicle_Class
        {
            get; set;
        }

        public int Maximum_Load
        {
            get; set;
        }

        public decimal Fuel_Efficiency
        {
            get; set;
        }

        public Decimal Weight
        {
            get; set;
        }
    }
}