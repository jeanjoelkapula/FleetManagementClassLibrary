using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Dapper;
namespace FleetManagementSystemClassLibrary
{
    public class Cargo_Package
    {

        public int Cargo_Package_ID
        {
            get; set;
        }

        public List<Cargo> Cargo_ID
        {
            get; set;
        }

        public int Trip_ID
        {
            get; set;
        }
        public int Order_ID
        {
            get; set;
        }

        public void InsertPackage()
        {
            
          
        }

        public void AddCargo(Cargo cargo)
        {
            Cargo_ID.Add(cargo);
        }

        public Cargo_Package()
        {
            Cargo_ID = new List<Cargo>();
        }

        public static int GetNewestCargo()
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                var output = connection.Query<int>("CALL GetCargoId();", new DynamicParameters()).First();
                return output;
            }
        }

        public void AddPackage(List<int> Cargo_IDs,int Trip_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
            //    try
               // {
                    foreach (int Cargo_ID in Cargo_IDs)
                    {
                        var output = connection.Execute("CALL AddCargoPackage(@Cargo_ID, @Trip_ID);", new {Cargo_ID , Trip_ID});
                    }
             //   }
              //  catch (Exception e)
            //    {
                    
              //  }
            }

        }
/*
        public Cargo_Package(List<Cargo> Cargo_ID, int Trip_ID)
        {
            this.Cargo_ID = Cargo_ID;
            this.Trip_ID = Trip_ID;
        } */
    }
}