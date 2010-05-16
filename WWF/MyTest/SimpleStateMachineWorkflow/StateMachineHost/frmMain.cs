using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Samples.Workflow.SimpleStateMachineWorkflow;
using System.Workflow.Runtime;
using System.Workflow.Activities;

namespace StateMachineHost
{
    
    public partial class frmMain : Form, IOrderingService
    {
        private delegate void ItemStatusUpdateDelegate(Guid orderId, string newStatus);
        private WorkflowRuntime workflowRuntime = null;
        private ExternalDataExchangeService exchangeService = null;
        private Dictionary<string, List<string>> orderHistory;
     


      

        public frmMain()
        {
            InitializeComponent();

            orderHistory = new Dictionary<string, List<string>>();

            //Inicia el Workflow
            this.workflowRuntime = new WorkflowRuntime();
            //Sirve para intercambio de dato entre el Workflow y el Host
            this.exchangeService = new ExternalDataExchangeService();


            this.workflowRuntime.AddService(this.exchangeService);
            this.exchangeService.AddService(this);
            this.workflowRuntime.StartRuntime();


            this.itemsList.SelectedIndex = 0;


        }




        void submitButton_Click(object sender, System.EventArgs e)
        {
            string item = this.itemsList.SelectedItem.ToString();
            int quantity = (int)this.itemQuantity.Value;

            Type orderWorkflow = typeof(OrderProcessingWorkflow);
            WorkflowInstance workflowInstance = this.workflowRuntime.CreateWorkflow(orderWorkflow);

            this.orderHistory[workflowInstance.InstanceId.ToString()] = new List<string>();
            this.orderHistory[workflowInstance.InstanceId.ToString()].Add("Item: " + item + "; Quantity:" + quantity);


            workflowInstance.Start();

            NewOrderEvent(null, new NewOrderEventArgs(workflowInstance.InstanceId, item, quantity));

        }
        void ordersIdList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.orderStatus.Text = GetOrderHistory(this.ordersIdList.SelectedItem.ToString());
        }

        #region IOrderingService Members


        public event EventHandler<NewOrderEventArgs> NewOrderEvent;
        public void ItemStatusUpdate(Guid orderId, string newStatus)
        {
            if (this.ordersIdList.InvokeRequired == true)
            {
                ItemStatusUpdateDelegate statusUpdate = new ItemStatusUpdateDelegate(ItemStatusUpdate);
                object[] args = new object[2] { orderId, newStatus };
                this.Invoke(statusUpdate, args);
            }
            else
            {
                if (this.orderHistory.ContainsKey(orderId.ToString()))
                {
                    this.orderHistory[orderId.ToString()].Add
                        (DateTime.Now + " - " + newStatus);

                    // Update order status data UI info
                    if (this.ordersIdList.Items.Contains(orderId.ToString()) == false)
                    {
                        this.ordersIdList.Items.Add(orderId.ToString());
                    }

                    this.ordersIdList.SelectedItem = orderId.ToString();
                    this.orderStatus.Text = GetOrderHistory(orderId.ToString());
                }

            }


        }
        private string GetOrderHistory(string orderId)
        {
            // Retrieve the order status
            StringBuilder itemHistory = new StringBuilder();

            foreach (string status in this.orderHistory[orderId])
            {
                itemHistory.Append(status);
                itemHistory.Append(Environment.NewLine);
            }
            return itemHistory.ToString();
        }

        #endregion
    }
}
