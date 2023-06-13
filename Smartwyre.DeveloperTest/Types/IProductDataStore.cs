using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Types
{
    public interface IProductDataStore
    {
        Product GetProduct(string productIdentifier);
    }
}
