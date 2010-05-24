using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Xml;

namespace IntegrationSample
{
    public sealed partial class wfIntegrationAndRouting : SequentialWorkflowActivity
    {
        public wfIntegrationAndRouting()
        {
            InitializeComponent();
        }

        #region private variables

        private string userName;
        private string userTE;
        private string reclaimType;
        private string reclaimObservations;
        public XmlDocument domMessageToSend;
        public String typeIncorrectMessage = "El tipo de reclamo es incorrecto";
        public String typeIsNotImplementedYet = "El ruteo para este tipo de reclamo no está terminado todavía";

        #endregion

        //#region public properties

        //public string UserName
        //{
        //    get { return userName; }
        //    set { userName = value; }
        //}

        //public string UserTE
        //{
        //    get { return userTE; }
        //    set { userTE = value; }
        //}

        //public string ReclaimType
        //{
        //    get { return reclaimType; }
        //    set { reclaimType = value; }
        //}

        //public string ReclaimObservations
        //{
        //    get { return reclaimObservations; }
        //    set { reclaimObservations = value; }
        //}

        //#endregion

        private void IsTE(object sender, ConditionalEventArgs e)
        {
            if (reclaimType == "TE")
                e.Result = true;
            else
                e.Result = false;
        }

        private void codePrepareXmlExecute(object sender, EventArgs e)
        {
            domMessageToSend = new XmlDocument();
            XmlNode messageNode = domMessageToSend.AppendChild(domMessageToSend.CreateElement("Message"));
            messageNode.AppendChild(domMessageToSend.CreateElement("userName")).InnerText = userName;
            messageNode.AppendChild(domMessageToSend.CreateElement("userTE")).InnerText = userTE;
            messageNode.AppendChild(domMessageToSend.CreateElement("reclaimType")).InnerText = reclaimType;
            messageNode.AppendChild(domMessageToSend.CreateElement("reclaimObservations")).InnerText = reclaimObservations;
        }

        private void codeShowMessageExecute(object sender, EventArgs e)
        {
            System.Console.WriteLine("Calling Web Service");
        }

        private void GetValues_Invoked(object sender, ExternalDataEventArgs e)
        {
            WorkflowInitEventArgs eData = (e as WorkflowInitEventArgs);
            if (eData != null)
            {
                userName = eData.UserName;
                userTE = eData.UserTE;
                reclaimType = eData.ReclaimType;
                reclaimObservations = eData.ReclaimObservations;
            }

        }

        private void InvokingWebService(object sender, InvokeWebServiceEventArgs e)
        {
            System.Console.WriteLine("The workflow is now invoking the Web Service");
        }

        private void InvokedWebService(object sender, InvokeWebServiceEventArgs e)
        {
            System.Console.WriteLine("The Web Service invocation is finished");
        }

        
    }

}
