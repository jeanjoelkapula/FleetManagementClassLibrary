
﻿using System;
using Dapper;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
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

        public CargoConfiguration Vehicle_Body_Type
        {
            get; set;
        }

        public static void scheduleService()
        {
            
        }



        public static List<Service> GetServiceEntryServiceID()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service>("CALL GetServiceEntryServiceID();").ToList();
                return output;
            }
        }

        public static List<Service> GetServiceHistory()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, Service>("CALL GetServiceHistory();",
                    map: (s, v, bt, vt) =>
                    {
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

        public static List<Service> GetServiceHistoryStatus(string status)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, Service>("CALL GetServiceHistoryStatus(@status);",
                    map: (s, v, bt, vt) =>
                    {
                        s.Vehicle = v;
                        s.Vehicle_Body_Type = bt;
                        s.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class", param: new { status }).ToList();
                return output;
            }
        }

        public static List<Service> GetServiceSchedulesStatus(string status)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, Service>("CALL GetServiceSchedulesStatus(@status);",
                    map: (s, v, bt, vt) =>
                    {
                        s.Vehicle = v;
                        s.Vehicle_Body_Type = bt;
                        s.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class", param: new { status }).ToList();
                return output;
            }
        }


        public static List<Service> GetServiceHistoryStatusMechanic(string status, int userID)
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