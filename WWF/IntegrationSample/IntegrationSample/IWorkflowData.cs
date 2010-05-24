using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;

namespace IntegrationSample
{
    [ExternalDataExchange]
    public interface IWorkflowData
    {
        void SetHostMessage(string Message);
        event EventHandler<WorkflowInitEventArgs> WorkflowInitialization;
    }

    [Serializable]
    public class WorkflowInitEventArgs : ExternalDataEventArgs
    {
        private string userName;
        private string userTE;
        private string reclaimType;
        private string reclaimObservations;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string UserTE
        {
            get { return userTE; }
            set { userTE = value; }
        }

        public string ReclaimType
        {
            get { return reclaimType; }
            set { reclaimType = value; }
        }

        public string ReclaimObservations
        {
            get { return reclaimObservations; }
            set { reclaimObservations = value; }
        }

        public WorkflowInitEventArgs(Guid instanceId, string name, string te, string type, string observations)
            : base(instanceId)
        {
            userName = name;
            userTE = te;
            reclaimType = type;
            reclaimObservations = observations;
        }
    }

}
