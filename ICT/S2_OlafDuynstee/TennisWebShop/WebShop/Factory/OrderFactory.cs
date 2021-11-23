using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Data;
using Interfaces;

namespace Factory
{
    public static class OrderFactory
    {
        public static OrderInterface GetOrderInterface()
        {
            return new OrderDatabaseManager();
        }
    }
}
