using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Allus.Cnn.Common.BE;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;
using System.Collections;
using DevExpress.XtraGrid.Views.Base;

namespace Allus.Cnn.Common
{
    [ToolboxItem(true)]
    [DefaultEvent("OnGridClick")]
    public partial class MessageGridFind : UserControlBase
    {
        #region Fields
        ColaboratorData _colaborator;
        MessagesBECollection _MessagesCollectionDataSource;
        GridHitInfo _HitInfo = null;
        public event EventHandler OnGridClick;
        MessagesBE _currentMessage;
        public event EventHandler OnFindClickOrEnter;
        #endregion

        public MessagesBE CurrentMessage
        {
            get { return _currentMessage; }
            set { _currentMessage = value; }
        }

        public MessageGridFind()
        {
            InitializeComponent();
            _MessagesCollectionDataSource = new MessagesBECollection();
            messagesBECollectionBindingSource.DataSource = _MessagesCollectionDataSource;
        }

        public void Populate()
        {
            _colaborator = Controller.GetColaboratorDataInstance();
            MessagesBE wMessage = new MessagesBE();
            wMessage.Sender = _colaborator.Username;
            wMessage.MessageType = MessageType.None;
            try
            {
                _MessagesCollectionDataSource = Controller.SearchMessageByParams(wMessage, DateTime.Now.AddDays(-10), DateTime.Now);
                messagesBECollectionBindingSource.DataSource = _MessagesCollectionDataSource;
                grdMessages.RefreshDataSource();

            }
            catch (Exception ex)
            {
                base.ExceptionViewer.Show(ex);
            }
        }

        private void textFindPopUp1_OnFindClick(object sender, EventArgs e)
        {
            MessagesBE wMessage = new MessagesBE();
            wMessage.Sender = _colaborator.Username;
            wMessage.Title = textFindPopUp1.TextEditor.Text;
            //Busca para este usuario y solo los ultimos 10 dias
            DateTime? startDate = DateTime.Now.AddDays(-10);
            DateTime? endDate = System.DateTime.Now;
            //wMessage.Title = textFindPopUp1.TextEditor.Text;
            if (this.domainCombosFilters1.Mesh != null)
                wMessage.MeshName = this.domainCombosFilters1.Mesh.Name;

            if (chkUseDate.Checked)
            {
                startDate = dtpDateStart.Value;
                endDate = dtpDateEnd.Value;
            }
            if (OnFindClickOrEnter != null)
                OnFindClickOrEnter(sender, e);

            try
            {
                _MessagesCollectionDataSource = Controller.SearchMessageByParams(wMessage, startDate, endDate);
                messagesBECollectionBindingSource.DataSource = _MessagesCollectionDataSource;
                grdMessages.RefreshDataSource();
                if (OnFindClickOrEnter != null)
                    OnFindClickOrEnter(sender, e);
            }
            catch (Exception ex)
            {
                base.ExceptionViewer.Show(ex);
            }
        }

        private void textFindPopUp1_OnFindTextBoxEnter(object sender, EventArgs e)
        {
            MessagesBE wMessage = new MessagesBE();
            wMessage.Sender = _colaborator.Username;
            DateTime? startDate = DateTime.Now.AddDays(-10);
            DateTime? endDate = DateTime.Now;

            if (chkUseDate.Checked)
            {
                startDate = dtpDateStart.Value;
                endDate = dtpDateEnd.Value;
            }
            wMessage.Title = textFindPopUp1.TextEditor.Text;
            if (this.domainCombosFilters1.Mesh != null)
                wMessage.MeshName = this.domainCombosFilters1.Mesh.Name;
            try
            {
                _MessagesCollectionDataSource = Controller.SearchMessageByParams(wMessage, startDate, endDate);
                messagesBECollectionBindingSource.DataSource = _MessagesCollectionDataSource;
                grdMessages.RefreshDataSource();
                if (OnFindClickOrEnter != null)
                    OnFindClickOrEnter(sender, e);
            }
            catch (Exception ex)
            {
                base.ExceptionViewer.Show(ex);
            }
        }

        private void grdMessages_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                domainCombosFilters1.Populate();
                //Seteamos esta propiedad por código para que cuando se haga click en un combo no se cierre el Popup
                textFindPopUp1.Properties.CloseOnOuterMouseClick = false;

            }
        }

        private void grdMessages_Click(object sender, EventArgs e)
        {

            if (GetRowClick())
                return;

            if (_HitInfo.InRowCell)
            {
                _currentMessage = (MessagesBE)((System.Windows.Forms.BindingSource)grdMessages.DataSource).Current;
                if (_currentMessage == null)
                    return;

                if (OnGridClick != null)
                    OnGridClick(sender, e);
            }

        }

        private bool GetRowClick()
        {
            return (_HitInfo == null ||
                _HitInfo.HitTest == GridHitTest.Row ||
                _HitInfo.HitTest == GridHitTest.RowGroupButton ||
                _HitInfo.HitTest == GridHitTest.RowIndicator ||
                _HitInfo.HitTest == GridHitTest.EmptyRow);
        }

        private void grdMessages_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            _HitInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
        }

        private void grdMessages_KeyUp(object sender, KeyEventArgs e)
        {
            _currentMessage = (MessagesBE)((System.Windows.Forms.BindingSource)grdMessages.DataSource).Current;
            if (_currentMessage == null)
                return;

            if (OnGridClick != null)
                OnGridClick(sender, e);
        }


    }
}
