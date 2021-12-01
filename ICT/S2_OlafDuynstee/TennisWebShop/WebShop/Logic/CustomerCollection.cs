using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Data;
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
            if (customerDto.CustomerPassword == customer.CustomerPassword)
            {
                customer.LoggedIn = true;
                return customer;                                                                
            }
            else
            {
                customer.LoggedIn = false;
                return customer;
            }
        }
    }
}
