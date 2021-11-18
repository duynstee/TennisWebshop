﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Data
{
    public class ProductDatabaseManager
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
                        prod.Name = reader.GetString(0);
                        prod.Size = reader.GetString(1);
                        prod.Price = reader.GetString(2);
                        prod.Quantity = reader.GetInt32(3);
                        prod.Description = reader.GetString(4);

                        products.Add(prod);
                    }
                }
            }
            return products;
        }

    }
}