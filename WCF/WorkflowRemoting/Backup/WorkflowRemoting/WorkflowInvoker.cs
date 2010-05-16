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
using System.Threading;
using System.Security.Principal;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Runtime.Hosting;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
#endregion

namespace RKiss.WorkflowRemoting
{
    #region LogicalWorkflowContext
    [Serializable]
    [DataContract(Name = "LogicalWorkflowContext", Namespace = "RKiss.WorkflowRemoting")]
    [KnownType(typeof(HybridDictionary))]
    public sealed class LogicalWorkflowContext : ILogicalThreadAffinative, IDisposable 
    {
        #region Fields
        private DateTime _createdDT;
        private Guid _contextId;
        private Guid _workflowId;
        Dictionary<string, object> _workflowInitData = new Dictionary<string, object>();
        Dictionary<string, object> _properties = new Dictionary<string,object>();
        #endregion

        #region DataMembers
        [DataMember]
        public DateTime CreatedDT
        {
            get { return _createdDT; }
            set { _createdDT = value; }
        }
        [DataMember]
        public Guid ContextId
        {
            get { return _contextId; }
            set { _contextId = value; }
        }
        [DataMember]
        public Dictionary<string, object> WorkflowInitData
        {
            get { return _workflowInitData; }
            set { _workflowInitData = value; }
        }
        [DataMember]
        public Guid WorkflowId
        {
            get { return _workflowId; }
            set { _workflowId = value; }
        }
        [DataMember]
        public Dictionary<string, object> Properties
        {
            get { return _properties; }
            set { _properties = value; }
        }
        #endregion

        #region Constructors
        public LogicalWorkflowContext() : this(Guid.Empty) {}
        public LogicalWorkflowContext(Guid workflowId)
        {
            ContextId = Guid.NewGuid();
            WorkflowId = workflowId;
        }
        #endregion

        #region Methods
        public Guid GetAndClearWorkflowId()
        {
            Guid id = WorkflowId;
            WorkflowId = Guid.Empty;
            return id;
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            CallContext.FreeNamedDataSlot("LogicalWorkflowContext");
            GC.SuppressFinalize(this); 
        }
        #endregion
    }
    #endregion

    #region CreateWorkflowByXOMLAttribute
    public class CreateWorkflowByXOMLAttribute : Attribute
    {
        private string _workflowDefinitionKey = string.Empty;
        private string _rulesKey = string.Empty;

        public string WorkflowDefinitionKey
        {
            get { return _workflowDefinitionKey; }
            set { _workflowDefinitionKey = value; }
        }
        public string RulesKey
        {
            get { return _rulesKey; }
            set { _rulesKey = value; }
        }	
    }
    #endregion

    #region IXomlLoader
    [ServiceContract]
    public interface IXomlLoader
    {
        [OperationContract]
        Stream GetWorkflowDefinition(string key, Dictionary<string, object> namedArgumentValues);
        [OperationContract]
        Stream GetWorkflowRules(string key, Dictionary<string, object> namedArgumentValues);       
    }
    #endregion

    #region Workflow Local Service - Contract
    [ExternalDataExchange]
    public interface IInvokerLocalService
    {
        // to workflow
        event EventHandler<RequestEventArgs> Request;

        // from workflow
        void RaiseResponseEvent(Guid workflowInstanceId, object response);
    }
    #endregion

    #region ExternalDataEventArgs
    [Serializable]
    public class RequestEventArgs : ExternalDataEventArgs
    {
        private object _request;
        public RequestEventArgs(Guid InstanceId, object request)
            : base(InstanceId)
        {
            this._request = request;
        }
        public object Request
        {
            get { return _request; }
            set { _request = value; }
        }
    }
    [Serializable]
    public class ResponseEventArgs : ExternalDataEventArgs
    {
        private object _response;
        public ResponseEventArgs(Guid InstanceId, object response)
            : base(InstanceId)
        {
            this._response = response;
        }
        public object Response
        {
            get { return _response; }
            set { _response = value; }
        }
    }
    #endregion

