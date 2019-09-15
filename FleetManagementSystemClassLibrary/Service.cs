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

        public Vehicle_Type Vehicle_Type
        {
            get; set;
        }

        public Vehicle_Body_Type Vehicle_Body_Type
        {
            get; set;
        }

        public static List<Service> GetServiceHistory()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, Vehicle_Body_Type, Vehicle_Type, Service>("CALL GetServiceHistory();",
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

        public static List<Service> GetServiceHistoryDaily(DateTime daily)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, Vehicle_Body_Type, Vehicle_Type, Service>("CALL GetServiceHistoryDaily(@daily);",
                    map: (s, v, bt, vt) =>
                    {
                        s.Vehicle = v;
                        s.Vehicle_Body_Type = bt;
                        s.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class", param: new { daily }).ToList();
                return output;
            }
        }

        public static List<Service> GetServiceHistoryYearly(DateTime yearStart, DateTime yearEnd)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, Vehicle_Body_Type, Vehicle_Type, Service>("CALL GetServiceHistoryYearly(@yearStart, @yearEnd);",
                    map: (s, v, bt, vt) =>
                    {
                        s.Vehicle = v;
                        s.Vehicle_Body_Type = bt;
                        s.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class", param: new { yearStart, yearEnd }).ToList();
                return output;
            }
        }

        public static List<Service> GetServiceHistoryMonthly(DateTime monthStart, DateTime monthEnd)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, Vehicle_Body_Type, Vehicle_Type, Service>("CALL GetServiceHistoryMonthly(@monthStart, @monthEnd);",
                    map: (s, v, bt, vt) =>
                    {
                        s.Vehicle = v;
                        s.Vehicle_Body_Type = bt;
                        s.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class", param: new { monthStart, monthEnd }).ToList();
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