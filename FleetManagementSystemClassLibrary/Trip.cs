﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Collections;

namespace FleetManagementSystemClassLibrary
{
    public class Trip
    {
        public int Trip_ID
        {

            get; set;
            
        }

        public string End_Location
        {
            get; set;
        }

        public string Start_Location
        {
            get; set;
        }

        public int Distance
        {
            get; set;
        }

        public string Trip_Status
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

        public DateTime Scheduled_Date
        {
            get; set;
        }

        public User User
        {
            get; set;
        }
        public User Driver
        {
            get; set;
        }
        public Vehicle Vehicle
        {
            get; set;
        }

        public Cargo_Package Cargo_Package
        {
            get; set;
        }

        public static int ScheduleTrip(int User_ID,int Vehicle_ID, string Start_Location, string End_Location, int Driver_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<int>("CALL NewTrip(@User_ID,@Vehicle_ID, @Start_Location, @End_Location, @Driver_ID);", new {User_ID,Vehicle_ID ,Start_Location, End_Location,Driver_ID }).Single();
                return output;
            }
        }
        
        public static void AddCargo_Package()
        {

        }

        public static List<Trip> GetTripPendingByDriver(int User_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL getPendingTripsByDriver(@User_ID);", new {User_ID}).ToList(); ;
                Vehicle a = new Vehicle();
                IEnumerable<dynamic> iter = connection.Query("CALL getPendingTripsByDriver(@User_ID);", new { User_ID }).ToList(); 
                int count = 0;
                foreach (var row in iter)
                {
                    Trip temp = output.ElementAt<Trip>(count);
                    temp.Trip_ID = row.Trip_ID;

                    output.ElementAt<Trip>(count).Trip_ID = Convert.ToInt32(row.Trip_ID);
                    output.ElementAt<Trip>(count).Start_Location = row.Start_Location;
                    output.ElementAt<Trip>(count).End_Location = row.End_Location;
                    output.ElementAt<Trip>(count).User = User.GetUser(row.User_ID);
                    output.ElementAt<Trip>(count).Driver = User.GetUser(row.Driver_ID);
                    output.ElementAt<Trip>(count).Vehicle = Vehicle.getVehicle(Convert.ToInt32(row.Vehicle_ID));
                  //  output.ElementAt<Trip>(count).Start_Date = Convert.ToDateTime(row.Start_Date);
                    count++;
                }

                return output;
            }
        }
        public static List<Trip> GetScheduleByYear(DateTime yearStart, DateTime yearEnd)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL GetScheduleByYear(@yearStart, @yearEnd);", new {yearStart, yearEnd }).ToList(); ;
                Vehicle a = new Vehicle();
                IEnumerable<dynamic> iter = connection.Query("CALL GetScheduleByYear(@yearStart, @yearEnd);", new { yearStart, yearEnd }).ToList();
                int count = 0;
                foreach (var row in iter)
                {
                    Trip temp = output.ElementAt<Trip>(count);
                    temp.Trip_ID = row.Trip_ID;

                    output.ElementAt<Trip>(count).Trip_ID = Convert.ToInt32(row.Trip_ID);
                    output.ElementAt<Trip>(count).Start_Location = row.Start_Location;
                    output.ElementAt<Trip>(count).End_Location = row.End_Location;
                    output.ElementAt<Trip>(count).User = User.GetUser(row.User_ID);
                    output.ElementAt<Trip>(count).Driver = User.GetUser(row.Driver_ID);
                    output.ElementAt<Trip>(count).Vehicle = Vehicle.getVehicle(Convert.ToInt32(row.Vehicle_ID));
                    //output.ElementAt<Trip>(count).Start_Date = Convert.ToDateTime(row.Start_Date);
                    count++;
                }

                return output;
            }
        }
        public static List<Trip> GetScheduleByMonth(DateTime monthStart, DateTime monthEnd)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL GetTripScheduleByMonth(@monthStart, @monthEnd);", new { monthStart, monthEnd }).ToList(); ;
                Vehicle a = new Vehicle();
                IEnumerable<dynamic> iter = connection.Query("CALL GetTripScheduleByMonth(@monthStart, @monthEnd);", new { monthStart, monthEnd }).ToList();
                int count = 0;
                foreach (var row in iter)
                {
                    Trip temp = output.ElementAt<Trip>(count);
                    temp.Trip_ID = row.Trip_ID;

                    output.ElementAt<Trip>(count).Trip_ID = Convert.ToInt32(row.Trip_ID);
                    output.ElementAt<Trip>(count).Start_Location = row.Start_Location;
                    output.ElementAt<Trip>(count).End_Location = row.End_Location;
                    output.ElementAt<Trip>(count).User = User.GetUser(row.User_ID);
                    output.ElementAt<Trip>(count).Driver = User.GetUser(row.Driver_ID);
                    output.ElementAt<Trip>(count).Vehicle = Vehicle.getVehicle(Convert.ToInt32(row.Vehicle_ID));
                    //output.ElementAt<Trip>(count).Start_Date = Convert.ToDateTime(row.Start_Date);
                    count++;
                }

                return output;
            }
        }

        public static List<Trip> GetScheduleDaily(DateTime daily)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL GetScheduleDaily(@daily);", new {daily}).ToList(); ;
                Vehicle a = new Vehicle();
                IEnumerable<dynamic> iter = connection.Query("CALL GetScheduleDaily(@daily);", new {daily }).ToList();
                int count = 0;
                foreach (var row in iter)
                {
                    Trip temp = output.ElementAt<Trip>(count);
                    temp.Trip_ID = row.Trip_ID;

                    output.ElementAt<Trip>(count).Trip_ID = Convert.ToInt32(row.Trip_ID);
                    output.ElementAt<Trip>(count).Start_Location = row.Start_Location;
                    output.ElementAt<Trip>(count).End_Location = row.End_Location;
                    output.ElementAt<Trip>(count).User = User.GetUser(row.User_ID);
                    output.ElementAt<Trip>(count).Driver = User.GetUser(row.Driver_ID);
                    output.ElementAt<Trip>(count).Vehicle = Vehicle.getVehicle(Convert.ToInt32(row.Vehicle_ID));
                    //output.ElementAt<Trip>(count).Start_Date = Convert.ToDateTime(row.Start_Date);
                    count++;
                }

                return output;
            }
        }
        public static List<Trip> GetTripHistoryByYear(DateTime yearStart, DateTime yearEnd)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL GetTripHistoryByYear(@yearStart, @yearEnd);", new { yearStart, yearEnd }).ToList(); ;
                Vehicle a = new Vehicle();
                IEnumerable<dynamic> iter = connection.Query("CALL GetTripHistoryByYear(@yearStart, @yearEnd);", new { yearStart, yearEnd }).ToList();
                int count = 0;
                foreach (var row in iter)
                {
                    Trip temp = output.ElementAt<Trip>(count);
                    temp.Trip_ID = row.Trip_ID;

                    output.ElementAt<Trip>(count).Trip_ID = Convert.ToInt32(row.Trip_ID);
                    output.ElementAt<Trip>(count).Start_Location = row.Start_Location;
                    output.ElementAt<Trip>(count).End_Location = row.End_Location;
                    output.ElementAt<Trip>(count).User = User.GetUser(row.User_ID);
                    output.ElementAt<Trip>(count).Driver = User.GetUser(row.Driver_ID);
                    output.ElementAt<Trip>(count).Vehicle = Vehicle.getVehicle(Convert.ToInt32(row.Vehicle_ID));
                    //output.ElementAt<Trip>(count).Start_Date = Convert.ToDateTime(row.Start_Date);
                    count++;
                }

                return output;
            } 
        }
        public static List<Trip> GetTripHistoryByMonth(DateTime monthStart, DateTime monthEnd)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL GetTripHistoryByMonth(@monthStart, @monthEnd);", new { monthStart, monthEnd }).ToList(); ;
                Vehicle a = new Vehicle();
                IEnumerable<dynamic> iter = connection.Query("CALL GetTripHistoryByMonth(@monthStart, @monthEnd);", new { monthStart, monthEnd }).ToList();
                int count = 0;
                foreach (var row in iter)
                {
                    Trip temp = output.ElementAt<Trip>(count);
                    temp.Trip_ID = row.Trip_ID;

                    output.ElementAt<Trip>(count).Trip_ID = Convert.ToInt32(row.Trip_ID);
                    output.ElementAt<Trip>(count).Start_Location = row.Start_Location;
                    output.ElementAt<Trip>(count).End_Location = row.End_Location;
                    output.ElementAt<Trip>(count).User = User.GetUser(row.User_ID);
                    output.ElementAt<Trip>(count).Driver = User.GetUser(row.Driver_ID);
                    output.ElementAt<Trip>(count).Vehicle = Vehicle.getVehicle(Convert.ToInt32(row.Vehicle_ID));
                    //output.ElementAt<Trip>(count).Start_Date = Convert.ToDateTime(row.Start_Date);
                    count++;
                }

                return output;
            }
        }
        public static List<Trip> GetTripHistoryDaily(DateTime daily)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL GetTripHistoryDaily(@daily);", new { daily }).ToList(); ;
                Vehicle a = new Vehicle();
                IEnumerable<dynamic> iter = connection.Query("CALL GetTripHistoryDaily(@daily);", new { daily }).ToList();
                int count = 0;
                foreach (var row in iter)
                {
                    Trip temp = output.ElementAt<Trip>(count);
                    temp.Trip_ID = row.Trip_ID;

                    output.ElementAt<Trip>(count).Trip_ID = Convert.ToInt32(row.Trip_ID);
                    output.ElementAt<Trip>(count).Start_Location = row.Start_Location;
                    output.ElementAt<Trip>(count).End_Location = row.End_Location;
                    output.ElementAt<Trip>(count).User = User.GetUser(row.User_ID);
                    output.ElementAt<Trip>(count).Driver = User.GetUser(row.Driver_ID);
                    output.ElementAt<Trip>(count).Vehicle = Vehicle.getVehicle(Convert.ToInt32(row.Vehicle_ID));
                    //output.ElementAt<Trip>(count).Start_Date = Convert.ToDateTime(row.Start_Date);
                    count++;
                }

                return output;
            }
        }
        public static List<Trip> GetDriverHistoryByYear(int User_ID, DateTime yearStart, DateTime yearEnd)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL GetDriverHistoryByYear(@User_ID, @yearStart, @yearEnd);", new { User_ID, yearStart, yearEnd }).ToList(); 
                Vehicle a = new Vehicle();
                IEnumerable<dynamic> iter = connection.Query("CALL GetDriverHistoryByYear(@User_ID, @yearStart, @yearEnd);", new { User_ID, yearStart, yearEnd }).ToList(); 
                int count = 0;
                foreach (var row in iter)
                {
                    Trip temp = output.ElementAt<Trip>(count);
                    temp.Trip_ID = row.Trip_ID;

                    output.ElementAt<Trip>(count).Trip_ID = Convert.ToInt32(row.Trip_ID);
                    output.ElementAt<Trip>(count).Start_Location = row.Start_Location;
                    output.ElementAt<Trip>(count).End_Location = row.End_Location;
                    output.ElementAt<Trip>(count).User = User.GetUser(row.User_ID);
                    output.ElementAt<Trip>(count).Driver = User.GetUser(row.Driver_ID);
                    output.ElementAt<Trip>(count).Vehicle = Vehicle.getVehicle(Convert.ToInt32(row.Vehicle_ID));
                    //  output.ElementAt<Trip>(count).Start_Date = Convert.ToDateTime(row.Start_Date);
                    count++;
                }

                return output;
            }
        }
        public static List<Trip> GetDriverHistoryByMonth(int User_ID, DateTime monthStart, DateTime monthEnd)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL GetDriverHistoryByMonth(@User_ID, @monthStart, @monthEnd);", new { User_ID, monthStart, monthEnd }).ToList();
                Vehicle a = new Vehicle();
                IEnumerable<dynamic> iter = connection.Query("CALL GetDriverHistoryByMonth(@User_ID, @monthStart, @monthEnd);", new { User_ID, monthStart, monthEnd }).ToList();
                int count = 0;
                foreach (var row in iter)
                {
                    Trip temp = output.ElementAt<Trip>(count);
                    temp.Trip_ID = row.Trip_ID;

                    output.ElementAt<Trip>(count).Trip_ID = Convert.ToInt32(row.Trip_ID);
                    output.ElementAt<Trip>(count).Start_Location = row.Start_Location;
                    output.ElementAt<Trip>(count).End_Location = row.End_Location;
                    output.ElementAt<Trip>(count).User = User.GetUser(row.User_ID);
                    output.ElementAt<Trip>(count).Driver = User.GetUser(row.Driver_ID);
                    output.ElementAt<Trip>(count).Vehicle = Vehicle.getVehicle(Convert.ToInt32(row.Vehicle_ID));
                    //  output.ElementAt<Trip>(count).Start_Date = Convert.ToDateTime(row.Start_Date);
                    count++;
                }

                return output;
            }
        }
        public static List<Trip> GetDriverHistoryDaily(int User_ID, DateTime daily)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL GetDriverHistoryDaily(@User_ID, @daily);", new { User_ID, daily }).ToList();
                Vehicle a = new Vehicle();
                IEnumerable<dynamic> iter = connection.Query("CALL GetDriverHistoryDaily(@User_ID, @daily);", new { User_ID, daily }).ToList();
                int count = 0;
                foreach (var row in iter)
                {
                    Trip temp = output.ElementAt<Trip>(count);
                    temp.Trip_ID = row.Trip_ID;

                    output.ElementAt<Trip>(count).Trip_ID = Convert.ToInt32(row.Trip_ID);
                    output.ElementAt<Trip>(count).Start_Location = row.Start_Location;
                    output.ElementAt<Trip>(count).End_Location = row.End_Location;
                    output.ElementAt<Trip>(count).User = User.GetUser(row.User_ID);
                    output.ElementAt<Trip>(count).Driver = User.GetUser(row.Driver_ID);
                    output.ElementAt<Trip>(count).Vehicle = Vehicle.getVehicle(Convert.ToInt32(row.Vehicle_ID));
                    //  output.ElementAt<Trip>(count).Start_Date = Convert.ToDateTime(row.Start_Date);
                    count++;
                }

                return output;
            }
        }

        public static List<Trip> GetDriverScheduleByMonth(int User_ID, DateTime monthStart, DateTime monthEnd)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL GetDriverScheduleByMonth(@User_ID, @monthStart, @monthEnd);", new { User_ID, monthStart, monthEnd }).ToList();
                Vehicle a = new Vehicle();
                IEnumerable<dynamic> iter = connection.Query("CALL GetDriverScheduleByMonth(@User_ID, @monthStart, @monthEnd);", new { User_ID, monthStart, monthEnd }).ToList();
                int count = 0;
                foreach (var row in iter)
                {
                    Trip temp = output.ElementAt<Trip>(count);
                    temp.Trip_ID = row.Trip_ID;

                    output.ElementAt<Trip>(count).Trip_ID = Convert.ToInt32(row.Trip_ID);
                    output.ElementAt<Trip>(count).Start_Location = row.Start_Location;
                    output.ElementAt<Trip>(count).End_Location = row.End_Location;
                    output.ElementAt<Trip>(count).User = User.GetUser(row.User_ID);
                    output.ElementAt<Trip>(count).Driver = User.GetUser(row.Driver_ID);
                    output.ElementAt<Trip>(count).Vehicle = Vehicle.getVehicle(Convert.ToInt32(row.Vehicle_ID));
                    //  output.ElementAt<Trip>(count).Start_Date = Convert.ToDateTime(row.Start_Date);
                    count++;
                }

                return output;
            }
        }
        public static List<Trip> GetDriverScheduleDaily(int User_ID, DateTime daily)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL GetDriverScheduleDaily(@User_ID, @daily);", new { User_ID, daily }).ToList();
                Vehicle a = new Vehicle();
                IEnumerable<dynamic> iter = connection.Query("CALL GetDriverScheduleDaily(@User_ID, @daily);", new { User_ID, daily }).ToList();
                int count = 0;
                foreach (var row in iter)
                {
                    Trip temp = output.ElementAt<Trip>(count);
                    temp.Trip_ID = row.Trip_ID;

                    output.ElementAt<Trip>(count).Trip_ID = Convert.ToInt32(row.Trip_ID);
                    output.ElementAt<Trip>(count).Start_Location = row.Start_Location;
                    output.ElementAt<Trip>(count).End_Location = row.End_Location;
                    output.ElementAt<Trip>(count).User = User.GetUser(row.User_ID);
                    output.ElementAt<Trip>(count).Driver = User.GetUser(row.Driver_ID);
                    output.ElementAt<Trip>(count).Vehicle = Vehicle.getVehicle(Convert.ToInt32(row.Vehicle_ID));
                    //  output.ElementAt<Trip>(count).Start_Date = Convert.ToDateTime(row.Start_Date);
                    count++;
                }

                return output;
            }
        }
        public static List<Trip> GetDriverScheduleByYear(int User_ID, DateTime yearStart, DateTime yearEnd)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL GetDriverScheduleByYear(@User_ID, @yearStart, @yearEnd);", new { User_ID, yearStart, yearEnd }).ToList();
                Vehicle a = new Vehicle();
                IEnumerable<dynamic> iter = connection.Query("CALL GetDriverScheduleByYear(@User_ID, @yearStart, @yearEnd);", new { User_ID, yearStart, yearEnd }).ToList();
                int count = 0;
                foreach (var row in iter)
                {
                    Trip temp = output.ElementAt<Trip>(count);
                    temp.Trip_ID = row.Trip_ID;

                    output.ElementAt<Trip>(count).Trip_ID = Convert.ToInt32(row.Trip_ID);
                    output.ElementAt<Trip>(count).Start_Location = row.Start_Location;
                    output.ElementAt<Trip>(count).End_Location = row.End_Location;
                    output.ElementAt<Trip>(count).User = User.GetUser(row.User_ID);
                    output.ElementAt<Trip>(count).Driver = User.GetUser(row.Driver_ID);
                    output.ElementAt<Trip>(count).Vehicle = Vehicle.getVehicle(Convert.ToInt32(row.Vehicle_ID));
                    //  output.ElementAt<Trip>(count).Start_Date = Convert.ToDateTime(row.Start_Date);
                    count++;
                }

                return output;
            }
        }
        public static void StartTrip(int Trip_ID, int Vehicle_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Execute("CALL StartTrip(@Trip_ID,@Vehicle_ID);", new {Trip_ID, Vehicle_ID});
            }
        }
        public static List<Trip> GetTripCompletedByDriver(int User_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL getCompletedTripsByDriver(@User_ID);", new { User_ID }).ToList(); ;
                Vehicle a = new Vehicle();
                IEnumerable<dynamic> iter = connection.Query("CALL getCompletedTripsByDriver(@User_ID);", new { User_ID }).ToList();
                int count = 0;
                foreach (var row in iter)
                {
                    Trip temp = output.ElementAt<Trip>(count);
                    temp.Trip_ID = row.Trip_ID;

                    output.ElementAt<Trip>(count).Trip_ID = Convert.ToInt32(row.Trip_ID);
                    output.ElementAt<Trip>(count).Start_Location = row.Start_Location;
                    output.ElementAt<Trip>(count).End_Location = row.End_Location;
                    output.ElementAt<Trip>(count).User = User.GetUser(row.User_ID);
                    output.ElementAt<Trip>(count).Driver = User.GetUser(row.Driver_ID);
                    output.ElementAt<Trip>(count).Vehicle = Vehicle.getVehicle(Convert.ToInt32(row.Vehicle_ID));
                    output.ElementAt<Trip>(count).Start_Date = Convert.ToDateTime(row.Start_Date);
                    count++;
                }

                return output;
            }
        }
        public static Trip GetTrip(int Trip_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL GetTrip(@Trip_ID);", new { Trip_ID }).FirstOrDefault();
                return output;
            }
        }
        public static List<Trip> getAllTrips()
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL GetAllTrips();").ToList();
                return output;
            }
        }

        public static List<Trip> getAllActiveTrips()
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL ViewAllActiveTrips();").ToList();
                return output;
            }
        }

        public string GetStartLocation(int Trip_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<string>("CALL GetStartLocation(@Trip_ID);", new {Trip_ID}).ToString();
                return output;
            }
        }
        public static List<Trip> getAllPendingTrips()
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL viewAllPendingTrips();", new DynamicParameters()).ToList(); ;
                Vehicle a = new Vehicle();
                IEnumerable<dynamic> iter = connection.Query("CALL viewAllPendingTrips();", new DynamicParameters()).ToList();
                int count = 0;
                foreach (var row in iter)
                {
                    Trip temp = output.ElementAt<Trip>(count);
                    temp.Trip_ID = row.Trip_ID;
                    
                    output.ElementAt<Trip>(count).Trip_ID = Convert.ToInt32(row.Trip_ID);
                    output.ElementAt<Trip>(count).Start_Location = row.Start_Location;
                    output.ElementAt<Trip>(count).End_Location = row.End_Location;
                    output.ElementAt<Trip>(count).User = User.GetUser(row.User_ID);
                    output.ElementAt<Trip>(count).Driver = User.GetUser(row.Driver_ID);
                    output.ElementAt<Trip>(count).Vehicle = Vehicle.getVehicle(Convert.ToInt32(row.Vehicle_ID));
                    //output.ElementAt<Trip>(count).Start_Date = Convert.ToDateTime(row.Start_Date);
                    count++;
                }

                return output;
            }
        }
        public static List<Trip> getAllCompletedTrips()
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL ViewAllCompletedTrips();", new DynamicParameters()).ToList(); ;
                Vehicle a = new Vehicle();
                IEnumerable<dynamic> iter = connection.Query("CALL ViewAllCompletedTrips();", new DynamicParameters()).ToList();
                int count = 0;
                foreach (var row in iter)
                {
                    Trip temp = output.ElementAt<Trip>(count);
                    temp.Trip_ID = row.Trip_ID;

                    output.ElementAt<Trip>(count).Trip_ID = row.Trip_ID;
                    output.ElementAt<Trip>(count).Start_Location = row.Start_Location;
                    output.ElementAt<Trip>(count).End_Location = row.End_Location;
                    output.ElementAt<Trip>(count).User = User.GetUser(row.User_ID);
                    output.ElementAt<Trip>(count).Driver = User.GetUser(row.Driver_ID);
                    output.ElementAt<Trip>(count).Vehicle = FleetManagementSystemClassLibrary.Vehicle.getVehicle(Convert.ToInt32(row.Vehicle_ID));
                    output.ElementAt<Trip>(count).Start_Date = Convert.ToDateTime(row.Start_Date);
                    count++;
                }

                return output;
            }
        }

        public static void CompleteTrip(int Trip_ID, int Vehicle_ID)
        {
           
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Execute("CALL CompleteTrip(@Trip_ID, @Vehicle_ID);", new {Trip_ID, Vehicle_ID});
            }
        }

        public static Trip getTrip(int Trip_ID)
        {
            throw new System.NotImplementedException();
        }

        public static void updateTrip(int Trip_ID)
        {

        }
    }
}