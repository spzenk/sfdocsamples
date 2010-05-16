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
using System.Threading;
using System.Globalization;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Runtime.Remoting.Messaging;
using System.Reflection;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Configuration;
using System.ComponentModel;
#endregion

namespace RKiss.WorkflowRemoting
{
    #region ChannelFactory2
    public class ChannelFactory2 : ChannelFactory
    {
        Type _channelType;
        IChannelFactory _factory;
        object _tp;

        public ChannelFactory2(Type channelType, string endpointConfigurationName)
        {
            if (!channelType.IsInterface)
                throw new InvalidOperationException("The channelType must be Interface");
            _channelType = channelType;
            base.InitializeEndpoint(endpointConfigurationName, null);
        }

        public object CreateChannel()
        {
            // create transparent proxy
            base.EnsureOpened();
            object[] objArray = new object[] { _channelType, base.Endpoint.Address, null };
            _tp = _factory.GetType().InvokeMember("CreateChannel", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, null, _factory, objArray, CultureInfo.InvariantCulture);
            return _tp;
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            _factory = base.CreateFactory();
            this.GetType().BaseType.InvokeMember("innerFactory", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance, null, this, new object[] { _factory }, CultureInfo.InvariantCulture);
            base.OnOpen(timeout);
        }

        protected override System.ServiceModel.Description.ServiceEndpoint CreateDescription()
        {
            ContractDescription desc = ContractDescription.GetContract(_channelType);
            return new ServiceEndpoint(desc);
        }

        public object InvokeMethod(string methodName, object[] args)
        {
            // invoke method on the transparent proxy
            if (_tp == null)
                throw new NullReferenceException("The channel is not created");
            object retVal = _tp.GetType().InvokeMember(methodName, BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, null, _tp, args, CultureInfo.InvariantCulture);
            return retVal;
        }
    }
    #endregion

    #region WorkflowInvokerAttribute
    [AttributeUsage(AttributeTargets.Method)]
    public class WorkflowInvokerAttribute : Attribute, IOperationBehavior
    {
        #region Properties
        private Type _workflowType;
        private string _workflowInitDataKey;
        private int _responseTime = 60;
        private string _callContextActors;

        public string WorkflowInitDataKey
        {
            get { return _workflowInitDataKey; }
            set { _workflowInitDataKey = value; }
        }
        public Type WorkflowType
        {
            get { return _workflowType; }
            set { _workflowType = value; }
        }
        public int ResponseTime
        {
            get { return _responseTime; }
            set { _responseTime = value; }
        }
        public string CallContextActors
        {
            get { return _callContextActors; }
            set { _callContextActors = value; }
        }
        #endregion

        #region Constructors
        public WorkflowInvokerAttribute()
        {
        }
        public WorkflowInvokerAttribute(Type workflowType, string workflowInitDataKey, int responseTime, string callContextActors)
        {
            _workflowType = workflowType;
            _workflowInitDataKey = workflowInitDataKey;
            _responseTime = responseTime;
            _callContextActors = callContextActors;
        }
        #endregion

        #region IOperationBehavior Members
        public void ApplyDispatchBehavior(OperationDescription description, DispatchOperation dispatch)
        {
            if (dispatch.Invoker is WorkflowOperationInvoker)
            {
                return;
            }
            dispatch.Invoker = new WorkflowOperationInvoker(WorkflowType, ResponseTime, CallContextActors, description, dispatch.Invoker);
        }
        public void AddBindingParameters(OperationDescription description, BindingParameterCollection parameters) { }
        public void ApplyClientBehavior(OperationDescription description, ClientOperation proxy) { }
        public void Validate(OperationDescription description) { }
        #endregion
    }
    #endregion

    #region Invoker
    public class WorkflowOperationInvoker : IOperationInvoker
    {
        #region Private Members
        Type _workflowType;
        private int _responseTime;
        OperationDescription _description;
        IOperationInvoker _innerOperationInvoker;
        string _callContextActors;
        #endregion

        #region Properties
        public Type WorkflowType
        {
            get { return _workflowType; }
        }
        public int ResponseTime
        {
            get { return _responseTime; }
        }
        #endregion

        #region Constructors
        public WorkflowOperationInvoker()
        {
        }
        public WorkflowOperationInvoker(Type workflowType, int responseTime, string callContextActors, OperationDescription description, IOperationInvoker innerOperationInvoker)
        {
            this._workflowType = workflowType;
            this._responseTime = responseTime;
            this._callContextActors = callContextActors;
            this._description = description;
            this._innerOperationInvoker = innerOperationInvoker;
        }
        #endregion

