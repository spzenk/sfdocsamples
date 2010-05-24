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

namespace IntegrationSample
{
	partial class wfIntegrationAndRouting
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
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding4 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference2 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            this.SendMessageToHost = new System.Workflow.Activities.CallExternalMethodActivity();
            this.callExternalMethodActivity2 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.callExternalMethodActivity1 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.invokeWebServiceTE = new System.Workflow.Activities.InvokeWebServiceActivity();
            this.branchElse = new System.Workflow.Activities.IfElseBranchActivity();
            this.branchInvoicing = new System.Workflow.Activities.IfElseBranchActivity();
            this.branchADSL = new System.Workflow.Activities.IfElseBranchActivity();
            this.branchTE = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseReclaimType = new System.Workflow.Activities.IfElseActivity();
            this.codePrepareXml = new System.Workflow.Activities.CodeActivity();
            this.GetValues = new System.Workflow.Activities.HandleExternalEventActivity();
            // 
            // SendMessageToHost
            // 
            this.SendMessageToHost.InterfaceType = typeof(IntegrationSample.IWorkflowData);
            this.SendMessageToHost.MethodName = "SetHostMessage";
            this.SendMessageToHost.Name = "SendMessageToHost";
            activitybind1.Name = "wfIntegrationAndRouting";
            activitybind1.Path = "typeIncorrectMessage";
            workflowparameterbinding1.ParameterName = "Message";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.SendMessageToHost.ParameterBindings.Add(workflowparameterbinding1);
            // 
            // callExternalMethodActivity2
            // 
            this.callExternalMethodActivity2.InterfaceType = typeof(IntegrationSample.IWorkflowData);
            this.callExternalMethodActivity2.MethodName = "SetHostMessage";
            this.callExternalMethodActivity2.Name = "callExternalMethodActivity2";
            activitybind2.Name = "wfIntegrationAndRouting";
            activitybind2.Path = "typeIsNotImplementedYet";
            workflowparameterbinding2.ParameterName = "Message";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.callExternalMethodActivity2.ParameterBindings.Add(workflowparameterbinding2);
            // 
            // callExternalMethodActivity1
            // 
            this.callExternalMethodActivity1.InterfaceType = typeof(IntegrationSample.IWorkflowData);
            this.callExternalMethodActivity1.MethodName = "SetHostMessage";
            this.callExternalMethodActivity1.Name = "callExternalMethodActivity1";
            activitybind3.Name = "wfIntegrationAndRouting";
            activitybind3.Path = "typeIsNotImplementedYet";
            workflowparameterbinding3.ParameterName = "Message";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.callExternalMethodActivity1.ParameterBindings.Add(workflowparameterbinding3);
            // 
            // invokeWebServiceTE
            // 
            this.invokeWebServiceTE.MethodName = "ReceiveMessage";
            this.invokeWebServiceTE.Name = "invokeWebServiceTE";
            activitybind4.Name = "wfIntegrationAndRouting";
            activitybind4.Path = "domMessageToSend";
            workflowparameterbinding4.ParameterName = "message";
            workflowparameterbinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.invokeWebServiceTE.ParameterBindings.Add(workflowparameterbinding4);
            this.invokeWebServiceTE.ProxyClass = typeof(IntegrationSample.ReparacionTE.Service);
            this.invokeWebServiceTE.Invoking += new System.EventHandler<System.Workflow.Activities.InvokeWebServiceEventArgs>(this.InvokingWebService);
            this.invokeWebServiceTE.Invoked += new System.EventHandler<System.Workflow.Activities.InvokeWebServiceEventArgs>(this.InvokedWebService);
            // 
            // branchElse
            // 
            this.branchElse.Activities.Add(this.SendMessageToHost);
            this.branchElse.Name = "branchElse";
            // 
            // branchInvoicing
            // 
            this.branchInvoicing.Activities.Add(this.callExternalMethodActivity2);
            ruleconditionreference1.ConditionName = "Invoice";
            this.branchInvoicing.Condition = ruleconditionreference1;
            this.branchInvoicing.Name = "branchInvoicing";
            // 
            // branchADSL
            // 
            this.branchADSL.Activities.Add(this.callExternalMethodActivity1);
            ruleconditionreference2.ConditionName = "ADSL";
            this.branchADSL.Condition = ruleconditionreference2;
            this.branchADSL.Name = "branchADSL";
            // 
            // branchTE
            // 
            this.branchTE.Activities.Add(this.invokeWebServiceTE);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.IsTE);
            this.branchTE.Condition = codecondition1;
            this.branchTE.Name = "branchTE";
            // 
            // ifElseReclaimType
            // 
            this.ifElseReclaimType.Activities.Add(this.branchTE);
            this.ifElseReclaimType.Activities.Add(this.branchADSL);
            this.ifElseReclaimType.Activities.Add(this.branchInvoicing);
            this.ifElseReclaimType.Activities.Add(this.branchElse);
            this.ifElseReclaimType.Name = "ifElseReclaimType";
            // 
            // codePrepareXml
            // 
            this.codePrepareXml.Name = "codePrepareXml";
            this.codePrepareXml.ExecuteCode += new System.EventHandler(this.codePrepareXmlExecute);
            // 
            // GetValues
            // 
            this.GetValues.EventName = "WorkflowInitialization";
            this.GetValues.InterfaceType = typeof(IntegrationSample.IWorkflowData);
            this.GetValues.Name = "GetValues";
            this.GetValues.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.GetValues_Invoked);
            // 
            // wfIntegrationAndRouting
            // 
            this.Activities.Add(this.GetValues);
            this.Activities.Add(this.codePrepareXml);
            this.Activities.Add(this.ifElseReclaimType);
            this.Name = "wfIntegrationAndRouting";
            this.CanModifyActivities = false;

		}

		#endregion

        private CallExternalMethodActivity callExternalMethodActivity1;
        private CallExternalMethodActivity callExternalMethodActivity2;
        private InvokeWebServiceActivity invokeWebServiceTE;
        private CallExternalMethodActivity SendMessageToHost;
        private HandleExternalEventActivity GetValues;
        private IfElseBranchActivity branchElse;
        private CodeActivity codePrepareXml;
        private IfElseBranchActivity branchADSL;
        private IfElseBranchActivity branchTE;
        private IfElseActivity ifElseReclaimType;
        private IfElseBranchActivity branchInvoicing;



































    }
}
