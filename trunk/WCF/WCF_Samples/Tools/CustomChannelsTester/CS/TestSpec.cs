﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=2.0.50727.42.
// 
namespace TestSpec {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://WCF/TestSpec")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://WCF/TestSpec", IsNullable=false)]
    public partial class TestSpec {
        
        private TestSpecServiceContract serviceContractField;
        
        private TestSpecTestDetails testDetailsField;
        
        /// <remarks/>
        public TestSpecServiceContract ServiceContract {
            get {
                return this.serviceContractField;
            }
            set {
                this.serviceContractField = value;
            }
        }
        
        /// <remarks/>
        public TestSpecTestDetails TestDetails {
            get {
                return this.testDetailsField;
            }
            set {
                this.testDetailsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class TestSpecServiceContract {
        
        private Contract isOneWayField;
        
        private Contract isAsyncField;
        
        private Contract isSessionField;
        
        private Contract isCallBackField;
        
        /// <remarks/>
        public Contract IsOneWay {
            get {
                return this.isOneWayField;
            }
            set {
                this.isOneWayField = value;
            }
        }
        
        /// <remarks/>
        public Contract IsAsync {
            get {
                return this.isAsyncField;
            }
            set {
                this.isAsyncField = value;
            }
        }
        
        /// <remarks/>
        public Contract IsSession {
            get {
                return this.isSessionField;
            }
            set {
                this.isSessionField = value;
            }
        }
        
        /// <remarks/>
        public Contract IsCallBack {
            get {
                return this.isCallBackField;
            }
            set {
                this.isCallBackField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://WCF/TestSpec")]
    public partial class Contract {
        
        private bool expandAllField;
        
        private bool expandAllFieldSpecified;
        
        private bool valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ExpandAll {
            get {
                return this.expandAllField;
            }
            set {
                this.expandAllField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ExpandAllSpecified {
            get {
                return this.expandAllFieldSpecified;
            }
            set {
                this.expandAllFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public bool Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class TestSpecTestDetails {
        
        private string serverMachineNameField;
        
        private string serverPortNumberField;
        
        private string clientCallBackAddressField;
        
        private string serverTimeoutField;
        
        private string clientTimeoutField;
        
        private string numberOfClientsField;
        
        private string messagesPerClientField;
        
        public TestSpecTestDetails() {
            this.clientCallBackAddressField = "";
            this.serverTimeoutField = "300";
            this.clientTimeoutField = "60";
            this.numberOfClientsField = "1";
            this.messagesPerClientField = "1";
        }
        
        /// <remarks/>
        public string ServerMachineName {
            get {
                return this.serverMachineNameField;
            }
            set {
                this.serverMachineNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string ServerPortNumber {
            get {
                return this.serverPortNumberField;
            }
            set {
                this.serverPortNumberField = value;
            }
        }
        
        /// <remarks/>
        public string ClientCallBackAddress {
            get {
                return this.clientCallBackAddressField;
            }
            set {
                this.clientCallBackAddressField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string ServerTimeout {
            get {
                return this.serverTimeoutField;
            }
            set {
                this.serverTimeoutField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string ClientTimeout {
            get {
                return this.clientTimeoutField;
            }
            set {
                this.clientTimeoutField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string NumberOfClients {
            get {
                return this.numberOfClientsField;
            }
            set {
                this.numberOfClientsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string MessagesPerClient {
            get {
                return this.messagesPerClientField;
            }
            set {
                this.messagesPerClientField = value;
            }
        }
    }
}