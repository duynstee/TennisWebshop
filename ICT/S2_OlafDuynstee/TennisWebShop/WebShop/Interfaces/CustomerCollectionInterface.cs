using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface CustomerCollectionInterface
    {
        int CheckEmail(string customerEmail);
        void CreateCustomer(CustomerDto customerDto);
        CustomerDto LoginCustomer(string customerEmail);
    }
}
