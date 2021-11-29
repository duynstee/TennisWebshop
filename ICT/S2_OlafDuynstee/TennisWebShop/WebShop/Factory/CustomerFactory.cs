using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Data;
using Interfaces;

namespace Factory
{
    public static class CustomerFactory
    {
        public static CustomerInterface GetCustomerInterface()
        {
            return new OrderDatabaseManager();
        }

        public static CustomerCollectionInterface CustomerCollectionInterface()
        {
            return new CustomerDatabaseManager();
        }
    }
}
