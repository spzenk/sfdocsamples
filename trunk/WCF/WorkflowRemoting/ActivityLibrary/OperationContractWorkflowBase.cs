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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
//
using RKiss.WorkflowRemoting;
#endregion

namespace RKiss.ActivityLibrary
{
    [Designer(typeof(OperationContractWorkflowDesigner), typeof(IRootDesigner))]
    [ActivityValidator(typeof(OperationContractWorkflowValidator))]
    public partial class OperationContractWorkflowBase : SequentialWorkflowActivity, IEventActivity, IActivityEventListener<QueueEventArgs>, ITypeFilterProvider
    {
        #region Private Members
        private EventQueueName _queueName;
        #endregion

        #region Properties and Events
        public readonly static DependencyProperty ReceivedEvent = DependencyProperty.Register("Received", typeof(EventHandler), typeof(OperationContractWorkflowBase));
        public static readonly DependencyProperty TypeProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Type", typeof(Type), typeof(OperationContractWorkflowBase), new PropertyMetadata(DependencyPropertyOptions.Metadata));
        public static readonly DependencyProperty MethodNameProperty = System.Workflow.ComponentModel.DependencyProperty.Register("MethodName", typeof(string), typeof(OperationContractWorkflowBase), new PropertyMetadata(DependencyPropertyOptions.Metadata));
        public static readonly DependencyProperty ParametersProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Parameters", typeof(WorkflowParameterBindingCollection), typeof(OperationContractWorkflowBase), new PropertyMetadata(DependencyPropertyOptions.Metadata | DependencyPropertyOptions.ReadOnly));
        #endregion

        #region Constructor
        public OperationContractWorkflowBase()
        {
            this.Name = "OperationContractWorkflowBase";
            base.SetReadOnlyPropertyValue(OperationContractWorkflowBase.ParametersProperty, new WorkflowParameterBindingCollection(this));
        }
        #endregion

        #region Initialize
        protected override void Initialize(IServiceProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            if (this.Parent != null)
                throw new InvalidOperationException("This is a root Activity");

            _queueName = new EventQueueName(this.Type, this.MethodName);
            WorkflowQueuingService queueService = (WorkflowQueuingService)provider.GetService(typeof(WorkflowQueuingService));
            if (queueService != null)
            {
                WorkflowQueue queue = null;
                if (queueService.Exists(_queueName))
                {
                    queue = queueService.GetWorkflowQueue(_queueName);
                    queue.Enabled = true;
                }
                else
                {
                    queue = queueService.CreateWorkflowQueue(_queueName, true);
                }
            }
            base.Initialize(provider);
        }
        #endregion

        #region Execute
        protected sealed override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            if (executionContext == null)
                throw new ArgumentNullException("executionContext");

            WorkflowQueuingService queueService = executionContext.GetService<WorkflowQueuingService>();
            WorkflowQueue queue = queueService.GetWorkflowQueue(_queueName);
            queue.RegisterForQueueItemAvailable(this, this.QualifiedName);

            if (queue.Count > 0)
            {
                object item = queue.Dequeue();
                ProcessQueueItem(executionContext, item);
                queue.UnregisterForQueueItemAvailable(this);

                // run all Activities
                return base.Execute(executionContext);
            }
            return ActivityExecutionStatus.Executing;
        }
        #endregion

        #region Activity clossing
        protected override void OnClosed(IServiceProvider provider)
        {
            base.OnClosed(provider);
            WorkflowQueuingService queueService = (WorkflowQueuingService)provider.GetService(typeof(WorkflowQueuingService));
            if (_queueName != null && queueService != null)
            {
                queueService.DeleteWorkflowQueue(_queueName);
            }
        }

        protected sealed override ActivityExecutionStatus Cancel(ActivityExecutionContext executionContext)
        {
            if (executionContext == null)
                throw new ArgumentNullException("executionContext");

            WorkflowQueuingService queueService = executionContext.GetService<WorkflowQueuingService>();
            if (_queueName != null && queueService != null)
            {
                WorkflowQueue queue = queueService.GetWorkflowQueue(_queueName);
                queue.UnregisterForQueueItemAvailable(this);
            }
            return ActivityExecutionStatus.Closed;
        }

        protected sealed override ActivityExecutionStatus HandleFault(ActivityExecutionContext executionContext, Exception exception)
        {
            if (executionContext == null)
                throw new ArgumentNullException("executionContext");
            if (exception == null)
                throw new ArgumentNullException("exception");

            ActivityExecutionStatus status = this.Cancel(executionContext);
            if (status == ActivityExecutionStatus.Canceling)
            {
                return ActivityExecutionStatus.Faulting;
            }
            return status;
        }
        #endregion

        #region IActivityEventListener Members
        void IActivityEventListener<QueueEventArgs>.OnEvent(object sender, QueueEventArgs e)
        {
            ActivityExecutionContext executionContext = sender as ActivityExecutionContext;
            WorkflowQueuingService queueService = executionContext.GetService<WorkflowQueuingService>();
            WorkflowQueue queue = queueService.GetWorkflowQueue(e.QueueName);

            if (queue.Count > 0)
            {
                object item = queue.Dequeue();
                ProcessQueueItem(executionContext, item);
                queue.UnregisterForQueueItemAvailable(this);

                // run all Activities
                base.Execute(executionContext);
            }
        }
        #endregion

        #region IEventActivity members
        void IEventActivity.Subscribe(ActivityExecutionContext parentContext, IActivityEventListener<QueueEventArgs> parentEventHandler)
        {
            WorkflowQueuingService queueService = parentContext.GetService<WorkflowQueuingService>();
            if (_queueName != null && queueService != null && parentEventHandler != null)
            {
                WorkflowQueue queue = queueService.GetWorkflowQueue(_queueName);
                queue.RegisterForQueueItemAvailable(parentEventHandler, this.QualifiedName);
            }
        }

