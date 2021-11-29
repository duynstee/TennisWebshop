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
            CustomerCollectionInterface dbMan = CustomerFactory.CustomerCollectionInterface();

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

                return true;
            }

            else
            {
                return false; 
            }
        }
    }
}
