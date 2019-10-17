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


        public string Model_Name

        {
            get; set;
        }


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
        */


        public CargoConfiguration Vehicle_Body_Type;

        public int Maximum_Load { get; set; }

        public decimal Fuel_Efficiency { get; set; }

        public decimal Weight { get; set; }

        public int Vehicle_Type_ID { get; set; }

        public int Cargo_Body_Configuration_ID { get; set; }

        public Vehicle()
        {
            //blank on purpose
        }

        public Vehicle(string plate_Number, string manufacturer, int current_Odometer, int next_Service_Odometer, int year, string status, int maximum_Load, decimal fuel_Efficiency, decimal weight, int vehicle_type_ID, int cargo_body_configuration_ID)
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
            
            Cargo_Body_Configuration_ID = cargo_body_configuration_ID;
            
        }

        public bool RegisterVehicle()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                try
                {
                    var output = connection.Query<Vehicle>("CALL CreateVehicle(@Plate_Number, @Manufacturer, @Current_Odometer, @Next_Service_Odometer, @Year, @Status, @Maximum_Load, @Fuel_Efficiency, @Weight, @Vehicle_Type_ID, @Cargo_Body_Configuration_ID);", new { Plate_Number = Plate_Number, Manufacturer= Manufacturer, Current_Odometer = Current_Odometer, Next_Service_Odometer = Next_Service_Odometer,  Year = Year, Status = Status, Maximum_Load = Maximum_Load, Fuel_Efficiency = Fuel_Efficiency, Weight = Weight, Vehicle_Type_ID = Vehicle_Type_ID, Cargo_Body_Configuration_ID = Cargo_Body_Configuration_ID }).ToList();
                    return true;
                }
                catch
                {
                    return false;
                }
                
                
            }
        }

        
        public static List<Vehicle> GetAllVehicles()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Vehicle>("CALL GetVehicles;", new DynamicParameters()).ToList();

                return output;
            }
        }
                


        public bool UpdateVehicle()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {

                try
                {
                    var output = connection.Query<Vehicle>("CALL UpdateVehicle(@Vehicle_ID, @Plate_Number, @Manufacturer, @Current_Odometer, @Next_Service_Odometer, @Year, @Status, @Maximum_Load, @Fuel_Efficiency, @Weight, @Vehicle_Type_ID, @Cargo_Body_Configuration_ID);", this).ToList();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

        public bool SuspendVehicle(int ID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                try
                {
                    var output = connection.Query<Vehicle>("CALL SuspendVehicle(@id)", new {id = ID });
                        return true;
                }
                catch
                {
                    return false;
                }
            }
        }



        public static List<Vehicle> GetVehiclesForServiceEntry()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Vehicle>("CALL GetVehiclesForServiceEntry();").ToList();
                return output;
            }
        }

        public static void UpdateVehicleStatus(int vehicleID, string inService)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                connection.Execute("CALL UpdateVehicleStatus(@vehicleID, @inService);", param: new { vehicleID, inService });
            }
        }
      
        public Vehicle getVehicle(int Vehicle_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Vehicle>("CALL getVehicle(@Vehicle_ID);", new { Vehicle_ID }).FirstOrDefault();
                return output;


            }
        }

        private static string LoadConnectionString(string id = "fleetmanagementDB")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;

        }


    }
}