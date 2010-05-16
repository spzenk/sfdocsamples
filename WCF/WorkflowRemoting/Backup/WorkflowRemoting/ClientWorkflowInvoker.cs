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
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Text;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.ServiceModel.Channels;
#endregion

namespace RKiss.WorkflowRemoting
{
    public class WorkflowDefaults
    {
        public const string WorkflowLocalhost = "wf://localhost/";
        public const string WorkflowByWCF = "wcf://";
    }

    #region ClientWorkflowInvoker
    /// <summary></summary>
	public class ClientWorkflowInvoker : IChannelSender, System.Runtime.Remoting.Channels.IChannel
    {
        #region private members
        private string _ChannelName = default(string);				
		private int	_ChannelPriority = default (int);			
		private int	_TimeOut = 60;
        private string _CallContextActor = default(string);
		private IClientChannelSinkProvider _Provider = null;	
		#endregion	

		#region properties
	    /// <summary></summary>
		public IClientChannelSinkProvider Provider 
		{ 
			get { return _Provider; }
		}
		/// <summary></summary>
		public int TimeOut					
		{ 
			get { return _TimeOut; }
		}
        /// <summary></summary>
        public string CallContextActor
        {
            get { return _CallContextActor; }
        }
		#endregion

		#region constructor
		/// <summary></summary>
		public ClientWorkflowInvoker(IDictionary properties, IClientChannelSinkProvider clientSinkProvider) 
		{	
			try 
			{	
                // configuration file
			    if(properties.Contains("timeout"))
                    _TimeOut = Convert.ToInt32(properties["timeout"]);
                if (properties.Contains("name"))
                    _ChannelName = Convert.ToString(properties["name"]);
                if (properties.Contains("callcontextActor"))
                    _CallContextActor = Convert.ToString(properties["callcontextActor"]);
             
				// channel provider
				_Provider = clientSinkProvider == null ? new BinaryClientFormatterSinkProvider() : clientSinkProvider;

				// add the ClientWorkflowInvokerProvider at the end
				IClientChannelSinkProvider provider = _Provider;
                while (provider.Next != null)
                {
                    provider = provider.Next;
                }
				provider.Next = new ClientWorkflowInvokerProvider();
			}
			catch(Exception ex) 
			{
                Trace.WriteLine(ex);
			}
		}
		#endregion

		#region IChannel members
		/// <summary></summary>
		public string ChannelName		
		{ 
			get { return _ChannelName; }
		}
		/// <summary></summary>
		public int ChannelPriority	
		{	
			get { return _ChannelPriority; }
		}
		/// <summary></summary>
		public string Parse(string url, out string objectURI)	
		{ 
			return objectURI = null;
        }
        #endregion

        #region IChannelSender members
        /// <summary></summary>
		public virtual IMessageSink CreateMessageSink(string url, object data, out string objectURI)
		{
   			// endpoint
			objectURI = null;

			// check the logical url address
			if(string.IsNullOrEmpty(url))
				return null;

            if (url.StartsWith(WorkflowDefaults.WorkflowLocalhost) ||
                url.StartsWith(WorkflowDefaults.WorkflowByWCF))
            {
                // create the Provider Sink  
                IMessageSink sink = (IMessageSink)Provider.CreateSink(this, url, data);

                // successful result
			    return sink;	
            }
            return null;       
		}
		#endregion
	}
	#endregion


    #region ClientWorkflowInvokerProvider
    /// <summary>
    /// 
    /// </summary>
    public class ClientWorkflowInvokerProvider : IClientChannelSinkProvider
    {
        /// <summary></summary>
        public IClientChannelSink CreateSink(IChannelSender channel, string url, object remoteChannelData)
        {
            // create the Message Sink 
            IClientChannelSink sink = new ClientWorkflowInvokerSink(channel, url);

            // successful result
            return sink;
        }

        /// <summary></summary>
        public IClientChannelSinkProvider Next
        {
            get { return null; }
            set { throw new NotSupportedException(); }
        }
    }
    #endregion

