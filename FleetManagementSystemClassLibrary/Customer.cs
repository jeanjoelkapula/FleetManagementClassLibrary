using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FleetManagementSystemClassLibrary
{
    public class Customer
    {
        public int Customer_ID
        {
            get; set;
        }
        public Customer(string Customer_First_Name, string Customer_Last_Name, string ContactNumber, string Email)
        {
            this.Customer_First_Name = Customer_First_Name;
            this.Customer_Last_Name = Customer_Last_Name;
            this.ContactNumber = ContactNumber;
            this.Email = Email;
        }
        public string Customer_First_Name
        {
            get; set;
        }
        public string Customer_Last_Name
        {
            get; set;
        }
        public string Email
        {
            get; set;
        }
        public string ContactNumber
        {
            get; set;
        }

        public void addCustomer()
        {
            throw new System.NotImplementedException();
        }

        public void editCustomer()
        {
            throw new System.NotImplementedException();
        }
    }
}