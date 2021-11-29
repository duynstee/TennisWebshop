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
        public string CustomerEmail;
        public string CustomerPassword;
        public string CustomerName;
        public string CustomerAddress;
        public string CustomerPhoneNumber;
        
        private List<OrderList> listOrders = new List<OrderList>();

        public void AddProdToOrder(int productID)
        {
            CustomerInterface dbMan = CustomerFactory.GetCustomerInterface();
            dbMan.AddProdToOrder(productID);
        }

        public void RemoveProdFromOrder(int orderItemID)
        {
            CustomerInterface dbMan = CustomerFactory.GetCustomerInterface();
            dbMan.RemoveProdFromOrder(orderItemID);
        }
    }
}
