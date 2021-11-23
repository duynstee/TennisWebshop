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
        public List<Order> GetOrderList()
        {
            OrderInterface dbMan = OrderFactory.GetOrderInterface();

            var orders = dbMan.GetAllOrders();

            List<Order> orderIDList = new List<Order>();
            

            foreach (var order in orders)
            {
                Order ord = new Order();
                ord.OrderID = order.OrderID;
                ord.ProductID = order.ProductID;
                ord.Quantity = order.Quantity;
                ord.ProductName = order.ProductName;
                orderIDList.Add(ord);
            }

            return orderIDList;
        }
    }
}