    #region ClientWorkflowInvokerSink
    /// <summary>
    /// 
    /// </summary>
    public class ClientWorkflowInvokerSink : IClientChannelSink
    {
        #region private members
        private ClientWorkflowInvoker _Sender;							
        private string _endpoint;					
        #endregion

        #region properties
        ClientWorkflowInvoker Sender { get { return _Sender; } }
        #endregion

        #region constructor
        /// <summary>
        /// 
        /// </summary>
        public ClientWorkflowInvokerSink(IChannelSender channel, string url)
        {
            // state
            _Sender = channel as ClientWorkflowInvoker;
            _endpoint = url;
            //_endpoint = url.Replace(WorkflowDefaults.WorkflowLocalhost, "");				
        }
        #endregion

        #region ProcessMessage
        /// <summary>
        /// 
        /// </summary>
        public void ProcessMessage(IMessage requestMessage, ITransportHeaders requestHeaders, Stream requestStream,
            out ITransportHeaders responseHeaders, out Stream responseStream)
        {
            object returnValue = null;
            responseHeaders = null;
            responseStream = new MemoryStream();
            IMessage responseMsg = null;
            IMethodCallMessage mcm = requestMessage as IMethodCallMessage;
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                if (_endpoint.StartsWith(WorkflowDefaults.WorkflowLocalhost))
                {
                    #region Invoke local Workflow
                    LogicalWorkflowContext lwc = LCC.LogicalWorkflowContext;
                    Guid workflowInstanceId = lwc.GetAndClearWorkflowId();
                    bool bGetWorkflowById = !workflowInstanceId.Equals(Guid.Empty);
   
                    // create workflow
                    Invoker invoker = null;
                    if (bGetWorkflowById)
                    {
                        invoker = WorkflowInvoker.Create(workflowInstanceId);
                    }
                    else
                    {
                        string endpoint = _endpoint.Replace(WorkflowDefaults.WorkflowLocalhost, "").Trim('/');
                        Type workflowType = RemotingServices.GetServerTypeForUri(endpoint);
                        invoker = WorkflowInvoker.Create(workflowType, lwc.WorkflowInitData);
                    }

                    // send remoting message
                    invoker.SendMessage(mcm);

                    // handle response
                    if (RemotingServices.IsOneWay(mcm.MethodBase) == false)
                    {
                        invoker.WaitForResponse(_Sender.TimeOut);
                        returnValue = invoker.GetResponse<object>();
                    }
                    #endregion
                }
                else if (_endpoint.StartsWith(WorkflowDefaults.WorkflowByWCF))
                {
                    #region Invoke remote Workflow by WCF
                    try
                    {   
                        string endpoint = _endpoint.Replace(WorkflowDefaults.WorkflowByWCF, "").Trim('/');
                        using (ChannelFactory2 factory = new ChannelFactory2(Type.GetType(mcm.TypeName), endpoint))
                        {
                            object tp = factory.CreateChannel();

                            using (OperationContextScope scope = new OperationContextScope(tp as IContextChannel))
                            {
                                // CallContext over the loosely coupled contract (LogicalWorkflowContext and Unknown)
                                object lwc = LCC.GetLogicalWorkflowContext;
                                if (lwc != null)
                                {
                                    MessageHeader header = MessageHeader.CreateHeader("LogicalWorkflowContext", "RKiss.WorkflowRemoting", lwc, false, "WorkflowRemoting");
                                    OperationContext.Current.OutgoingMessageHeaders.Add(header);
                                }
                                if (!string.IsNullOrEmpty(Sender.CallContextActor))
                                {
                                    IDictionaryEnumerator enumerator = LCC.GetDataContract().GetEnumerator();
                                    while (enumerator.MoveNext())
                                    {
                                        // skip it
                                        if (enumerator.Value is LogicalWorkflowContext)
                                            continue;

                                        DataContractAttribute dca = enumerator.Key as DataContractAttribute;
                                        MessageHeader header = MessageHeader.CreateHeader(dca.Name, dca.Namespace, enumerator.Value, false, Sender.CallContextActor);
                                        OperationContext.Current.OutgoingMessageHeaders.Add(header);
                                    }
                                }
                                
                                // action
                                returnValue = factory.InvokeMethod(mcm.MethodName, mcm.Args);
                            }
                            factory.Close();
                        }
                    }
                    catch (TargetInvocationException ex)
                    {
                        throw ex.InnerException;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                }
                else
                {
                    throw new InvalidOperationException("No supported schema");
                }

                // return value
                responseMsg = (IMessage)new ReturnMessage(returnValue, null, 0, null, mcm);
            }
            catch (System.ServiceModel.FaultException fe)
            {
                Exception ex = new Exception(fe.Message);
                ex.GetType().InvokeMember("_stackTraceString", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance, null, ex, new object[] { fe.ToString() });
                responseMsg = new ReturnMessage(ex, mcm);
            }
            catch (Exception ex)
            {
                responseMsg = new ReturnMessage(ex, mcm);
            }
            finally
            {
                #region serialize IMessage response to return back
                bf.Serialize(responseStream, responseMsg);
                responseStream.Position = 0;
                responseHeaders = requestHeaders;
                #endregion
            }
        }
        #endregion

