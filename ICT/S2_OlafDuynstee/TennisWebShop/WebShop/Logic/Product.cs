using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class Product
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }


        public Product()
        {

        }
        public Product(string name, string size, int quantity, string description)
        {
            name = this.Name;
            size = this.Size;
            quantity = this.Quantity;
            description = this.Description;
        }
    }
}
