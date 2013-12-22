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
using Fwk.UI.Common;

namespace Health.Front.Events
{
    [ToolboxItem(true)]
    public partial class uc_docprontviewer : XtraUserControl
    {
        RichTextBox box;
        RichTextBoxLink link;
        /// <summary>
        /// "Singleevent.rtf"
        /// </summary>
        public string FileName { get; set; }
        public uc_docprontviewer()
        {
            InitializeComponent();
            box = new RichTextBox ();
            box.Dock = DockStyle.Fill;

            //fDockPanel.Dock = DockingStyle.Bottom;
            //fDockPanel.ControlContainer.Controls.Add(box);
            //fDockPanel.Height /= 2;

            link = new RichTextBoxLink();
            link.RichTextBox = box;
            
            link.PrintingSystem = printingSystem1;

            //bciClientPageSize.Tag = RichTextPrintFormat.ClientPageSize;
            //bciRichTextBoxSize.Tag = RichTextPrintFormat.RichTextBoxSize;
            //repositoryItemSpinEdit1.Mask.EditMask = "\\d{1,5}";
            //repositoryItemSpinEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
        }

        public void Pupulate()
        {
            //box.LoadFile(FileName, RichTextBoxStreamType.RichText);
            try
            {
                template = Fwk.HelperFunctions.FileFunctions.OpenTextFile(this.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
           }

            box.Rtf = Create_Doc();

            link.CreateDocument();
            using (WaitCursorHelper w = new WaitCursorHelper(this))
            {
                printingSystem1.Graph.PageUnit = GraphicsUnit.Pixel;
            }
          


        }





        string template = string.Empty;
        

        string Create_Doc()
        {
            StringBuilder t = new StringBuilder(template);
            t.Replace("Institution", "Instituto Adelia Maria");
            t.Replace("Fecha1", "12/12/5048");
            t.Replace("Mot1", "12/12/5048");
            t.Replace("Esp1", "12/12/5048");
            t.Replace("Diag1", "12/12/5048");
            
            return t.ToString();
        }

    }
}
