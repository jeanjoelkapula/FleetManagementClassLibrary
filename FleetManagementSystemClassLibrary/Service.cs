using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;


namespace FleetManagementSystemClassLibrary
{
    public class Service
    {
        public string Service_ID
        {
            get; set;
        }

        public int Row_Count
        {
            get; set;
        }

        public string Service_Type
        {
            get; set;
        }

        public decimal Cost
        {
            get; set;
        }

        public DateTime Scheduled_Date
        {
            get; set;
        }

        public DateTime Start_Date
        {
            get; set;
        }

        public DateTime Completion_Date
        {
            get; set;
        }

        public string Service_Status
        {
            get; set;
        }

        public Vehicle Vehicle
        {
            get; set;
        }

        public List<Part> Parts
        {
            get; set; 
        }

        public User User
        {
            get; set;
        }

        public Vehicle_Type Vehicle_Type
        {
            get; set;
        }

        public Cargo_Body_Configuration Vehicle_Body_Type
        {
            get; set;
        }

        public static List<Service> GetServiceHistory()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, Cargo_Body_Configuration, Vehicle_Type, Service>("CALL GetServiceHistory();",
                    map: (s, v, bt, vt) => {
                        s.Vehicle = v;
                        s.Vehicle_Body_Type = bt;
                        s.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class"
               ).ToList();
                return output;
            }
        }

        public static void scheduleService()
        {
            throw new System.NotImplementedException();
        }

        public static List<Service> getAllServices()
        {
            throw new System.NotImplementedException();
        }

        public static Service getService(int Service_ID)
        {
            throw new System.NotImplementedException();
        }

        public static void updateService(int Service_ID)
        {
            throw new System.NotImplementedException();
        }

        private static string LoadConnectionString(string id = "fleetmanagementDB")
        {

            return ConfigurationManager.ConnectionStrings[id].ConnectionString;

        }
    }
}