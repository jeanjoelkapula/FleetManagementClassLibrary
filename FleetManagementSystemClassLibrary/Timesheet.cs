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

        public decimal Hourly_Rate
        {
            get; set;
        }

        public decimal Overtime_Rate
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

        public decimal CalculateSalary()
        {
            decimal overtimeHours = 0;

            if(Hours_Worked > 160)
            {
                overtimeHours = Hours_Worked - 160;
            }

            decimal workingHours = Hours_Worked - overtimeHours;
            decimal salary = (workingHours * Hourly_Rate) + (overtimeHours * Overtime_Rate);
            return salary;
        }

        public static List<Timesheet> GetAllTimesheets()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Timesheet>("CALL GetAllTimesheets()").ToList();
                return output;
            }
        }

        public static Timesheet GetTimesheet(int Timesheet_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Timesheet>("CALL GetTimesheet(@Timesheet_ID)",new {Timesheet_ID}).FirstOrDefault();
                return output;
            }
        }

        public Timesheet logTimesheet()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Timesheet>("CALL logTimesheet(@Timesheet_ID, @User.User_ID, @Submission_Date, @Hours_Worked, @Hourly_Rate, @Overtime_Rate);", this).FirstOrDefault();
                return output;
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