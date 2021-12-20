using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.VisualBasic.CompilerServices;

namespace TestDAL
{
    public class TestCustomerDatabaseManager : CustomerCollectionInterface
    {
        public int CheckEmail(string Email)
        {
            if (Email == "olaf.duynstee@gmail.com")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public string CheckPassword(string Email)
        {
            if (Email == "olaf.duynstee@gmail.com")
            {
                return "Gorilla2";
            }
            else
            {
                return "0";
            }
        }

        public CustomerDto LoginCustomer(string Email)
        {
            CustomerDto customerDto = new CustomerDto();
            customerDto.CustomerName = "Olaf";
            customerDto.CustomerID = 1;
            customerDto.CustomerEmail = "olaf.duynstee@gmail.com";
            customerDto.CustomerPassword = "Gorilla2";
            return customerDto;
        }

        public void ChangePassword(string password, string Email)
        {

        }

        public void CreateCustomer(CustomerDto customer)
        {

        }

        public CustomerDto GetCustomerInfo(string email)
        {
            CustomerDto customer = new CustomerDto();
            return customer;
        }
    }
}
