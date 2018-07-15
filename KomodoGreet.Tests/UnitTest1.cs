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
        public void CustomerRepository_CreateCustomer_ShouldDisplayDetailsForPotentialCustomer()
        {
            //Arrange
            var mockConsole = new MockConsole(new string[]
                {"1", "3", "Jane", "Doe", "123 Main Street", "Indianapolis", "IN", "46208", "2"});
            var customerUI = new CustomerUI(mockConsole);

            //Act
            customerUI.Run();

            //Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Doe, Jane - Potential");
        }

        [TestMethod]
        public void CustomerRepository_CreateCustomer_ShouldDisplayDetailsForPastCustomer()
        {
            //Arrange
            var mockConsole = new MockConsole(new string[]
                {"1", "2", "John", "Smith", "456 S. Central Street", "Indianapolis", "IN", "46208", "2"});
            var customerUI = new CustomerUI(mockConsole);

            //Act
            customerUI.Run();

            //Assert
            var outputText = mockConsole.Output;
            StringAssert.Contains(outputText, "Smith, John - Past");
        }

        [TestMethod]
        public void CustomerRepository_CreateCustomer_ShouldDisplayDetailsForCurrentCustomer()
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
        public void CustomerRepository_Search_ShouldReturnDetailsForCustomerByLastName()
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
        public void CustomerRepository_Search_ShouldReturnNoCustomerMessageIfNoMatch()
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
