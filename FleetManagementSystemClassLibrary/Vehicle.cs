using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using MySql.Data.MySqlClient;
namespace FleetManagementSystemClassLibrary
{
    public class Vehicle
    {
        public int Vehicle_ID
        {
            get; set;
        }

        public string Plate_Number
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

        public string Vehicle_Class
        {
            get; set;
        }

        public int Weight
        {
            get => default;
            set
            {
            }
        }

        public int Maximum_Payload
        {
            get => default;
            set
            {
            }
        }

        public Vehicle_Body_Type Vehicle_Body_Type
        {
            get => default;
            set
            {
            }
        }

        public static void registerVehicle()
        {
            throw new System.NotImplementedException();
        }

        public static List<Vehicle> getAllVehicles()
        {
            throw new System.NotImplementedException();
        }

        public static Vehicle getVehicle(int Vehicle_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Vehicle>("CALL GetVehicle(@Vehicle_ID);", new { Vehicle_ID }).FirstOrDefault();
                return output;
            }
        }

        public static void updateVehicle(int VehiclVehicle_ID)
        {

        }
    }
}