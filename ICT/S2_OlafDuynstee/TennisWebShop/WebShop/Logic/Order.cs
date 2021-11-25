using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Order
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ProductID  { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Size { get; set; }

        public Order()
        {
            
        }
        public Order(int id, int orderId, int productID, int quantity)
        {
            ID = id;
            OrderID = orderId;
            ProductID = productID;
            Quantity = quantity;
        }
    }
}
