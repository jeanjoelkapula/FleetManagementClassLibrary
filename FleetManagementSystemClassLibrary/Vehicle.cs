using MySql.Data.MySqlClient;
using System;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

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

        public decimal Fuel_Efficiency { get; set; }

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


        public int Maximum_Load
        {
            get; set;
        }

        public decimal Weight { get; set; }

        public CargoConfiguration Vehicle_Body_Type
        {
            get;set;
        }

        public string Status { get; set; }

        public int Year { get; set; }

        public int Vehicle_Type_ID { get; set; }

        public int Cargo_Configuration_ID { get; set; }

        public decimal Engine_Size
        {
            get; set;
        }

        public Vehicle()
        {
            //Blank on purpose
        }


        public Vehicle(string plate_Number, string manufacturer, int current_Odometer, int next_Service_Odometer, int year, string status, int maximum_Load, decimal fuel_Efficiency, decimal weight, int vehicle_type_ID, int cargo_body_configuration_ID, string modelName)
        {
            Plate_Number = plate_Number;

            Manufacturer = manufacturer;

            Current_Odometer = current_Odometer;

            Next_Service_Odometer = next_Service_Odometer;

            Year = year;

            Status = status;

            Maximum_Load = maximum_Load;

            Fuel_Efficiency = fuel_Efficiency;

            Weight = weight;

            Vehicle_Type_ID = vehicle_type_ID;

            Cargo_Configuration_ID = cargo_body_configuration_ID;

            Model_Name = modelName;

        }

        public bool RegisterVehicle()
        {
                

            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                try
                {
                    connection.Query("CALL CreateVehicle(@Plate_Number, @Manufacturer, @Current_Odometer, @Next_Service_Odometer, @Year, @Status, @Maximum_Load, @Fuel_Efficiency, @Weight, @Vehicle_Type_ID, @Cargo_Configuration_ID, @Model_Name);", 
                                                        new {Plate_Number, Manufacturer, Current_Odometer, Next_Service_Odometer, Year, Status, Maximum_Load, Fuel_Efficiency, Weight, Vehicle_Type_ID, Cargo_Configuration_ID, Model_Name });


                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine(e.Source);
                    Console.WriteLine(e.InnerException);
                    return false;
                }


            }
        }


        public List<Vehicle> GetAllVehicles()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                List<Vehicle> output = connection.Query<Vehicle>("CALL GetVehicles;", this).ToList();
                             
                                
                return output;
            }
        }

        public List<Vehicle> GetAllAvailableVehicles()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                List<Vehicle> output = connection.Query<Vehicle>("CALL getAvailableVehicles;").ToList();


                return output;
            }
        }


        public bool UpdateVehicle()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {

                /*
                Console.WriteLine("VehID: " + Vehicle_ID);
                Console.WriteLine("RegNo: " + Plate_Number);
                Console.WriteLine("Manuf: " + Manufacturer);
                Console.WriteLine("curod: " + Current_Odometer);
                Console.WriteLine("nexod: " + Next_Service_Odometer);
                Console.WriteLine("year : " + Year);
                Console.WriteLine("statu: " + Status);
                Console.WriteLine("maxpa: " + Maximum_Load);
                Console.WriteLine("weigh: " + Weight);
                Console.WriteLine("vtyid: " + Vehicle_Type_ID);
                Console.WriteLine("caboc: " + Cargo_Configuration_ID);
                Console.WriteLine("modna: " + Model_Name);
                */
                try
                {
                    connection.Query("CALL UpdateVehicle(@Vehicle_ID, @Plate_Number, @Manufacturer, @Current_Odometer, @Next_Service_Odometer, @Year, @Status, @Maximum_Load, @Fuel_Efficiency, @Weight, @Vehicle_Type_ID, @Cargo_Configuration_ID, @Model_Name);",
                                                        new { Vehicle_ID, Plate_Number, Manufacturer, Current_Odometer, Next_Service_Odometer, Year, Status, Maximum_Load, Fuel_Efficiency, Weight, Vehicle_Type_ID, Cargo_Configuration_ID, Model_Name });

                    return true;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.InnerException);

                    return false;
                }

            }
        }
        public static string GetVehicleStatus(int Vehicle_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {

                string status = connection.Query<string>("call GetVehicleStatus(@Vehicle_ID);", new { Vehicle_ID }).SingleOrDefault();

                return status;
            }
        }
        public bool SuspendVehicle(int ID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                try
                {
                    var output = connection.Query<Vehicle>("CALL SuspendVehicle(@id)", new { id = ID });
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        private static string LoadConnectionString(string id = "fleetmanagementDB")
        {

            return ConfigurationManager.ConnectionStrings[id].ConnectionString;

        }

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

        public static Vehicle getVehicle(int Vehicle_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {

                Vehicle vehicle = connection.Query<Vehicle>("call GetVehicle(@Vehicle_ID);", new { Vehicle_ID }).SingleOrDefault();

                return vehicle;
            }
        }

        public static string GetVehicleType(int Vehicle_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {

                string vehicle = connection.Query<string>("call GetVehicleType(@Vehicle_ID);", new { Vehicle_ID }).SingleOrDefault();
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


    }
}