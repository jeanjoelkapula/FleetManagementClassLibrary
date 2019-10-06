using System;
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
            
            get => default(int);
            set
            {
            }
            
        }

        public Depot End_Location
        {
            get; set;
        }

        public Depot Start_Location
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

        public Vehicle Vehicle
        {
            get; set;
        }

        public List<Cargo> Cargo_Package
        {
            get; set;
        }

        public static void ScheduleTrip(int User_ID,int Vehicle_ID, int Start_Location, int End_Location, int Distance)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Execute("CALL NewTrip(@User_ID,@Vehicle_ID, @Start_Location, @End_Location, @Distance);", new {User_ID,Vehicle_ID ,Start_Location, End_Location, Distance });
            }
        }

        public static List<Trip> getAllTrips()
        {
            throw new System.NotImplementedException();
        }

        public static List<Trip> getAllActiveTrips()
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL ViewAllActiveTrips();").ToList();
                return output;
            }
        }


        public static List<Trip> getAllPendingTrips()
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Trip>("CALL ViewAllPendingTrips();").ToList(); ;

                IEnumerable<dynamic> iter = connection.Query("CALL ViewAllPendingTrips();").ToList();
                int count = 0;
                foreach (var row in iter)
                {
                    Trip temp = output.ElementAt<Trip>(count);
                    temp.Trip_ID = row.Trip_ID;
                    
                    output.ElementAt<Trip>(count).Trip_ID = row.Trip_ID;
                    output.ElementAt<Trip>(count).Start_Location = Depot.GetDepot(row.Start_Location_ID);
                    output.ElementAt<Trip>(count).End_Location = Depot.GetDepot(row.End_Location_ID);
                    output.ElementAt<Trip>(count).User = User.GetUser(row.User_ID);
                    output.ElementAt<Trip>(count).Vehicle = Vehicle.getVehicle(Convert.ToInt32(row.Vehicle_ID));
                    output.ElementAt<Trip>(count).Start_Date = row.Start_Date;
                    count++;
                }

                return output;
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