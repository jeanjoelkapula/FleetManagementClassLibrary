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

        public void AddPackage(int Trip_ID)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
            //    try
               // {
                    foreach (Cargo cp in Cargo_ID)
                    {
                        var output = connection.Execute("CALL AddCargoPackage(@Cargo_ID, @Trip_ID);", new { cp.Cargo_ID, Trip_ID});
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