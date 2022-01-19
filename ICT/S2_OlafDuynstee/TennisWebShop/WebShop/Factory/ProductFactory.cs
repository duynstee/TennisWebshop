using System;
using Database.Data;
using Interfaces;
using TestDAL;

namespace Factory
{
    public static class ProductFactory
    {
        public static ProductInterface GetProductInterface(bool test)
        {
            if (test == false)
            {
                return new ProductDatabaseManager();
            }
            else
            {
                return new TestProductDatabaseManager();
            }
            
        }
    }
}
