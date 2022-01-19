using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Tests
{
    [TestClass()]
    public class ProductCollectionTests
    {
        private bool test = true;

        [TestMethod()]
        public void GetProductList_Is_List_Of_Products()
        {
            // Arrange
            ProductCollection pc = new ProductCollection(test);
            List<Product> products = pc.GetProductList();
            // Act
            
            // Assert
            Assert.IsNotNull(products);
        }
    }
}