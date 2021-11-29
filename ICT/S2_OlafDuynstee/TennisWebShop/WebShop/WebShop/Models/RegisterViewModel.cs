using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class RegisterViewModel
    {
        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
    }
}
