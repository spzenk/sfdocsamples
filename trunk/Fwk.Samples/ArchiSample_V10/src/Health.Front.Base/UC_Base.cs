using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Health.Front.Bases;

namespace Health.Front
{
    public partial class Xtra_UC_Base : Fwk.UI.Controls.UC_UserControlBase
    {
        [DefaultValue(false)]
        public bool ShowSave { get; set; }
        [DefaultValue(true)]
        public bool ShowClose { get; set; } 
        protected void Exit(object o,EventArgs e)
        {
            if (OnExitControlEvent != null)
                OnExitControlEvent(o, e);
        }
        public event EventHandler OnExitControlEvent;
        public Fwk.Bases.EntityUpdateEnum State = Fwk.Bases.EntityUpdateEnum.NEW;

        public Xtra_UC_Base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void AceptChanges(bool this_will_close) { }
        /// <summary>
        /// 
        /// </summary>
        public virtual void CancelChanges() { }
        /// <summary>
        /// 
        /// </summary>
        public virtual void Exit() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        public virtual void Populate(object filter) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        public virtual void SetTitle(string title) { }

        private void Xtra_UC_Base_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                this.Refresh();
            }
        }



        public string Key { get; set; }
    }
}
