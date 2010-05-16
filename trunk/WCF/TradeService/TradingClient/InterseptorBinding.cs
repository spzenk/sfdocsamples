//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel.Design.Serialization;
//using System.Configuration;
//using System.ServiceModel;
//using System.ServiceModel.Channels;
//using System.ServiceModel.Configuration;
//using System.Text;
//using System.Threading;
//using System.Xml;

//namespace Client
//{

//    public class MessageInterceptor : IMessageInterceptor
//    {
//        private Random randomizer = null;
//        private int dropRate = 3;

//        public MessageInterceptor()
//        {
//            this.randomizer = new Random(DateTime.Now.Millisecond);

//        }

//        public void ProcessSend(ref Message message)
//        {
//            string action = message.Headers.Action;
//            Console.WriteLine(string.Format("Voting on message {0} ...", action));
//            if (!(action.Contains("ITradingService")))
//            {
//                return;
//            }
//            int randomNumber = this.randomizer.Next(10);
//            if ((this.dropRate != 0) && (randomNumber <= this.dropRate))
//            {
//                Console.WriteLine("Dropping message.");
//                message = null;
//                return;
//            }
//            Console.WriteLine("Forwarding message.");

//        }

//        public void ProcessReceive(ref Message message)
//        {

//        }
//    }


//    public interface IMessageInterceptor
//    {
//        void ProcessReceive(ref Message message);
//        void ProcessSend(ref Message message);
//    }

//    public class InterceptorBindingElement : BindingElement
//    {
//        IMessageInterceptor interceptor;

//        public InterceptorBindingElement(): this(new MessageInterceptor())
//        {

//        }

//        public InterceptorBindingElement(IMessageInterceptor interceptor)
//        {
//            this.interceptor = interceptor;
//        }

//        protected InterceptorBindingElement(InterceptorBindingElement other)
//            : base(other)
//        {
//            this.interceptor = other.interceptor;
//        }

//        public IMessageInterceptor Interceptor
//        {
//            get { return this.interceptor; }
//            set { this.interceptor = value; }
//        }

//        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
//        {
//            InterceptorChannelFactory<TChannel> result = new InterceptorChannelFactory<TChannel>(this.interceptor, context.Binding);
//            result.InnerChannelFactory = context.BuildInnerChannelFactory<TChannel>();
//            return result;
//        }

//        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
//        {
//            InterceptorChannelListener<TChannel> result = new InterceptorChannelListener<TChannel>(this.interceptor, context.Binding);
//            result.InnerChannelListener = context.BuildInnerChannelListener<TChannel>();
//            return result;
//        }

//        public override BindingElement Clone()
//        {
//            return new InterceptorBindingElement(this);
//        }

//        public override T GetProperty<T>(BindingContext context)
//        {
//            return context.GetInnerProperty<T>();
//        }
//    }

//    class InterceptorChannelBase<TChannel> : ChannelBase
//        where TChannel : IChannel
//    {
//        TChannel innerChannel;
//        IMessageInterceptor interceptor;

//        protected InterceptorChannelBase(ChannelManagerBase manager, TChannel innerChannel, IMessageInterceptor interceptor)
//            : base(manager)
//        {
//            this.innerChannel = innerChannel;
//            this.interceptor = interceptor;
//        }

//        internal TChannel InnerChannel
//        {
//            get { return this.innerChannel; }
//        }

//        internal IMessageInterceptor Interceptor
//        {
//            get { return this.interceptor; }
//        }

//        protected override void OnAbort()
//        {
//            this.innerChannel.Abort();
//        }

//        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
//        {
//            return this.innerChannel.BeginClose(timeout, callback, state);
//        }

//        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
//        {
//            return this.innerChannel.BeginOpen(timeout, callback, state);
//        }

//        protected override void OnClose(TimeSpan timeout)
//        {
//            this.innerChannel.Close(timeout);
//        }

//        protected override void OnEndClose(IAsyncResult result)
//        {
//            this.innerChannel.EndClose(result);
//        }

//        protected override void OnEndOpen(IAsyncResult result)
//        {
//            this.innerChannel.EndOpen(result);
//        }

//        protected override void OnOpen(TimeSpan timeout)
//        {
//            this.innerChannel.Open(timeout);
//        }

//        internal virtual void OnDropMessage() { }
//    }

//    class NullMessageInterceptor : IMessageInterceptor
//    {
//        public void ProcessSend(ref Message message)
//        {
//        }

//        public void ProcessReceive(ref Message message)
//        {
//        }
//    }

//    class InterceptorChannelFactory<TChannel> : ChannelFactoryBase<TChannel>
//    {
//        IMessageInterceptor interceptor;
//        IChannelFactory<TChannel> innerChannelFactory;

//        public InterceptorChannelFactory(IMessageInterceptor interceptor, IDefaultCommunicationTimeouts timeouts)
//            : base(timeouts)
//        {
//            if (interceptor == null)
//            {
//                this.interceptor = new NullMessageInterceptor();
//            }
//            else
//            {
//                this.interceptor = interceptor;
//            }
//        }

//        internal IChannelFactory<TChannel> InnerChannelFactory
//        {
//            get { return this.innerChannelFactory; }
//            set { this.innerChannelFactory = value; }
//        }

//        public IMessageInterceptor Interceptor
//        {
//            get { return interceptor; }
//        }

//        public override MessageVersion MessageVersion
//        {
//            get { return this.innerChannelFactory.MessageVersion; }
//        }

//        public override string Scheme
//        {
//            get { return this.innerChannelFactory.Scheme; }
//        }

//        protected override void OnOpen(TimeSpan timeout)
//        {
//            this.innerChannelFactory.Open(timeout);
//        }

//        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
//        {
//            return this.innerChannelFactory.BeginOpen(timeout, callback, state);
//        }

//        protected override void OnEndOpen(IAsyncResult result)
//        {
//            this.innerChannelFactory.EndOpen(result);
//        }

//        protected override void OnClose(TimeSpan timeout)
//        {
//            this.innerChannelFactory.Close(timeout);
//        }

//        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
//        {
//            return this.innerChannelFactory.BeginClose(timeout, callback, state);
//        }

//        protected override void OnEndClose(IAsyncResult result)
//        {
//            this.innerChannelFactory.EndClose(result);
//        }

