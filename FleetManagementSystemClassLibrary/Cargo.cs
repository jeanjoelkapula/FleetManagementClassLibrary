using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public CargoType CargoType
        {
            get; set;
        }

        public List<Goods> Goods
        {
            get; set;
        }

        public void packCargo()
        {
            throw new System.NotImplementedException();
        }

        public void editCargo()
        {
            throw new System.NotImplementedException();
        }
    }
}