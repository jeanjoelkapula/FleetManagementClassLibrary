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

        public static void registerVehicle()
        {
            throw new System.NotImplementedException();
        }

        public static List<Vehicle> getAllVehicles()
        {
            throw new System.NotImplementedException();
        }

        public static Vehicle getVehicle()
        {
            throw new System.NotImplementedException();
        }
    }
}