//        protected override TChannel OnCreateChannel(EndpointAddress remoteAddress, Uri via)
//        {
//            TChannel innerChannel = this.InnerChannelFactory.CreateChannel(remoteAddress, via);
//            if (typeof(TChannel) == typeof(IOutputChannel))
//            {
//                return (TChannel)(object)new InterceptorOutputChannel(this, this.interceptor, (IOutputChannel)innerChannel);
//            }
//            else if (typeof(TChannel) == typeof(IRequestChannel))
//            {
//                return (TChannel)(object)new InterceptorRequestChannel(this, this.interceptor, (IRequestChannel)innerChannel);
//            }
//            else if (typeof(TChannel) == typeof(IDuplexChannel))
//            {
//                return (TChannel)(object)new InterceptorDuplexChannel(this, (IDuplexChannel)innerChannel, this.interceptor);
//            }
//            else if (typeof(TChannel) == typeof(IOutputSessionChannel))
//            {
//                return (TChannel)(object)new InterceptorOutputSessionChannel(this, this.interceptor, (IOutputSessionChannel)innerChannel);
//            }
//            else if (typeof(TChannel) == typeof(IRequestSessionChannel))
//            {
//                return (TChannel)(object)new InterceptorRequestSessionChannel(this, this.interceptor,
//                    (IRequestSessionChannel)innerChannel);
//            }
//            else if (typeof(TChannel) == typeof(IDuplexSessionChannel))
//            {
//                return (TChannel)(object)new InterceptorDuplexSessionChannel(this, (IDuplexSessionChannel)innerChannel, this.interceptor);
//            }
//            throw new ArgumentException("Channel type is not supported.", "TChannel");
//        }

//        class InterceptorOutputChannel : InterceptorChannelBase<IOutputChannel>, IOutputChannel
//        {
//            public InterceptorOutputChannel(ChannelFactoryBase factory, IMessageInterceptor interceptor, IOutputChannel innerChannel)
//                : base(factory, innerChannel, interceptor)
//            {
//            }

//            public EndpointAddress RemoteAddress
//            {
//                get { return this.InnerChannel.RemoteAddress; }
//            }

//            public Uri Via
//            {
//                get { return this.InnerChannel.Via; }
//            }

//            public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
//            {
//                ThrowIfDisposedOrNotOpen();
//                return new SendAsyncResult<IOutputChannel>(this, message, callback, state);
//            }

//            public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
//            {
//                ThrowIfDisposedOrNotOpen();
//                return new SendAsyncResult<IOutputChannel>(this, message, timeout, callback, state);
//            }

//            public void EndSend(IAsyncResult result)
//            {
//                SendAsyncResult<IOutputChannel>.End(result);
//            }

//            public void Send(Message message)
//            {
//                ThrowIfDisposedOrNotOpen();
//                Interceptor.ProcessSend(ref message);
//                if (message == null)
//                {
//                    OnDropMessage();
//                }
//                else
//                {
//                    this.InnerChannel.Send(message);
//                }
//            }

//            public void Send(Message message, TimeSpan timeout)
//            {
//                ThrowIfDisposedOrNotOpen();
//                Interceptor.ProcessSend(ref message);
//                if (message == null)
//                {
//                    OnDropMessage();
//                }
//                else
//                {
//                    this.InnerChannel.Send(message, timeout);
//                }
//            }
//        }

//        class InterceptorRequestChannel : InterceptorChannelBase<IRequestChannel>, IRequestChannel
//        {
//            public InterceptorRequestChannel(ChannelFactoryBase factory, IMessageInterceptor interceptor, IRequestChannel innerChannel)
//                : base(factory, innerChannel, interceptor)
//            {
//            }

//            public EndpointAddress RemoteAddress
//            {
//                get { return this.InnerChannel.RemoteAddress; }
//            }

//            public Uri Via
//            {
//                get { return this.InnerChannel.Via; }
//            }

//            public IAsyncResult BeginRequest(Message message, AsyncCallback callback, object state)
//            {
//                ThrowIfDisposedOrNotOpen();
//                return new RequestAsyncResult(this, message, callback, state);
//            }

//            public IAsyncResult BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
//            {
//                ThrowIfDisposedOrNotOpen();
//                return new RequestAsyncResult(this, message, timeout, callback, state);
//            }

//            public Message EndRequest(IAsyncResult result)
//            {
//                return RequestAsyncResult.End(result);
//            }

//            public Message Request(Message message)
//            {
//                ThrowIfDisposedOrNotOpen();
//                Interceptor.ProcessSend(ref message);
//                if (message == null)
//                {
//                    OnDropMessage();
//                    return Message.CreateMessage(MessageVersion.Soap12WSAddressing10, new DroppedMessageFault("Request Message dropped by interceptor."), "http://www.w3.org/2005/08/addressing/fault");
//                }
//                else
//                {
//                    Message reply = this.InnerChannel.Request(message);
//                    Interceptor.ProcessReceive(ref reply);

//                    if (reply == null)
//                    {
//                        OnDropMessage();
//                        return Message.CreateMessage(MessageVersion.Soap12WSAddressing10, new DroppedMessageFault("Reply Message dropped by the interceptor."), "http://www.w3.org/2005/08/addressing/fault");
//                    }
//                    else
//                    {
//                        return reply;
//                    }
//                }
//            }

//            public Message Request(Message message, TimeSpan timeout)
//            {
//                ThrowIfDisposedOrNotOpen();
//                Interceptor.ProcessSend(ref message);
//                if (message == null)
//                {
//                    OnDropMessage();
//                    return Message.CreateMessage(message.Version, new DroppedMessageFault("Request Message dropped by interceptor."), "http://www.w3.org/2005/08/addressing/fault");
//                }
//                else
//                {
//                    Message reply = this.InnerChannel.Request(message, timeout);
//                    Interceptor.ProcessReceive(ref reply);

//                    if (reply == null)
//                    {
//                        OnDropMessage();
//                        return Message.CreateMessage(message.Version, new DroppedMessageFault("Reply Message dropped by the interceptor."), "http://www.w3.org/2005/08/addressing/fault");
//                    }
//                    else
//                    {
//                        return reply;
//                    }
//                }
//            }
//        }

//        class InterceptorOutputSessionChannel : InterceptorOutputChannel, IOutputSessionChannel
//        {
//            IOutputSessionChannel innerSessionChannel;

