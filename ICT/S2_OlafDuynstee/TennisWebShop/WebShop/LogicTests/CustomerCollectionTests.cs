using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Logic.Tests
{
    [TestClass()]
    public class CustomerCollectionTests
    {
        private bool test = true;
        [TestMethod()]
        public void CreateCustomerTest_With_Used_Email()
        {
            // Arrange
            CustomerCollection cc = new CustomerCollection(test);
            Customer customer = new Customer(test);
            customer.CustomerEmail = "olaf.duynstee@gmail.com";
            customer.CustomerPassword = "test123";

            // Act

            // Assert
            Assert.IsFalse(cc.CreateCustomer(customer));
        }

        [TestMethod()]
        public void LoginCustomerTest_With_Wrong_Inlog()
        {
            // Arrange
            CustomerCollection cc = new CustomerCollection(test);
            Customer c = new Customer(test);
            c.CustomerEmail = "Olaf.duynstee@gmail.com";
            c.CustomerPassword = "WrongPassword";
            c.LoggedIn = false;
            // Act
            Customer newc = cc.LoginCustomer(c);
            // Assert
            Assert.IsFalse(newc.LoggedIn);
        }

        [TestMethod()]
        public void LoginCustomerTest_With_Correct_Login()
        {
            // Arrange
            CustomerCollection cc = new CustomerCollection(test);
            Customer c = new Customer(test);
            c.CustomerEmail = "Olaf.duynstee@gmail.com";
            c.CustomerPassword = "Gorilla2";
            c.LoggedIn = false;
            // Act
            Customer newc = cc.LoginCustomer(c);
            // Assert
            Assert.IsTrue(newc.LoggedIn);
        }

        [TestMethod()]
        public void ChangePasswordTest_With_Wrong_Password()
        {
            // Arrange
            CustomerCollection cc = new CustomerCollection(test);
            string customerEmail = "olaf.duynstee@gmail.com";
            string oldPassword = "Gorilla";
            string newPassword = "Gorilla3";
            // Act
            bool testResult = cc.ChangePassword(customerEmail, oldPassword, newPassword);
            // Assert
            Assert.IsFalse(testResult);
        }
        
        [TestMethod()]
        public void ChangePasswordTest_With_Correct_Password()
        {
            // Arrange
            CustomerCollection cc = new CustomerCollection(test);
            string customerEmail = "olaf.duynstee@gmail.com";
            string oldPassword = "Gorilla2";
            string newPassword = "Gorilla2";
            // Act
            bool testResult = cc.ChangePassword(customerEmail, oldPassword, newPassword);
            // Assert
            Assert.IsTrue(testResult);
        }
    }
}