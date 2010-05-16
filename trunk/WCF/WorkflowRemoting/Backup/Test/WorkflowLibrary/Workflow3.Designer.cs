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

namespace WorkflowLibrary
{
	partial class Workflow3
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
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding5 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.returnActivity1 = new RKiss.ActivityLibrary.ReturnActivity();
            this.sequenceActivity3 = new System.Workflow.Activities.SequenceActivity();
            this.connectorActivity7 = new RKiss.ActivityLibrary.ConnectorActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.sequenceActivity2 = new System.Workflow.Activities.SequenceActivity();
            this.returnActivity7 = new RKiss.ActivityLibrary.ReturnActivity();
            this.connectorActivity8 = new RKiss.ActivityLibrary.ConnectorActivity();
            this.returnActivity6 = new RKiss.ActivityLibrary.ReturnActivity();
            this.returnActivity5 = new RKiss.ActivityLibrary.ReturnActivity();
            this.returnActivity4 = new RKiss.ActivityLibrary.ReturnActivity();
            this.connectorActivity6 = new RKiss.ActivityLibrary.ConnectorActivity();
            this.adapterActivity1 = new RKiss.ActivityLibrary.AdapterActivity();
            this.connectorActivity5 = new RKiss.ActivityLibrary.ConnectorActivity();
            this.sequenceActivity5 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity4 = new System.Workflow.Activities.SequenceActivity();
            this.RETURN = new RKiss.ActivityLibrary.ReturnActivity();
            this.returnActivity2 = new RKiss.ActivityLibrary.ReturnActivity();
            this.returnActivity3 = new RKiss.ActivityLibrary.ReturnActivity();
            this.connectorActivity4 = new RKiss.ActivityLibrary.ConnectorActivity();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.compensatableTransactionScopeActivity1 = new System.Workflow.ComponentModel.CompensatableTransactionScopeActivity();
            this.conditionedActivityGroup1 = new System.Workflow.Activities.ConditionedActivityGroup();
            this.parallelActivity1 = new System.Workflow.Activities.ParallelActivity();
            this.connectorActivity2 = new RKiss.ActivityLibrary.ConnectorActivity();
            this.connectorActivity3 = new RKiss.ActivityLibrary.ConnectorActivity();
            this.connectorActivity1 = new RKiss.ActivityLibrary.ConnectorActivity();
            // 
            // returnActivity1
            // 
            this.returnActivity1.ConnectorActivityName = "connectorActivity3";
            this.returnActivity1.Name = "returnActivity1";
            // 
            // sequenceActivity3
            // 
            this.sequenceActivity3.Activities.Add(this.returnActivity1);
            this.sequenceActivity3.Name = "sequenceActivity3";
            // 
            // connectorActivity7
            // 
            this.connectorActivity7.MethodName = "SayHello";
            this.connectorActivity7.Name = "connectorActivity7";
            this.connectorActivity7.Type = typeof(InterfaceContract.ITest);
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:00");
            // 
            // sequenceActivity2
            // 
            this.sequenceActivity2.Activities.Add(this.sequenceActivity3);
            this.sequenceActivity2.Name = "sequenceActivity2";
            // 
            // returnActivity7
            // 
            this.returnActivity7.ConnectorActivityName = "connectorActivity8";
            this.returnActivity7.Name = "returnActivity7";
            // 
            // connectorActivity8
            // 
            this.connectorActivity8.MethodName = "SayHello";
            this.connectorActivity8.Name = "connectorActivity8";
            this.connectorActivity8.Type = typeof(InterfaceContract.ITest);
            // 
            // returnActivity6
            // 
            this.returnActivity6.ConnectorActivityName = "connectorActivity7";
            this.returnActivity6.Name = "returnActivity6";
            // 
            // returnActivity5
            // 
            this.returnActivity5.ConnectorActivityName = "connectorActivity6";
            this.returnActivity5.Name = "returnActivity5";
            // 
            // returnActivity4
            // 
            this.returnActivity4.ConnectorActivityName = "connectorActivity5";
            this.returnActivity4.Name = "returnActivity4";
            // 
            // connectorActivity6
            // 
            this.connectorActivity6.MethodName = "SayHello";
            this.connectorActivity6.Name = "connectorActivity6";
            this.connectorActivity6.Type = typeof(InterfaceContract.ITest);
            // 
            // adapterActivity1
            // 
            this.adapterActivity1.MethodName = "SayHello";
            this.adapterActivity1.Name = "adapterActivity1";
            this.adapterActivity1.Type = typeof(InterfaceContract.ITest);
            this.adapterActivity1.Uri = "@myEndpoint";
            // 
            // connectorActivity5
            // 
            this.connectorActivity5.MethodName = "SayHello";
            this.connectorActivity5.Name = "connectorActivity5";
            this.connectorActivity5.Type = typeof(InterfaceContract.ITest);
            // 
            // sequenceActivity5
            // 
            this.sequenceActivity5.Activities.Add(this.connectorActivity7);
            this.sequenceActivity5.Name = "sequenceActivity5";
            // 
            // sequenceActivity4
            // 
            this.sequenceActivity4.Activities.Add(this.delayActivity1);
            this.sequenceActivity4.Name = "sequenceActivity4";
            // 
            // RETURN
            // 
            this.RETURN.ConnectorActivityName = "connectorActivity5";
            this.RETURN.Enabled = false;
            this.RETURN.Name = "RETURN";
            // 
            // returnActivity2
            // 
            this.returnActivity2.ConnectorActivityName = "connectorActivity4";
            this.returnActivity2.Name = "returnActivity2";
            // 
            // returnActivity3
            // 
            this.returnActivity3.ConnectorActivityName = "connectorActivity2";
            this.returnActivity3.Name = "returnActivity3";
            // 
            // connectorActivity4
            // 
            this.connectorActivity4.MethodName = "Echo";
            this.connectorActivity4.Name = "connectorActivity4";
            activitybind1.Name = "Workflow3";
            activitybind1.Path = "Workflow3_msg1";
            workflowparameterbinding1.ParameterName = "addr";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.connectorActivity4.Parameters.Add(workflowparameterbinding1);
            this.connectorActivity4.Type = typeof(InterfaceContract.Test);
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.sequenceActivity2);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // compensatableTransactionScopeActivity1
            // 
            this.compensatableTransactionScopeActivity1.Activities.Add(this.connectorActivity8);
            this.compensatableTransactionScopeActivity1.Activities.Add(this.returnActivity7);
            this.compensatableTransactionScopeActivity1.Name = "compensatableTransactionScopeActivity1";
            this.compensatableTransactionScopeActivity1.TransactionOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;
            // 
            // conditionedActivityGroup1
            // 
            this.conditionedActivityGroup1.Activities.Add(this.connectorActivity5);
            this.conditionedActivityGroup1.Activities.Add(this.adapterActivity1);
            this.conditionedActivityGroup1.Activities.Add(this.connectorActivity6);
            this.conditionedActivityGroup1.Activities.Add(this.returnActivity4);
            this.conditionedActivityGroup1.Activities.Add(this.returnActivity5);
            this.conditionedActivityGroup1.Activities.Add(this.returnActivity6);
            this.conditionedActivityGroup1.Name = "conditionedActivityGroup1";
            // 
            // parallelActivity1
            // 
            this.parallelActivity1.Activities.Add(this.sequenceActivity4);
            this.parallelActivity1.Activities.Add(this.sequenceActivity5);
            this.parallelActivity1.Name = "parallelActivity1";
            // 
            // connectorActivity2
            // 
            this.connectorActivity2.MethodName = "Echo";
            this.connectorActivity2.Name = "connectorActivity2";
            activitybind2.Name = "Workflow3";
            activitybind2.Path = "Workflow3_msg1";
            workflowparameterbinding2.ParameterName = "addr";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.connectorActivity2.Parameters.Add(workflowparameterbinding2);
            this.connectorActivity2.Type = typeof(InterfaceContract.Test);
            // 
            // connectorActivity3
            // 
            this.connectorActivity3.MethodName = "Echo";
            this.connectorActivity3.Name = "connectorActivity3";
            activitybind3.Name = "Workflow3";
            activitybind3.Path = "Workflow3_msg1";
            workflowparameterbinding3.ParameterName = "addr";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.connectorActivity3.Parameters.Add(workflowparameterbinding3);
            this.connectorActivity3.Type = typeof(InterfaceContract.Test);
            // 
            // connectorActivity1
            // 
            this.connectorActivity1.Enabled = false;
            this.connectorActivity1.MethodName = "SayHello";
            this.connectorActivity1.Name = "connectorActivity1";
            activitybind4.Name = "Workflow3";
            activitybind4.Path = "Workflow3_msg1";
            workflowparameterbinding4.ParameterName = "msg";
            workflowparameterbinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.connectorActivity1.Parameters.Add(workflowparameterbinding4);
            this.connectorActivity1.Type = typeof(InterfaceContract.ITest);
            // 
            // Workflow3
            // 
            this.Activities.Add(this.connectorActivity1);
            this.Activities.Add(this.connectorActivity3);
            this.Activities.Add(this.connectorActivity2);
            this.Activities.Add(this.parallelActivity1);
            this.Activities.Add(this.conditionedActivityGroup1);
            this.Activities.Add(this.compensatableTransactionScopeActivity1);
            this.Activities.Add(this.sequenceActivity1);
            this.Activities.Add(this.connectorActivity4);
            this.Activities.Add(this.returnActivity3);
            this.Activities.Add(this.returnActivity2);
            this.Activities.Add(this.RETURN);
            this.MethodName = "OneWay";
            this.Name = "Workflow3";
            activitybind5.Name = "Workflow3";
            activitybind5.Path = "Workflow3_msg1";
            workflowparameterbinding5.ParameterName = "msg";
            workflowparameterbinding5.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.Parameters.Add(workflowparameterbinding5);
            this.Type = typeof(InterfaceContract.ITest);
            this.Received += new System.EventHandler(this.codeActivity1_ExecuteCode);
            this.CanModifyActivities = false;

		}

		#endregion

        private RKiss.ActivityLibrary.ReturnActivity returnActivity7;
        private RKiss.ActivityLibrary.ConnectorActivity connectorActivity8;
        private CompensatableTransactionScopeActivity compensatableTransactionScopeActivity1;
        private RKiss.ActivityLibrary.ConnectorActivity connectorActivity7;
        private SequenceActivity sequenceActivity5;
        private SequenceActivity sequenceActivity4;
        private ParallelActivity parallelActivity1;
        private DelayActivity delayActivity1;
        private RKiss.ActivityLibrary.ReturnActivity returnActivity6;
        private RKiss.ActivityLibrary.ReturnActivity returnActivity5;
        private RKiss.ActivityLibrary.ConnectorActivity connectorActivity6;
        private RKiss.ActivityLibrary.AdapterActivity adapterActivity1;
        private RKiss.ActivityLibrary.ConnectorActivity connectorActivity5;
        private ConditionedActivityGroup conditionedActivityGroup1;
        private RKiss.ActivityLibrary.ReturnActivity returnActivity4;
        private RKiss.ActivityLibrary.ReturnActivity returnActivity3;
        private RKiss.ActivityLibrary.ReturnActivity returnActivity2;
        private RKiss.ActivityLibrary.ConnectorActivity connectorActivity4;
        private RKiss.ActivityLibrary.ConnectorActivity connectorActivity2;
        private RKiss.ActivityLibrary.ConnectorActivity connectorActivity3;
        private SequenceActivity sequenceActivity3;
        private SequenceActivity sequenceActivity2;
        private RKiss.ActivityLibrary.ConnectorActivity connectorActivity1;
        private RKiss.ActivityLibrary.ReturnActivity returnActivity1;
        private SequenceActivity sequenceActivity1;
        private RKiss.ActivityLibrary.ReturnActivity RETURN;



































































































































    }
}