//            public InterceptorOutputSessionChannel(ChannelFactoryBase factory, IMessageInterceptor interceptor, IOutputSessionChannel innerChannel)
//                : base(factory, interceptor, innerChannel)
//            {
//                this.innerSessionChannel = innerChannel;
//            }

//            public IOutputSession Session
//            {
//                get { return innerSessionChannel.Session; }
//            }

//            internal override void OnDropMessage()
//            {
//                Fault();
//                innerSessionChannel.Abort();
//            }
//        }

//        class InterceptorRequestSessionChannel : InterceptorRequestChannel, IRequestSessionChannel
//        {
//            IRequestSessionChannel innerSessionChannel;

//            public InterceptorRequestSessionChannel(ChannelFactoryBase factory, IMessageInterceptor interceptor,
//                IRequestSessionChannel innerChannel)
//                : base(factory, interceptor, innerChannel)
//            {
//                this.innerSessionChannel = innerChannel;
//            }

//            public IOutputSession Session
//            {
//                get { return innerSessionChannel.Session; }
//            }

//            internal override void OnDropMessage()
//            {
//                Fault();
//                innerSessionChannel.Abort();
//            }
//        }
//    }

//    class InterceptorConverter : TypeConverter
//    {
//        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
//        {
//            if (typeof(string) == sourceType)
//            {
//                return true;
//            }
//            return base.CanConvertFrom(context, sourceType);
//        }

//        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
//        {
//            if (typeof(InstanceDescriptor) == destinationType)
//            {
//                return true;
//            }
//            return base.CanConvertTo(context, destinationType);
//        }

//        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
//        {
//            if (value is string)
//            {
//                if (null == value)
//                {
//                    throw new ArgumentNullException("value");
//                }

//                Type type = Type.GetType((string)value, true);
//                // fusion
//                object retval = Activator.CreateInstance(type);
//                return retval;
//            }
//            return base.ConvertFrom(context, culture, value);
//        }

//        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
//        {
//            if (typeof(string) == destinationType && value is IMessageInterceptor)
//            {
//                if (null == value)
//                {
//                    throw new ArgumentNullException("value");
//                }
//                return value.GetType().Namespace;
//            }

//            return base.ConvertTo(context, culture, value, destinationType);
//        }
//    }

//    class InterceptorDuplexChannel : InterceptorChannelBase<IDuplexChannel>, IDuplexChannel
//    {
//        public InterceptorDuplexChannel(ChannelManagerBase manager, IDuplexChannel innerChannel, IMessageInterceptor interceptor)
//            : base(manager, innerChannel, interceptor)
//        {
//        }

//        public EndpointAddress LocalAddress
//        {
//            get { return this.InnerChannel.LocalAddress; }
//        }

//        public EndpointAddress RemoteAddress
//        {
//            get { return this.InnerChannel.RemoteAddress; }
//        }

//        public Uri Via
//        {
//            get { return this.InnerChannel.Via; }
//        }

//        public IAsyncResult BeginReceive(AsyncCallback callback, object state)
//        {
//            return this.BeginReceive(DefaultReceiveTimeout, callback, state);
//        }

//        public IAsyncResult BeginReceive(TimeSpan timeout, AsyncCallback callback, object state)
//        {
//            return this.BeginTryReceive(timeout, callback, state);
//        }

//        public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
//        {
//            return this.BeginSend(message, DefaultSendTimeout, callback, state);
//        }

//        public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
//        {
//            ThrowIfDisposedOrNotOpen();
//            return new SendAsyncResult<IDuplexChannel>(this, message, timeout, callback, state);
//        }

//        public Message EndReceive(IAsyncResult result)
//        {
//            Message message;
//            this.EndTryReceive(result, out message);
//            return message;
//        }

//        public void EndSend(IAsyncResult result)
//        {
//            SendAsyncResult<IDuplexChannel>.End(result);
//        }

//        public bool TryReceive(TimeSpan timeout, out Message message)
//        {
//            ThrowIfDisposedOrNotOpen();
//            do
//            {
//                if (this.InnerChannel.TryReceive(timeout, out message))
//                {
//                    if (message == null)
//                    {
//                        return true;
//                    }
//                    else
//                    {
//                        Interceptor.ProcessReceive(ref message);
//                        if (message == null)
//                        {
//                            OnDropMessage();
//                        }
//                    }
//                }
//                else
//                {
//                    return false;
//                }
//            } while (message == null);

//            return true;
//        }

//        public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
//        {
//            ThrowIfDisposedOrNotOpen();
//            return new TryReceiveAsyncResult<IDuplexChannel>(this, timeout, callback, state);
//        }

//        public bool EndTryReceive(IAsyncResult result, out Message message)
//        {
//            message = TryReceiveAsyncResult<IDuplexChannel>.End(result);
//            return true;
//        }

//        public bool WaitForMessage(TimeSpan timeout)
//        {
//            return this.InnerChannel.WaitForMessage(timeout);
//        }

//        public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
//        {
//            return this.InnerChannel.BeginWaitForMessage(timeout, callback, state);
//        }

//        public bool EndWaitForMessage(IAsyncResult result)
//        {
//            return this.InnerChannel.EndWaitForMessage(result);
//        }

//        public Message Receive()
//        {
//            return this.Receive(DefaultReceiveTimeout);
//        }

//        public Message Receive(TimeSpan timeout)
//        {
//            Message message;
//            if (this.TryReceive(timeout, out message))
//            {
//                return message;
//            }
//            else
//            {
//                throw new TimeoutException("Receive timed out.");
//            }
//        }

//        public void Send(Message message)
//        {
//            this.Send(message, DefaultSendTimeout);
//        }

//        public void Send(Message message, TimeSpan timeout)
//        {
//            ThrowIfDisposedOrNotOpen();
//            Interceptor.ProcessSend(ref message);
//            if (message == null)
//            {
//                OnDropMessage();
//            }
//            else
//            {
//                this.InnerChannel.Send(message, timeout);
//            }
//        }
//    }


//    class InterceptorDuplexSessionChannel : InterceptorDuplexChannel, IDuplexSessionChannel
//    {
//        IDuplexSessionChannel innerSessionChannel;

//        public InterceptorDuplexSessionChannel(ChannelManagerBase manager, IDuplexSessionChannel innerChannel, IMessageInterceptor interceptor)
//            : base(manager, innerChannel, interceptor)
//        {
//            this.innerSessionChannel = innerChannel;
//        }

