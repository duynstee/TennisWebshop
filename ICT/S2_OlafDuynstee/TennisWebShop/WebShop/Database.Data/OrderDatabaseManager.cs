using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Database.Data
{
    public class OrderDatabaseManager : OrderInterface
    {
        private string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebshopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<OrderDto> GetAllOrders()
        {
            List<OrderDto> Orders = new List<OrderDto>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("select * from Orders inner join Products on Orders.ProductID=Products.ProductID", conn))
                {
                    conn.Open();

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderDto ord = new OrderDto();
                        ord.OrderID = reader.GetInt32(1);
                        ord.ProductID = reader.GetInt32(2);
                        ord.Quantity = reader.GetInt32(3);
                        ord.ProductName = reader.GetString(5);

                        Orders.Add(ord);
                    }
                }
            }
            return Orders;
        }
    }
}
