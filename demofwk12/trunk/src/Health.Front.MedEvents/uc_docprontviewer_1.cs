using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraRichEdit;
using Fwk.UI.Common;

namespace Health.Front.Events
{
    [ToolboxItem(true)]
    public partial class uc_docprontviewer_1 : XtraUserControl
    {
        public uc_docprontviewer_1()
        {
            InitializeComponent();
            //richEditControl1.ReadOnly = true;
        }

        public void Pupulate(string doc)
        {
            //box.LoadFile(FileName, RichTextBoxStreamType.RichText);
            //using (WaitCursorHelper w = new WaitCursorHelper(this))
            //{ 
               
                try
                {
                    richEditControl1.Document.BeginUpdate();
                    richEditControl1.Document.Sections[0].Margins.Left = 1;
                    richEditControl1.Document.Sections[0].Margins.Right = 1;
                    richEditControl1.Document.Sections[0].Margins.Top = 1;
                    richEditControl1.ReadOnly=true;
                    richEditControl1.HtmlText = doc;
                    //switchToSimpleViewItem1
              
                    richEditControl1.Document.EndUpdate();
                    
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            //}

        }


       
        


    }
}