//        public IDuplexSession Session
//        {
//            get { return innerSessionChannel.Session; }
//        }

//        internal override void OnDropMessage()
//        {
//            //Fault();
//            //innerSessionChannel.Abort();
//        }
//    }

//    class InterceptorChannelListener<TChannel> : ChannelListenerBase<TChannel>
//        where TChannel : class, IChannel
//    {
//        IMessageInterceptor interceptor;

//        public InterceptorChannelListener(IMessageInterceptor interceptor, IDefaultCommunicationTimeouts timeouts)
//            : base(timeouts)
//        {
//            if (interceptor == null)
//            {
//                this.interceptor = new NullMessageInterceptor();
//            }
//            else
//            {
//                this.interceptor = interceptor;
//            }
//        }

//        public new IChannelListener<TChannel> InnerChannelListener
//        {
//            get { return (IChannelListener<TChannel>)base.InnerChannelListener; }
//            set { base.InnerChannelListener = value; }
//        }

//        public IMessageInterceptor Interceptor
//        {
//            get { return interceptor; }
//        }

//        public override Uri Uri
//        {
//            get { return GetInnerListenerSnapshot().Uri; }
//        }

//        public override MessageVersion MessageVersion
//        {
//            get { return GetInnerListenerSnapshot().MessageVersion; }
//        }

//        public override string Scheme
//        {
//            get { return GetInnerListenerSnapshot().Scheme; }
//        }

//        protected override void OnOpen(TimeSpan timeout)
//        {
//            this.InnerChannelListener.Open(timeout);
//        }

//        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
//        {
//            return this.InnerChannelListener.BeginOpen(timeout, callback, state);
//        }

//        protected override void OnEndOpen(IAsyncResult result)
//        {
//            this.InnerChannelListener.EndOpen(result);
//        }

//        protected override void OnClose(TimeSpan timeout)
//        {
//            this.InnerChannelListener.Close(timeout);
//        }

//        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
//        {
//            return this.InnerChannelListener.BeginClose(timeout, callback, state);
//        }

//        protected override void OnEndClose(IAsyncResult result)
//        {
//            this.InnerChannelListener.EndClose(result);
//        }

//        void ThrowIfInnerListenerNotSet()
//        {
//            if (this.InnerChannelListener == null)
//            {
//                throw new InvalidOperationException("Inner listener is not set.");
//            }
//        }

//        IChannelListener GetInnerListenerSnapshot()
//        {
//            IChannelListener innerChannelListener = this.InnerChannelListener;

//            if (innerChannelListener == null)
//            {
//                throw new InvalidOperationException("Inner listener is not set.");
//            }

//            return innerChannelListener;
//        }

//        protected override TChannel OnAcceptChannel(TimeSpan timeout)
//        {
//            TChannel innerChannel = this.InnerChannelListener.AcceptChannel(timeout);
//            return OnAcceptChannel(innerChannel);
//        }

//        protected override IAsyncResult OnBeginAcceptChannel(TimeSpan timeout, AsyncCallback callback, object state)
//        {
//            return this.InnerChannelListener.BeginAcceptChannel(timeout, callback, state);
//        }

//        protected override TChannel OnEndAcceptChannel(IAsyncResult result)
//        {
//            TChannel innerChannel = this.InnerChannelListener.EndAcceptChannel(result);
//            return OnAcceptChannel(innerChannel);
//        }

//        protected override bool OnWaitForChannel(TimeSpan timeout)
//        {
//            return this.InnerChannelListener.WaitForChannel(timeout);
//        }

//        protected override IAsyncResult OnBeginWaitForChannel(TimeSpan timeout, AsyncCallback callback, object state)
//        {
//            return this.InnerChannelListener.BeginWaitForChannel(timeout, callback, state);
//        }

//        protected override bool OnEndWaitForChannel(IAsyncResult result)
//        {
//            return this.InnerChannelListener.EndWaitForChannel(result);
//        }

//        TChannel OnAcceptChannel(TChannel innerChannel)
//        {
//            if (innerChannel == null)
//            {
//                return null;
//            }

//            if (typeof(TChannel) == typeof(IInputChannel))
//            {
//                return (TChannel)(object)new InterceptorInputChannel(this, (IInputChannel)innerChannel);
//            }
//            else if (typeof(TChannel) == typeof(IReplyChannel))
//            {
//                return (TChannel)(object)new InterceptorReplyChannel(this, (IReplyChannel)innerChannel);
//            }
//            else if (typeof(TChannel) == typeof(IDuplexChannel))
//            {
//                return (TChannel)(object)new InterceptorDuplexChannel(this, (IDuplexChannel)innerChannel, this.interceptor);
//            }
//            else if (typeof(TChannel) == typeof(IInputSessionChannel))
//            {
//                return (TChannel)(object)new InterceptorInputSessionChannel(this,
//                    (IInputSessionChannel)innerChannel);
//            }
//            else if (typeof(TChannel) == typeof(IReplySessionChannel))
//            {
//                return (TChannel)(object)new InterceptorReplySessionChannel(this,
//                    (IReplySessionChannel)innerChannel);
//            }
//            else if (typeof(TChannel) == typeof(IDuplexSessionChannel))
//            {
//                return (TChannel)(object)new InterceptorDuplexSessionChannel(this,
//                    (IDuplexSessionChannel)innerChannel, this.interceptor);
//            }

//            // Cannot wrap this channel.
//            return innerChannel;
//        }

//        class InterceptorInputChannel : InterceptorChannelBase<IInputChannel>, IInputChannel
//        {
//            InterceptorChannelListener<TChannel> listener;

//            public InterceptorInputChannel(InterceptorChannelListener<TChannel> listener, IInputChannel innerChannel)
//                : base(listener, innerChannel, listener.interceptor)
//            {
//                this.listener = listener;
//            }

//            public EndpointAddress LocalAddress
//            {
//                get { return this.InnerChannel.LocalAddress; }
//            }

//            public IAsyncResult BeginReceive(AsyncCallback callback, object state)
//            {
//                return this.BeginReceive(listener.DefaultReceiveTimeout, callback, state);
//            }

//            public IAsyncResult BeginReceive(TimeSpan timeout, AsyncCallback callback, object state)
//            {
//                return this.BeginTryReceive(timeout, callback, state);
//            }

//            public Message EndReceive(IAsyncResult result)
//            {
//                Message message;
//                this.EndTryReceive(result, out message);
//                return message;
//            }

