//*****************************************************************************
//    Description.....Custom Remoting for Workflow
//                                
//    Author..........Roman Kiss, rkiss@pathcom.com
//    Copyright © 2006 ATZ Consulting Inc. (see included license.rtf file)        
//                        
//    Date Created:    07/07/06
//
//    Date        Modified By     Description
//-----------------------------------------------------------------------------
//    07/07/06    Roman Kiss     Initial Revision
//*****************************************************************************
//
#region References
using System;
using System.Globalization;
using System.Diagnostics;
using System.Configuration;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using System.Runtime.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Workflow.Runtime.Hosting; 
#endregion

namespace RKiss.ActivityLibrary
{
    [ToolboxBitmap(typeof(AdapterActivity), "Resources.Adapter.bmp")] 
    [ToolboxItem(typeof(ActivityToolboxItem))]
    [Designer(typeof(AdapterDesigner), typeof(IDesigner))]
    [ActivityValidator(typeof(InvokeRemotingValidator))]
    public class AdapterActivity : Activity, ITypeFilterProvider
    {
        #region Constructor
        public AdapterActivity()
        {
            this.Name = "AdapterActivity";
            base.SetReadOnlyPropertyValue(AdapterActivity.ParametersProperty, new WorkflowParameterBindingCollection(this));
        }
        #endregion

        #region Properties and Events
        public static readonly DependencyProperty TypeProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Type", typeof(Type), typeof(AdapterActivity), new PropertyMetadata(DependencyPropertyOptions.Metadata));
        public static readonly DependencyProperty MethodNameProperty = System.Workflow.ComponentModel.DependencyProperty.Register("MethodName", typeof(string), typeof(AdapterActivity), new PropertyMetadata(DependencyPropertyOptions.Metadata));
        public static readonly DependencyProperty UriProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Uri", typeof(string), typeof(AdapterActivity));
        public static readonly DependencyProperty ParametersProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Parameters", typeof(WorkflowParameterBindingCollection), typeof(AdapterActivity), new PropertyMetadata(DependencyPropertyOptions.Metadata | DependencyPropertyOptions.ReadOnly));
        public static DependencyProperty InvokingEvent = DependencyProperty.Register("Invoking", typeof(EventHandler), typeof(AdapterActivity));
        public static DependencyProperty InvokedEvent = DependencyProperty.Register("Invoked", typeof(EventHandler), typeof(AdapterActivity));
        #endregion

        #region Execute
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext aec)
        {
            // intercept before the call
            base.RaiseEvent(AdapterActivity.InvokingEvent, this, EventArgs.Empty);
            OnMethodInvoking(EventArgs.Empty);

            #region Invoke remoting object
            MethodInfo mi = Type.GetMethod(this.MethodName, BindingFlags.Public | BindingFlags.Instance);
            object[] objArray = Helpers.GetParameters(mi, this.Parameters);
            WorkflowParameterBinding returnValueBinding = null;
            if (this.Parameters.Contains("(ReturnValue)"))
            {
                returnValueBinding = this.Parameters["(ReturnValue)"];
            }
            try
            {
                // endpoint
                string objectUri = this.Uri.StartsWith("@") ? ConfigurationManager.AppSettings[this.Uri.Substring(1)] : this.Uri;
                if (string.IsNullOrEmpty(objectUri))
                    throw new Exception(string.Format("Missing endpoint in {0}", this.QualifiedName));

                object proxy = Activator.GetObject(this.Type, objectUri);
                object retVal = Type.InvokeMember(this.MethodName, BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, null, proxy, objArray, CultureInfo.InvariantCulture);
                if (returnValueBinding != null)
                {
                    returnValueBinding.Value = retVal;
                }
            }
            catch (TargetInvocationException ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                Trace.WriteLine(ex);
                throw;
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex);
                throw;
            }
            Helpers.SaveOutRefParameters(objArray, mi, this.Parameters);
            #endregion
            
            // intercept after the call
            base.RaiseEvent(AdapterActivity.InvokedEvent, this, EventArgs.Empty);
            OnMethodInvoked(EventArgs.Empty);

