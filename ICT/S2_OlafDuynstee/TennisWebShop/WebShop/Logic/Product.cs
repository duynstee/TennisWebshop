using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }


        public Product()
        {

        }
        public Product(string productName, string size, string price, int quantity, string description)
        {
            ProductName = productName;
            Size = size;
            Price = price;
            Quantity = quantity;
            Description = description;
        }
    }
}
