using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Database.Data
{
    public class OrderDatabaseManager : OrderInterface, CustomerInterface
    {
        private string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebshopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<OrderDto> GetAllOrders(int customerID)
        {
            List<OrderDto> Orders = new List<OrderDto>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("select * from Orders inner join OrderItem on Orders.OrderID=OrderItem.OrderID inner join Products on OrderItem.ProductID=Products.ProductID WHERE CustomerID = @CustomerID", conn))
                {
                    query.Parameters.AddWithValue("@CustomerID", customerID);
                    conn.Open();

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderDto ord = new OrderDto();
                        ord.OrderItemId = reader.GetInt32(2);
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

        public void AddProdToOrder(int productId, int customerID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                int orderId = 0;
                
                using (SqlCommand query =
                    new SqlCommand("SELECT OrderID FROM orders WHERE CustomerID = @CustomerID", conn))
                {
                    query.Parameters.AddWithValue("@CustomerID", customerID);
                    conn.Open();
                    
                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        orderId = reader.GetInt32(0);
                    }
                    conn.Close();
                }
              
                using (var query = new SqlCommand("INSERT INTO OrderItem(ProductID, OrderID) Values(@ProductID, @OrderID)", conn))
                {
                    query.Parameters.AddWithValue("@ProductID", productId);
                    query.Parameters.AddWithValue("@OrderID", orderId);
                    conn.Open();
                    query.ExecuteNonQuery();
                }
            }
        }

        public void RemoveProdFromOrder(int orderItemID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var query = new SqlCommand("DELETE FROM OrderItem WHERE Id = @orderItemID", conn))
                {
                    query.Parameters.AddWithValue("@orderItemID", orderItemID);

                    query.ExecuteNonQuery();
                }
            }
        }
    }
}
