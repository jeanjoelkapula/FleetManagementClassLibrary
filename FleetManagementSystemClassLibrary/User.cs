using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FleetManagementSystemClassLibrary
{
    public class User
    {
        public int User_ID
        {
            get;set;
        }

        public string First_Name
        {
            get; set;
        }

        public string Last_Name
        {
            get; set;
        }

        public int Username
        {
            get; set;
        }

        public string Password
        {
            get; set;
        }

        public string Contact_Number
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public Role Role
        {
            get; set;
        }

        public static void RegisterUser()
        {
            throw new System.NotImplementedException();
        }

        public void LoginUser()
        {
            throw new System.NotImplementedException();
        }
    }
}