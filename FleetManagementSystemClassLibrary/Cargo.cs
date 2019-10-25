using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Dapper;
namespace FleetManagementSystemClassLibrary
{
    public class Cargo
    {
        public int Cargo_ID
        {
            get; set;
        }

        public decimal Cargo_Weight
        {
            get; set;
        }

        public string Cargo_Description
        {
            get; set;
        }
        public Cargo()
        {

        }
        public Cargo(decimal Cargo_Weight, string Cargo_Description)
        {

            this.Cargo_Weight = Cargo_Weight;
            this.Cargo_Description = Cargo_Description;
        }

        public void packCargo()
        {
            throw new System.NotImplementedException();
        }
        /*
                public static Cargo GetCargoID(decimal weight, string description)
                {
                    using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
                    {
                        var output = connection.Query<Cargo>("CALL GetCargoId(@Trip_ID);", new {weight, description });
                        return output;
                    }
                }
                */
        public static int newCargo(decimal Cargo_Weight, string Cargo_Description)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                try
                {
                    var output = connection.Query<int>("CALL NewCargo(@Cargo_Weight, @Cargo_Description);", new { Cargo_Weight, Cargo_Description }).FirstOrDefault();
                    return output;
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
        }

        public static List<Cargo> GetPackageOnTrip(int Trip_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<Cargo>("CALL GetPackageOnTrip(@Trip_ID);", new { Trip_ID }).ToList();
                return output;
            }
        }
        public static int GetCargoID(decimal Cargo_Weight, string Cargo_Description)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<int>("CALL GetCargoByID(@Cargo_Weight, @Cargo_Description);", new { Cargo_Weight, Cargo_Description }).FirstOrDefault();
                return output;
            }
        }
        public static void DeleteCargo(int Cargo_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                try
                {
                    var output = connection.Execute("CALL DeleteCargo(@Cargo_ID);", new { Cargo_ID });

                }
                catch (Exception e)
                {

                }
            }
        }

        public int GetLatestCargoID()
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<int>("CALL GetCargoByID(@Cargo_Weight, @Cargo_Description);", new { Cargo_Weight, Cargo_Description }).FirstOrDefault();
                return output;
            }
        }
        public void editCargo()
        {
            throw new System.NotImplementedException();
        }
    }
}