    using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class OrderDto
    {
        public int OrderItemId { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
    }
}
