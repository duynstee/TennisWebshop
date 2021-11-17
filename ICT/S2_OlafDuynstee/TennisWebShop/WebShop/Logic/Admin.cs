using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class Admin
    {
        public string Name { get; set; }
        public string Password { get; set; }

        void AddProduct(Product product, List<Product> productList)
        {
            productList.Add(product);
        }

        void Remove(Product product, List<Product> productList)
        {
            productList.Remove(product);
        }
    }
}
