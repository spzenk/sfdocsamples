using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Workflow.Runtime;
using IntegrationSample;
using System.Workflow.Activities;

namespace ReclamosAtencionPublico
{
    public partial class frmReclamo : Form, IntegrationSample.IWorkflowData
    {
        public frmReclamo()
        {
            InitializeComponent();
        }

        
        WorkflowInstance workflowInstance;
        WorkflowRuntime workflowRuntime;

        int instanceCounter = 0;

        private void frmReclamo_Load(object sender, EventArgs e)
        {
            workflowRuntime = new WorkflowRuntime();

            ExternalDataExchangeService dataExchange = new ExternalDataExchangeService();
            workflowRuntime.AddService(dataExchange);
            dataExchange.AddService(this);
                        
            workflowRuntime.StartRuntime();

            workflowRuntime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(workflowRuntime_WorkflowCompleted);
        }

        /// <summary>
        /// Evento que se ejecuta cada vez que se completa una instancia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void workflowRuntime_WorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            lblInstances .Text = (++instanceCounter).ToString() + " instancias procesadas";
        }

        #region IWorkflowData Members

        public void SetHostMessage(string Message)
        {
            MessageBox.Show(Message, "Workflow Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public event EventHandler<WorkflowInitEventArgs> WorkflowInitialization;

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Creamos una instancia del workflow
            Type type = typeof(IntegrationSample.wfIntegrationAndRouting);
            workflowInstance = workflowRuntime.CreateWorkflow(type);
            workflowInstance.Start();
            
            //Creamos un objeto para pasar los parametros necesarios en la
            //llamada al evento
            WorkflowInitEventArgs eventArgs = new WorkflowInitEventArgs(workflowInstance.InstanceId, txtUser.Text,
                txtTE.Text, cmbType.Text, txtObs.Text);
            
            //Llamada al evento que comunica la aplicacion con el workflow
            if(WorkflowInitialization != null) 
                WorkflowInitialization(null, eventArgs);
        }
   }
}