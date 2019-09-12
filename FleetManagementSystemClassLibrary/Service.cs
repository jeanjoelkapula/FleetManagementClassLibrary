using System;
using Dapper;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FleetManagementSystemClassLibrary
{
    public class Service
    {
        public int Service_ID
        {
            get; set;
        }

        public string Job_Details
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

        public static List<Service> GetServiceHistory()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service>("CALL GetServiceHistory();").ToList();
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