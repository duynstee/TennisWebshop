using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using Factory;
using Interfaces;

namespace Logic
{
    public class CustomerCollection
    {
        private bool CheckEmail(string customerEmail)
        {
            CustomerCollectionInterface dbMan = CustomerFactory.GetCustomerCollectionInterface();

            if (dbMan.CheckEmail(customerEmail) == 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private bool CheckPassword(string email, string insertedPassword)
        {
            CustomerCollectionInterface dbMan = CustomerFactory.GetCustomerCollectionInterface();
            string password;
            password = dbMan.CheckPassword(email);

            if (password == insertedPassword)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CreateCustomer(Customer customer)
        {
            if (CheckEmail(customer.CustomerEmail) == true)
            {
                CustomerDto customerDto = new CustomerDto();
                customerDto.CustomerEmail = customer.CustomerEmail;
                customerDto.CustomerPassword = customer.CustomerPassword;
                customerDto.CustomerName = customer.CustomerName;
                customerDto.CustomerAddress = customer.CustomerAddress;
                customerDto.CustomerPhoneNumber = customer.CustomerPhoneNumber;

                CustomerCollectionInterface dbMan = CustomerFactory.GetCustomerCollectionInterface();
                dbMan.CreateCustomer(customerDto);
                return true;
            }

            else
            {
                return false; 
            }
        }

        public Customer LoginCustomer(Customer customerLogin)
        {
            CustomerCollectionInterface dbMan = CustomerFactory.GetCustomerCollectionInterface();
            CustomerDto customerDto = dbMan.LoginCustomer(customerLogin.CustomerEmail);
            
            Customer customerData = new Customer();
            customerData.CustomerID = customerDto.CustomerID;
            customerData.CustomerEmail = customerDto.CustomerEmail;
            customerData.CustomerName = customerDto.CustomerName;
            customerData.CustomerPassword = customerDto.CustomerPassword;
            if (customerData.CustomerPassword == customerLogin.CustomerPassword)
            {
                customerData.LoggedIn = true;
                return customerData;
            }
            else
            {
                customerData.LoggedIn = false;
                return customerData;
            }
        }

        public bool ChangePassword(string CustomerEmail, string CustomerPassword, string CustomerNewPassword)
        {
            var passwordTrue = CheckPassword(CustomerEmail, CustomerPassword);
            if (passwordTrue == true)
            {
                CustomerCollectionInterface dbMan = CustomerFactory.GetCustomerCollectionInterface();
                dbMan.ChangePassword(CustomerEmail, CustomerNewPassword);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Customer GetCustomerInfo(string customerEmail)
        {
            CustomerCollectionInterface dbMan = CustomerFactory.GetCustomerCollectionInterface();
            CustomerDto customerDto = dbMan.GetCustomerInfo(customerEmail);

            Customer customerData = new Customer();
            customerData.CustomerID = customerDto.CustomerID;
            customerData.CustomerEmail = customerDto.CustomerEmail;
            customerData.CustomerName = customerDto.CustomerName;
            customerData.CustomerAddress = customerDto.CustomerAddress;
            customerData.CustomerPhoneNumber = customerDto.CustomerPhoneNumber;

            return customerData;
        }
    }
}
