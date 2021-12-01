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

        public Customer LoginCustomer(Customer customer)
        {
            CustomerCollectionInterface dbMan = CustomerFactory.GetCustomerCollectionInterface();
            var customerDto = dbMan.LoginCustomer(customer.CustomerEmail);

            Customer _customer = new Customer();
            customerDto.CustomerID = _customer.CustomerID;
            customerDto.CustomerEmail = _customer.CustomerEmail;
            customerDto.CustomerName = _customer.CustomerName;
            if (customerDto.CustomerPassword == customer.CustomerPassword)
            {
                customer.LoggedIn = true;
                return _customer;
            }
            else
            {
                customer.LoggedIn = false;
                return _customer;
            }
        }
    }
}
