using System.Collections.Generic;

namespace Interfaces
{
    public interface OrderInterface
    {
        List<OrderDto> GetAllOrders(int customerID);
    }
}
