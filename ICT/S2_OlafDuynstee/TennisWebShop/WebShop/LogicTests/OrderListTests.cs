using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Tests
{
    [TestClass()]
    public class OrderListTests
    {
        private bool test = true;
        [TestMethod()]
        public void GetOrderListTest()
        {
            CustomerCollection cc = new CustomerCollection(test);
            string testEmail = "olaf.duynstee@gmail.com";
            OrderList oL = new OrderList();
            Customer testCustomer = new Customer(test);
            // Arrange

            testCustomer = cc.GetCustomerInfo(testEmail);
            List<Order> orders = oL.GetOrderList(testCustomer.CustomerID);
            // Act

            // Assert
            Assert.IsNotNull(orders);
        }
    }
}