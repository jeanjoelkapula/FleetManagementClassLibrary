using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public static void ScheduleTrip()
        {
            throw new System.NotImplementedException();
        }
    }
}