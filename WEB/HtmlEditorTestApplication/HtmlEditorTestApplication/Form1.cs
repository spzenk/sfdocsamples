using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HtmlEditorTestApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void barButtonItemLoadHtml_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            richEditControl1.HtmlText = richTextBoxHtmlToLoad.Text;
        }

        private void barButtonItemSaveHtml_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            richTextBoxSavedHtml.Text = richEditControl1.HtmlText;
        }
    }
}
