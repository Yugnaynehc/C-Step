using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ProductDetailsContracts
{
    [ServiceContract]
    public interface IProductDetails
    {
        [OperationContract]
        [WebGet(UriTemplate = "products/{productID}")]
        Product GetProduct(string productID);
    }
}
