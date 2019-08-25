using System;
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

        public void updateService()
        {

        }
    }
}