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
using System.Diagnostics;
using System.Globalization;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Reflection;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
//
using RKiss.WorkflowRemoting;
#endregion

namespace RKiss.ActivityLibrary
{
    [ToolboxBitmap(typeof(ReturnActivity), "Resources.Response.bmp")]
    [ToolboxItem(typeof(ActivityToolboxItem))]
    [Designer(typeof(ReturnActivityDesigner), typeof(IDesigner))]
    [ActivityValidator(typeof(ReturnActivityValidator))]
    public class ReturnActivity : System.Workflow.ComponentModel.Activity
    {
        #region Register of the Properties and Events
        public readonly static DependencyProperty ConnectorActivityNameProperty = DependencyProperty.Register("ConnectorActivityName", typeof(string), typeof(ReturnActivity), new PropertyMetadata("", DependencyPropertyOptions.Metadata));
        public static readonly DependencyProperty ParametersProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Parameters", typeof(WorkflowParameterBindingCollection), typeof(ReturnActivity), new PropertyMetadata(DependencyPropertyOptions.Metadata | DependencyPropertyOptions.ReadOnly));
        public readonly static DependencyProperty InvokingEvent = DependencyProperty.Register("Invoking", typeof(EventHandler), typeof(ReturnActivity));
        #endregion

        #region Constructor
        public ReturnActivity()
        {
            this.Name = "ReturnActivity";
            base.SetReadOnlyPropertyValue(ReturnActivity.ParametersProperty, new WorkflowParameterBindingCollection(this));
        }
        #endregion

        #region Execute
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            if (executionContext == null)
                throw new ArgumentNullException("executionContext");
           
            Type type = typeof(IInvokerLocalService);

            object obj = executionContext.GetService(type);
            if (obj == null)
                throw new InvalidOperationException("IInvokerLocalService not found");

            // pre-processing
            base.RaiseEvent(ReturnActivity.InvokingEvent, this, EventArgs.Empty);
            this.OnInvoking(EventArgs.Empty);

            // return object
            object returnValue = null;
            if (this.ConnectorActivityName != "(None)")
            {
                returnValue = this.Parameters.Contains("(ReturnValue)") ? this.Parameters["(ReturnValue)"].GetValue(WorkflowParameterBinding.ValueProperty) : null;
            }

            // fire and forget in sync manner
            object[] args = new object[2] { this.WorkflowInstanceId, returnValue };
            type.InvokeMember("RaiseResponseEvent", BindingFlags.InvokeMethod, null, obj, args);

            return ActivityExecutionStatus.Closed;
        }
        #endregion

        #region GetParameterPropertyDescriptors
        internal void GetParameterPropertyDescriptors(IDictionary properties)
        {
            if (this.Site != null)
            {
                ITypeProvider provider = (ITypeProvider)this.Site.GetService(typeof(ITypeProvider));
                if (provider == null)
                {
                    throw new InvalidOperationException("Missing ITypeProvider Service");
                }
                if ((this.ConnectorActivityName != null) && !string.IsNullOrEmpty(this.ConnectorActivityName.Trim()))
                {
                    Activity activity = Helpers.GetRootActivity(this).GetActivityByName(this.ConnectorActivityName, false) as Activity;
                    if (activity != null)
                    {
                        Type type = activity.GetType().InvokeMember("Type", BindingFlags.ExactBinding | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance, null, activity, new object[0]) as Type;
                        string methodname = activity.GetType().InvokeMember("MethodName", BindingFlags.ExactBinding | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance, null, activity, new object[0]) as string;
                        if (type != null && !string.IsNullOrEmpty(methodname))
                        {
                            MethodInfo mi = type.GetMethod(methodname);
                            if (mi != null && mi.ReturnType != typeof(void))
                            {
                                Trace.WriteLine(string.Format("GetParameterPropertyDescriptors - ReturnType={0}", mi.ReturnType));
                                PropertyDescriptor descriptor = new ParameterBindingPropertyDescriptor<ReturnActivity>("(ReturnValue)", mi.ReturnType, new Attribute[] { DesignOnlyAttribute.Yes, new DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden), new BrowsableAttribute(true), new CategoryAttribute("Parameters"), new DescriptionAttribute(mi.ReturnType.FullName), new EditorAttribute(typeof(BindUITypeEditor), typeof(UITypeEditor)) });
                                if (descriptor != null)
                                {
                                    properties[descriptor.Name] = descriptor;
                                }
                            }
                        }
                    }
                }
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
                base.AddHandler(ReturnActivity.InvokingEvent, value);
            }
            remove
            {
                base.RemoveHandler(ReturnActivity.InvokingEvent, value);
            }
        }
        protected virtual void OnInvoking(EventArgs e)
        {
        }
        #endregion

        #region Activity DependencyProperties 
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("ToHostProcess")]
        public WorkflowParameterBindingCollection Parameters
        {
            get
            {
                return ((WorkflowParameterBindingCollection)(base.GetValue(ReturnActivity.ParametersProperty)));
            }
        }

        [Description("Please select a preceding ConnectorActivity name")]
        [Category("Activity")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue("")]
        [Editor(typeof(ConnectorActivityDropDownEditor), typeof(UITypeEditor))]
        public string ConnectorActivityName
        {
            get
            {
                return ((string)(base.GetValue(ReturnActivity.ConnectorActivityNameProperty)));
            }
            set
            {
                base.SetValue(ReturnActivity.ConnectorActivityNameProperty, value);
            }
        }
        #endregion
    }

    #region ReturnActivityValidator
    public class ReturnActivityValidator : ActivityValidator
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

            ReturnActivity activity = obj as ReturnActivity;
            collection.Clear();

            if (activity == null)
                throw new NullReferenceException("activity");

            if (activity.Parent != null)
            {
                //int lastIndex = activity.Parent.Activities.Count - 1;
                //if (activity.Parent.Activities[lastIndex].QualifiedName != activity.QualifiedName)
                //{
                //    collection.Add(new ValidationError("Activity must be at last position).", 0));
                //    return collection;
                //}
            }
            #endregion

            #region validate Properties (In Order)
            try
            {
                if (activity.Parent != null)
                {
                    if (string.IsNullOrEmpty(activity.ConnectorActivityName))
                    {
                        collection.Add(ValidationError.GetNotSetValidationError("ConnectorActivityName"));
                        return collection;
                    }

                    if (activity.ConnectorActivityName != "(None)")
                    {
                        Activity connector = Helpers.GetRootActivity(activity).GetActivityByName(activity.ConnectorActivityName, false) as Activity;
                        if (connector != null)
                        {
                            string methodname = connector.GetType().InvokeMember("MethodName", BindingFlags.ExactBinding | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance, null, connector, new object[0], CultureInfo.InvariantCulture) as string;
                            if (string.IsNullOrEmpty(methodname))
                            {
                                activity.ConnectorActivityName = default(string);
                                collection.Add(new ValidationError("Missing corresponding ConnectorActivity (MethodName)", 0));
                                return collection;
                            }
                            Type type = connector.GetType().InvokeMember("Type", BindingFlags.ExactBinding | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance, null, connector, new object[0], CultureInfo.InvariantCulture) as Type;
                            if (type == null)
                            {
                                collection.Add(new ValidationError("Missing corresponding ConnectorActivity (Type)", 0));
                                return collection;
                            }
                        }
                        else
                        {
                            activity.ConnectorActivityName = default(string);
                            collection.Add(new ValidationError("Missing corresponding ConnectorActivity", 0));
                            return collection;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
            #endregion

            return collection;
        }
    }
    #endregion
}
