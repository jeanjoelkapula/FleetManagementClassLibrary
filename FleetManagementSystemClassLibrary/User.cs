using System;
using Dapper;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FleetManagementSystemClassLibrary
{
    public class User
    {
        public int User_ID
        {
            get; set;
        }

        public string First_Name
        {
            get; set;
        }

        public string Last_Name
        {
            get; set;
        }

        public string Username
        {
            get; set;
        }

        public string Password
        {
            get; set;
        }

        public int Role_ID { get; set; }

        public string Title { get; set; }


        public string Contact_Number
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public string Status { get; set; }



        public static User RegisterUser(User user)
        {
            using(MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<User>("CALL AddUser(@Role_ID, @First_Name, @Last_Name, @Username, @Contact_Number, @Email);", user).FirstOrDefault();
                return output;
            }
        }

        public static User GetLoggedUserDetails(string Username, string Password)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<User>("CALL GetLoggedUserDetails(@Username, @Password);", new { Username, Password }).ToList().FirstOrDefault();

                return output;
            }
        }

        public static bool AuthenticateUser(string Username, String Password)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<bool>("select ValidateUser(@Username, @Password);", new { Username, Password }).FirstOrDefault();
                return output;
            }
        }

        public static void SuspendUser(int User_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Execute("CALL SuspendUser(@User_ID);", new { User_ID});
               
            }
        }

        public static User GetUser(int User_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<User>("CALL GetUserDetails(@User_ID);", new { User_ID }).FirstOrDefault();
                return output;
            }
        }

        public static List<User> GetMechanics()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<User>("CALL GetMechanics();").ToList();
                return output;
            }
        }

        public static List<User> GetAllUsers()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<User>("CALL GetAllUsers();").ToList();
                return output;
            }
        }

        public static List<User> GetAllOperationsEmployees()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<User>("CALL GetAllOperationsEmployees();").ToList();
                return output;
            }
        }

        public static void UpdateUser(User user)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                connection.Execute("CALL UpdateUser(@User_ID, @Role_ID, @First_Name, @Last_Name, @Username, @Password, @Contact_Number, @Email, @Status);", user);
            }

        }

        public static List<User> FilterUserByRole(string role)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<User>("CALL FilterUsersByRole(@role);", new { role }).ToList();
                return output;
            }
        }

        public static bool isUsernameValid(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<bool>("select UserNameExists(@username);", new { username }).FirstOrDefault();
                return output;
            }
        }

        public static void ResetPassword(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Execute("CALL ResetPassword(@username, @password);", new { username, password });
                
            }
        }

        public static List<User> FilterUserByStatus(string status)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<User>("CALL FilterUsersByStatus(@status);", new { status }).ToList();
                return output;
            }
        }

        public static string LoadConnectionString(string id = "fleetmanagementDB")
        {
            
                return ConfigurationManager.ConnectionStrings[id].ConnectionString;            
            
        }
    }
}