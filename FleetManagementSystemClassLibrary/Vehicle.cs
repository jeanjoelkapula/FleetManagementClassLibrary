using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FleetManagementSystemClassLibrary
{
    public class Vehicle
    {
        public int Vehicle_ID
        {
            get; set;
        }

        public string Registration_Number
        {
            get; set;
        }

        public string Manufacturer
        {
            get; set;
        }

        public decimal Engine_Size
        {
            get; set;
        }

        public int Current_Odometer
        {
            get; set;
        }

        public int Next_Service_Odometer
        {
            get; set;
        }

        public Vehicle_Type Vehicle_Type
        {
            get; set;
        }
    }
}