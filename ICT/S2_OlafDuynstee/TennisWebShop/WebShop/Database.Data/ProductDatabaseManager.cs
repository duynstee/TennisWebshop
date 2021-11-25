using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Database.Data
{
    public class ProductDatabaseManager : ProductInterface
    {
        private string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebshopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<ProductDto> GetAllProducts()
        {
            List<ProductDto> products = new List<ProductDto>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("select * from Products", conn))
                {
                    conn.Open();

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductDto prod = new ProductDto();
                        prod.ProductId = reader.GetInt32(0);
                        prod.ProductName = reader.GetString(1);
                        prod.Size = reader.GetString(2);
                        prod.Price = reader.GetString(3);
                        prod.Quantity = reader.GetInt32(4);
                        prod.Description = reader.GetString(5 );

                        products.Add(prod);
                    }
                }
            }
            return products;
        }

    }
}
