﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30128.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductClient.ProductInformationService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductInformationService.IProductInformation")]
    public interface IProductInformation {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductInformation/HowMuchWillItCost", ReplyAction="http://tempuri.org/IProductInformation/HowMuchWillItCostResponse")]
        decimal HowMuchWillItCost(int productID, int howMany);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductInformationChannel : ProductClient.ProductInformationService.IProductInformation, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductInformationClient : System.ServiceModel.ClientBase<ProductClient.ProductInformationService.IProductInformation>, ProductClient.ProductInformationService.IProductInformation {
        
        public ProductInformationClient() {
        }
        
        public ProductInformationClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductInformationClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductInformationClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductInformationClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public decimal HowMuchWillItCost(int productID, int howMany) {
            return base.Channel.HowMuchWillItCost(productID, howMany);
        }
    }
}
