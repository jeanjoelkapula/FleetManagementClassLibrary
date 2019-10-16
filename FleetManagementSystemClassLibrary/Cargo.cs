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

        public Cargo(int Cargo_ID,decimal Cargo_Weight,string Cargo_Description)
        {
            this.Cargo_ID = Cargo_ID;
            this.Cargo_Weight = Cargo_Weight;
            this.Cargo_Description = Cargo_Description;
        }

        public void packCargo()
        {
            throw new System.NotImplementedException();
        }

        public void newCargo(decimal Cargo_Weight, string Cargo_Description)
        {
            using (MySqlConnection connection = new MySqlConnection(User.LoadConnectionString()))
            {
                try
                {
                    var output = connection.Query<Cargo>("CALL NewCargo(@Cargo_Weight, @Cargo_Description);", new {Cargo_Weight = Cargo_Weight, Cargo_Description = Cargo_Description }).ToList();
                    
                }
                catch (Exception e)
                {
                    
                }
            }
        }

        public void editCargo()
        {
            throw new System.NotImplementedException();
        }
    }
}