//            public bool TryReceive(TimeSpan timeout, out Message message)
//            {
//                ThrowIfDisposedOrNotOpen();
//                do
//                {
//                    if (this.InnerChannel.TryReceive(timeout, out message))
//                    {
//                        if (message == null)
//                        {
//                            return true;
//                        }
//                        else
//                        {
//                            Interceptor.ProcessReceive(ref message);
//                            if (message == null)
//                            {
//                                OnDropMessage();
//                            }
//                        }
//                    }
//                    else
//                    {
//                        return false;
//                    }
//                } while (message == null);

//                return true;
//            }

//            public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
//            {
//                ThrowIfDisposedOrNotOpen();
//                return new TryReceiveAsyncResult<IInputChannel>(this, timeout, callback, state);
//            }

//            public bool EndTryReceive(IAsyncResult result, out Message message)
//            {
//                message = TryReceiveAsyncResult<IInputChannel>.End(result);
//                return true;
//            }

//            public bool WaitForMessage(TimeSpan timeout)
//            {
//                return this.InnerChannel.WaitForMessage(timeout);
//            }

//            public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
//            {
//                return this.InnerChannel.BeginWaitForMessage(timeout, callback, state);
//            }

//            public bool EndWaitForMessage(IAsyncResult result)
//            {
//                return this.InnerChannel.EndWaitForMessage(result);
//            }

//            public Message Receive()
//            {
//                return this.Receive(listener.DefaultReceiveTimeout);
//            }

//            public Message Receive(TimeSpan timeout)
//            {
//                Message message;
//                if (this.TryReceive(timeout, out message))
//                {
//                    return message;
//                }
//                else
//                {
//                    throw new TimeoutException("Receive timed out.");
//                }
//            }
//        }

//        class InterceptorReplyChannel : InterceptorChannelBase<IReplyChannel>, IReplyChannel
//        {
//            InterceptorChannelListener<TChannel> listener;

//            public InterceptorReplyChannel(InterceptorChannelListener<TChannel> listener, IReplyChannel innerChannel)
//                : base(listener, innerChannel, listener.interceptor)
//            {
//                this.listener = listener;
//            }

//            public EndpointAddress LocalAddress
//            {
//                get { return this.InnerChannel.LocalAddress; }
//            }

//            public IAsyncResult BeginReceiveRequest(AsyncCallback callback, object state)
//            {
//                return this.BeginReceiveRequest(listener.DefaultReceiveTimeout, callback, state);
//            }

//            public IAsyncResult BeginReceiveRequest(TimeSpan timeout, AsyncCallback callback, object state)
//            {
//                return this.BeginTryReceiveRequest(timeout, callback, state);
//            }

//            public IRequestContext EndReceiveRequest(IAsyncResult result)
//            {
//                IRequestContext requestContext;
//                this.EndTryReceiveRequest(result, out requestContext);
//                return requestContext;
//            }

//            public bool TryReceiveRequest(TimeSpan timeout, out IRequestContext requestContext)
//            {
//                ThrowIfDisposedOrNotOpen();
//                Message resultMessage;
//                IRequestContext innerRequestContext;

//                requestContext = null;

//                do
//                {
//                    if (this.InnerChannel.TryReceiveRequest(timeout, out innerRequestContext))
//                    {
//                        if (innerRequestContext == null)
//                        {
//                            return true;
//                        }
//                        else
//                        {
//                            resultMessage = innerRequestContext.RequestMessage;
//                            Interceptor.ProcessReceive(ref resultMessage);
//                            if (resultMessage == null)
//                            {
//                                OnDropMessage();
//                            }
//                            else
//                            {
//                                requestContext = new InterceptorRequestContext(resultMessage, this, innerRequestContext, timeout);
//                            }
//                        }
//                    }
//                    else
//                    {
//                        return false;
//                    }
//                } while (resultMessage == null);

//                return true;
//            }

//            public IAsyncResult BeginTryReceiveRequest(TimeSpan timeout, AsyncCallback callback, object state)
//            {
//                ThrowIfDisposedOrNotOpen();
//                return new TryReceiveRequestAsyncResult(this, timeout, callback, state);
//            }

//            public bool EndTryReceiveRequest(IAsyncResult result, out IRequestContext requestContext)
//            {
//                IRequestContext context;
//                Message message = TryReceiveRequestAsyncResult.End(result, out context);
//                if (context == null)
//                {
//                    requestContext = null;
//                }
//                else
//                {
//                    requestContext = new InterceptorRequestContext(message, this, context, listener.DefaultSendTimeout);
//                }
//                return true;
//            }

//            public bool WaitForRequest(TimeSpan timeout)
//            {
//                return this.InnerChannel.WaitForRequest(timeout);
//            }

//            public IAsyncResult BeginWaitForRequest(TimeSpan timeout, AsyncCallback callback, object state)
//            {
//                return this.InnerChannel.BeginWaitForRequest(timeout, callback, state);
//            }

//            public bool EndWaitForRequest(IAsyncResult result)
//            {
//                return this.InnerChannel.EndWaitForRequest(result);
//            }

//            public IRequestContext ReceiveRequest()
//            {
//                return this.ReceiveRequest(listener.DefaultReceiveTimeout);
//            }

//            public IRequestContext ReceiveRequest(TimeSpan timeout)
//            {
//                IRequestContext requestContext;
//                if (this.TryReceiveRequest(timeout, out requestContext))
//                {
//                    return requestContext;
//                }
//                else
//                {
//                    throw new TimeoutException("Receive request timed out.");
//                }
//            }

//            class InterceptorRequestContext : IRequestContext
//            {
//                Message message;
//                InterceptorReplyChannel channel;
//                IRequestContext innerContext;
//                TimeSpan defaultSendTimeout;

//                public InterceptorRequestContext(Message message, InterceptorReplyChannel channel, IRequestContext innerContext, TimeSpan defaultSendTimeout)
//                {
//                    this.channel = channel;
//                    this.innerContext = innerContext;
//                    this.message = message;
//                    this.defaultSendTimeout = defaultSendTimeout;
//                }

//                public Message RequestMessage
//                {
//                    get { return this.message; }
//                }

//                public void Abort()
//                {
//                    this.innerContext.Abort();
//                }

//                public IAsyncResult BeginReply(Message message, AsyncCallback callback, object state)
//                {
//                    return this.BeginReply(message, defaultSendTimeout, callback, state);
//                }

