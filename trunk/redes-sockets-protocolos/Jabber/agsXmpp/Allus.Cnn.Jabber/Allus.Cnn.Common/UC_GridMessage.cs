using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Allus.Cnn.Common.BE;
using System.Linq;

namespace Allus.Cnn.Common
{
    [System.ComponentModel.ToolboxItem(true)]
    [DefaultEvent("OnGridClick")]
    public partial class UC_GridMessage : UserControlBase
    {
        #region Fields
        bool _RecivedGrid = true;
        [Browsable(true), Category("Allus.Libs")]
        public bool RecivedGrid
        {
            set
            {
                _RecivedGrid = value;
                if (_RecivedGrid)
                {
                    colDate.Caption = "Recibido";
                    colSender.Visible = _RecivedGrid;
                }
                else
                {
                    colDate.Caption = "Enviado";
                    colSender.Visible = _RecivedGrid;
                }
            }

            get
            {
                return _RecivedGrid;

            }

        }


        GridHitInfo _HitInfo = null;
        AlertMessage _currentMessage;

        public AlertMessage CurrentMessage
        {
            get { return _currentMessage; }
            set { _currentMessage = value; }
        }
        AlertMessageList _AlertMessageList = new AlertMessageList();

        public event EventHandler OnGridClick;

        #endregion

        public UC_GridMessage()
        {
            InitializeComponent();
        }


        private void grdMessages_Click(object sender, EventArgs e)
        {
            if (GetRowClick())
                return;


            _currentMessage = (AlertMessage)((System.Windows.Forms.BindingSource)grdMessages.DataSource).Current;

            if (_currentMessage == null)
                return;

            if (_HitInfo.InRowCell)
            {

                ValidateConfirmation();

                grdMessages.RefreshDataSource();

                if (OnGridClick != null)
                    OnGridClick(sender, e);
            }
        }


        private void ValidateConfirmation()
        {
            if (!_RecivedGrid)
                return;
            //Preguntamos si el mensaje esta confirmado (si Confirmed = NULL significa que no requiere confirmacion). Ver AlertMessage
            if (_currentMessage.Confirmed != true && _currentMessage.RequireConfirm == true)
            {
                MessageViewer.MessageBoxIcon = Allus.Libs.Common.MessageBoxIcon.Question;
                MessageViewer.MessageBoxButtons = MessageBoxButtons.YesNo;
                MessageViewer.Title = "Confirmaci�n de recepci�n de mensaje";

                //Confirmar
                if (MessageViewer.Show("El remitente del mensaje ha solicitado el env�o de confirmaci�n de lectura tras la lectura del mensaje. \r\n �Desea enviar una confirmaci�n?") == DialogResult.Yes)
                {
                    //Si el usuario confirma y el mensaje ya habia sido leido solo actualizamos
                    _currentMessage.Confirmed = true;
                    if (!ValidateRead())
                        Controller.UpdateReceivedMessage(_currentMessage, Environment.UserName);
                    else
                        Controller.CreateReceivedMessage(_currentMessage, Environment.UserName);
                }
                else
                {  //Si el usuario no confirma ponemos Confirmed = false y luego vamos a crear
                    _currentMessage.Confirmed = false;
                }
            }

            //Si el mensaje no habia sido leido creamos el ReceivedMessage en la Base de Datos.
            if (ValidateRead())
                Controller.CreateReceivedMessage(_currentMessage, Environment.UserName);
        }

        private bool ValidateRead()
        {
            if (!_currentMessage.Read)
            {
                _currentMessage.Read = true;

                return true;
            }
            return false;
        }

        private bool GetRowClick()
        {
            return (_HitInfo == null ||
                _HitInfo.HitTest == GridHitTest.Row ||
                _HitInfo.HitTest == GridHitTest.RowGroupButton ||
                _HitInfo.HitTest == GridHitTest.RowIndicator ||
                _HitInfo.HitTest == GridHitTest.EmptyRow);
        }

        public void Populate(AlertMessage pAlertMessage)
        {
            _AlertMessageList.Add(pAlertMessage);
            grdMessages.RefreshDataSource();
        }


        private void grdMessages_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            _HitInfo = grdViewMessages.CalcHitInfo(new Point(e.X, e.Y));
        }

        private void grdMessages_Load(object sender, EventArgs e)
        {
            alertMessageBindingSource.DataSource = _AlertMessageList;
        }

        public void AlertClick(object sender, EventArgs e)
        {
            //TODO
            System.Guid wGuid = (System.Guid)((DevExpress.XtraBars.Alerter.AlertClickEventArgs)e).Info.Tag;
            AlertMessage a = (from item in _AlertMessageList where item.MessageGuid == wGuid select item).First();
            grdViewMessages.FocusedRowHandle = grdViewMessages.GetRowHandle(alertMessageBindingSource.IndexOf(a));
                                 
            //grdViewMessages.FocusedRowHandle = 0;
            grdViewMessages.SelectRow(grdViewMessages.FocusedRowHandle);
            //grdViewMessages.FocusedRowHandle = grdViewMessages.find

            _currentMessage = (AlertMessage)((System.Windows.Forms.BindingSource)grdMessages.DataSource).Current;

            if (_currentMessage == null)
                return;

            ValidateConfirmation();

            grdMessages.RefreshDataSource();

            if (OnGridClick != null)
                OnGridClick(sender, e);

        }
        private void grdMessages_KeyUp(object sender, KeyEventArgs e)
        {
            _currentMessage = (AlertMessage)((System.Windows.Forms.BindingSource)grdMessages.DataSource).Current;
            if (_currentMessage == null)
                return;

            if (OnGridClick != null)
                OnGridClick(sender, e);
        }

    }
}
