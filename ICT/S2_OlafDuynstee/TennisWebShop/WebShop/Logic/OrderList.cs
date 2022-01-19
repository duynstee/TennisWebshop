using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Data;
using Factory;
using Interfaces;

namespace Logic
{
    public class OrderList
    {
        public bool test { get; set; }

        public OrderList()
        {
            test = false;
        }

        public OrderList(bool test)
        {
            this.test = test;
        }
        public List<Order> GetOrderList(int customerID)
        {
            OrderInterface dbMan = OrderFactory.GetOrderInterface(test);

            var orders = dbMan.GetAllOrders(customerID);

            List<Order> orderIDList = new List<Order>();
            
            foreach (var order in orders)
            {
                Order ord = new Order();
                ord.OrderItemID = order.OrderItemId;
                ord.ProductName = order.ProductName;
                ord.Price = order.Price;
                ord.Size = order.Size;
                ord.Quantity = order.Quantity;
                orderIDList.Add(ord);
            }
            return orderIDList;
        }
    }
}