//                public IAsyncResult BeginReply(Message message, TimeSpan timeout, AsyncCallback callback, object state)
//                {
//                    return new ReplyAsyncResult(channel, message, timeout, innerContext, callback, state);
//                }

//                public void Close()
//                {
//                    this.innerContext.Close();
//                }

//                public void Close(TimeSpan timeout)
//                {
//                    this.innerContext.Close(timeout);
//                }

//                public void Dispose()
//                {
//                    this.innerContext.Dispose();
//                }

//                public void EndReply(IAsyncResult result)
//                {
//                    ReplyAsyncResult.End(result);
//                }

//                public void Reply(Message message)
//                {
//                    this.Reply(message, defaultSendTimeout);
//                }

//                public void Reply(Message message, TimeSpan timeout)
//                {
//                    channel.Interceptor.ProcessSend(ref message);
//                    if (message == null)
//                    {
//                        channel.OnDropMessage();
//                    }
//                    else
//                    {
//                        this.innerContext.Reply(message, timeout);
//                    }
//                }
//            }
//        }

//        class InterceptorInputSessionChannel : InterceptorInputChannel, IInputSessionChannel
//        {
//            IInputSessionChannel innerSessionChannel;

//            public InterceptorInputSessionChannel(InterceptorChannelListener<TChannel> listener, IInputSessionChannel innerChannel)
//                : base(listener, innerChannel)
//            {
//                this.innerSessionChannel = innerChannel;
//            }

//            public IInputSession Session
//            {
//                get { return innerSessionChannel.Session; }
//            }

//            internal override void OnDropMessage()
//            {
//                Fault();
//                innerSessionChannel.Abort();
//            }
//        }

//        class InterceptorReplySessionChannel : InterceptorReplyChannel, IReplySessionChannel
//        {
//            IReplySessionChannel innerSessionChannel;

//            public InterceptorReplySessionChannel(InterceptorChannelListener<TChannel> listener, IReplySessionChannel innerChannel)
//                : base(listener, innerChannel)
//            {
//                this.innerSessionChannel = innerChannel;
//            }

//            public IInputSession Session
//            {
//                get { return innerSessionChannel.Session; }
//            }

//            internal override void OnDropMessage()
//            {
//                Fault();
//                innerSessionChannel.Abort();
//            }
//        }
//    }

//    class InterceptorSection : BindingElementExtensionElement
//    {
//        const string ClassType = "type";

//        public override Type BindingElementType
//        {
//            get { return typeof(InterceptorBindingElement); }
//        }

//        [ConfigurationProperty(ClassType)]
//        [TypeConverter(typeof(InterceptorConverter))]
//        public IMessageInterceptor Interceptor
//        {
//            get { return (IMessageInterceptor)base[ClassType]; }
//            set { base[ClassType] = value; }
//        }

//        protected override BindingElement CreateBindingElement()
//        {
//            InterceptorBindingElement bindingElement = new InterceptorBindingElement((IMessageInterceptor)base[ClassType]);
//            return bindingElement;
//        }
//    }

//    class ReplyAsyncResult : AsyncResult
//    {
//        Message message;
//        TimeSpan timeout;
//        IRequestContext innerContext;
//        InterceptorChannelBase<IReplyChannel> channel;

//        public ReplyAsyncResult(InterceptorChannelBase<IReplyChannel> channel, Message message,
//            TimeSpan timeout, IRequestContext innerContext, AsyncCallback callback, object state)
//            : base(callback, state)
//        {
//            this.message = message;
//            this.timeout = timeout;
//            this.innerContext = innerContext;
//            this.channel = channel;

//            channel.Interceptor.ProcessSend(ref this.message);
//            if (this.message == null)
//            {
//                channel.OnDropMessage();
//                this.message = Message.CreateMessage(message.Version, new DroppedMessageFault("Reply Message dropped by interceptor."), "http://www.w3.org/2005/08/addressing/fault");
//                Complete(true);
//            }
//            else
//            {
//                innerContext.BeginReply(this.message, new AsyncCallback(HandleCallback), null);
//            }
//        }

//        void HandleCallback(IAsyncResult asyncResult)
//        {
//            try
//            {
//                innerContext.EndReply(asyncResult);
//                Complete(false);
//            }
//            catch (Exception e)
//            {
//                Complete(false, e);
//            }
//        }

//        public new WaitHandle AsyncWaitHandle
//        {
//            get { return base.AsyncWaitHandle; }
//        }

//        public new bool IsCompleted
//        {
//            get { return base.IsCompleted; }
//        }

//        public new bool CompletedSynchronously
//        {
//            get { return base.CompletedSynchronously; }
//        }

//        public static void End(IAsyncResult result)
//        {
//            if (result == null)
//            {
//                throw new ArgumentNullException("result");
//            }
//            ReplyAsyncResult requestResult = result as ReplyAsyncResult;
//            if (requestResult == null)
//            {
//                throw new ArgumentException("Invalid AsyncResult", "result");
//            }
//            AsyncResult.End(requestResult);
//        }
//    }


//    class RequestAsyncResult : AsyncResult
//    {
//        Message message;
//        TimeSpan timeout;
//        InterceptorChannelBase<IRequestChannel> channel;

//        public RequestAsyncResult(InterceptorChannelBase<IRequestChannel> channel, Message message, AsyncCallback callback, object state)
//            : base(callback, state)
//        {
//            this.message = message;
//            this.channel = channel;

//            channel.Interceptor.ProcessSend(ref this.message);
//            if (this.message == null)
//            {
//                channel.OnDropMessage();
//                this.message = Message.CreateMessage(MessageVersion.Soap12WSAddressing10, new DroppedMessageFault("Request Message dropped by interceptor."), "http://www.w3.org/2005/08/addressing/fault");
//                Complete(true);
//            }
//            else
//            {
//                channel.InnerChannel.BeginRequest(this.message, new AsyncCallback(HandleCallback), null);
//            }
//        }

//        public RequestAsyncResult(InterceptorChannelBase<IRequestChannel> channel, Message message, TimeSpan timeout, AsyncCallback callback, object state)
//            : base(callback, state)
//        {
//            this.message = message;
//            this.timeout = timeout;
//            this.channel = channel;

