using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Interfaces;
using Microsoft.VisualBasic.CompilerServices;

namespace Database.Data
{
    public class CustomerDatabaseManager : CustomerCollectionInterface
    {
        private string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebshopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int CheckEmail(string CustomerEmail)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("SELECT COUNT(*) FROM Customers WHERE CustomerEmail = @CustomerEmail", conn))
                {
                    conn.Open();
                    query.Parameters.AddWithValue("@CustomerEmail", CustomerEmail);
                    int total = (int) query.ExecuteScalar();
                    return total;
                }
            }
        }

        public string CheckPassword(string email)
        {
            string oldPassword = "0";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query =
                    new SqlCommand("Select * from Customers where CustomerEmail = @CustomerEmail", conn))
                {
                    conn.Open();
                    query.Parameters.AddWithValue("@CustomerEmail", email);

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        oldPassword = reader.GetString(2);
                    }
                }
            }

            return oldPassword;
        }

        public void CreateCustomer(CustomerDto customerDto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query =
                    new SqlCommand(
                        "INSERT INTO Customers(CustomerEmail, CustomerPassword, CustomerName, CustomerAddress, CustomerPhoneNumber) VALUES(@Email, @Password, @Name, @Address, @PhoneNumber)", conn))
                {
                    conn.Open();
                    query.Parameters.AddWithValue("@Email", customerDto.CustomerEmail);
                    query.Parameters.AddWithValue("@Password", customerDto.CustomerPassword);
                    query.Parameters.AddWithValue("@Name", customerDto.CustomerName);
                    query.Parameters.AddWithValue("@Address", customerDto.CustomerAddress);
                    query.Parameters.AddWithValue("@PhoneNumber", customerDto.CustomerPhoneNumber);

                    query.ExecuteNonQuery();
                    conn.Close();
                }

                int customerId = 0;
                using (SqlCommand query =
                    new SqlCommand("select * from Customers where CustomerEmail = @CustomerEmail", conn))
                {
                    conn.Open();
                    query.Parameters.AddWithValue("@CustomerEmail", customerDto.CustomerEmail);

                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        customerId = reader.GetInt32(0);
                    }
                    conn.Close();
                }

                using (SqlCommand query = new SqlCommand("INSERT INTO Orders(CustomerID) VALUES (@CustomerID)", conn))
                {
                    conn.Open();
                    query.Parameters.AddWithValue("@CustomerID", customerId);
                    query.ExecuteNonQuery();
                }
            }
        }

        public CustomerDto LoginCustomer(string customerEmail)
        {
            CustomerDto custDto = new CustomerDto();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("SELECT * FROM Customers WHERE CustomerEmail = @CustomerEmail", conn))
                {
                    conn.Open();
                    query.Parameters.AddWithValue("@CustomerEmail", customerEmail);
                    
                    var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        custDto.CustomerID = reader.GetInt32(0);
                        custDto.CustomerEmail = reader.GetString(1);
                        custDto.CustomerPassword = reader.GetString(2);
                        custDto.CustomerName = reader.GetString(3);
                    }
                }
            }
            return custDto;
        }

        public void ChangePassword(string email, string newPassword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("UPDATE Customers SET CustomerPassword = @newPassword WHERE CustomerEmail = @CustomerEmail", conn))
                {
                    conn.Open();
                    query.Parameters.AddWithValue("@newPassword", newPassword);
                    query.Parameters.AddWithValue("@CustomerEmail", email);

                    query.ExecuteNonQuery();
                }
            }   
        }
    }
}
