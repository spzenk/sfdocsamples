﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3620
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.3620.
// 
#pragma warning disable 1591

namespace WebService_Secure.gastosWs {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SingleServiceSoap", Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BaseEntity))]
    public partial class SingleService2 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ExecuteServiceOperationCompleted;
        
        private System.Threading.SendOrPostCallback ExecuteService_OneWayOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetServiceConfigurationOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetServicesListOperationCompleted;
        
        private System.Threading.SendOrPostCallback SetServiceConfigurationOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddServiceConfigurationOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteServiceConfigurationOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAllApplicationsIdOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetProviderInfoOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SingleService2() {
            this.Url = global::WebService_Secure.Properties.Settings.Default.WebService_Secure_gastosWs_SingleService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ExecuteServiceCompletedEventHandler ExecuteServiceCompleted;
        
        /// <remarks/>
        public event ExecuteService_OneWayCompletedEventHandler ExecuteService_OneWayCompleted;
        
        /// <remarks/>
        public event GetServiceConfigurationCompletedEventHandler GetServiceConfigurationCompleted;
        
        /// <remarks/>
        public event GetServicesListCompletedEventHandler GetServicesListCompleted;
        
        /// <remarks/>
        public event SetServiceConfigurationCompletedEventHandler SetServiceConfigurationCompleted;
        
        /// <remarks/>
        public event AddServiceConfigurationCompletedEventHandler AddServiceConfigurationCompleted;
        
        /// <remarks/>
        public event DeleteServiceConfigurationCompletedEventHandler DeleteServiceConfigurationCompleted;
        
        /// <remarks/>
        public event GetAllApplicationsIdCompletedEventHandler GetAllApplicationsIdCompleted;
        
        /// <remarks/>
        public event GetProviderInfoCompletedEventHandler GetProviderInfoCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ExecuteService", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ExecuteService(string providerName, string pServiceName, string pData) {
            object[] results = this.Invoke("ExecuteService", new object[] {
                        providerName,
                        pServiceName,
                        pData});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ExecuteServiceAsync(string providerName, string pServiceName, string pData) {
            this.ExecuteServiceAsync(providerName, pServiceName, pData, null);
        }
        
        /// <remarks/>
        public void ExecuteServiceAsync(string providerName, string pServiceName, string pData, object userState) {
            if ((this.ExecuteServiceOperationCompleted == null)) {
                this.ExecuteServiceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExecuteServiceOperationCompleted);
            }
            this.InvokeAsync("ExecuteService", new object[] {
                        providerName,
                        pServiceName,
                        pData}, this.ExecuteServiceOperationCompleted, userState);
        }
        
