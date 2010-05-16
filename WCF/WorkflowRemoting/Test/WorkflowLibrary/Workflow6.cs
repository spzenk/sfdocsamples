using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
//
using RKiss.ActivityLibrary;
using RKiss.WorkflowRemoting;

namespace WorkflowLibrary
{
    public sealed partial class Workflow6 : StateMachineWorkflowActivity
    {
        public Workflow6()
        {
            InitializeComponent();
        }

        private HybridDictionary _initData;
        public HybridDictionary InitData
        {
            get { return _initData; }
            set { _initData = value; }
        }
        private string _stateMsg = string.Empty;
        public string StateMsg
        {
            get { return _stateMsg; }
            set { _stateMsg = value; }
        }
        private int _counter;

        public int Counter
        {
            get { return _counter; }
            set { _counter = value; }
        }
	
	
        public String Connector_msg1 = default(System.String);
        public String Return__ReturnValue_1 = default(System.String);

        private void OnInit(object sender, EventArgs e)
        {
            StateMsg = "Init";
            Console.WriteLine("LWC={0}, {1}.Init,\t\t\tCallContext: {2}", LCC.LogicalWorkflowContext.ContextId, this.Name, Helpers.ConvertListToText(LCC.GetKeys()));
        }
        private void OnSayHelloProcessor(object sender, EventArgs e)
        {
            StateMsg = "SayHello";
            Counter++;
            Return__ReturnValue_1 = Connector_msg1;
            Console.WriteLine("LWC={0}, {1}.SayHello: {2},\tCallContext: {3}", LCC.LogicalWorkflowContext.ContextId, this.Name, Connector_msg1, Helpers.ConvertListToText(LCC.GetKeys()));
        }
        private void OnOneWayProcessor(object sender, EventArgs e)
        {
            StateMsg = "OneWay";
            Console.WriteLine("LWC={0}, {1}.OnWay:    {2},\tCallContext: {3}", LCC.LogicalWorkflowContext.ContextId, this.Name, Connector_msg1, Helpers.ConvertListToText(LCC.GetKeys()));
        }
        private void OnFireProcessor(object sender, EventArgs e)
        {
            StateMsg = "Fire";
            Console.WriteLine("LWC={0}, {1}.OnFire:   {2},\tCallContext: {3}", LCC.LogicalWorkflowContext.ContextId, this.Name, Connector_msg1, Helpers.ConvertListToText(LCC.GetKeys()));
        } 
        private void OnFinish(object sender, EventArgs e)
        {
            StateMsg = "Finish";
            Console.WriteLine("LWC={0}, {1}.Finish, Counter={2},\t\tCallContext: {3}", LCC.LogicalWorkflowContext.ContextId, this.Name, Counter, Helpers.ConvertListToText(LCC.GetKeys()));
        }
        private void OnCleanup(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("LWC={0}, {1}.Exit,\t\t\tCallContext: {2}", LCC.LogicalWorkflowContext.ContextId, this.Name, Helpers.ConvertListToText(LCC.GetKeys()));
            Console.ResetColor();

            if(StateMsg == "Fire")
                Console.WriteLine();            
        }

      

       
    }
}
