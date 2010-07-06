using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace Allus.Cnn.Common
{
    public partial class ExpandPopUpButton : SimpleButton
    {
        bool _IsFilterOpen = false;
        PopupContainerControl popupContainer;
        
        public PopupContainerControl PopupContainer
        {
            get { return popupContainer; }
            set { popupContainer = value; }
        }
        public ExpandPopUpButton()
        {
            InitializeComponent();
            this.Image = global::Allus.Cnn.Common.Properties.Resources.MaxImage;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            HideShowfilter();
           
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        public void HideShowfilter()
        {
            if (_IsFilterOpen)
            {

                this.Image = global::Allus.Cnn.Common.Properties.Resources.MaxImage;
                popupContainer.Hide();
            }
            else
            {
                this.Image = global::Allus.Cnn.Common.Properties.Resources.MinImage;
                popupContainer.Show();


            }
            _IsFilterOpen = !_IsFilterOpen;

        }
    }
}
