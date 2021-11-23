using System;
using Database.Data;
using Interfaces;

namespace Factory
{
    public static class ProductFactory
    {
        public static ProductInterface GetProductInterface()
        {
            return new ProductDatabaseManager();
        }
    }
}
