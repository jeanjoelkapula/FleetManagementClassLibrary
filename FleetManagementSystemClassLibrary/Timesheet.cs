using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace FleetManagementSystemClassLibrary
{
    public class Timesheet
    {
        public int Timesheet_ID
        {
            get; set;
        }

        public DateTime Submission_Date
        {
            get; set;
        }

        public decimal Hours_Worked
        {
            get; set;
        }

        public User User
        {
            get; set;
        }

        public string Status
        {
            get; set;
        }

        public int User_ID
        {
            get
            {
                return User.User_ID;
            }
        }

        public decimal CalculateSalary(Decimal Hourly_Rate)
        {
            decimal overtimeHours = 0;

            if(Hours_Worked > 160)
            {
                overtimeHours = Hours_Worked - 160;
            }

            decimal workingHours = Hours_Worked - overtimeHours;
            decimal salary = (workingHours * Hourly_Rate) + (overtimeHours * (Hourly_Rate * (decimal) 1.5));
            return salary;
        }

        public static List<Timesheet> GetAllTimesheets()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var timesheets = connection.Query<Timesheet, User, Timesheet>(
                "CALL GetAllTimesheets();",
                (timesheet, user) =>
                {
                    timesheet.User = user;
                    return timesheet;
                },
                splitOn: "User_ID").ToList();
                return timesheets;
              
            }
        }

        public static List<Timesheet> GetTimesheetsByUser(int User_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var timesheets = connection.Query<Timesheet, User, Timesheet>(
                "CALL GetTimesheetsByUser(@User_ID);",
                (timesheet, user) =>
                {
                    timesheet.User = user;
                    return timesheet;
                },
                splitOn: "User_ID", param: new { User_ID }).ToList();
                return timesheets;

            }
        }

        public static List<Timesheet> GetTimesheetsByStatus(string Status)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var timesheets = connection.Query<Timesheet, User, Timesheet>(
                "CALL GetTimesheetsByStatus(@Status);",
                (timesheet, user) =>
                {
                    timesheet.User = user;
                    return timesheet;
                },
                splitOn: "User_ID", param: new { Status }).ToList();
                return timesheets;

            }
        }

        public static Timesheet GetTimesheet(int Timesheet_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Timesheet, User,Timesheet>("CALL GetTimesheet(@Timesheet_ID)",
                    map: (t, u) =>
                    {
                        t.User = u;
                        return t;
                    },
                    splitOn: "User_ID", param: new { Timesheet_ID }).FirstOrDefault();
                return output;
            }
        }

        public void LogTimesheet()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                 connection.Execute("CALL LogTimesheet( @User_ID, @Submission_Date, @Hours_Worked);",this); 
            }
        }
        public Timesheet updateStatus(string status)
        {
            Status = status;
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Timesheet>("CALL updateStatus(@Timesheet_ID, @Status);",this).FirstOrDefault();
                return output;
            }
        }

        private static string LoadConnectionString(string id = "fleetmanagementDB")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}