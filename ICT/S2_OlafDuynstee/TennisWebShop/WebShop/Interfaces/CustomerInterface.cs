using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface CustomerInterface
    {
        void AddProdToOrder(int productID, int customerID);
        void RemoveProdFromOrder(int OrderItemID);
    }
}
