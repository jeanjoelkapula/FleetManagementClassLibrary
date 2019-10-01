using Dapper;
using MySql.Data.MySqlClient;
using System;
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

        public string Plate_Number
        {
            get; set;
        }

        public string Manufacturer
        {
            get; set;
        }

        /*
        public decimal Engine_Size
        {
            get; set;
        }
        */

        public int Current_Odometer
        {
            get; set;
        }

        public int Next_Service_Odometer
        {
            get; set;
        }

        /*
        public Vehicle_Type Vehicle_Type
        {
            get; set;
        }
        */

        public int Year { get; set; }
        
        public string Status { get; set; }


        /*
        public int Maximum_Payload
        {
            get => default;
            set
            {
            }
        }
        */

        /*
        public Vehicle_Body_Type Vehicle_Body_Type
        {
            get => default;
            set
            {
            }
        }
        */

        public string Vehicle_Class { get; set; }

        public int Maximum_Load { get; set; }

        public decimal Fuel_Efficiency { get; set; }

        public decimal Weight { get; set; }

        public Vehicle()
        {
            //blank on purpose
        }

        public Vehicle(string plate_Number, string manufacturer, int current_Odometer, int next_Service_Odometer, int year, string status, string vehicle_Class, int maximum_Load, decimal fuel_Efficiency, decimal weight)
        {
            Plate_Number = plate_Number;
            Manufacturer = manufacturer;
            Current_Odometer = current_Odometer;
            Next_Service_Odometer = next_Service_Odometer;
            Year = year;
            Status = status;
            Vehicle_Class = vehicle_Class;
            Maximum_Load = maximum_Load;
            Fuel_Efficiency = fuel_Efficiency;
            Weight = weight;
        }

        public bool RegisterVehicle()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                try
                {
                    var output = connection.Query<Vehicle>("CALL CreateVehicle(@Vehicle_ID, @Plate_Number, @Manufacturer, @Current_Odometer, @Next_Service_Odometer, @Year, @Status, @Vehicle_Class, @Maximum_Load, @Fuel_Efficiency, @Weight );", this).ToList();
                    return true;
                }
                catch
                {
                    return false;
                }
                
                
            }
        }

        public List<Vehicle> GetAllUsableVehicles()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Vehicle>("CALL GetAllUsableVehicles;", new DynamicParameters()).ToList();

                return output;
            }
        }
        public List<Vehicle> GetAllVehicles()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Vehicle>("CALL GetAllVehicles;", new DynamicParameters()).ToList();

                return output;
            }
        }

        public static Vehicle GetVehicle(int VehiclVehicle_ID)
        {
            throw new System.NotImplementedException();
        }

        public static void UpdateVehicle(int VehiclVehicle_ID)
        {
            throw new System.NotImplementedException();
        }

        private static string LoadConnectionString(string id = "fleetmanagementDB")
        {

            return ConfigurationManager.ConnectionStrings[id].ConnectionString;

        }
    }
}