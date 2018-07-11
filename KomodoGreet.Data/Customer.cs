using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreet.Data
{
    public enum CustomerType
    {
        Current = 1,
        Past = 2,
        Potential = 3
    }

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public CustomerType CustomerType { get; set; }
        
        public Customer() { }

        public Customer(string firstName, string lastName, string streetAddress,
            string city, string state, string zipCode, CustomerType customerType)
        {
            FirstName = firstName;
            LastName = lastName;
            StreetAddress = streetAddress;
            City = city;
            State = state;
            ZipCode = zipCode;
            CustomerType = customerType;
        }
    }
}
