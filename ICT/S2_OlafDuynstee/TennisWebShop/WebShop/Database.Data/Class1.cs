using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace Database.Data
{
    public class ProductDatabaseManager
    {
        private string connectionString =
            "Data Source=localhost;Initial Catalog=WebShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<ProductDto> GetAllProducts()
        {
            List<ProductDto> products = new List<ProductDto>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("select * from Product"))
                {
                    conn.Open();

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductDto prod = new ProductDto();
                        prod.ProductID = reader.GetInt32(0);
                        prod.ProductName = reader.GetString(1);
                        prod.Price = reader.GetInt32(2);
                        prod.Quantity = reader.GetInt32(3);

                        products.Add(prod);
                    }
                }
            }

            return products;
        }
    }
}
