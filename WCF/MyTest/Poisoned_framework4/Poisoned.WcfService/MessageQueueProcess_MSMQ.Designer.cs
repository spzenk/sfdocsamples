namespace Poisoned.WcfService
{
    partial class MessageQueueProcess_MSMQ
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SysEventQueue = new System.Messaging.MessageQueue();
            // 
            // SysEventQueue
            // 
            this.SysEventQueue.DefaultPropertiesToSend.EncryptionAlgorithm = System.Messaging.EncryptionAlgorithm.None;
            this.SysEventQueue.DefaultPropertiesToSend.HashAlgorithm = System.Messaging.HashAlgorithm.None;
            this.SysEventQueue.DefaultPropertiesToSend.Label = "TarifadorLabel";
            this.SysEventQueue.Formatter = new System.Messaging.BinaryMessageFormatter(System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple, System.Runtime.Serialization.Formatters.FormatterTypeStyle.TypesAlways);
            this.SysEventQueue.MessageReadPropertyFilter.LookupId = true;
            this.SysEventQueue.MessageReadPropertyFilter.SentTime = true;
            this.SysEventQueue.Path = "corrsf71des01\\private$\\SysEventQueue";

        }

        #endregion

        private System.Messaging.MessageQueue SysEventQueue;
    }
}
