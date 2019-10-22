using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;


namespace FleetManagementSystemClassLibrary
{
    public class Parts
    {
        public int Part_ID
        {
            get; set;
        }

        public string Part_Name
        {
            get; set;
        }

        public int Quantity
        {
            get; set;
        }

        public string Service_ID
        {
            get; set;
        }

 
        public static void AddPart(string serviceID, string partName, int partQuantity)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                connection.Execute("CALL AddPart(@serviceID, @partName, @partQuantity);", param: new { serviceID, partName, partQuantity });
            }
        }

        public static void DeleteParts(string serviceID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                connection.Execute("CALL DeleteParts(@serviceID);", param: new { serviceID });
            }
        }

        public static void DeletePart(int partID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                connection.Execute("CALL DeletePart(@partID);", param: new { partID });
            }
        }

        public static List<Parts> GetPartsPerService(string serviceID)
        {
            using (MySqlConnection connection = new MySqlConnection(LoadConnectionString()))
            {
                var output = connection.Query<Parts>("CALL GetPartsPerService(@serviceID);", param: new { serviceID }).ToList();
                return output;
            }
        }


        private static string LoadConnectionString(string id = "fleetmanagementDB")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }


        public void addPart()
        {
            throw new System.NotImplementedException();
        }
    }
}