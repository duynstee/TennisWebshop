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
        public static CustomerInterface GetCustomerInterface()
        {
            return new OrderDatabaseManager();
        }

        public static CustomerInterface GetCustomerInterface(bool test)
        {
            return new TestOrderDatabaseManager();
        }

        public static CustomerCollectionInterface GetCustomerCollectionInterface()
        {
            return new CustomerDatabaseManager();
        }

        public static CustomerCollectionInterface GetCustomerCollectionInterface(bool test)
        {
            return new TestCustomerDatabaseManager();
        }
    }
}