//            channel.Interceptor.ProcessSend(ref this.message);
//            if (this.message == null)
//            {
//                channel.OnDropMessage();
//                this.message = Message.CreateMessage(message.Version, new DroppedMessageFault("Request Message dropped by interceptor."), "http://www.w3.org/2005/08/addressing/fault");
//                Complete(true);
//            }
//            else
//            {
//                channel.InnerChannel.BeginRequest(this.message, timeout, new AsyncCallback(HandleCallback), null);
//            }
//        }

//        void HandleCallback(IAsyncResult asyncResult)
//        {
//            try
//            {
//                Message reply = channel.InnerChannel.EndRequest(asyncResult);
//                channel.Interceptor.ProcessReceive(ref reply);
//                if (reply == null)
//                {
//                    channel.OnDropMessage();
//                    this.message = Message.CreateMessage(MessageVersion.Soap12WSAddressing10, new DroppedMessageFault("Reply Message dropped by interceptor."), "http://www.w3.org/2005/08/addressing/fault");
//                }
//                else
//                {
//                    this.message = reply;
//                }
//                Complete(false);
//            }
//            catch (Exception e)
//            {
//                Complete(false, e);
//            }
//        }

//        public new WaitHandle AsyncWaitHandle
//        {
//            get { return base.AsyncWaitHandle; }
//        }

//        public new bool IsCompleted
//        {
//            get { return base.IsCompleted; }
//        }

//        public new bool CompletedSynchronously
//        {
//            get { return base.CompletedSynchronously; }
//        }

//        public static Message End(IAsyncResult result)
//        {
//            if (result == null)
//            {
//                throw new ArgumentNullException("result");
//            }
//            RequestAsyncResult requestResult = result as RequestAsyncResult;
//            if (requestResult == null)
//            {
//                throw new ArgumentException("Invalid AsyncResult", "result");
//            }
//            AsyncResult.End(requestResult);

//            return requestResult.message;
//        }
//    }

//    class SendAsyncResult<TChannel> : AsyncResult
//        where TChannel : IOutputChannel
//    {
//        Message message;
//        TimeSpan timeout;
//        InterceptorChannelBase<TChannel> channel;

//        public SendAsyncResult(InterceptorChannelBase<TChannel> channel, Message message, AsyncCallback callback, object state)
//            : base(callback, state)
//        {
//            this.message = message;
//            this.channel = channel;

//            channel.Interceptor.ProcessSend(ref this.message);
//            if (this.message == null)
//            {
//                channel.OnDropMessage();
//                Complete(true);
//            }
//            else
//            {
//                channel.InnerChannel.BeginSend(this.message, new AsyncCallback(HandleCallback), null);
//            }
//        }

//        public SendAsyncResult(InterceptorChannelBase<TChannel> channel, Message message, TimeSpan timeout, AsyncCallback callback, object state)
//            : base(callback, state)
//        {
//            this.message = message;
//            this.timeout = timeout;
//            this.channel = channel;

//            channel.Interceptor.ProcessSend(ref this.message);
//            if (this.message == null)
//            {
//                channel.OnDropMessage();
//                Complete(true);
//            }
//            else
//            {
//                channel.InnerChannel.BeginSend(this.message, timeout, new AsyncCallback(HandleCallback), null);
//            }
//        }

//        void HandleCallback(IAsyncResult asyncResult)
//        {
//            try
//            {
//                channel.InnerChannel.EndSend(asyncResult);
//                Complete(false);
//            }
//            catch (Exception e)
//            {
//                Complete(false, e);
//            }
//        }

//        public new WaitHandle AsyncWaitHandle
//        {
//            get { return base.AsyncWaitHandle; }
//        }

//        public new bool IsCompleted
//        {
//            get { return base.IsCompleted; }
//        }

//        public new bool CompletedSynchronously
//        {
//            get { return base.CompletedSynchronously; }
//        }

//        public static void End(IAsyncResult result)
//        {
//            if (result == null)
//            {
//                throw new ArgumentNullException("result");
//            }
//            SendAsyncResult<TChannel> outputResult = result as SendAsyncResult<TChannel>;
//            if (outputResult == null)
//            {
//                throw new ArgumentException("Invalid AsyncResult", "result");
//            }
//            AsyncResult.End(outputResult);
//        }
//    }

//    class TryReceiveAsyncResult<TChannel> : AsyncResult
//        where TChannel : IInputChannel
//    {
//        Message message;
//        TimeSpan timeout;
//        InterceptorChannelBase<TChannel> channel;

//        public TryReceiveAsyncResult(InterceptorChannelBase<TChannel> channel, TimeSpan timeout, AsyncCallback callback, object state)
//            : base(callback, state)
//        {
//            this.channel = channel;
//            this.timeout = timeout;
//            channel.InnerChannel.BeginTryReceive(timeout, new AsyncCallback(HandleCallback), null);
//        }

//        void HandleCallback(IAsyncResult asyncResult)
//        {
//            Message message;
//            try
//            {
//                if (channel.InnerChannel.EndTryReceive(asyncResult, out message))
//                {
//                    if (message == null)
//                    {
//                        this.message = null;

//                        Complete(false);
//                    }
//                    else
//                    {
//                        channel.Interceptor.ProcessReceive(ref message);

//                        if (message == null)
//                        {
//                            channel.OnDropMessage();
//                            asyncResult = channel.InnerChannel.BeginTryReceive(timeout, new AsyncCallback(HandleCallback), null);
//                        }
//                        else
//                        {
//                            this.message = message;

//                            Complete(false);
//                        }
//                    }
//                }
//                else
//                {
//                    Complete(false, new TimeoutException("Receive request timed out."));
//                }
//            }
//            catch (Exception e)
//            {
//                Complete(false, e);
//            }
//        }

//        public static Message End(IAsyncResult asyncResult)
//        {
//            if (asyncResult == null)
//            {
//                throw new ArgumentNullException("asyncResult");
//            }
//            TryReceiveAsyncResult<TChannel> inputResult = asyncResult as TryReceiveAsyncResult<TChannel>;
//            if (inputResult == null)
//            {
//                throw new ArgumentException("Invalid AsyncResult", "asyncResult");
//            }
//            AsyncResult.End(inputResult);

//            return inputResult.message;
//        }
//    }

//    class TryReceiveRequestAsyncResult : AsyncResult
//    {
//        Message message;
//        IRequestContext context;
//        TimeSpan timeout;
//        InterceptorChannelBase<IReplyChannel> channel;

