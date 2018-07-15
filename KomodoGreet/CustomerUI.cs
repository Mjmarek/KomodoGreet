using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using KomodoGreet.BLL;
using KomodoGreet.Contracts;
using KomodoGreet.Data;

namespace KomodoGreet
{
    public class CustomerUI
    {
        private IConsole _console;
        public CustomerRepository CustomerRepository;

        public CustomerUI(IConsole console)
        {
            _console = console;
            CustomerRepository = new CustomerRepository();
        }

        public void Run()
        {
            bool finished = false;
            do
            {
                _console.Write("Welcome to Komodo!\n" +
                               "What would you like to do?\n" +
                               "1: Add a customer\n" +
                               "2: See all customers\n" +
                               "3: Search for customers\n" +
                               "4: Exit program\r\n");
                var menuChoice = _console.ReadLine();
                
                if (String.IsNullOrWhiteSpace(menuChoice))
                {
                    finished = true;
                }
                else if (menuChoice == "1")
                {
                    Create();
                }
                else if (menuChoice == "2")
                {
                    SeeAllCustomers();
                }
                else if (menuChoice == "3")
                {
                    Search();
                }
                else if (menuChoice == "4")
                {
                    finished = true;
                }
                
            } while (!finished);
        }

        public void Create()
        {
            _console.Clear();

            _console.WriteLine("What type of customer is this?\n" +
                               "1: Current\n" +
                               "2: Past\n" +
                               "3: Potentional");
            string selection = _console.ReadLine();
            int selectionType = int.Parse(selection);
            CustomerType userType = (CustomerType) selectionType;

            _console.WriteLine("What is the customer's first name?");
            string userFirst = _console.ReadLine();

            _console.WriteLine("What is the customer's last name?");
            string userLast = _console.ReadLine();

            _console.WriteLine("What is the customer's street address?");
            string userAddress = _console.ReadLine();

            _console.WriteLine("What city does the customer live in?");
            string userCity = _console.ReadLine();

            _console.WriteLine("What state does the customer live in?");
            string userState = _console.ReadLine();

            _console.WriteLine("What is the customer's zipcode?");
            string userZip = _console.ReadLine();

            var customer = CustomerRepository.Create(userFirst, userLast, userAddress, userCity, userState, userZip, userType);
            CustomerRepository.AddCustomerToList(customer);

            _console.Clear();
        }

        public void SeeAllCustomers()
        {
            _console.Clear();

            var customers = CustomerRepository.GetAllCustomers();

            foreach (var customer in customers)
            {
                _console.WriteLine($"{customer.LastName}, {customer.FirstName} - {customer.CustomerType}\n");
            }
        }

        public void Search()
        {
            _console.Clear();

            _console.WriteLine("Please enter the last name of the customer you'd like to search for:");
            string searchLastName = _console.ReadLine();

            var customers = CustomerRepository.GetCustomersByName(searchLastName);

            if (customers.Count == 0)
            {
                _console.WriteLine("There are no customers with that last name.\n");
            }
            else
            {
                foreach (var customer in customers)
                {
                    _console.WriteLine($"{customer.FirstName} {customer.LastName}\n" +
                                       $"{customer.StreetAddress}\n" +
                                       $"{customer.City}, {customer.State} {customer.ZipCode}\n");
                }
            }
        }
    }
}
