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
        private string Name;
        private string Address;
        private string PhoneNumber;
        private string Email;
        private string Password;

        private List<OrderList> ListOrders = new List<OrderList>();

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