        #region IOperationInvoker Members
        object[] IOperationInvoker.AllocateInputs()
        {
            return this._innerOperationInvoker.AllocateInputs();
        }

        object IOperationInvoker.Invoke(object instance, object[] inputs, out object[] outputs)
        {
            outputs = new object[0];
            object retVal = null;
            Invoker invoker = null;

            // set incoming objects in the CallContext
            LCC.SetDataContract(OperationContext.Current.IncomingMessageHeaders, this._callContextActors);
            LogicalWorkflowContext lwc = LCC.LogicalWorkflowContext;

            // check the workflowId
            Guid workflowInstanceId = lwc.GetAndClearWorkflowId();
            bool bGetWorkflowById = !workflowInstanceId.Equals(Guid.Empty);
 
            // options for workflow type
            if (this._workflowType == null)
            {
                string endpointUri = string.Concat(instance.GetType().FullName, ".", this._description.SyncMethod.Name);
                this._workflowType = RemotingServices.GetServerTypeForUri(endpointUri);
            }
            if (!bGetWorkflowById && this._workflowType == null)
            {
                // throw exception or perform some pre-processing
                retVal = this._innerOperationInvoker.Invoke(instance, inputs, out outputs);

                // done (no workflow invoked)
                return retVal;
            }

            // create message operation
            MethodMessage message = new MethodMessage(this._description.SyncMethod, inputs, null);

            // workflow invoker options (statefull or stateless)
            if (bGetWorkflowById)
            {
                invoker = WorkflowInvoker.Create(workflowInstanceId);
            }
            else 
            {
                invoker = WorkflowInvoker.Create(this._workflowType, lwc.WorkflowInitData);
            }

            // send message to the workflow queue
            invoker.SendMessage(message);

            // response
            if (!this._description.IsOneWay)
            {
                invoker.WaitForResponse(this.ResponseTime);
                retVal = invoker.GetResponse<object>();
            }

            // done
            return retVal;
        }

