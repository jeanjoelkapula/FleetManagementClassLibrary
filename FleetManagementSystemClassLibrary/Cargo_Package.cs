using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FleetManagementSystemClassLibrary
{
    public class Cargo_Package
    {

        public string Description
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
        public decimal Weight
        {
            get; set;
        }

        public void AddCargo(Cargo cargo)
        {
            Cargo_ID.Add(cargo);
        }
        public Cargo_Package(List<Cargo> Cargo_ID, int Trip_ID, string Description, decimal Weight)
        {
            this.Cargo_ID = Cargo_ID;
            this.Trip_ID = Trip_ID;
            this.Description = Description;
            this.Weight = Weight;
        }
    }
}