using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Database.Data;
using Factory;
using Interfaces;

namespace Logic
{
    public class ProductCollection
    {
        public List<Product> GetProductList()
        {
            //ProductDatabaseManager dbMan = new ProductDatabaseManager();
            ProductInterface dbMan = ProductFactory.GetProductInterface();
            
            var products = dbMan.GetAllProducts();

            List<Product> productList = new List<Product>();

            foreach (var product in products)
            {
                Product prod = new Product();
                prod.ProductName = product.ProductName;
                prod.Size = product.Size;
                prod.Price = product.Price;
                prod.Quantity = product.Quantity;
                prod.Description = product.Description;
                productList.Add(prod);
            }

            return productList;
        } 
    }
}
