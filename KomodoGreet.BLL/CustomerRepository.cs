using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoGreet.Data;

namespace KomodoGreet.BLL
{
    public class CustomerRepository
    {
        private List<Customer> _customerList = new List<Customer>();

        public Customer Create(string firstName, string lastName, string streetAddress,
            string city, string state, string zipCode, CustomerType customerType)
        {
            switch (customerType)
            {
                case CustomerType.Current:
                    return new Customer(firstName, lastName, streetAddress, city, state, zipCode, CustomerType.Current);
                case CustomerType.Past:
                    return new Customer(firstName, lastName, streetAddress, city, state, zipCode, CustomerType.Past);
                case CustomerType.Potential:
                    return new Customer(firstName, lastName, streetAddress, city, state, zipCode, CustomerType.Potential);
                default:
                    throw new Exception("Unknown customer type");
            }
        }

        public void AddCustomerToList(Customer customer)
        {
            _customerList.Add(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerList;
        }

        public List<Customer> GetCustomersByName(string searchLastName)
        {
            var matchedNames = new List<Customer>();

            foreach (var customer in _customerList)
            {
                if (customer.LastName == searchLastName)
                {
                    matchedNames.Add(customer);
                }
            }

            return matchedNames;
        }
    }
}
