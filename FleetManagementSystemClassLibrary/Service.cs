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

        public string Description
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

        public List<Parts> Parts
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

        public static List<Service> GetServiceEntryServiceID()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service>("CALL GetServiceEntryServiceID();").ToList();
                return output;
            }
        }

        public static string GetServiceID(int vID, DateTime scheduledDate)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                string output = connection.Query<string>("CALL GetServiceID(@vID, @scheduledDate);", new { vID, scheduledDate }).SingleOrDefault();
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
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class"
               ).ToList();
                return output;
            }
        }
        public static List<Parts> GetServiceParts(string serviceID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Parts>("CALL GetServiceParts(@serviceID);",  new { serviceID }).ToList();
                return output;
            }
        }

        public static List<Service> GetServiceHistoryStatus(string status)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, User, Service>("CALL GetServiceHistoryStatus(@status);",
                    map: (s, v, bt, vt, u) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        s.User = u;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class, User_ID", param: new { status }).ToList();
                return output;
            }
        }
        //
        public static List<Service> GetServiceSchedulesStatus(string status)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, User, Service>("CALL GetServiceSchedulesStatus(@status);",
                    map: (s, v, bt, vt, u) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        s.User = u;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class, User_ID", param: new { status }).ToList();
                return output;
            }
        }


        public static List<Service> GetServiceHistoryStatusMechanic(string status, int userID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, Service>("CALL GetServiceHistoryStatusMechanic(@status, @userID);",
                    map: (s, v, bt, vt) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class", param: new { status, userID }).ToList();
                return output;
            }
        }

        public static List<Service> GetServiceSchedulesStatusMechanic(string status, int userID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, User, Service>("CALL GetServiceSchedulesStatusMechanic(@status, @userID);",
                    map: (s, v, bt, vt, u) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        s.User = u;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class, User_ID", param: new { status, userID }).ToList();
                return output;
            }
        }


        public static void StartService(string ServiceID, DateTime startDate)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                connection.Execute("CALL StartService(@ServiceID, @startDate);", param: new { ServiceID, startDate});
            }
        }

        public static void CompleteService(string ServiceID, DateTime completionDate)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                connection.Execute("CALL CompleteService(@ServiceID,@completionDate);", param: new { ServiceID, completionDate });
            }
        }

        public static void UpdateServiceStatusCompleted(int vehicleID, string inService, DateTime scheduledDate, DateTime dateNow, int cost)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                connection.Execute("CALL UpdateServiceStatusCompleted(@vehicleID, @inService, @scheduledDate, @dateNow, @cost);", param: new { vehicleID, inService, scheduledDate, dateNow, cost });
            }
        }


        public static void UpdateServiceCost(string serviceID, int cost)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                connection.Execute("CALL UpdateServiceCost(@serviceID, @cost);", param: new { serviceID, cost });
            }
        }

        public static List<Service> GetServiceHistoryPerMechanic(int userID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, Service>("CALL GetServiceHistoryPerMechanic(@userID);",
                    map: (s, v, bt, vt) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class", param: new { userID }).ToList();
                return output;
            }
        }


        public static List<Service> GetServiceSchedules()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, User, Service>("CALL GetServiceSchedules();",
                    map: (s, v, bt, vt,u) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        s.User = u;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class, User_ID"
               ).ToList();

                
                return output;
            }
        }

        public static Service GetService(string Service)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, User, Service>("CALL GetService(@Service);",
                    map: (s, v, bt, vt, u) =>
                    {
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        s.Vehicle = v;
                        s.User = u;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class, User_ID", param:new {Service}
               ).FirstOrDefault();


                return output;
            }
        }

        public static List<Service> GetServiceSchedulesMechanic(int userID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, Service>("CALL GetServiceSchedulesMechanic(@userID);",
                    map: (s, v, bt, vt) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class", param: new { userID }).ToList();
                return output;
            }
        }

        public static List<Service> GetServiceHistoryDaily(DateTime daily)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, Service>("CALL GetServiceHistoryDaily(@daily);",
                    map: (s, v, bt, vt) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class", param: new { daily }).ToList();
                return output;
            }
        }

        public static List<Service> GetServiceHistoryDailyMechanic(DateTime daily, int userID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, Service>("CALL GetServiceHistoryDailyMechanic(@daily, @userID);",
                    map: (s, v, bt, vt) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class", param: new { daily, userID }).ToList();
                return output;
            }
        }

        public static List<Service> GetServiceAppointmentDaily(DateTime daily)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, User, Service>("CALL GetServiceAppointmentDaily(@daily);",
                    map: (s, v, bt, vt, u) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        s.User = u;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class, User_ID", param: new { daily }).ToList();
                return output;
            }
        }


        public static List<Service> GetServiceAppointmentDailyMechanic(DateTime daily, int userID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, Service>("CALL GetServiceAppointmentDailyMechanic(@daily, @userID);",
                    map: (s, v, bt, vt) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class", param: new { daily, userID }).ToList();
                return output;
            }
        }

        public static List<Service> GetServiceHistoryYearly(DateTime yearStart, DateTime yearEnd)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, Service>("CALL GetServiceHistoryYearly(@yearStart, @yearEnd);",
                    map: (s, v, bt, vt) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class", param: new { yearStart, yearEnd }).ToList();
                return output;
            }
        }



        public static List<Service> GetServiceHistoryYearlyMechanic(DateTime yearStart, DateTime yearEnd, int userID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, Service>("CALL GetServiceHistoryYearlyMechanic(@yearStart, @yearEnd, @userID);",
                    map: (s, v, bt, vt) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class", param: new { yearStart, yearEnd, userID }).ToList();
                return output;
            }
        }


        public static List<Service> GetServiceAppointmentYearly(DateTime yearStart, DateTime yearEnd)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, User, Service>("CALL GetServiceAppointmentYearly(@yearStart, @yearEnd);",
                    map: (s, v, bt, vt, u) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        s.User = u;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class, User_ID", param: new { yearStart, yearEnd }).ToList();
                return output;
            }
        }



        public static List<Service> GetServiceAppointmentYearlyMechanic(DateTime yearStart, DateTime yearEnd, int userID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, Service>("CALL GetServiceAppointmentYearlyMechanic(@yearStart, @yearEnd, @userID);",
                    map: (s, v, bt, vt) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class", param: new { yearStart, yearEnd, userID }).ToList();
                return output;
            }
        }

        public static List<Service> GetServiceHistoryMonthly(DateTime monthStart, DateTime monthEnd)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, Service>("CALL GetServiceHistoryMonthly(@monthStart, @monthEnd);",
                    map: (s, v, bt, vt) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class", param: new { monthStart, monthEnd }).ToList();
                return output;
            }
        }


        public static List<Service> GetServiceHistoryMonthlyMechanic(DateTime monthStart, DateTime monthEnd, int userID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, Service>("CALL GetServiceHistoryMonthlyMechanic(@monthStart, @monthEnd, @userID);",
                    map: (s, v, bt, vt) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class", param: new { monthStart, monthEnd, userID }).ToList();
                return output;
            }
        }

        public static List<Service> GetServiceAppointmentMonthly(DateTime monthStart, DateTime monthEnd)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, User, Service>("CALL GetServiceAppointmentMonthly(@monthStart, @monthEnd);",
                    map: (s, v, bt, vt, u) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        s.User = u;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class, User_ID", param: new { monthStart, monthEnd }).ToList();
                return output;
            }
        }


        public static List<Service> GetServiceAppointmentMonthlyMechanic(DateTime monthStart, DateTime monthEnd, int userID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Service, Vehicle, CargoConfiguration, Vehicle_Type, Service>("CALL GetServiceAppointmentMonthlyMechanic(@monthStart, @monthEnd, @userID);",
                    map: (s, v, bt, vt) =>
                    {
                        s.Vehicle = v;
                        v.Vehicle_Body_Type = bt;
                        v.Vehicle_Type = vt;
                        return s;
                    },
                    splitOn: "Vehicle_ID, Description, Vehicle_Class", param: new { monthStart, monthEnd, userID }).ToList();
                return output;
            }
        }

        public static void AddServiceSchedule(string serviceID, int userID, int vehicleID, DateTime scheduled_Date, string serviceStatus, string serviceType, string description)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Execute("CALL AddServiceSchedule(@serviceID, @userID, @vehicleID, @scheduled_Date, @serviceStatus, @serviceType, @description);", new { serviceID, userID, vehicleID, scheduled_Date, serviceStatus, serviceType, description });
            }
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