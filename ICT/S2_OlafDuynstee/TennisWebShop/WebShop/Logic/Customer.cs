 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class Customer
    {
        private string Name;
        private string Address;
        private string PhoneNumber;
        private string Email;
        private string Password;

        private List<OrderList> ListOrders = new List<OrderList>();
    }
}
