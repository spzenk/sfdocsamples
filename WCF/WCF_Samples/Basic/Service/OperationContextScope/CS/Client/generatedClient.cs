﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Microsoft.ServiceModel.Samples
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Microsoft.ServiceModel.Samples", ConfigurationName="Microsoft.ServiceModel.Samples.IMessageHeaderReader")]
    public interface IMessageHeaderReader
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IMessageHeaderReader/RetrieveHeader", ReplyAction="http://Microsoft.ServiceModel.Samples/IMessageHeaderReader/RetrieveHeaderResponse" +
            "")]
        bool RetrieveHeader(string guid);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IMessageHeaderReaderChannel : Microsoft.ServiceModel.Samples.IMessageHeaderReader, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class MessageHeaderReaderClient : System.ServiceModel.ClientBase<Microsoft.ServiceModel.Samples.IMessageHeaderReader>, Microsoft.ServiceModel.Samples.IMessageHeaderReader
    {
        
        public MessageHeaderReaderClient()
        {
        }
        
        public MessageHeaderReaderClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public MessageHeaderReaderClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public MessageHeaderReaderClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public MessageHeaderReaderClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public bool RetrieveHeader(string guid)
        {
            return base.Channel.RetrieveHeader(guid);
        }
    }
}
