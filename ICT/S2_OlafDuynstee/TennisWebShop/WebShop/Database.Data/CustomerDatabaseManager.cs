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
                }
            }
        }
    }
}