    #region Workflow Local Service - Implementation
    public class InvokerLocalService : IInvokerLocalService
    {
        private WorkflowRuntime _workflowRuntime;
        private ManualWorkflowSchedulerService _scheduler;
        public WorkflowRuntime WorkflowRuntime { get { return _workflowRuntime; } }
        public ManualWorkflowSchedulerService Scheduler { get { return _scheduler; } }
        public InvokerLocalService(WorkflowRuntime workflowRuntime)
        {
            if (workflowRuntime == null)
                throw new ArgumentNullException("workflowRuntime");

            this._workflowRuntime = workflowRuntime;
            this._scheduler = workflowRuntime.GetService<ManualWorkflowSchedulerService>();  
        }
  
        #region IInvokerLocalService Members - to workflow
        public event EventHandler<RequestEventArgs> Request;
        public void RaiseRequestEvent(Guid workflowInstanceId, object request)
        {
            RaiseRequestEvent(workflowInstanceId, request, string.Empty, false);
        }
        public void RaiseRequestEvent(Guid workflowInstanceId, object request, string identity, bool bStateMachine)
        {
            // Create the EventArgs for this event
            RequestEventArgs e = new RequestEventArgs(workflowInstanceId, request);
            e.Identity = identity;
            e.WaitForIdle = bStateMachine;

            // Raise the event
            if (this.Request != null)
            {
                if (this.Scheduler == null)
                {
                    this.Request(null, e);
                }
                else
                {
                    this.Scheduler.RunWorkflow(workflowInstanceId);
                    this.Request(null, e);
                    this.Scheduler.RunWorkflow(workflowInstanceId);
                }
            }
        }
        #endregion

        #region IInvokerLocalService Members - from workflow
        public event EventHandler<ResponseEventArgs> Response;
        public void RaiseResponseEvent(Guid workflowInstanceId, object response)
        {
            // Create the EventArgs for this event
            ResponseEventArgs e = new ResponseEventArgs(workflowInstanceId, response);

            // Raise the event
            if (this.Response != null)
            {
                this.Response(null, e);
            }
        }
        #endregion
    }
    #endregion

    #region WorkflowInvoker
    public class WorkflowInvoker
    {
        #region private Constructor
        private WorkflowInvoker()
        {
        }
        #endregion