        void IEventActivity.Unsubscribe(ActivityExecutionContext parentContext, IActivityEventListener<QueueEventArgs> parentEventHandler)
        {
            WorkflowQueuingService queueService = parentContext.GetService<WorkflowQueuingService>();
            if (_queueName != null && queueService != null && parentEventHandler != null)
            {
                WorkflowQueue queue = queueService.GetWorkflowQueue(_queueName);
                queue.UnregisterForQueueItemAvailable(parentEventHandler);
            }
        }

        IComparable IEventActivity.QueueName
        {
            get { return _queueName; }
        }
        #endregion

        #region ProcessQueueItem
        protected virtual void ProcessQueueItem(ActivityExecutionContext executionContext, object item)
        {
            IMethodCallMessage message = item as IMethodCallMessage;
            if (message == null)
            {
                Exception exception = message as Exception;
                if (exception != null)
                {
                    throw exception;
                }
                throw new InvalidOperationException("Invalid LocalServiceMessage");
            }
            else if (message.MethodName == this.MethodName)
            {
                // LogicalCallConetext
                LCC.CopyFrom(message);

                // roles
                Helpers.ValidateRoles(this, message);

                WorkflowParameterBindingCollection collection = this.Parameters;
                if (collection != null)
                {
                    int ii = 0;
                    MethodInfo mi = this.Type.GetMethod(this.MethodName);
                    if (mi != null)
                    {
                        foreach (ParameterInfo pi in mi.GetParameters())
                        {
                            if (!pi.ParameterType.IsByRef && (!pi.IsIn || !pi.IsOut))
                            {
                                if (collection.Contains(pi.Name))
                                {
                                    WorkflowParameterBinding binding = collection[pi.Name];
                                    binding.Value = message.InArgs[ii++];
                                }
                            }
                        }
                    }
                }

                // postprocessing
                OnReceived(EventArgs.Empty);
                base.RaiseEvent(OperationContractWorkflowBase.ReceivedEvent, this, EventArgs.Empty);

                // done
                return;
            }
            throw new InvalidOperationException("Invalid received MethodMessage");
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

        #region Activity Event Handlers
        [Description("Please specify the method to be called after the activity is executed")]
        [Category("Handlers")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event EventHandler Received
        {
            add
            {
                base.AddHandler(OperationContractWorkflowBase.ReceivedEvent, value);
            }
            remove
            {
                base.RemoveHandler(OperationContractWorkflowBase.ReceivedEvent, value);
            }
        }
        protected virtual void OnReceived(EventArgs e)
        {
        }
        #endregion

        #region Activity DependencyProperties
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("OperactionContract")]
        public WorkflowParameterBindingCollection Parameters
        {
            get
            {
                return ((WorkflowParameterBindingCollection)(base.GetValue(OperationContractWorkflowBase.ParametersProperty)));
            }
        }

        [Description("The type of the contract (Interface)")]
        [Category("OperactionContract")]
        [Browsable(true)]
        [Editor(typeof(TypeBrowserEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue((string)null), RefreshProperties(RefreshProperties.All)]
        [ValidationOption(ValidationOption.Required)]
        public Type Type
        {
            get
            {
                return ((Type)(base.GetValue(OperationContractWorkflowBase.TypeProperty)));
            }
            set
            {
                base.SetValue(OperationContractWorkflowBase.TypeProperty, value);
            }
        }

        [Description("Method of the contract (Interface)")]
        [Category("OperactionContract")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [MergableProperty(false), DefaultValue(""), TypeConverter(typeof(MethodPropertyValueProviderTypeConverter)), RefreshProperties(RefreshProperties.All)]
        [ValidationOption(ValidationOption.Required)]
        public string MethodName
        {
            get
            {
                return ((string)(base.GetValue(OperationContractWorkflowBase.MethodNameProperty)));
            }
            set
            {
                base.SetValue(OperationContractWorkflowBase.MethodNameProperty, value);
            }
        }
        #endregion
    }

    #region OperationContractWorkflowValidator
    public class OperationContractWorkflowValidator : CompositeActivityValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            Trace.WriteLine("OperationContractWorkflowValidator");

            #region validate Activity
            if (manager == null)
                throw new ArgumentNullException("manager");

            if (obj == null)
                throw new ArgumentNullException("obj");

            ValidationErrorCollection collection = base.Validate(manager, obj);
            if (collection.HasErrors)
                return collection;

            OperationContractWorkflowBase activity = obj as OperationContractWorkflowBase;
            collection.Clear();

            if (activity == null)
                throw new NullReferenceException("activity");

            #endregion

            #region validate Properties (In Order)
            if (activity.Type == null)
            {
                collection.Add(new ValidationError("The Type property is invalid (null).", 0, true, "Type"));
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
            if (activity.Type.GetMethod(activity.MethodName).ReturnType != typeof(void))
            {
                bool bExist = false;
                foreach (Activity item in activity.EnabledActivities)
                {
                    if (item is ReturnActivity)
                    {
                        ReturnActivity rra = item as ReturnActivity;
                        if (rra.ConnectorActivityName == activity.QualifiedName)
                        {
                            bExist = true;
                            break;
                        }
                    }
                }
                if (!bExist)
                {
                    collection.Add(new ValidationError("Missing corresponding ReturnActivity for handling a return value", 0));
                    return collection;
                }
            }
            #endregion

            return collection;
        }
    }
    #endregion
}
