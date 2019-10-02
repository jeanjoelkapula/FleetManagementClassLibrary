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


        public int Maximum_Load { get; set; }

        public decimal Fuel_Efficiency { get; set; }

        public decimal Weight { get; set; }

        public int Vehicle_Class { get; set; }

        public int Vehicle_Configuration { get; set; }

        public Vehicle()
        {
            //blank on purpose
        }

        public Vehicle(string plate_Number, string manufacturer, int current_Odometer, int next_Service_Odometer, int year, string status, int maximum_Load, decimal fuel_Efficiency, decimal weight, int vehicle_class, int vehicle_configuration)
        {
            Plate_Number = plate_Number;
            //Console.WriteLine(plate_Number);
            Manufacturer = manufacturer;
            //Console.WriteLine(manufacturer);
            Current_Odometer = current_Odometer;
            //Console.WriteLine(current_Odometer);
            Next_Service_Odometer = next_Service_Odometer;
            //Console.WriteLine(next_Service_Odometer);
            Year = year;
            //Console.WriteLine(year);
            Status = status;
            //Console.WriteLine(status);
            Maximum_Load = maximum_Load;
            //Console.WriteLine(maximum_Load);
            Fuel_Efficiency = fuel_Efficiency;
            //Console.WriteLine(fuel_Efficiency);
            Weight = weight;
            //Console.WriteLine(weight);
            Vehicle_Class = vehicle_class;
            //Console.WriteLine(vehicle_class);
            Vehicle_Configuration = vehicle_configuration;
            //Console.WriteLine(vehicle_configuration);
        }

        public bool RegisterVehicle()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                try
                {
                    var output = connection.Query<Vehicle>("CALL CreateVehicle(@Plate_Number, @Manufacturer, @Current_Odometer, @Next_Service_Odometer, @Year, @Status, @Maximum_Load, @Fuel_Efficiency, @Weight, @Vehicle_Class, @Vehicle_Configuration);", this).ToList();
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