        IAsyncResult IOperationInvoker.InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            return this._innerOperationInvoker.InvokeBegin(instance, inputs, callback, state);
        }
        object IOperationInvoker.InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            return this._innerOperationInvoker.InvokeEnd(instance, out outputs, result);
        }
        bool IOperationInvoker.IsSynchronous
        {
            get { return this._innerOperationInvoker.IsSynchronous; }
        }
        #endregion
    }
    #endregion

    #region MethodMessage
    [Serializable]
    public sealed class MethodMessage : IMethodCallMessage
    {
        #region Fields
        [NonSerialized]
        private object[] args;
        private LogicalCallContext callContext;
        private object[] clonedArgs;
        [NonSerialized]
        private Type interfaceType;
        [NonSerialized]
        private string methodName;
        [NonSerialized]
        private List<string> inArgName;
        #endregion

        #region Constructors
        public MethodMessage() { }
        public MethodMessage(MethodBase mb, object[] args, string identity)
        {
            this.interfaceType = mb.DeclaringType;
            this.methodName = mb.Name;
            this.args = args;
            inArgName = new List<string>();
            foreach (ParameterInfo pi in mb.GetParameters())
            {
                if (!pi.ParameterType.IsByRef && (!pi.IsIn || !pi.IsOut))
                {
                    inArgName.Add(pi.Name);
                }
            }
            this.callContext = LCC.LogicalCallContext;
            this.Clone();
        }
        #endregion

        #region IMethodCallMessage Members
        public object GetInArg(int argNum)
        {
            return clonedArgs[argNum];
        }
        public string GetInArgName(int index)
        {
            return inArgName[index];
        }
        public int InArgCount
        {
            get { return clonedArgs.Length; }
        }
        public object[] InArgs
        {
            get { return clonedArgs; }
        }
        #endregion

        #region IMethodMessage Members
        public int ArgCount
        {
            get { throw new NotImplementedException(); }
        }
        public object[] Args
        {
            get { throw new NotImplementedException(); }
        }
        public object GetArg(int argNum)
        {
            throw new NotImplementedException();
        }
        public string GetArgName(int index)
        {
            throw new NotImplementedException();
        }
        public bool HasVarArgs
        {
            get { throw new NotImplementedException(); }
        }
        public LogicalCallContext LogicalCallContext
        {
            get { return callContext; }
        }
        public MethodBase MethodBase
        {
            get { throw new NotImplementedException(); }
        }
        public string MethodName
        {
            get { return methodName; }
        }
        public object MethodSignature
        {
            get { throw new NotImplementedException(); }
        }
        public string TypeName
        {
            get { return interfaceType.AssemblyQualifiedName; }
        }
        public string Uri
        {
            get { throw new NotImplementedException(); }
        }
        #endregion

        #region IMessage Members
        public System.Collections.IDictionary Properties
        {
            get { throw new NotImplementedException(); }
        }
        #endregion

        #region Helpers
        private object Clone()
        {
            object[] objArray = new object[this.args.Length];
            for (int ii = 0; ii < this.args.Length; ii++)
            {
                objArray[ii] = this.Clone(this.args[ii]);
            }
            this.clonedArgs = objArray;
            return objArray;
        }
        private object Clone(object source)
        {
            if ((source == null) || source.GetType().IsValueType)
            {
                return source;
            }
            ICloneable cloneable = source as ICloneable;
            if (cloneable != null)
            {
                return cloneable.Clone();
            }
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(0x400);
            try
            {
                bf.Serialize(ms, source);
            }
            catch (SerializationException ex)
            {
                throw new InvalidOperationException("EventArgumentSerializationException", ex);
            }
            ms.Position = 0;
            return bf.Deserialize(ms);
        }
        #endregion
    }
    #endregion

    #region LogicalCallContextContract
    /// <summary>
    /// Utility for LogicalCallContext over the WCF connectivity
    /// </summary>
    public class LCC
    {
        private LCC() { }
        /// <summary>
        /// Get all DataContract object from the LogicalCallContext
        /// </summary>
        /// <returns>Dictionary all LogicalCallContext objects</returns>
        public static Dictionary<DataContractAttribute, object> GetDataContract()
        {
            Dictionary<DataContractAttribute, object> dic = new Dictionary<DataContractAttribute, object>();
            ExecutionContext context = ExecutionContext.Capture();
            LogicalCallContext lcc = context.GetType().InvokeMember("LogicalCallContext", BindingFlags.NonPublic | BindingFlags.ExactBinding | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance, null, context, new object[0], CultureInfo.InvariantCulture) as LogicalCallContext;
            object clone = lcc.Clone();
            Hashtable datastore = clone.GetType().InvokeMember("Datastore", BindingFlags.NonPublic | BindingFlags.ExactBinding | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance, null, clone, new object[0], CultureInfo.InvariantCulture) as Hashtable;
            if (datastore != null)
            {
                IDictionaryEnumerator enumerator = datastore.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    object[] attributes = enumerator.Value.GetType().GetCustomAttributes(typeof(DataContractAttribute), false);
                    if (attributes.Length > 0)
                    {
                        DataContractAttribute dca = attributes[0] as DataContractAttribute;
                        dic.Add(dca, enumerator.Value);
                    }
                }
            }
            return dic;
        }

        /// <summary>
        /// Set wellknown headers into the CallContext Thread slot
        /// </summary>
        /// <param name="headers">List of all message headers</param>
        /// <param name="actor">Role (actor) of the headers. Note this is also the name of the assembly, where must be declared all CallContext Headers.</param>
        public static void SetDataContract(MessageHeaders headers, string actor)
        {
            if (string.IsNullOrEmpty(actor))
            {
                try
                {
                    // wellknown header LogicalWorkflowContext
                    LogicalWorkflowContext lwc = headers.GetHeader<LogicalWorkflowContext>("LogicalWorkflowContext", "RKiss.WorkflowRemoting", "WorkflowRemoting");
                    if(lwc == null)
                        throw new NullReferenceException("Deserializer failed for header 'LogicalWorkflowContext'");

                    // set data into the Thread slot
                    CallContext.SetData("LogicalWorkflowContext", lwc);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex);
                }
            }
            else
            {
                bool bDoneForLWC = false;
                for (int ii = 0; ii < headers.Count; ii++)
                {
                    string typeName = string.Concat(headers[ii].Namespace, ".", headers[ii].Name, ",", headers[ii].Actor);
                    if (!bDoneForLWC && typeName == "RKiss.WorkflowRemoting.LogicalWorkflowContext,WorkflowRemoting")
                    {
                        object lwc = headers.GetHeader<LogicalWorkflowContext>(ii);
                        if (lwc == null)
                            throw new NullReferenceException("Deserializer failed for header 'LogicalWorkflowContext'");

                        // set data into the Thread slot
                        CallContext.SetData("LogicalWorkflowContext", lwc);

                        // next header
                        bDoneForLWC = true;
                        continue;
                    }
                    else if (!string.IsNullOrEmpty(headers[ii].Actor) && string.Concat(actor, ",").Contains(string.Concat(headers[ii].Actor, ",")))
                    {
                        try
                        {
                            Type type = Type.GetType(typeName);
                            if (type == null)
                                throw new TypeLoadException(typeName);

                            // deserializer
                            DataContractSerializer dcs = new DataContractSerializer(type, headers[ii].Name, headers[ii].Namespace);
                            object data = dcs.ReadObject(headers.GetReaderAtHeader(ii), true);

                            if (data == null)
                                throw new NullReferenceException(string.Format("Deserializer failed for header '{0}'", headers[ii].Name));

                            // set data into the Thread slot
                            CallContext.SetData(headers[ii].Name, data);
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex);
                        }
                    }
                }
            }
        }
        public static Hashtable CopyFrom(IMethodMessage message)
        {
            object clone = message.LogicalCallContext.Clone();
            Hashtable datastore = default(Hashtable);
            if (message != null && message.LogicalCallContext != null && message.LogicalCallContext.HasInfo)
            {
                datastore = clone.GetType().InvokeMember("Datastore", BindingFlags.NonPublic | BindingFlags.ExactBinding | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance, null, clone, new object[0], CultureInfo.InvariantCulture) as Hashtable;
                if (datastore != null)
                {
                    IDictionaryEnumerator enumerator = datastore.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        CallContext.SetData((string)enumerator.Key, enumerator.Value);
                    }
                }
            }
            return datastore;
        }
        public static List<string> GetKeys()
        {
            List<string> keys = new List<string>();
            ExecutionContext context = ExecutionContext.Capture();
            LogicalCallContext lcc = context.GetType().InvokeMember("LogicalCallContext", BindingFlags.NonPublic | BindingFlags.ExactBinding | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance, null, context, new object[0], CultureInfo.InvariantCulture) as LogicalCallContext;
            object clone = lcc.Clone();
            Hashtable datastore = clone.GetType().InvokeMember("Datastore", BindingFlags.NonPublic | BindingFlags.ExactBinding | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance, null, clone, new object[0], CultureInfo.InvariantCulture) as Hashtable;
            if (datastore != null)
            {
                IDictionaryEnumerator enumerator = datastore.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    keys.Add((string)enumerator.Key);
                }
            }
            return keys;
        }
        public static List<string> GetKeys(IMethodMessage message)
        {
            List<string> keys = new List<string>();
            object clone = message.LogicalCallContext.Clone();
            Hashtable datastore = clone.GetType().InvokeMember("Datastore", BindingFlags.NonPublic | BindingFlags.ExactBinding | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance, null, clone, new object[0], CultureInfo.InvariantCulture) as Hashtable;
            if (datastore != null)
            {
                IDictionaryEnumerator enumerator = datastore.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    keys.Add((string)enumerator.Key);
                }
            }
            return keys;
        }
        public static void FreeLogicalWorkflowContext()
        {
            CallContext.FreeNamedDataSlot("LogicalWorkflowContext");
        }
        public static object GetLogicalWorkflowContext
        {
            get
            {
                return CallContext.GetData("LogicalWorkflowContext");
            }
        }
        public static LogicalWorkflowContext LogicalWorkflowContext
        {
            get 
            { 
                LogicalWorkflowContext context = (LogicalWorkflowContext)CallContext.GetData("LogicalWorkflowContext");
                if (context == null)
                {
                    context = new LogicalWorkflowContext();
                    CallContext.SetData("LogicalWorkflowContext", context);
                }
                return context;
            }
        }
        public static LogicalCallContext LogicalCallContext
        {
            get
            {
                ExecutionContext context = ExecutionContext.Capture();
                LogicalCallContext lcc = context.GetType().InvokeMember("LogicalCallContext", BindingFlags.NonPublic | BindingFlags.ExactBinding | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance, null, context, new object[0], CultureInfo.InvariantCulture) as LogicalCallContext;
                return lcc.Clone() as LogicalCallContext;
            }
        }
    }
    #endregion

}

