using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace Microsoft.Samples.Workflow.SimpleStateMachineWorkflow
{
    partial class OrderProcessingWorkflow
    {
        #region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            this.setStateActivity1 = new System.Workflow.Activities.SetStateActivity();
            this.updatestatusOrderReceived = new System.Workflow.Activities.CallExternalMethodActivity();
            this.newOrderExternalEvent = new System.Workflow.Activities.HandleExternalEventActivity();
            this.eventDriven1 = new System.Workflow.Activities.EventDrivenActivity();
            this.OrderCompletedStateActivity = new System.Workflow.Activities.StateActivity();
            this.OrderProcessingStateActivity = new System.Workflow.Activities.StateActivity();
            this.WaitingForOrderStateActivity = new System.Workflow.Activities.StateActivity();
            // 
            // setStateActivity1
            // 
            this.setStateActivity1.Name = "setStateActivity1";
            this.setStateActivity1.TargetStateName = "OrderProcessingStateActivity";
            // 
            // updatestatusOrderReceived
            // 
            this.updatestatusOrderReceived.InterfaceType = typeof(Microsoft.Samples.Workflow.SimpleStateMachineWorkflow.IOrderingService);
            this.updatestatusOrderReceived.MethodName = "ItemStatusUpdate";
            this.updatestatusOrderReceived.Name = "updatestatusOrderReceived";
            // 
            // newOrderExternalEvent
            // 
            this.newOrderExternalEvent.EventName = "NewOrderEvent";
            this.newOrderExternalEvent.InterfaceType = typeof(Microsoft.Samples.Workflow.SimpleStateMachineWorkflow.IOrderingService);
            this.newOrderExternalEvent.Name = "newOrderExternalEvent";
            // 
            // eventDriven1
            // 
            this.eventDriven1.Activities.Add(this.newOrderExternalEvent);
            this.eventDriven1.Activities.Add(this.updatestatusOrderReceived);
            this.eventDriven1.Activities.Add(this.setStateActivity1);
            this.eventDriven1.Name = "eventDriven1";
            // 
            // OrderCompletedStateActivity
            // 
            this.OrderCompletedStateActivity.Name = "OrderCompletedStateActivity";
            // 
            // OrderProcessingStateActivity
            // 
            this.OrderProcessingStateActivity.Name = "OrderProcessingStateActivity";
            // 
            // WaitingForOrderStateActivity
            // 
            this.WaitingForOrderStateActivity.Activities.Add(this.eventDriven1);
            this.WaitingForOrderStateActivity.Name = "WaitingForOrderStateActivity";
            // 
            // OrderProcessingWorkflow
            // 
            this.Activities.Add(this.WaitingForOrderStateActivity);
            this.Activities.Add(this.OrderProcessingStateActivity);
            this.Activities.Add(this.OrderCompletedStateActivity);
            this.CompletedStateName = "OrderCompletedStateActivity";
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "WaitingForOrderStateActivity";
            this.Name = "OrderProcessingWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private StateActivity OrderProcessingStateActivity;
        private StateActivity OrderCompletedStateActivity;
        private HandleExternalEventActivity newOrderExternalEvent;
        private EventDrivenActivity eventDriven1;
        private CallExternalMethodActivity updatestatusOrderReceived;
        private SetStateActivity setStateActivity1;
        private StateActivity WaitingForOrderStateActivity;



















    }
}
