using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoGreet.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Customer_CreatePotentialCustomer_ShouldSucceed()
        {
            //Arrange
            var mockConsole = new MockConsole(new string[]
                {"1", "3", "Jane", "Doe", "123 Main Street", "Indianapolis", "IN", "46208", "2"});
            var customerUI = new CustomerUI(mockConsole);

            //Act
            customerUI.Run();

            //Assert
            //TODO - remove: var customerRepository = customerUI.CustomerRepository;
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Doe, Jane - Potential");
        }

        [TestMethod]
        public void Customer_CreatePastCustomer_ShouldSucceed()
        {
            //Arrange
            var mockConsole = new MockConsole(new string[]
                {"1", "2", "John", "Smith", "456 S. Central Street", "Indianapolis", "IN", "46208", "2"});
            var customerUI = new CustomerUI(mockConsole);

            //Act
            customerUI.Run();

            //Assert
            //TODO - remove: var customerRepository = customerUI.CustomerRepository;
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Smith, John - Past");
        }

        [TestMethod]
        public void Customer_CreateCurrentCustomer_ShouldSucceed()
        {
            //Arrange
            var mockConsole = new MockConsole(new string[]
                {"1", "1", "Amy", "Pond", "52 N. Police Box Lane", "Chicago", "IL", "60630", "2"});
            var customerUI = new CustomerUI(mockConsole);

            //Act
            customerUI.Run();

            //Assert
            var customerRepository = customerUI.CustomerRepository;
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Pond, Amy - Current");
        }

        [TestMethod]
        public void Customer_SearchCustomer_ShouldSucceed()
        {
            //Arrange
            var mockConsole = new MockConsole(new string[]
                {"1", "1", "Amy", "Pond", "52 N. Police Box Lane", "Chicago", "IL", "60630", "3", "Pond"});
            var customerUI = new CustomerUI(mockConsole);

            //Act
            customerUI.Run();

            //Assert
            var customerRepository = customerUI.CustomerRepository;
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "52 N. Police Box Lane");
        }

        [TestMethod]
        public void Customer_SearchCustomerNotInList_ShouldSucceed()
        {
            //Arrange
            var mockConsole = new MockConsole(new string[]
                {"1", "1", "Amy", "Pond", "52 N. Police Box Lane", "Chicago", "IL", "60630", "3", "Smith"});
            var customerUI = new CustomerUI(mockConsole);

            //Act
            customerUI.Run();

            //Assert
            var customerRepository = customerUI.CustomerRepository;
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "There are no customers with that last name.");
        }
    }
}
