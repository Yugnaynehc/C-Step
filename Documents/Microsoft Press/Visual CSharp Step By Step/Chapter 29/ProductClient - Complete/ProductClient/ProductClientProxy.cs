using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ProductDetailsContracts;

namespace ProductClient
{
    class ProductClientProxy : ClientBase<IProductDetails>, IProductDetails
    {
        public Product GetProduct(string productID)
        {
            return this.Channel.GetProduct(productID);
        }
    }
}