        #region Async pattern
        internal delegate IClientChannelSinkStack AsyncMessageDelegate(IMessage requestMessage, ITransportHeaders requestHeaders, Stream requestStream, out ITransportHeaders responseHeaders, out Stream responseStream, IClientChannelSinkStack sinkStack);

        private IClientChannelSinkStack AsyncProcessMessage(IMessage requestMessage, ITransportHeaders requestHeaders, Stream requestStream, out ITransportHeaders responseHeaders, out Stream responseStream, IClientChannelSinkStack sinkStack)
        {
            this.ProcessMessage(requestMessage, requestHeaders, requestStream, out responseHeaders, out responseStream);
            return sinkStack;
        }
        private void AsyncFinishedCallback(IAsyncResult ar)
        {
            IClientChannelSinkStack sinkStack = null;
            try
            {
                ITransportHeaders responseHeaders = null;
                Stream responseStream = null;
                sinkStack = ((AsyncMessageDelegate)((AsyncResult)ar).AsyncDelegate).EndInvoke(out responseHeaders, out responseStream, ar);
                sinkStack.AsyncProcessResponse(responseHeaders, responseStream);
            }
            catch (Exception ex)
            {
                try
                {
                    if (sinkStack != null)
                    {
                        sinkStack.DispatchException(ex);
                    }
                    return;
                }
                catch(Exception ex2)
                {
                    Trace.WriteLine(ex2);
                    return;
                }
            }
        }
        public void AsyncProcessRequest(IClientChannelSinkStack sinkStack, IMessage requestMessage, ITransportHeaders requestHeaders, Stream requestStream)
        {
            ITransportHeaders responseHeaders = null;
            Stream responseStream = null;
            AsyncCallback callback = new AsyncCallback(this.AsyncFinishedCallback);
            IAsyncResult result = new AsyncMessageDelegate(this.AsyncProcessMessage).BeginInvoke(requestMessage, requestHeaders, requestStream, out responseHeaders, out responseStream, sinkStack, callback, null);
        }
        #endregion

        #region Misc
        /// <summary></summary>
        public Stream GetRequestStream(IMessage msg, ITransportHeaders headers) 
        { 
            return null; 
        }
        /// <summary></summary>
        public IDictionary Properties 
        { 
            get { return null; } 
        }
        /// <summary></summary>
        public IClientChannelSink NextChannelSink 
        { 
            get { return null; } 
        }
        /// <summary></summary>
        public void AsyncProcessResponse(IClientResponseChannelSinkStack sinkStack, object state, ITransportHeaders headers, Stream stream)
        {
            throw new RemotingException("Wrong sequence in config file - clientProviders");
        }
        #endregion
    }
    #endregion
}