using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Allus.Cnn.Common.BE;
using Allus.Cnn.Common;

namespace Allus.Cnn.Common
{
    [ToolboxItem(true)]
    [DefaultEvent("SendMessageEvent")]
    public partial class MessageCreatorContainer : UserControlBase
    {
    
        [CategoryAttribute("Allus.Factory")]
        public event EventHandler SendMessageEvent;
        MessageCreatorBase _CurrentMessageCreator;

        string _MeshName;
        [Browsable(false)]
        public string MeshName
        {
            get
            {
                return _MeshName;
            }
            set { _MeshName = value; }
        }

        public MessageCreatorContainer()
        {
            InitializeComponent();
        }
        void FillMessage()
        {
           
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (_CurrentMessageCreator == null) return;

            AlertMessage wMessage = new AlertMessage();


            wMessage.MessageGuid = Guid.NewGuid();
            wMessage.Date = System.DateTime.Now;
            wMessage.MeshName = _MeshName;
            _CurrentMessageCreator.FillMessage(wMessage);

            if (this.radioGroup1.SelectedIndex != -1)
                wMessage.Priority = (int)this.radioGroup1.Properties.Items[this.radioGroup1.SelectedIndex].Value;
            else
                wMessage.Priority = 1;


            if (SendMessageEvent != null)
                SendMessageEvent(wMessage, new EventArgs());
            this.radioGroup1.SelectedIndex = 1;

            //this.radioGroup_MessageType.SelectedIndex = -1;
            //panelControl1.Controls.Clear();
            _CurrentMessageCreator.ClearControls();
            //popupContainerEdit_MessageType.Text = "Tipo de mensaje ";
        }

      
        private void radioGroup1_MouseLeave(object sender, EventArgs e)
        {
            radioGroup1.Visible = false;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            radioGroup1.Visible = true;
        }

        private void MessageCreator_Load(object sender, EventArgs e)
        {
            panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup_MessageType.SelectedIndex = 0;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageType c = (MessageType)this.radioGroup_MessageType.Properties.Items[this.radioGroup1.SelectedIndex].Value;
        }


        private void radioGroup_MessageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup_MessageType.SelectedIndex == -1)
                return;

            if (_CurrentMessageCreator != null)
            {
                if (!_CurrentMessageCreator.IsEmpty() && this.panelControl1.Controls.Count > 0)
                {
                    this.MessageViewer.MessageBoxButtons = MessageBoxButtons.YesNo;
                    this.MessageViewer.MessageBoxIcon = Allus.Libs.Common.MessageBoxIcon.Question;
                    DialogResult res = this.MessageViewer.Show("¿Desea perder los cambios del mensaje anterior?");

                    base.SetMessageViewInfoDefault();

                    if (res != DialogResult.Yes) 
                        return;
                }
            }

            MessageType c = (MessageType)this.radioGroup_MessageType.Properties.Items[this.radioGroup_MessageType.SelectedIndex].Value;
            string typeName = string.Empty;
            switch (c)
            {
                case MessageType.SimpleText:
                    {
                        MessageCreatorSimple _msgCreator = new MessageCreatorSimple();
                        _CurrentMessageCreator = _msgCreator;
                        typeName = "Texto simple";
                        break;
                    }
                case MessageType.RichText:
                    {
                        MessageCreatorRichText _msgCreator = new MessageCreatorRichText();
                        _CurrentMessageCreator = _msgCreator;
                        typeName = "Texto enriquecido";
                        break;
                    }
                case MessageType.Marquee:
                    {
                        MarqueeEditor _msgCreator = new MarqueeEditor();
                        //_msgCreator.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                        _CurrentMessageCreator = _msgCreator;
                        typeName = "Marquesina";                        
                        break;
                    }
            }
           
            popupContainerEdit_MessageType.Text = "Tipo de mensaje " + typeName;

            Allus.Libs.Common.HelperFunctions.AddtoPanel(_CurrentMessageCreator, panelControl1);
            panelControl1.Controls[0].Dock = DockStyle.Fill;

        }

      
    }
}
