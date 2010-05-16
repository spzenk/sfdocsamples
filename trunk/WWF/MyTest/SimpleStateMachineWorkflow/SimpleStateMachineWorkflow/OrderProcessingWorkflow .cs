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

namespace Microsoft.Samples.Workflow.SimpleStateMachineWorkflow
{
    public sealed partial class OrderProcessingWorkflow : StateMachineWorkflowActivity
    {

        #region fields
        NewOrderEventArgs receivedOrderDetails;
        Guid orderId;

        public Guid OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        string orderItem;

        public string OrderItem
        {
            get { return orderItem; }
            set { orderItem = value; }
        }
        int orderQuantity;

        public int OrderQuantity
        {
            get { return orderQuantity; }
            set { orderQuantity = value; }
        }
        string orderItemStatus;

        public string OrderItemStatus
        {
            get { return orderItemStatus; }
            set { orderItemStatus = value; }
        }



        #endregion

        public OrderProcessingWorkflow()
        {
            InitializeComponent();
        }
        private void OrderReceived(object sender, EventArgs e)
        {
            this.orderId = receivedOrderDetails.ItemId;
            this.orderItem = receivedOrderDetails.Item;
            this.orderQuantity = receivedOrderDetails.Quantity;
            this.orderItemStatus = "Received order";
                

        }


    }
}
