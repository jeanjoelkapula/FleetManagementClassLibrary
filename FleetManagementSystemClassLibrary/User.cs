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

        public static void registerUser()
        {
            throw new System.NotImplementedException();
        }
        public static void LoginUser()
        {
            throw new System.NotImplementedException();
        }


        public static User getUser(int User_ID)
        {
            throw new System.NotImplementedException();
        }

        public static List<User> getAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public static void updateUser(int User_ID)
        {
            throw new System.NotImplementedException();

        }

        public static void suspendUser(int User_ID)
        {
            throw new System.NotImplementedException();
        }
    }
}