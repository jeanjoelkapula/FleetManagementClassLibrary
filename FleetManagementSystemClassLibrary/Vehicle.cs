using MySql.Data.MySqlClient;
using System;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
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



        public string Model_Name
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

        public CargoConfiguration Vehicle_Body_Type
        {
            get => default;
            set
            {
            }
        }

        public string Status { get; set; }

        public int Year { get; set; }

        public static void registerVehicle()
        {
            throw new System.NotImplementedException();
        }

        public static List<Vehicle> getAllVehicles()
        {
            throw new System.NotImplementedException();
        }

        public static List<Vehicle> GetVehiclesForServiceEntry()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Vehicle>("CALL GetVehiclesForServiceEntry();").ToList();
                return output;
            }
        }

        public static Vehicle getVehicle(int VehiclVehicle_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                Vehicle vehicle = connection.Query<Vehicle>("call GetVehicleDetails(@Vehicle_ID);", new { VehiclVehicle_ID }).SingleOrDefault();
                return vehicle;
            }
        }

        public static void UpdateVehicleStatus(int vehicleID, string inService)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                connection.Execute("CALL UpdateVehicleStatus(@vehicleID, @inService);", param: new { vehicleID, inService });
            }
        }

        public static void updateVehicle(int VehiclVehicle_ID)
        {
            throw new System.NotImplementedException();
        }

        private static string LoadConnectionString(string id = "fleetmanagementDB")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }  
}