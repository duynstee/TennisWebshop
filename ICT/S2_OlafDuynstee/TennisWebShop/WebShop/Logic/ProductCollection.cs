using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Data;

namespace Logic
{
    public class ProductCollection
    {
        public List<Product> GetproductList()
        {
            ProductDatabaseManager dbMan = new ProductDatabaseManager();
            var products = dbMan.GetAllProducts();

            List<Product> productList = new List<Product>();

            foreach (var product in products)
            {
                Product prod = new Product();
                prod.Name = product.Name;
                prod.Size = product.Size;
                prod.Price = product.Price;
                prod.Quantity = product.Quantity;
                prod.Description = product.Description;
                productList.Add(prod);
            }

            return productList;

            /*productList.Add(new Product("Product1", "M","5" , 3, "lalala"));
            productList.Add(new Product("Product2", "S", "20", 4, "blablabla"));
            productList.Add(new Product("naam 3", "S", "25",  4, "mooie beschrijving"));
            return productList;*/
        } 
    }
}
