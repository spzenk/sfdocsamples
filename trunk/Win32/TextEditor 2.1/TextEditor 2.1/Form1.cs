using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
 using CSharpBinding;


using ICSharpCode.TextEditor.Actions;

namespace Controls.TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtEditor.Document.TextContent = GetCode();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ICSharpCode.TextEditor.Document.IFormattingStrategy oFormatting =
                        new CSharpBinding.FormattingStrategy.CSharpFormattingStrategy();
            txtEditor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            txtEditor.Document.FormattingStrategy = oFormatting;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ICSharpCode.TextEditor.TextAreaControl ta = new TextAreaControl(txtEditor);
            CSharpBinding.FormattingStrategy.CSharpFormattingStrategy Formating = new CSharpBinding.FormattingStrategy.CSharpFormattingStrategy();
            Formating.IndentLines(ta.TextArea, 0, txtEditor.Document.TotalNumberOfLines - 1);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ICSharpCode.TextEditor.Document.TextMarker t = new TextMarker(10, 30, TextMarkerType.SolidBlock);
            
            //ICSharpCode.TextEditor.Util.TextUtility.RegionMatches(txtEditor.Document,0,30,"#");
            string commentStart = "#region";
            string commentEnd = "#endregion";

            IDocument document = txtEditor.Document;// new DocumentFactory().CreateDocument();  
            
            
            int selectionStartOffset = 0;
            int selectionEndOffset = selectionStartOffset + document.TextContent.Length;

            BlockCommentRegion commentRegion = ToggleBlockComment.FindSelectedCommentRegion(document, commentStart, commentEnd, selectionStartOffset, selectionEndOffset);
            
            
        }

        private string   GetCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);
            sb.Append(@"using System;");
            sb.Append(Environment.NewLine);
            sb.Append(@"using System.Collections.Generic;");
            sb.Append(Environment.NewLine);
            sb.Append(@"using System.Text;");
            sb.Append(Environment.NewLine);
            sb.Append(@"");
            sb.Append(Environment.NewLine);
            sb.Append(@"namespace TextEditor");
            sb.Append(Environment.NewLine);
            sb.Append(@"{");
            sb.Append(Environment.NewLine);
            sb.Append(@"    public class ClaseTexto");
            sb.Append(Environment.NewLine);
            sb.Append(@"    {");
            sb.Append(Environment.NewLine);
            sb.Append(@"        #region [MetodosA]");
            sb.Append(Environment.NewLine);
            sb.Append(@"");
            sb.Append(Environment.NewLine);
            sb.Append(@"        /// <summary>");
            sb.Append(Environment.NewLine);
            sb.Append(@"        /// Comentario CrearA");
            sb.Append(Environment.NewLine);
            sb.Append(@"        /// </summary>");
            sb.Append(Environment.NewLine);
            sb.Append(@"        /// <returns></returns>");
            sb.Append(Environment.NewLine);
            sb.Append(@"        public string CrearA()");
            sb.Append(Environment.NewLine);
            sb.Append(@"        { return string.Empty;}");
            sb.Append(Environment.NewLine);
            sb.Append(@"        public string MoverA()");
            sb.Append(Environment.NewLine);
            sb.Append(@"        { return string.Empty; }");
            sb.Append(Environment.NewLine);
            sb.Append(@"");
            sb.Append(Environment.NewLine);
            sb.Append(@"        #endregion");
            sb.Append(Environment.NewLine);
            sb.Append(@"");
            sb.Append(Environment.NewLine);
            sb.Append(@"        #region [Metodos B]");
            sb.Append(Environment.NewLine);
            sb.Append(@"");
            sb.Append(Environment.NewLine);
            sb.Append(@"        public string CrearB()");
            sb.Append(Environment.NewLine);
            sb.Append(@"        { return string.Empty; }");
            sb.Append(Environment.NewLine);
            sb.Append(@"");
            sb.Append(Environment.NewLine);
            sb.Append(@"        public string MoverB()");
            sb.Append(Environment.NewLine);
            sb.Append(@"        { return string.Empty; }");
            sb.Append(Environment.NewLine);
            sb.Append(@"");
            sb.Append(Environment.NewLine);
            sb.Append(@"        #endregion");
            sb.Append(Environment.NewLine);
            sb.Append(@"    }");
            sb.Append(Environment.NewLine);
            sb.Append(@"}");
            sb.Append(Environment.NewLine);
            sb.Append(@"");
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }


    }
}