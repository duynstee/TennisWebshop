  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;
using Interfaces;

namespace Logic
{
    public class Customer
    {
        public bool test { get; set; }

        public int CustomerID;
        public string CustomerEmail;
        public string CustomerPassword;
        public string CustomerName;
        public string CustomerAddress;
        public string CustomerPhoneNumber;
        public bool LoggedIn = false;

        private List<OrderList> listOrders = new List<OrderList>();

        public Customer()
        {
            test = false;
        }

        public Customer(bool test)
        {
            this.test = test;
        }
        public void AddProdToOrder(int productID, int customerID)
        {
            CustomerInterface dbMan = CustomerFactory.GetCustomerInterface(test);
            dbMan.AddProdToOrder(productID, customerID);
        }

        public void RemoveProdFromOrder(int orderItemID)
        {
            CustomerInterface dbMan = CustomerFactory.GetCustomerInterface(test);
            dbMan.RemoveProdFromOrder(orderItemID);
        }
    }
}
