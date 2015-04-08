using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epiron.Front.Bases.Controls
{
    public partial class EP_LookUpEdit : DevExpress.XtraEditors.LookUpEdit, IEpironControl
    {
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit fProperties;
    
        [Browsable(true)]
        [Category("Epiron")]
        public string TextUICode { get; set; }

        [Browsable(true)]
        [Category("Epiron")]
        public Boolean CheckEditingABMValue { get; set; }

        [Browsable(true)]
        [Category("Epiron")]
        public Boolean CheckEditingABM { get; set; }

        private void InitializeComponent()
        {
            this.fProperties = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // fProperties
            // 

            this.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});

            //this.fProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            //new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fProperties.Name = "fProperties";
            this.fProperties.ReadOnly = true;
            this.fProperties.ShowFooter = false;
            this.fProperties.ShowHeader = false;
            this.fProperties.ShowLines = false;
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).EndInit();
            this.ResumeLayout(false);

        }

        
    }
}