            // activity is done
            return ActivityExecutionStatus.Closed;
        }
        #endregion

        #region ITypeFilterProvider Members
        public bool CanFilterType(Type type, bool throwOnError)
        {
            return type.IsInterface;
        }
        string ITypeFilterProvider.FilterDescription
        {
            get { return "Browse and select Interface to reference:"; }
        }
        #endregion    

        #region Activity DependencyProperties
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("InterfaceContract")]
        public WorkflowParameterBindingCollection Parameters
        {
            get
            {
                return ((WorkflowParameterBindingCollection)(base.GetValue(AdapterActivity.ParametersProperty)));
            }

        }

        [Description("The interface contract for remoting object")]
        [Category("InterfaceContract")]
        [Browsable(true)]
        [Editor(typeof(TypeBrowserEditor), typeof(UITypeEditor))] 
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue((string)null), RefreshProperties(RefreshProperties.All)]
        [ValidationOption(ValidationOption.Required)]
        public Type Type
        {
            get
            {
                return ((Type)(base.GetValue(AdapterActivity.TypeProperty)));
            }
            set
            {
                base.SetValue(AdapterActivity.TypeProperty, value);
            }
        }

        [Description("Operation of the Interface contract")]
        [Category("InterfaceContract")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [MergableProperty(false), DefaultValue(""), TypeConverter(typeof(MethodPropertyValueProviderTypeConverter)), RefreshProperties(RefreshProperties.All)]
        [ValidationOption(ValidationOption.Required)]
        public string MethodName
        {
            get
            {
                return ((string)(base.GetValue(AdapterActivity.MethodNameProperty)));
            }
            set
            {
                base.SetValue(AdapterActivity.MethodNameProperty, value);
            }
        }

        [Description("Please specified the endpoint uri address of the remoting object")]
        [Category("Endpoint")]
        [Browsable(true)]
        [Editor(typeof(BindUITypeEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [MergableProperty(false)]
        [ValidationOption(ValidationOption.Required)]
        //[DefaultValue(@"msmqSender://localhost\Private$\OcrChannel_0/createocr")]
        public string Uri
        {
            get
            {
                return ((string)(base.GetValue(AdapterActivity.UriProperty)));
            }
            set
            {
                base.SetValue(AdapterActivity.UriProperty, value);
            }
        }
        #endregion

        #region Activity Event Handlers
        [Description("Please specify the method to be called before the activity is executed")]
        [Category("Handlers")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event EventHandler Invoking
        {
            add
            {
                base.AddHandler(AdapterActivity.InvokingEvent, value);
            }
            remove
            {
                base.RemoveHandler(AdapterActivity.InvokingEvent, value);
            }
        }

        [Description("Please specify the method to be called after the activity is executed")]
        [Category("Handlers")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event EventHandler Invoked
        {
            add
            {
                base.AddHandler(AdapterActivity.InvokedEvent, value);
            }
            remove
            {
                base.RemoveHandler(AdapterActivity.InvokedEvent, value);
            }
        }

        protected virtual void OnMethodInvoking(EventArgs e)
        {
        }
        protected virtual void OnMethodInvoked(EventArgs e)
        {
        }
        #endregion     
    }

    #region InvokeRemotingValidator
    public class InvokeRemotingValidator : ActivityValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            #region validate Activity
            if (manager == null)
                throw new ArgumentNullException("manager");

            if (obj == null)
                throw new ArgumentNullException("obj");

            ValidationErrorCollection collection = base.Validate(manager, obj);
            if (collection.HasErrors)
                return collection;

            AdapterActivity activity = obj as AdapterActivity;
            collection.Clear();

            if (activity == null)
                throw new NullReferenceException("activity");

            if (activity.Parent == null)
                return collection;

            //if (Helpers.IsLoopActivity(activity.Parent))
            //{
            //    collection.Add(new ValidationError("Activity can not be inside loop", 0));
            //    return collection;
            //}
            #endregion

            #region validate Properties (In Order)
            if (activity.Type == null)
            {
                collection.Add(new ValidationError("The Type property is invalid (null).", 0, false, "Type"));
                return collection;
            }

            if (!activity.Type.IsInterface)
            {
                collection.Add(new ValidationError("The Type is not Interface", 0, false, "Type"));
                return collection;
            }

            if (string.IsNullOrEmpty(activity.MethodName))
            {
                collection.Add(ValidationError.GetNotSetValidationError("MethodName"));
                return collection;
            }

            if (!activity.IsBindingSet(AdapterActivity.UriProperty))
            {
                if (string.IsNullOrEmpty(activity.Uri))
                {
                    collection.Add(ValidationError.GetNotSetValidationError("Uri"));
                    return collection;
                }
            }
            #endregion

            //Log.State(Log.StateSlot, "Activity_Validation", activity.Name);
            return collection;
        }
    }
    #endregion
}




