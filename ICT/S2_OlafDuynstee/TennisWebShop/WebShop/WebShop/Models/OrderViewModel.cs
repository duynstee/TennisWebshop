using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class OrderViewModel
    {
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string  Size { get; set; }
        public int Quantity { get; set; }

    }
}
