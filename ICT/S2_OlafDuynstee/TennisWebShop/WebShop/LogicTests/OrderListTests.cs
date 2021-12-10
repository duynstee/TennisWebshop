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
        [TestMethod()]
        public void GetOrderListTest()
        {
            CustomerCollection cc = new CustomerCollection();
            string testEmail = "olaf.duynstee@gmail.com";
            OrderList oL = new OrderList();
            Customer testCustomer = new Customer();
            // Arrange

            testCustomer = cc.GetCustomerInfo(testEmail);
            List<Order> orders = oL.GetOrderList(testCustomer.CustomerID);
            // Act

            // Assert
            Assert.IsNotNull(orders);
        }
    }
}