        #region Create
        public static Invoker Create(Type workflowType, Dictionary<string, object> namedArgumentValues)
        {
            return Create(workflowType, namedArgumentValues, Guid.NewGuid());
        }
        public static Invoker Create(string workflowTypeName, Dictionary<string, object> namedArgumentValues)
        {
            return Create(Type.GetType(workflowTypeName), namedArgumentValues, Guid.NewGuid());
        }
        public static Invoker Create(Type workflowType)
        {
            return Create(workflowType, null, Guid.NewGuid());
        }
        public static Invoker Create(string workflowTypeName)
        {
            return Create(Type.GetType(workflowTypeName), null, Guid.NewGuid());
        }
        public static Invoker Create(Type workflowType, Dictionary<string, object> namedArgumentValues, Guid instanceId)
        {
            return Create(workflowType, namedArgumentValues, instanceId, true);
        }
        public static Invoker Create(Type workflowType, Dictionary<string, object> namedArgumentValues, Guid instanceId, bool bStart)
        {
            if (workflowType == null)
                throw new ArgumentNullException("Invoker requires a workflowType");

            // state machine?
            bool isStateMachine = (workflowType.BaseType == typeof(StateMachineWorkflowActivity));

            // workflow runtime core
            WorkflowRuntime workflowRuntime = WorkflowHosting.WorkflowRuntime;

            // Get a reference to the ExternalDataExchangeService from the WorkflowRuntime
            ExternalDataExchangeService dataExchangeService = workflowRuntime.GetService<ExternalDataExchangeService>();

            // Get a reference to the LocalService
            InvokerLocalService invokerLocalService = (InvokerLocalService)dataExchangeService.GetService(typeof(InvokerLocalService));
    
            // check XOML attribute
            object[] attributes = workflowType.GetCustomAttributes(typeof(CreateWorkflowByXOMLAttribute), true);

            // create workflow instance based on the configuration options
            WorkflowInstance instance = null;
            if (attributes == null || attributes.Length == 0)
            {
                // default: create instance of the workflow
                instance = workflowRuntime.CreateWorkflow(workflowType, namedArgumentValues, instanceId);
            }
            else
            {
                // options: direct from the file system or via a custom XomlLoader (database, filesystem, remoting, ...)
                CreateWorkflowByXOMLAttribute attribute = attributes[0] as CreateWorkflowByXOMLAttribute;

                try
                {
                    // sources link
                    string workflowDefinitionSource = attribute.WorkflowDefinitionKey.StartsWith("@") ? ConfigurationManager.AppSettings[attribute.WorkflowDefinitionKey.Substring(1)] : attribute.WorkflowDefinitionKey;
                    string rulesSource = attribute.RulesKey.StartsWith("@") ? ConfigurationManager.AppSettings[attribute.RulesKey.Substring(1)] : attribute.RulesKey;

                    // text readers
                    bool bIsXomlLoader = workflowType.GetInterface(typeof(IXomlLoader).FullName) != null;
                    if (bIsXomlLoader)
                    {
                        IXomlLoader loader = Activator.CreateInstance(workflowType) as IXomlLoader;
                        using (Stream xomlStream = loader.GetWorkflowDefinition(workflowDefinitionSource, namedArgumentValues))
                        using (Stream rulesStream = loader.GetWorkflowRules(rulesSource, namedArgumentValues))
                        using (XmlTextReader xomlReader = xomlStream == null ? null : new XmlTextReader(xomlStream))
                        using (XmlTextReader rulesReader = rulesStream == null ? null : new XmlTextReader(rulesStream))
                        {
                            instance = workflowRuntime.CreateWorkflow(xomlReader, rulesReader, null, instanceId);
                        }
                    }
                    else
                    {
                        using (XmlTextReader xomlReader = string.IsNullOrEmpty(workflowDefinitionSource) ? null : new XmlTextReader(workflowDefinitionSource))
                        using (XmlTextReader rulesReader = string.IsNullOrEmpty(rulesSource) ? null : new XmlTextReader(rulesSource))
                        {
                           instance = workflowRuntime.CreateWorkflow(xomlReader, rulesReader, null, instanceId);
                        }
                    }                  
                }
                catch (WorkflowValidationFailedException ex)
                {
                    string errMsg = string.Format("{0} {1} TotalErrors={2}", ex.Message, ex.Errors[0].ErrorText, ex.Errors.Count);
                    ex.GetType().BaseType.InvokeMember("_message", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.ExactBinding | BindingFlags.FlattenHierarchy | BindingFlags.Instance, null, ex, new object[1] { errMsg }, CultureInfo.InvariantCulture);
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            
            // start workflow
            if (bStart)
            {
                instance.Start();
            }

            // plug-in the local service 
            Invoker invoker = new Invoker(invokerLocalService, instance, isStateMachine);

            // now we can communicate with workflow instance
            return invoker;
        }
        public static Invoker Create(Guid instanceId)
        {
            // workflow runtime core
            WorkflowRuntime workflowRuntime = WorkflowHosting.WorkflowRuntime;

            // Get a reference to the ExternalDataExchangeService from the WorkflowRuntime
            ExternalDataExchangeService dataExchangeService = workflowRuntime.GetService<ExternalDataExchangeService>();

            // Get a reference to the LocalService
            InvokerLocalService invokerLocalService = (InvokerLocalService)dataExchangeService.GetService(typeof(InvokerLocalService));

            // get instance of the workflow
            WorkflowInstance instance = workflowRuntime.GetWorkflow(instanceId);
    
            try 
            {
                // workaround to detect WorkflowStatus, if the status == Created, the executor will start this instance
                instance.Start(); 
            }
            catch(Exception ex) 
            {
                // WorkflowStatus != Created (therefore we can go ahead and use it)
                Trace.WriteLine(ex.Message);
            }

            // plug-in the local service 
            Invoker invoker = new Invoker(invokerLocalService, instance, true);

            // now we can communicate with workflow instance
            return invoker;
        }
        public static bool CreateAndUnload(Type workflowType, Dictionary<string, object> namedArgumentValues, Guid instanceId)
        {
            Invoker invoker = Create(workflowType, namedArgumentValues, instanceId, false);
            return invoker.WorkflowInstance.TryUnload();
        }
        public static bool CreateAndUnload(string workflowUri, Dictionary<string, object> namedArgumentValues, Guid instanceId)
        {
            Type workflowType = RemotingServices.GetServerTypeForUri(workflowUri);
            return CreateAndUnload(workflowType, namedArgumentValues, instanceId);
        }
        #endregion

        #region RequestResponse
        public static T RequestResponse<T>(Type workflowType, object request) where T : class
        {
            return RequestResponse<T>(workflowType, request, null, int.MaxValue / 1000);
        }
        public static T RequestResponse<T>(Type workflowType, object request, Dictionary<string, object> namedArgumentValues) where T : class
        {
            return RequestResponse<T>(workflowType, request, namedArgumentValues, int.MaxValue / 1000);
        }
        public static T RequestResponse<T>(Type workflowType, object request, Dictionary<string, object> namedArgumentValues, int timeoutInSec) where T : class
        {
            return RequestResponse<T>(workflowType, request, namedArgumentValues, timeoutInSec, string.Empty); 
        }
        public static T RequestResponse<T>(Type workflowType, object request, Dictionary<string, object> namedArgumentValues, int timeoutInSec, string identity) where T : class
        {
            // create workflow invoker
            Invoker invoker = WorkflowInvoker.Create(workflowType, namedArgumentValues);

            // pass request object to the workflow
            invoker.RaiseRequestEvent(request, identity);

            // wait for response from workflow
            invoker.WaitForResponse(timeoutInSec);

            // response
            return invoker.GetResponse<T>();
        }
        #endregion

        #region Remoting sender
        public static T Contract<T>(string endpoint) where T: class
        {
            return (T)Activator.GetObject(typeof(T), endpoint);
        }
        #endregion

        #region Identity
        public static string Identity()
        {
            string identity = null;
            IIdentity threadIdentity = Thread.CurrentPrincipal.Identity;
            WindowsIdentity windowsIdentity = threadIdentity as WindowsIdentity;
            if (windowsIdentity != null && windowsIdentity.User != null)
            {
                identity = windowsIdentity.User.Translate(typeof(NTAccount)).ToString();
            }
            else if (threadIdentity != null && windowsIdentity != null)
            {
                identity = windowsIdentity.Name;
            }
            return identity;
        }
        #endregion
    }
    #endregion

    #region Invoker
    public class Invoker
    {
        #region Private
        AutoResetEvent _waitForResponse = new AutoResetEvent(false);
        WorkflowTerminatedEventArgs _eT;
        WorkflowSuspendedEventArgs _eS;
        WorkflowCompletedEventArgs _eC;
        InvokerLocalService _localservice;
        ResponseEventArgs _response;
        WorkflowInstance _instance;
        bool _bStateMachine = false;
        #endregion

        #region Properties
        public WorkflowInstance WorkflowInstance
        {
            get { return _instance; }
        }
        public WorkflowTerminatedEventArgs WorkflowTerminatedEventArgs
        {
            get { return _eT; }
        }
        public WorkflowSuspendedEventArgs WorkflowSuspendedEventArgs
        {
            get { return _eS; }
        }
        public WorkflowCompletedEventArgs WorkflowCompletedEventArgs
        {
            get { return _eC; }
        }
        #endregion

        #region Constructor
        public Invoker(InvokerLocalService localservice, WorkflowInstance instance, bool bStateMachine)
        {
            _instance = instance;
            _localservice = localservice;
            _bStateMachine = bStateMachine;

            // response handler
            _localservice.Response += new EventHandler<ResponseEventArgs>(localservice_FireResponse);

            // exception handlers
            _localservice.WorkflowRuntime.WorkflowTerminated += new EventHandler<WorkflowTerminatedEventArgs>(OnWorkflowTerminated);
            _localservice.WorkflowRuntime.WorkflowSuspended += new EventHandler<WorkflowSuspendedEventArgs>(OnWorkflowSuspended);

            // completed handler
            _localservice.WorkflowRuntime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(OnWorkflowCompleted);
        }      
        #endregion

        #region To workflow
        public void SendMessage(IMethodMessage message)
        {    
            // identity
            string identity = WorkflowInvoker.Identity();
            if (!string.IsNullOrEmpty(identity) && message.LogicalCallContext != null)
            {
                // workaround to create an IdentityContextData for LogicalCallContext 
                Type type = Type.GetType("System.Workflow.Activities.IdentityContextData, System.Workflow.Activities, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
                object identityContextData = Activator.CreateInstance(type, BindingFlags.CreateInstance | BindingFlags.ExactBinding | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new object[] { identity }, CultureInfo.CurrentCulture);
                message.LogicalCallContext.SetData("__identitycontext__", identityContextData);
            }

            // contract type
            Type contractType = Type.GetType(message.TypeName);
            if (contractType == null)
                throw new TypeLoadException(message.TypeName);

            // create queue name
            EventQueueName qn = new EventQueueName(contractType, message.MethodName);
            
            // enqueue item
            if (_bStateMachine)
            {
                if (_localservice.Scheduler != null)
                    _localservice.Scheduler.RunWorkflow(_instance.InstanceId);
                _instance.EnqueueItemOnIdle(qn, message, null, null);
            }
            else
            {
                _instance.EnqueueItem(qn, message, null, null);
            }          
            if (_localservice.Scheduler != null)
                _localservice.Scheduler.RunWorkflow(_instance.InstanceId);
        }
        public void RaiseRequestEvent(object request)
        {
            _localservice.RaiseRequestEvent(_instance.InstanceId, request);
        }
        public void RaiseRequestEvent(object request, string identity)
        {
            _localservice.RaiseRequestEvent(_instance.InstanceId, request, identity, _bStateMachine);
        }
        #endregion

        #region Handlers
        public void OnWorkflowTerminated(object sender, WorkflowTerminatedEventArgs e)
        {
            if (_instance.InstanceId == e.WorkflowInstance.InstanceId)
            {
                this._eT = e;
                _waitForResponse.Set();
                _localservice.WorkflowRuntime.WorkflowTerminated -= new EventHandler<WorkflowTerminatedEventArgs>(OnWorkflowTerminated);
            }
        }
        public void OnWorkflowSuspended(object sender, WorkflowSuspendedEventArgs e)
        {
            if (_instance.InstanceId == e.WorkflowInstance.InstanceId)
            {
                this._eS = e;
                _waitForResponse.Set();
                _localservice.WorkflowRuntime.WorkflowSuspended -= new EventHandler<WorkflowSuspendedEventArgs>(OnWorkflowSuspended);
            }
        }
        public void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            if (_instance.InstanceId == e.WorkflowInstance.InstanceId)
            {
                this._eC = e;
                _waitForResponse.Set();
                _localservice.WorkflowRuntime.WorkflowCompleted -= new EventHandler<WorkflowCompletedEventArgs>(OnWorkflowCompleted);
            }
        }
        #endregion

        #region WaitForResponse
        public void WaitForResponse()
        {
            WaitForResponse(int.MaxValue);
        }
        public void WaitForResponse(int secondsTimeOut)
        {
            bool retval = _waitForResponse.WaitOne(secondsTimeOut * 1000, false);
            if (_eT != null)
                throw this._eT.Exception;
            if (_eS != null)
                throw new WorkflowSuspendedException(_eS.Error);
            if (retval == false)
                throw new Exception("The workflow timeout expired");
        }
        #endregion

        #region From workflow
        public void localservice_FireResponse(object sender, ResponseEventArgs e)
        {
            if (_instance.InstanceId == e.InstanceId)
            {
                _response = e;
                _waitForResponse.Set();
                _localservice.Response -= new EventHandler<ResponseEventArgs>(localservice_FireResponse);
            }
        }    
        public T GetResponse<T>() where T : class
        {
            return _response == null ? default(T) : (T)_response.Response;
        }
        public Dictionary<string, object> OutputParameters
        {
            get
            {
                return this._eC == null ? null : _eC.OutputParameters;
            }
        }
        #endregion     
    }
    #endregion

    #region WorkflowSuspendedException
    [Serializable]
    public sealed class WorkflowSuspendedException : Exception
    {
          // Methods
          public WorkflowSuspendedException(){}
          public WorkflowSuspendedException(string message) : base(message) {}
          private WorkflowSuspendedException(SerializationInfo info, StreamingContext context) : base(info, context){}
          public WorkflowSuspendedException(string message, Exception exception) : base(message, exception){}
    }
    #endregion
}

//WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();
//Activity activity = serializer.Deserialize(xomlReader) as Activity;
//instance = workflowRuntime.CreateWorkflow(activity.GetType(), null, instanceId);


