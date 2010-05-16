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

namespace Fwk.SequentialWorkflow
{
    partial class ExpenseReportWorkflow
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
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition2 = new System.Workflow.Activities.CodeCondition();
            this.rejectEvent = new System.Workflow.Activities.HandleExternalEventActivity();
            this.approveEvent = new System.Workflow.Activities.HandleExternalEventActivity();
            this.invokeGetLeadApproval = new System.Workflow.Activities.CallExternalMethodActivity();
            this.invokeGetManagerApproval = new System.Workflow.Activities.CallExternalMethodActivity();
            this.eventDriven2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDriven1 = new System.Workflow.Activities.EventDrivenActivity();
            this.faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.ifNeedsLeadApproval = new System.Workflow.Activities.IfElseBranchActivity();
            this.elseNeedsManagerApproval = new System.Workflow.Activities.IfElseBranchActivity();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.listenApproveReject = new System.Workflow.Activities.ListenActivity();
            this.evaluateExpenseReportAmount = new System.Workflow.Activities.IfElseActivity();
            // 
            // rejectEvent
            // 
            this.rejectEvent.EventName = "ExpenseReportRejected";
            this.rejectEvent.InterfaceType = typeof(Fwk.SequentialWorkflow.IExpenseReportService);
            this.rejectEvent.Name = "rejectEvent";
            this.rejectEvent.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.rejectEvent_Invoked);
            // 
            // approveEvent
            // 
            this.approveEvent.EventName = "ExpenseReportApproved";
            this.approveEvent.InterfaceType = typeof(Fwk.SequentialWorkflow.IExpenseReportService);
            this.approveEvent.Name = "approveEvent";
            this.approveEvent.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.approveEvent_Invoked);
            // 
            // invokeGetLeadApproval
            // 
            this.invokeGetLeadApproval.Description = "The workflow uses this to call a method that is defined in the host application.";
            this.invokeGetLeadApproval.InterfaceType = typeof(Fwk.SequentialWorkflow.IExpenseReportService);
            this.invokeGetLeadApproval.MethodName = "GetLeadApproval";
            this.invokeGetLeadApproval.Name = "invokeGetLeadApproval";
            workflowparameterbinding1.ParameterName = "message";
            workflowparameterbinding1.Value = "XXXXXXXXXXXXX";
            this.invokeGetLeadApproval.ParameterBindings.Add(workflowparameterbinding1);
            // 
            // invokeGetManagerApproval
            // 
            this.invokeGetManagerApproval.Description = "The workflow uses this to call a method that is defined in the host application.";
            this.invokeGetManagerApproval.InterfaceType = typeof(Fwk.SequentialWorkflow.IExpenseReportService);
            this.invokeGetManagerApproval.MethodName = "GetManagerApproval";
            this.invokeGetManagerApproval.Name = "invokeGetManagerApproval";
            workflowparameterbinding2.ParameterName = "message";
            workflowparameterbinding2.Value = "yyyyyy";
            this.invokeGetManagerApproval.ParameterBindings.Add(workflowparameterbinding2);
            // 
            // eventDriven2
            // 
            this.eventDriven2.Activities.Add(this.rejectEvent);
            this.eventDriven2.Name = "eventDriven2";
            // 
            // eventDriven1
            // 
            this.eventDriven1.Activities.Add(this.approveEvent);
            this.eventDriven1.Name = "eventDriven1";
            // 
            // faultHandlersActivity1
            // 
            this.faultHandlersActivity1.Name = "faultHandlersActivity1";
            // 
            // ifNeedsLeadApproval
            // 
            this.ifNeedsLeadApproval.Activities.Add(this.invokeGetLeadApproval);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.DetermineApprovalContact);
            this.ifNeedsLeadApproval.Condition = codecondition1;
            this.ifNeedsLeadApproval.Name = "ifNeedsLeadApproval";
            // 
            // elseNeedsManagerApproval
            // 
            this.elseNeedsManagerApproval.Activities.Add(this.invokeGetManagerApproval);
            codecondition2.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.DetermineApprovalContact);
            this.elseNeedsManagerApproval.Condition = codecondition2;
            this.elseNeedsManagerApproval.Name = "elseNeedsManagerApproval";
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new System.EventHandler(this.Show_Form2);
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.Show_Form1);
            // 
            // listenApproveReject
            // 
            this.listenApproveReject.Activities.Add(this.eventDriven1);
            this.listenApproveReject.Activities.Add(this.eventDriven2);
            this.listenApproveReject.Name = "listenApproveReject";
            // 
            // evaluateExpenseReportAmount
            // 
            this.evaluateExpenseReportAmount.Activities.Add(this.elseNeedsManagerApproval);
            this.evaluateExpenseReportAmount.Activities.Add(this.ifNeedsLeadApproval);
            this.evaluateExpenseReportAmount.Activities.Add(this.faultHandlersActivity1);
            this.evaluateExpenseReportAmount.Name = "evaluateExpenseReportAmount";
            // 
            // ExpenseReportWorkflow
            // 
            this.Activities.Add(this.evaluateExpenseReportAmount);
            this.Activities.Add(this.listenApproveReject);
            this.Activities.Add(this.codeActivity1);
            this.Activities.Add(this.codeActivity2);
            this.Name = "ExpenseReportWorkflow";
            this.Initialized += new System.EventHandler(this.ExpenseReportWorkflow_Initialized);
            this.Completed += new System.EventHandler(this.ExpenseReportWorkflow_Completed);
            this.CanModifyActivities = false;

        }

        #endregion

        private CodeActivity codeActivity1;
        private CodeActivity codeActivity2;
        private CallExternalMethodActivity invokeGetManagerApproval;
        private EventDrivenActivity eventDriven2;
        private EventDrivenActivity eventDriven1;
        private ListenActivity listenApproveReject;
        private FaultHandlersActivity faultHandlersActivity1;
        private IfElseBranchActivity ifNeedsLeadApproval;
        private IfElseBranchActivity elseNeedsManagerApproval;
        private IfElseActivity evaluateExpenseReportAmount;
        private CallExternalMethodActivity invokeGetLeadApproval;
        private HandleExternalEventActivity approveEvent;
        private HandleExternalEventActivity rejectEvent;






































    }
}
