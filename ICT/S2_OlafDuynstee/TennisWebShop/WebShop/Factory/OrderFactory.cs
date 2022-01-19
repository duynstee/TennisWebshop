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
    public static class OrderFactory
    {
        public static OrderInterface GetOrderInterface(bool test)
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
    }
}