//        public TryReceiveRequestAsyncResult(InterceptorChannelBase<IReplyChannel> channel, TimeSpan timeout, AsyncCallback callback, object state)
//            : base(callback, state)
//        {
//            this.timeout = timeout;
//            this.channel = channel;
//            channel.InnerChannel.BeginTryReceiveRequest(timeout, new AsyncCallback(HandleCallback), null);
//        }

//        void HandleCallback(IAsyncResult asyncResult)
//        {
//            IRequestContext context;
//            try
//            {
//                if (channel.InnerChannel.EndTryReceiveRequest(asyncResult, out context))
//                {
//                    if (context == null)
//                    {
//                        this.message = null;
//                        this.context = null;

//                        Complete(false);
//                    }
//                    else
//                    {
//                        Message result = context.RequestMessage;

//                        channel.Interceptor.ProcessReceive(ref result);
//                        if (result == null)
//                        {
//                            channel.OnDropMessage();
//                            asyncResult = channel.InnerChannel.BeginTryReceiveRequest(timeout, new AsyncCallback(HandleCallback), null);
//                        }
//                        else
//                        {
//                            this.message = result;
//                            this.context = context;

//                            Complete(false);
//                        }
//                    }
//                }
//                else
//                {
//                    Complete(false, new TimeoutException("Receive request timed out."));
//                }
//            }
//            catch (Exception e)
//            {
//                Complete(false, e);
//            }
//        }

//        public static Message End(IAsyncResult asyncResult, out IRequestContext context)
//        {
//            if (asyncResult == null)
//            {
//                throw new ArgumentNullException("asyncResult");
//            }
//            TryReceiveRequestAsyncResult replyResult = asyncResult as TryReceiveRequestAsyncResult;
//            if (replyResult == null)
//            {
//                throw new ArgumentException("Invalid AsyncResult", "asyncResult");
//            }
//            AsyncResult.End(replyResult);

//            context = replyResult.context;
//            return replyResult.message;
//        }
//    }


//    class DroppedMessageFault : MessageFault
//    {
//        FaultReason faultReason;
//        FaultCode faultCode;

//        public DroppedMessageFault(string reason)
//        {
//            faultReason = new FaultReason(reason);
//            faultCode = new FaultCode("DroppedMessageFault");
//        }

//        public override FaultCode Code
//        {
//            get { return faultCode; }
//        }

//        public override bool HasDetail
//        {
//            get { return false; }
//        }

//        public override FaultReason Reason
//        {
//            get { return faultReason; }
//        }

//        protected override void OnWriteDetailContents(XmlDictionaryWriter writer)
//        {
//            throw new NotImplementedException("The method or operation is not implemented.");
//        }
//    }

//    abstract class AsyncResult : IAsyncResult
//    {
//        AsyncCallback callback;
//        object state;
//        bool completedSynchronously;
//        bool endCalled;
//        Exception exception;
//        bool isCompleted;
//        ManualResetEvent manualResetEvent;

//        protected AsyncResult(AsyncCallback callback, object state)
//        {
//            this.callback = callback;
//            this.state = state;
//        }

//        public object AsyncState
//        {
//            get { return state; }
//        }

//        public WaitHandle AsyncWaitHandle
//        {
//            get
//            {
//                if (manualResetEvent != null)
//                {
//                    return manualResetEvent;
//                }

//                lock (ThisLock)
//                {
//                    if (manualResetEvent == null)
//                    {
//                        manualResetEvent = new ManualResetEvent(isCompleted);
//                    }
//                }

//                return manualResetEvent;
//            }
//        }

//        public bool CompletedSynchronously
//        {
//            get { return completedSynchronously; }
//        }

//        public bool IsCompleted
//        {
//            get { return isCompleted; }
//        }

//        object ThisLock
//        {
//            get { return this; }
//        }

//        protected void Complete(bool completedSynchronously)
//        {
//            if (isCompleted)
//            {
//                throw new InvalidOperationException("AsyncResults can only be completed once.");
//            }
//            ManualResetEvent manualResetEvent = null;
//            this.completedSynchronously = completedSynchronously;

//            if (completedSynchronously)
//            {
//                // If we completedSynchronously, then there's no chance that the manualResetEvent was created so
//                // we don't need to worry about a race
//                this.isCompleted = true;
//                if (this.manualResetEvent != null)
//                {
//                    throw new InvalidOperationException("No ManualResetEvent should be created for a synchronous AsyncResult.");
//                }
//            }
//            else
//            {
//                lock (ThisLock)
//                {
//                    this.isCompleted = true;
//                    manualResetEvent = this.manualResetEvent;
//                }
//            }

//            try
//            {
//                if (callback != null)
//                {
//                    callback(this);
//                }
//                if (manualResetEvent != null)
//                {
//                    manualResetEvent.Set();
//                }
//            }
//            catch (Exception unhandledException)
//            {
//                // The callback raising an exception is equivalent to Main raising an exception w/out a catch.
//                // Queue it onto another thread and throw it there to ensure that there's no other handler in 
//                // place and the default unhandled exception behavior occurs.

//                // Because the stack trace gets lost on a rethrow, we're wrapping it in a generic exception
//                // so the stack trace is preserved.
//                unhandledException = new Exception("AsyncCallbackException", unhandledException);
//                ThreadPool.UnsafeQueueUserWorkItem(new WaitCallback(RaiseUnhandledException), unhandledException);
//            }
//        }

//        protected void Complete(bool completedSynchronously, Exception exception)
//        {
//            this.exception = exception;
//            Complete(completedSynchronously);
//        }

//        protected static void End(AsyncResult asyncResult)
//        {
//            if (asyncResult == null)
//            {
//                throw new ArgumentNullException("asyncResult");
//            }

//            if (asyncResult.endCalled)
//            {
//                throw new InvalidOperationException("Async object already ended.");
//            }

//            asyncResult.endCalled = true;

//            if (!asyncResult.isCompleted)
//            {
//                using (WaitHandle waitHandle = asyncResult.AsyncWaitHandle)
//                {
//                    waitHandle.WaitOne();
//                }
//            }

//            if (asyncResult.exception != null)
//            {
//                throw asyncResult.exception;
//            }
//        }

//        void RaiseUnhandledException(object o)
//        {
//            Exception exception = (Exception)o;
//            throw exception;
//        }
//    }
//}
