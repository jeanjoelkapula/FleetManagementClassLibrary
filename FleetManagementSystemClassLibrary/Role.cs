using MySql.Data.MySqlClient;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace FleetManagementSystemClassLibrary
{
    public class Role
    {
        public int Role_ID
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

        public static List<string> GetRoles()
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<string>("CALL GetRoles();").ToList();
                return output;
            }
        }

        public static Role GetRole(string title)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Role>("CALL GetRole(@title);", new { title }).FirstOrDefault();
                return output;
            }
        }
        public static Role GetRoleByID(int ID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Role>("CALL GetRoleByID(@ID);", new { ID }).FirstOrDefault();
                return output;
            }
        }

        public void addRole()
        {
            throw new System.NotImplementedException();
        }

        public void editRole()
        {
            throw new System.NotImplementedException();
        }

        private static string LoadConnectionString(string id = "fleetmanagementDB")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}