﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

[ServiceContract]
public interface IProductInformation
{
    [OperationContract]
    decimal HowMuchWillItCost(int productID, int howMany);
}