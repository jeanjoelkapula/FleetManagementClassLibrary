using System;
using System.Collections.Generic;
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

        public int Hours_Worked
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
    }
}