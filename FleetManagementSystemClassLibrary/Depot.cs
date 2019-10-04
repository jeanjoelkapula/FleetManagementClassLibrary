using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySql;
using Dapper;

namespace FleetManagementSystemClassLibrary
{
    public class Depot
    {
        public int Depot_ID
        {
            get; set;
        }

        public string Depot_Name
        {
            get; set;
        }

        public string Depot_Address
        {
            get; set;
        }

        public void editDepot()
        {
            throw new System.NotImplementedException();
        }

        public void addDepot()
        {
            throw new System.NotImplementedException();
        }

        public void viewDepots()
        {
            throw new System.NotImplementedException();
        }

        public static Depot GetDepot(int Depot_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Depot>("CALL getDepot(@Depot_ID);", new { Depot_ID }).FirstOrDefault();
                return output;
            }
        }

    }
}