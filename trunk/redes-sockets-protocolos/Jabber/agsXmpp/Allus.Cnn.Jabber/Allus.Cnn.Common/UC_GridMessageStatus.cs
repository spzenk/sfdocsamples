using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Allus.Cnn.Common.BE;
using System.Linq;

namespace Allus.Cnn.Common
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class UC_GridMessageStatus : DevExpress.XtraEditors.XtraUserControl
    {
        List<ColaboratorData> _ColaboratorDataSourceOriginal = new List<ColaboratorData>();

        public UC_GridMessageStatus()
        {
            InitializeComponent();
        }

        public void Populate(Guid pMessageId, string pMeshId)
        {
            textFind1.TextEditor.Text = string.Empty;
            ColaboratorData wColaboratorData = new ColaboratorData(new MeshBE(string.Empty, pMeshId));
            _ColaboratorDataSourceOriginal = Controller.SearchMessageReadConfirmed(pMessageId, wColaboratorData);
            colaboratorDataBindingSource.DataSource = _ColaboratorDataSourceOriginal;
            gridControl1.RefreshDataSource();
            if (bandedGridView1.RowCount > 0)
                exportToolBar1.Enabled = true;
            else
                exportToolBar1.Enabled = false;
        }

        private void UC_GridMessageStatus_Load(object sender, EventArgs e)
        {
            exportToolBar1.Enabled = false;
        }

        private void textFind1_OnFindClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textFind1.TextEditor.Text))
            {
                colaboratorDataBindingSource.DataSource = _ColaboratorDataSourceOriginal;
                gridControl1.RefreshDataSource();
            }
            else
            {
                //Filtramos la b�squeda
                var wColaboratorDataSourceFiltered =
                       (from Colaborators in _ColaboratorDataSourceOriginal
                        where
                        (Colaborators.Username.ToUpper().Contains(textFind1.TextEditor.Text.ToUpper()) ||
                        Colaborators.Firstname.ToUpper().Contains(textFind1.TextEditor.Text.ToUpper()) ||
                        Colaborators.Surname.ToUpper().Contains(textFind1.TextEditor.Text.ToUpper()) ||
                        Colaborators.MessageStatus.ToUpper().Contains(textFind1.TextEditor.Text.ToUpper()))
                        select Colaborators);

                colaboratorDataBindingSource.DataSource = wColaboratorDataSourceFiltered;
                gridControl1.RefreshDataSource();
            }
            bandedGridView1.ExpandAllGroups();
        }

        private void textFind1_OnFindTextBoxEnter(object sender, EventArgs e)
        {
            textFind1_OnFindClick(sender, e);
        }

    }
}
