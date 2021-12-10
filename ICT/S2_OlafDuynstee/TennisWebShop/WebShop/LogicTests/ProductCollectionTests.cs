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
        [TestMethod()]
        public void GetProductList_Is_List_Of_Products()
        {
            // Arrange
            ProductCollection pc = new ProductCollection();
            List<Product> products = pc.GetProductList();
            // Act
            
            // Assert
            Assert.IsNotNull(products);
        }
    }
}