using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Data;
using Interfaces;
using TestDAL;

namespace Factory
{
    public static class CustomerFactory
    {
        public static CustomerInterface GetCustomerInterface(bool test)
        {
            if (test == false)
            {
                return new OrderDatabaseManager();
            }
            else
            {
                return new TestOrderDatabaseManager();
            }
            
        }

        public static CustomerCollectionInterface GetCustomerCollectionInterface(bool test)
        {
            if (test == false)
            {
                return new CustomerDatabaseManager();
            }
            else
            {
                return new TestCustomerDatabaseManager();
            }
        }
    }
}
