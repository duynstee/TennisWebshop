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
                using (SqlCommand query = new SqlCommand("select * from Orders inner join OrderItem on Orders.OrderID=OrderItem.OrderID inner join Products on OrderItem.ProductID=Products.ProductID", conn))
                {
                    conn.Open();

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderDto ord = new OrderDto();
                        ord.ProductName = reader.GetString(7);
                        ord.Size = reader.GetString(8);
                        ord.Price = reader.GetString(9);
                        ord.Quantity = reader.GetInt32(5);

                        Orders.Add(ord);
                    }
                }
            }
            return Orders;
        }

        public void AddToOrder(int productId, int orderId)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                
                using (var query = new SqlCommand("INSERT INTO OrderItem(OrderID, ProductID) Values(@OrderID, @ProductID)", conn))
                {
                    query.Parameters.AddWithValue("@OrderID", orderId);
                    query.Parameters.AddWithValue("@ProductID", productId);

                    query.ExecuteNonQuery();
                }
            }
        }
    }
}