        private void OnExecuteServiceOperationCompleted(object arg) {
            if ((this.ExecuteServiceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ExecuteServiceCompleted(this, new ExecuteServiceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ExecuteService_OneWay", RequestNamespace="http://tempuri.org/", OneWay=true, Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void ExecuteService_OneWay(string providerName, string pServiceName, string pData) {
            this.Invoke("ExecuteService_OneWay", new object[] {
                        providerName,
                        pServiceName,
                        pData});
        }
        
        /// <remarks/>
        public void ExecuteService_OneWayAsync(string providerName, string pServiceName, string pData) {
            this.ExecuteService_OneWayAsync(providerName, pServiceName, pData, null);
        }
        
        /// <remarks/>
        public void ExecuteService_OneWayAsync(string providerName, string pServiceName, string pData, object userState) {
            if ((this.ExecuteService_OneWayOperationCompleted == null)) {
                this.ExecuteService_OneWayOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExecuteService_OneWayOperationCompleted);
            }
            this.InvokeAsync("ExecuteService_OneWay", new object[] {
                        providerName,
                        pServiceName,
                        pData}, this.ExecuteService_OneWayOperationCompleted, userState);
        }
        
        private void OnExecuteService_OneWayOperationCompleted(object arg) {
            if ((this.ExecuteService_OneWayCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ExecuteService_OneWayCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetServiceConfiguration", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetServiceConfiguration(string providerName, string serviceName) {
            object[] results = this.Invoke("GetServiceConfiguration", new object[] {
                        providerName,
                        serviceName});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetServiceConfigurationAsync(string providerName, string serviceName) {
            this.GetServiceConfigurationAsync(providerName, serviceName, null);
        }
        
        /// <remarks/>
        public void GetServiceConfigurationAsync(string providerName, string serviceName, object userState) {
            if ((this.GetServiceConfigurationOperationCompleted == null)) {
                this.GetServiceConfigurationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetServiceConfigurationOperationCompleted);
            }
            this.InvokeAsync("GetServiceConfiguration", new object[] {
                        providerName,
                        serviceName}, this.GetServiceConfigurationOperationCompleted, userState);
        }
        
        private void OnGetServiceConfigurationOperationCompleted(object arg) {
            if ((this.GetServiceConfigurationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetServiceConfigurationCompleted(this, new GetServiceConfigurationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetServicesList", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetServicesList(string providerName, bool ViewAsXml) {
            object[] results = this.Invoke("GetServicesList", new object[] {
                        providerName,
                        ViewAsXml});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetServicesListAsync(string providerName, bool ViewAsXml) {
            this.GetServicesListAsync(providerName, ViewAsXml, null);
        }
        
        /// <remarks/>
        public void GetServicesListAsync(string providerName, bool ViewAsXml, object userState) {
            if ((this.GetServicesListOperationCompleted == null)) {
                this.GetServicesListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetServicesListOperationCompleted);
            }
            this.InvokeAsync("GetServicesList", new object[] {
                        providerName,
                        ViewAsXml}, this.GetServicesListOperationCompleted, userState);
        }
        
        private void OnGetServicesListOperationCompleted(object arg) {
            if ((this.GetServicesListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetServicesListCompleted(this, new GetServicesListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SetServiceConfiguration", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void SetServiceConfiguration(string providerName, string pServiceName, ServiceConfiguration pServiceConfiguration) {
            this.Invoke("SetServiceConfiguration", new object[] {
                        providerName,
                        pServiceName,
                        pServiceConfiguration});
        }
        
        /// <remarks/>
        public void SetServiceConfigurationAsync(string providerName, string pServiceName, ServiceConfiguration pServiceConfiguration) {
            this.SetServiceConfigurationAsync(providerName, pServiceName, pServiceConfiguration, null);
        }
        
        /// <remarks/>
        public void SetServiceConfigurationAsync(string providerName, string pServiceName, ServiceConfiguration pServiceConfiguration, object userState) {
            if ((this.SetServiceConfigurationOperationCompleted == null)) {
                this.SetServiceConfigurationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetServiceConfigurationOperationCompleted);
            }
            this.InvokeAsync("SetServiceConfiguration", new object[] {
                        providerName,
                        pServiceName,
                        pServiceConfiguration}, this.SetServiceConfigurationOperationCompleted, userState);
        }
        
        private void OnSetServiceConfigurationOperationCompleted(object arg) {
            if ((this.SetServiceConfigurationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetServiceConfigurationCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddServiceConfiguration", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void AddServiceConfiguration(string providerName, ServiceConfiguration pServiceConfiguration) {
            this.Invoke("AddServiceConfiguration", new object[] {
                        providerName,
                        pServiceConfiguration});
        }
        
        /// <remarks/>
        public void AddServiceConfigurationAsync(string providerName, ServiceConfiguration pServiceConfiguration) {
            this.AddServiceConfigurationAsync(providerName, pServiceConfiguration, null);
        }
        
        /// <remarks/>
        public void AddServiceConfigurationAsync(string providerName, ServiceConfiguration pServiceConfiguration, object userState) {
            if ((this.AddServiceConfigurationOperationCompleted == null)) {
                this.AddServiceConfigurationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddServiceConfigurationOperationCompleted);
            }
            this.InvokeAsync("AddServiceConfiguration", new object[] {
                        providerName,
                        pServiceConfiguration}, this.AddServiceConfigurationOperationCompleted, userState);
        }
        
        private void OnAddServiceConfigurationOperationCompleted(object arg) {
            if ((this.AddServiceConfigurationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddServiceConfigurationCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/DeleteServiceConfiguration", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void DeleteServiceConfiguration(string providerName, string pServiceName) {
            this.Invoke("DeleteServiceConfiguration", new object[] {
                        providerName,
                        pServiceName});
        }
        
        /// <remarks/>
        public void DeleteServiceConfigurationAsync(string providerName, string pServiceName) {
            this.DeleteServiceConfigurationAsync(providerName, pServiceName, null);
        }
        
        /// <remarks/>
        public void DeleteServiceConfigurationAsync(string providerName, string pServiceName, object userState) {
            if ((this.DeleteServiceConfigurationOperationCompleted == null)) {
                this.DeleteServiceConfigurationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteServiceConfigurationOperationCompleted);
            }
            this.InvokeAsync("DeleteServiceConfiguration", new object[] {
                        providerName,
                        pServiceName}, this.DeleteServiceConfigurationOperationCompleted, userState);
        }
        
        private void OnDeleteServiceConfigurationOperationCompleted(object arg) {
            if ((this.DeleteServiceConfigurationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteServiceConfigurationCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAllApplicationsId", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetAllApplicationsId(string providerName) {
            object[] results = this.Invoke("GetAllApplicationsId", new object[] {
                        providerName});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetAllApplicationsIdAsync(string providerName) {
            this.GetAllApplicationsIdAsync(providerName, null);
        }
        
        /// <remarks/>
        public void GetAllApplicationsIdAsync(string providerName, object userState) {
            if ((this.GetAllApplicationsIdOperationCompleted == null)) {
                this.GetAllApplicationsIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllApplicationsIdOperationCompleted);
            }
            this.InvokeAsync("GetAllApplicationsId", new object[] {
                        providerName}, this.GetAllApplicationsIdOperationCompleted, userState);
        }
        
        private void OnGetAllApplicationsIdOperationCompleted(object arg) {
            if ((this.GetAllApplicationsIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllApplicationsIdCompleted(this, new GetAllApplicationsIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetProviderInfo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public MetadataProvider GetProviderInfo(string providerName) {
            object[] results = this.Invoke("GetProviderInfo", new object[] {
                        providerName});
            return ((MetadataProvider)(results[0]));
        }
        
        /// <remarks/>
        public void GetProviderInfoAsync(string providerName) {
            this.GetProviderInfoAsync(providerName, null);
        }
        
        /// <remarks/>
        public void GetProviderInfoAsync(string providerName, object userState) {
            if ((this.GetProviderInfoOperationCompleted == null)) {
                this.GetProviderInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetProviderInfoOperationCompleted);
            }
            this.InvokeAsync("GetProviderInfo", new object[] {
                        providerName}, this.GetProviderInfoOperationCompleted, userState);
        }
        
        private void OnGetProviderInfoOperationCompleted(object arg) {
            if ((this.GetProviderInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetProviderInfoCompleted(this, new GetProviderInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ServiceConfiguration : BaseEntity {
        
        private string createdUserNameField;
        
        private System.DateTime createdDateTimeField;
        
        private string descriptionField;
        
        private string handlerField;
        
        private string requestField;
        
        private string responseField;
        
        private bool availableField;
        
        private bool auditField;
        
        private TransactionalBehaviour transactionalBehaviourField;
        
        private IsolationLevel isolationLevelField;
        
        private string applicationIdField;
        
        private string nameField;
        
        /// <remarks/>
        public string CreatedUserName {
            get {
                return this.createdUserNameField;
            }
            set {
                this.createdUserNameField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime CreatedDateTime {
            get {
                return this.createdDateTimeField;
            }
            set {
                this.createdDateTimeField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public string Handler {
            get {
                return this.handlerField;
            }
            set {
                this.handlerField = value;
            }
        }
        
        /// <remarks/>
        public string Request {
            get {
                return this.requestField;
            }
            set {
                this.requestField = value;
            }
        }
        
        /// <remarks/>
        public string Response {
            get {
                return this.responseField;
            }
            set {
                this.responseField = value;
            }
        }
        
        /// <remarks/>
        public bool Available {
            get {
                return this.availableField;
            }
            set {
                this.availableField = value;
            }
        }
        
        /// <remarks/>
        public bool Audit {
            get {
                return this.auditField;
            }
            set {
                this.auditField = value;
            }
        }
        
        /// <remarks/>
        public TransactionalBehaviour TransactionalBehaviour {
            get {
                return this.transactionalBehaviourField;
            }
            set {
                this.transactionalBehaviourField = value;
            }
        }
        
        /// <remarks/>
        public IsolationLevel IsolationLevel {
            get {
                return this.isolationLevelField;
            }
            set {
                this.isolationLevelField = value;
            }
        }
        
        /// <remarks/>
        public string ApplicationId {
            get {
                return this.applicationIdField;
            }
            set {
                this.applicationIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum TransactionalBehaviour {
        
        /// <remarks/>
        Support,
        
        /// <remarks/>
        Required,
        
        /// <remarks/>
        RequiresNew,
        
        /// <remarks/>
        Suppres,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum IsolationLevel {
        
        /// <remarks/>
        Chaos,
        
        /// <remarks/>
        ReadCommitted,
        
        /// <remarks/>
        ReadUncommitted,
        
        /// <remarks/>
        RepeatableRead,
        
        /// <remarks/>
        Serializable,
        
        /// <remarks/>
        Snapshot,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MetadataProvider))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ServiceConfiguration))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public abstract partial class BaseEntity {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MetadataProvider : BaseEntity {
        
        private string applicationIdField;
        
        private string nameField;
        
        private string configProviderTypeField;
        
        private string securityProviderNameField;
        
        private string sourceInfoField;
        
        /// <remarks/>
        public string ApplicationId {
            get {
                return this.applicationIdField;
            }
            set {
                this.applicationIdField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string ConfigProviderType {
            get {
                return this.configProviderTypeField;
            }
            set {
                this.configProviderTypeField = value;
            }
        }
        
        /// <remarks/>
        public string SecurityProviderName {
            get {
                return this.securityProviderNameField;
            }
            set {
                this.securityProviderNameField = value;
            }
        }
        
        /// <remarks/>
        public string SourceInfo {
            get {
                return this.sourceInfoField;
            }
            set {
                this.sourceInfoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void ExecuteServiceCompletedEventHandler(object sender, ExecuteServiceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExecuteServiceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ExecuteServiceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void ExecuteService_OneWayCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void GetServiceConfigurationCompletedEventHandler(object sender, GetServiceConfigurationCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetServiceConfigurationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetServiceConfigurationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void GetServicesListCompletedEventHandler(object sender, GetServicesListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetServicesListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetServicesListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void SetServiceConfigurationCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void AddServiceConfigurationCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void DeleteServiceConfigurationCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void GetAllApplicationsIdCompletedEventHandler(object sender, GetAllApplicationsIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllApplicationsIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllApplicationsIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void GetProviderInfoCompletedEventHandler(object sender, GetProviderInfoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetProviderInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetProviderInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public MetadataProvider Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((MetadataProvider)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591