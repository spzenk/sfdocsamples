using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ServiceModel;
using System.Threading;
using System.Drawing;

namespace WCFDirectHost.Services
{

    public enum IntelEventType
    {
        AgentEnter,
        IntelReceived,
        AgentLeave
    }

    public class IntelEventArgs : EventArgs
    {
        public AgentProfile  AgentProfile { get; private set; }
        public Bitmap Image { get; private set; }
        public string Caption {get; private set; }
        public IntelEventType EventType { get; private set; }

        public IntelEventArgs() { }
        
        public IntelEventArgs(IntelData intelData)
        {
            if (intelData.Image == null)
                throw new ArgumentException("Image cannot be null", "image");

            if (string.IsNullOrEmpty(intelData.Agent))
                throw new ArgumentException("Agent cannot be null or empty", "agent");

            this.AgentProfile = new AgentProfile(intelData.Agent);
            this.Image = intelData.Image;
            this.Caption = intelData.Caption;

            this.EventType = IntelEventType.IntelReceived;
        }

        public IntelEventArgs(string agent)
        {
            if (string.IsNullOrEmpty(agent))
                throw new ArgumentException("Cannot be null or empty", "agent");

            this.AgentProfile = new AgentProfile(agent); ;
            this.EventType = IntelEventType.AgentLeave;
        }

        public IntelEventArgs(AgentProfile agentProfile) {

            if (string.IsNullOrEmpty(agentProfile.Agent))
                throw new ArgumentException("Cannot be null or empty", "agent");

            this.AgentProfile = agentProfile;
            this.EventType = IntelEventType.AgentEnter;
            
        }
    }

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single, UseSynchronizationContext = false)]
    public class IntelService : IIntelService
    {
        private SynchronizationContext _syncContext = null;

        public event EventHandler<IntelEventArgs> AgentStatusChanged;
        public event EventHandler<IntelEventArgs> IntelReceived;

        public IntelService() { }

        public IntelService(SynchronizationContext syncContext) : this()
        {
            _syncContext = syncContext;
        }

        #region IIntelService Members

        public void Enter(AgentProfile agent)
        {
            if (agent != null && !string.IsNullOrEmpty(agent.Agent) )
                OnAgentStatusChanged(new IntelEventArgs(agent));           
        }

        public void SendIntel(IntelData intelData)
        {
            OnIntelRecevied(new IntelEventArgs(intelData));
        }     

        public void Leave(string agent)
        {
            if (!string.IsNullOrEmpty(agent))
                OnAgentStatusChanged(new IntelEventArgs(agent));    
        }

        private void OnAgentStatusChanged(IntelEventArgs intelEventArgs)
        {
            if (AgentStatusChanged != null) {
                if (_syncContext != null)
                    _syncContext.Send(send =>   { AgentStatusChanged(this, intelEventArgs); }, null );
                else
                    AgentStatusChanged(this, intelEventArgs);
          
            }
        }

        private void OnIntelRecevied(IntelEventArgs intelEventArgs)
        {
            if (IntelReceived != null)
            {
                if (_syncContext != null)
                    _syncContext.Send(send => { IntelReceived(this, intelEventArgs); }, null);
                else
                    IntelReceived(this, intelEventArgs);
            }
        }

        #endregion



    }
}
