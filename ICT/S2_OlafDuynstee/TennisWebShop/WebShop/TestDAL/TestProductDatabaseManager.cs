using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace TestDAL
{
    public class TestProductDatabaseManager
    {
        public List<ProductDto> GetAllProducts()
        {
            List<ProductDto> testList = new List<ProductDto>();
            ProductDto product1 = new ProductDto();
            ProductDto product2 = new ProductDto();
            ProductDto product3 = new ProductDto();

            testList.Add(product1);
            testList.Add(product2);
            testList.Add(product3);
            return testList;
        }
    }
}
