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
    partial class Workflow6
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
            this.setStateActivity4 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivity4 = new System.Workflow.Activities.CodeActivity();
            this.setStateActivity5 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivity5 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.setStateActivity3 = new System.Workflow.Activities.SetStateActivity();
            this.Return = new RKiss.ActivityLibrary.ReturnActivity();
            this.setStateActivity6 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivity6 = new System.Workflow.Activities.CodeActivity();
            this.Connector_Fire = new RKiss.ActivityLibrary.ConnectorActivity();
            this.setStateActivity2 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivity3 = new System.Workflow.Activities.CodeActivity();
            this.Connector_OneWay = new RKiss.ActivityLibrary.ConnectorActivity();
            this.setStateActivity1 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.Connector_SayHello = new RKiss.ActivityLibrary.ConnectorActivity();
            this.Init = new System.Workflow.Activities.StateInitializationActivity();
            this.End = new System.Workflow.Activities.StateInitializationActivity();
            this.Finish = new System.Workflow.Activities.StateFinalizationActivity();
            this.Response = new System.Workflow.Activities.StateInitializationActivity();
            this.onFire = new System.Workflow.Activities.EventDrivenActivity();
            this.onOneWay = new System.Workflow.Activities.EventDrivenActivity();
            this.onSayHello = new System.Workflow.Activities.EventDrivenActivity();
            this.Done = new System.Workflow.Activities.StateActivity();
            this.PreProcessor = new System.Workflow.Activities.StateActivity();
            this.Cleanup = new System.Workflow.Activities.StateActivity();
            this.PostProcessor = new System.Workflow.Activities.StateActivity();
            this.Processor = new System.Workflow.Activities.StateActivity();
            // 
            // setStateActivity4
            // 
            this.setStateActivity4.Name = "setStateActivity4";
            this.setStateActivity4.TargetStateName = "Processor";
            // 
            // codeActivity4
            // 
            this.codeActivity4.Name = "codeActivity4";
            this.codeActivity4.ExecuteCode += new System.EventHandler(this.OnInit);
            // 
            // setStateActivity5
            // 
            this.setStateActivity5.Name = "setStateActivity5";
            this.setStateActivity5.TargetStateName = "Done";
            // 
            // codeActivity5
            // 
            this.codeActivity5.Name = "codeActivity5";
            this.codeActivity5.ExecuteCode += new System.EventHandler(this.OnCleanup);
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.OnFinish);
            // 
            // setStateActivity3
            // 
            this.setStateActivity3.Name = "setStateActivity3";
            this.setStateActivity3.TargetStateName = "Processor";
            // 
            // Return
            // 
            this.Return.ConnectorActivityName = "Connector_SayHello";
            this.Return.Name = "Return";
            activitybind1.Name = "Workflow6";
            activitybind1.Path = "Return__ReturnValue_1";
            workflowparameterbinding1.ParameterName = "(ReturnValue)";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.Return.Parameters.Add(workflowparameterbinding1);
            // 
            // setStateActivity6
            // 
            this.setStateActivity6.Name = "setStateActivity6";
            this.setStateActivity6.TargetStateName = "Cleanup";
            // 
            // codeActivity6
            // 
            this.codeActivity6.Name = "codeActivity6";
            this.codeActivity6.ExecuteCode += new System.EventHandler(this.OnFireProcessor);
            // 
            // Connector_Fire
            // 
            this.Connector_Fire.MethodName = "Fire";
            this.Connector_Fire.Name = "Connector_Fire";
            activitybind2.Name = "Workflow6";
            activitybind2.Path = "Connector_msg1";
            workflowparameterbinding2.ParameterName = "msg";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.Connector_Fire.Parameters.Add(workflowparameterbinding2);
            this.Connector_Fire.Type = typeof(InterfaceContract.IFireTest);
            // 
            // setStateActivity2
            // 
            this.setStateActivity2.Name = "setStateActivity2";
            this.setStateActivity2.TargetStateName = "Cleanup";
            // 
            // codeActivity3
            // 
            this.codeActivity3.Name = "codeActivity3";
            this.codeActivity3.ExecuteCode += new System.EventHandler(this.OnOneWayProcessor);
            // 
            // Connector_OneWay
            // 
            this.Connector_OneWay.MethodName = "OneWay";
            this.Connector_OneWay.Name = "Connector_OneWay";
            activitybind3.Name = "Workflow6";
            activitybind3.Path = "Connector_msg1";
            workflowparameterbinding3.ParameterName = "msg";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.Connector_OneWay.Parameters.Add(workflowparameterbinding3);
            this.Connector_OneWay.Type = typeof(InterfaceContract.ITest);
            // 
            // setStateActivity1
            // 
            this.setStateActivity1.Name = "setStateActivity1";
            this.setStateActivity1.TargetStateName = "PostProcessor";
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new System.EventHandler(this.OnSayHelloProcessor);
            // 
            // Connector_SayHello
            // 
            this.Connector_SayHello.MethodName = "SayHello";
            this.Connector_SayHello.Name = "Connector_SayHello";
            activitybind4.Name = "Workflow6";
            activitybind4.Path = "Connector_msg1";
            workflowparameterbinding4.ParameterName = "msg";
            workflowparameterbinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.Connector_SayHello.Parameters.Add(workflowparameterbinding4);
            this.Connector_SayHello.Type = typeof(InterfaceContract.ITest);
            // 
            // Init
            // 
            this.Init.Activities.Add(this.codeActivity4);
            this.Init.Activities.Add(this.setStateActivity4);
            this.Init.Name = "Init";
            // 
            // End
            // 
            this.End.Activities.Add(this.codeActivity5);
            this.End.Activities.Add(this.setStateActivity5);
            this.End.Name = "End";
            // 
            // Finish
            // 
            this.Finish.Activities.Add(this.codeActivity1);
            this.Finish.Name = "Finish";
            // 
            // Response
            // 
            this.Response.Activities.Add(this.Return);
            this.Response.Activities.Add(this.setStateActivity3);
            this.Response.Name = "Response";
            // 
            // onFire
            // 
            this.onFire.Activities.Add(this.Connector_Fire);
            this.onFire.Activities.Add(this.codeActivity6);
            this.onFire.Activities.Add(this.setStateActivity6);
            this.onFire.Name = "onFire";
            // 
            // onOneWay
            // 
            this.onOneWay.Activities.Add(this.Connector_OneWay);
            this.onOneWay.Activities.Add(this.codeActivity3);
            this.onOneWay.Activities.Add(this.setStateActivity2);
            this.onOneWay.Name = "onOneWay";
            // 
            // onSayHello
            // 
            this.onSayHello.Activities.Add(this.Connector_SayHello);
            this.onSayHello.Activities.Add(this.codeActivity2);
            this.onSayHello.Activities.Add(this.setStateActivity1);
            this.onSayHello.Name = "onSayHello";
            // 
            // Done
            // 
            this.Done.Name = "Done";
            // 
            // PreProcessor
            // 
            this.PreProcessor.Activities.Add(this.Init);
            this.PreProcessor.Name = "PreProcessor";
            // 
            // Cleanup
            // 
            this.Cleanup.Activities.Add(this.End);
            this.Cleanup.Name = "Cleanup";
            // 
            // PostProcessor
            // 
            this.PostProcessor.Activities.Add(this.Response);
            this.PostProcessor.Activities.Add(this.Finish);
            this.PostProcessor.Name = "PostProcessor";
            // 
            // Processor
            // 
            this.Processor.Activities.Add(this.onSayHello);
            this.Processor.Activities.Add(this.onOneWay);
            this.Processor.Activities.Add(this.onFire);
            this.Processor.Name = "Processor";
            // 
            // Workflow6
            // 
            this.Activities.Add(this.Processor);
            this.Activities.Add(this.PostProcessor);
            this.Activities.Add(this.Cleanup);
            this.Activities.Add(this.PreProcessor);
            this.Activities.Add(this.Done);
            this.CompletedStateName = "Done";
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "PreProcessor";
            this.Name = "Workflow6";
            this.CanModifyActivities = false;

        }

        #endregion

        private CodeActivity codeActivity6;
        private SetStateActivity setStateActivity6;
        private EventDrivenActivity onFire;
        private RKiss.ActivityLibrary.ConnectorActivity Connector_Fire;
        private SetStateActivity setStateActivity5;
        private StateInitializationActivity End;
        private StateActivity Done;
        private CodeActivity codeActivity5;
        private SetStateActivity setStateActivity4;
        private StateInitializationActivity Init;
        private CodeActivity codeActivity4;
        private SetStateActivity setStateActivity2;
        private CodeActivity codeActivity3;
        private RKiss.ActivityLibrary.ConnectorActivity Connector_OneWay;
        private EventDrivenActivity onOneWay;
        private StateActivity PreProcessor;
        private CodeActivity codeActivity2;
        private CodeActivity codeActivity1;
        private StateFinalizationActivity Finish;
        private SetStateActivity setStateActivity1;
        private StateInitializationActivity Response;
        private EventDrivenActivity onSayHello;
        private StateActivity PostProcessor;
        private SetStateActivity setStateActivity3;
        private StateActivity Cleanup;
        private RKiss.ActivityLibrary.ReturnActivity Return;
        private RKiss.ActivityLibrary.ConnectorActivity Connector_SayHello;
        private StateActivity Processor;









































































































    }
}
