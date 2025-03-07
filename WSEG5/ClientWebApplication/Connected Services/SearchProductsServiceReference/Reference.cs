﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientWebApplication.SearchProductsServiceReference {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SearchProductsServiceReference.SearchProductsSoap")]
    public interface SearchProductsSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SearchByCategory", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SearchByCategory(string categoryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SearchByCategory", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SearchByCategoryAsync(string categoryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SearchBySupplier", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SearchBySupplier(string supplierUsername);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SearchBySupplier", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SearchBySupplierAsync(string supplierUsername);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SearchByProductName", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SearchByProductName(string productName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SearchByProductName", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SearchByProductNameAsync(string productName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SearchProductsSoapChannel : ClientWebApplication.SearchProductsServiceReference.SearchProductsSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SearchProductsSoapClient : System.ServiceModel.ClientBase<ClientWebApplication.SearchProductsServiceReference.SearchProductsSoap>, ClientWebApplication.SearchProductsServiceReference.SearchProductsSoap {
        
        public SearchProductsSoapClient() {
        }
        
        public SearchProductsSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SearchProductsSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SearchProductsSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SearchProductsSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet SearchByCategory(string categoryId) {
            return base.Channel.SearchByCategory(categoryId);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SearchByCategoryAsync(string categoryId) {
            return base.Channel.SearchByCategoryAsync(categoryId);
        }
        
        public System.Data.DataSet SearchBySupplier(string supplierUsername) {
            return base.Channel.SearchBySupplier(supplierUsername);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SearchBySupplierAsync(string supplierUsername) {
            return base.Channel.SearchBySupplierAsync(supplierUsername);
        }
        
        public System.Data.DataSet SearchByProductName(string productName) {
            return base.Channel.SearchByProductName(productName);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SearchByProductNameAsync(string productName) {
            return base.Channel.SearchByProductNameAsync(productName);
        }
    }
}
