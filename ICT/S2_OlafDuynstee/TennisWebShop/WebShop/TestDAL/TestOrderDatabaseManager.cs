using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace TestDAL
{
    public class TestOrderDatabaseManager : OrderInterface, CustomerInterface
    {
        public List<OrderDto> GetAllOrders(int customerid)
        {
            List<OrderDto> orders = new List<OrderDto>();
            OrderDto order1 = new OrderDto();
            OrderDto order2 = new OrderDto();
            OrderDto order3 = new OrderDto();
            orders.Add(order1);
            orders.Add(order2);
            orders.Add(order3);
            return orders;
        }

        public void AddProdToOrder(int customerId, int productId)
        {

        }

        public void RemoveProdFromOrder(int orderItemId){}
    }
}
