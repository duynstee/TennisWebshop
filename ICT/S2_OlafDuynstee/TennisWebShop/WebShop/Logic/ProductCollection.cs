using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ProductCollection
    {
        public List<Product> GetproductList()
        {
            List<Product> productList = new List<Product>();

            productList.Add(new Product("Product1", "M", 3, "lalala"));
            productList.Add(new Product("Product2", "S", 4, "blablabla"));
            productList.Add(new Product("naam 3", "S", 4, "mooie beschrijving"));
            return productList;


        } 
    }
}
