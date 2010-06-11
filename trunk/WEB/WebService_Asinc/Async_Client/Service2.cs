﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.3074
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by wsdl, Version=2.0.50727.3038.
// 
namespace SF.Proxy {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Service1Soap", Namespace="http://tempuri.org/")]
    public partial class Service1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ExecuteServiceOperationCompleted;
        
        /// <remarks/>
        public Service1() {
            this.Url = "http://localhost:49243/Service1.asmx";
        }
        
        /// <remarks/>
        public event ExecuteServiceCompletedEventHandler ExecuteServiceCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ExecuteService", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Employee ExecuteService(string name) {
            object[] results = this.Invoke("ExecuteService", new object[] {
                        name});
            return ((Employee)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginExecuteService(string name, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ExecuteService", new object[] {
                        name}, callback, asyncState);
        }
        
        /// <remarks/>
        public Employee EndExecuteService(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Employee)(results[0]));
        }
        
        /// <remarks/>
        public void ExecuteServiceAsync(string name) {
            this.ExecuteServiceAsync(name, null);
        }
        
        /// <remarks/>
        public void ExecuteServiceAsync(string name, object userState) {
            if ((this.ExecuteServiceOperationCompleted == null)) {
                this.ExecuteServiceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExecuteServiceOperationCompleted);
            }
            this.InvokeAsync("ExecuteService", new object[] {
                        name}, this.ExecuteServiceOperationCompleted, userState);
        }
        
        private void OnExecuteServiceOperationCompleted(object arg) {
            if ((this.ExecuteServiceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ExecuteServiceCompleted(this, new ExecuteServiceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Employee {
        
        private int employeeIDField;
        
        private string nationalIDNumberField;
        
        private int contactIDField;
        
        private string loginIDField;
        
        private System.Nullable<int> managerIDField;
        
        private string titleField;
        
        private System.DateTime birthDateField;
        
        private char maritalStatusField;
        
        private char genderField;
        
        private System.DateTime hireDateField;
        
        private bool salariedFlagField;
        
        private short vacationHoursField;
        
        private short sickLeaveHoursField;
        
        private bool currentFlagField;
        
        private System.Guid rowguidField;
        
        private System.DateTime modifiedDateField;
        
        private Employee[] employeesField;
        
        private Employee employee1Field;
        
        private Contact contactField;
        
        /// <comentarios/>
        public int EmployeeID {
            get {
                return this.employeeIDField;
            }
            set {
                this.employeeIDField = value;
            }
        }
        
        /// <comentarios/>
        public string NationalIDNumber {
            get {
                return this.nationalIDNumberField;
            }
            set {
                this.nationalIDNumberField = value;
            }
        }
        
        /// <comentarios/>
        public int ContactID {
            get {
                return this.contactIDField;
            }
            set {
                this.contactIDField = value;
            }
        }
        
        /// <comentarios/>
        public string LoginID {
            get {
                return this.loginIDField;
            }
            set {
                this.loginIDField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> ManagerID {
            get {
                return this.managerIDField;
            }
            set {
                this.managerIDField = value;
            }
        }
        
        /// <comentarios/>
        public string Title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
        
        /// <comentarios/>
        public System.DateTime BirthDate {
            get {
                return this.birthDateField;
            }
            set {
                this.birthDateField = value;
            }
        }
        
        /// <comentarios/>
        public char MaritalStatus {
            get {
                return this.maritalStatusField;
            }
            set {
                this.maritalStatusField = value;
            }
        }
        
        /// <comentarios/>
        public char Gender {
            get {
                return this.genderField;
            }
            set {
                this.genderField = value;
            }
        }
        
        /// <comentarios/>
        public System.DateTime HireDate {
            get {
                return this.hireDateField;
            }
            set {
                this.hireDateField = value;
            }
        }
        
        /// <comentarios/>
        public bool SalariedFlag {
            get {
                return this.salariedFlagField;
            }
            set {
                this.salariedFlagField = value;
            }
        }
        
        /// <comentarios/>
        public short VacationHours {
            get {
                return this.vacationHoursField;
            }
            set {
                this.vacationHoursField = value;
            }
        }
        
        /// <comentarios/>
        public short SickLeaveHours {
            get {
                return this.sickLeaveHoursField;
            }
            set {
                this.sickLeaveHoursField = value;
            }
        }
        
        /// <comentarios/>
        public bool CurrentFlag {
            get {
                return this.currentFlagField;
            }
            set {
                this.currentFlagField = value;
            }
        }
        
        /// <comentarios/>
        public System.Guid rowguid {
            get {
                return this.rowguidField;
            }
            set {
                this.rowguidField = value;
            }
        }
        
        /// <comentarios/>
        public System.DateTime ModifiedDate {
            get {
                return this.modifiedDateField;
            }
            set {
                this.modifiedDateField = value;
            }
        }
        
        /// <comentarios/>
        public Employee[] Employees {
            get {
                return this.employeesField;
            }
            set {
                this.employeesField = value;
            }
        }
        
        /// <comentarios/>
        public Employee Employee1 {
            get {
                return this.employee1Field;
            }
            set {
                this.employee1Field = value;
            }
        }
        
        /// <comentarios/>
        public Contact Contact {
            get {
                return this.contactField;
            }
            set {
                this.contactField = value;
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Contact {
        
        private int contactIDField;
        
        private bool nameStyleField;
        
        private string titleField;
        
        private string firstNameField;
        
        private string middleNameField;
        
        private string lastNameField;
        
        private string suffixField;
        
        private string emailAddressField;
        
        private int emailPromotionField;
        
        private string phoneField;
        
        private string passwordHashField;
        
        private string passwordSaltField;
        
        private System.Xml.XmlElement additionalContactInfoField;
        
        private System.Guid rowguidField;
        
        private System.DateTime modifiedDateField;
        
        private Employee[] employeesField;
        
        /// <comentarios/>
        public int ContactID {
            get {
                return this.contactIDField;
            }
            set {
                this.contactIDField = value;
            }
        }
        
        /// <comentarios/>
        public bool NameStyle {
            get {
                return this.nameStyleField;
            }
            set {
                this.nameStyleField = value;
            }
        }
        
        /// <comentarios/>
        public string Title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
        
        /// <comentarios/>
        public string FirstName {
            get {
                return this.firstNameField;
            }
            set {
                this.firstNameField = value;
            }
        }
        
        /// <comentarios/>
        public string MiddleName {
            get {
                return this.middleNameField;
            }
            set {
                this.middleNameField = value;
            }
        }
        
        /// <comentarios/>
        public string LastName {
            get {
                return this.lastNameField;
            }
            set {
                this.lastNameField = value;
            }
        }
        
        /// <comentarios/>
        public string Suffix {
            get {
                return this.suffixField;
            }
            set {
                this.suffixField = value;
            }
        }
        
        /// <comentarios/>
        public string EmailAddress {
            get {
                return this.emailAddressField;
            }
            set {
                this.emailAddressField = value;
            }
        }
        
        /// <comentarios/>
        public int EmailPromotion {
            get {
                return this.emailPromotionField;
            }
            set {
                this.emailPromotionField = value;
            }
        }
        
        /// <comentarios/>
        public string Phone {
            get {
                return this.phoneField;
            }
            set {
                this.phoneField = value;
            }
        }
        
        /// <comentarios/>
        public string PasswordHash {
            get {
                return this.passwordHashField;
            }
            set {
                this.passwordHashField = value;
            }
        }
        
        /// <comentarios/>
        public string PasswordSalt {
            get {
                return this.passwordSaltField;
            }
            set {
                this.passwordSaltField = value;
            }
        }
        
        /// <comentarios/>
        public System.Xml.XmlElement AdditionalContactInfo {
            get {
                return this.additionalContactInfoField;
            }
            set {
                this.additionalContactInfoField = value;
            }
        }
        
        /// <comentarios/>
        public System.Guid rowguid {
            get {
                return this.rowguidField;
            }
            set {
                this.rowguidField = value;
            }
        }
        
        /// <comentarios/>
        public System.DateTime ModifiedDate {
            get {
                return this.modifiedDateField;
            }
            set {
                this.modifiedDateField = value;
            }
        }
        
        /// <comentarios/>
        public Employee[] Employees {
            get {
                return this.employeesField;
            }
            set {
                this.employeesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    public delegate void ExecuteServiceCompletedEventHandler(object sender, ExecuteServiceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExecuteServiceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ExecuteServiceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Employee Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Employee)(this.results[0]));
            }
        }
    }
}