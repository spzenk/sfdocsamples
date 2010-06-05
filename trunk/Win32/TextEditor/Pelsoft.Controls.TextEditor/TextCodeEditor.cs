using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using CSharpBinding;
using VBBinding;
using CPPBinding;
using JavaBinding;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using Pelsoft.Controls.TextCodeEditor;
namespace Pelsoft.Controls.TextCodeEditor
{
	public delegate void MouseDownEventHand(object sender,System.EventArgs e);
	public delegate void ChangeEventHand(object sender);



	/// <summary>
	/// Summary description for TextCodeEditor.
	/// </summary>
	//[Designer(typeof(Pelsoft.Controls.TextCodeEditor.SysComponentDesigner))]
	//[Designer("Pelsoft.Controls.TextCodeEditor.Design.SysComponentDesigner, Pelsoft.Controls.TextCodeEditor.Design")]
	public class TextCodeEditor : System.Windows.Forms.UserControl
	{
		//public event  MouseDownEventHand  MouseDown2 ;

		//public event  ChangeEventHand  Change ;

		private ICSharpCode.TextEditor.TextEditorControl textEditorControl;
		public  System.Windows.Forms.ContextMenu Menu;
		private System.Windows.Forms.MenuItem menuItem1;
		
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.MenuItem menuItem2;


		private System.ComponentModel.Container components = null;

		
		public TextCodeEditor()
		{
		
			InitializeComponent();
			SetLenguaje();
			if(base.DesignMode)
				InitializeTextEditor();
		}


		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code

		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TextCodeEditor));
			this.textEditorControl = new ICSharpCode.TextEditor.TextEditorControl();
			this.Menu = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.lblTitle = new System.Windows.Forms.Label();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// textEditorControl
			// 
			this.textEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textEditorControl.Encoding = ((System.Text.Encoding)(resources.GetObject("textEditorControl.Encoding")));
			this.textEditorControl.Location = new System.Drawing.Point(0, 16);
			this.textEditorControl.Name = "textEditorControl";
			this.textEditorControl.ShowEOLMarkers = true;
			this.textEditorControl.ShowSpaces = true;
			this.textEditorControl.ShowTabs = true;
			this.textEditorControl.ShowVRuler = true;
			this.textEditorControl.Size = new System.Drawing.Size(544, 320);
			this.textEditorControl.TabIndex = 0;
			
			this.textEditorControl.Changed += new System.EventHandler(this.textEditorControl_Changed);
			this.textEditorControl.Load += new System.EventHandler(this.textEditorControl_Load);
			this.textEditorControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textEditorControl_MouseDown);
			// 
			// Menu
			// 
			this.Menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				 this.menuItem1});
			this.Menu.Popup += new System.EventHandler(this.Menu_Popup);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem3,
																					  this.menuItem4,
																					  this.menuItem5,
																					  this.menuItem6,
																					  this.menuItem8,
																					  this.menuItem9,
																					  this.menuItem10,
																					  this.menuItem12,
																					  this.menuItem13,
																					  this.menuItem2});
			this.menuItem1.Text = "Lenguaje";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 0;
			this.menuItem3.Text = "XML";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "C#";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 2;
			this.menuItem5.Text = "C64#";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 3;
			this.menuItem6.Text = "C++";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 4;
			this.menuItem8.Text = "HTML";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 5;
			this.menuItem9.Text = "JAVA";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 6;
			this.menuItem10.Text = "JScript";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 7;
			this.menuItem12.Text = "VBNET";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 8;
			this.menuItem13.Text = "VBSCRIPT";
			this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
			// 
			// lblTitle
			// 
			this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblTitle.BackColor = System.Drawing.Color.Silver;
			this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTitle.ContextMenu = this.Menu;
			this.lblTitle.Location = new System.Drawing.Point(0, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(544, 16);
			this.lblTitle.TabIndex = 1;
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 9;
			this.menuItem2.Text = "TXT";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// TextCodeEditor
			// 
			this.BackColor = System.Drawing.Color.Silver;
			this.ContextMenu = this.Menu;
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.textEditorControl);
			this.Name = "TextCodeEditor";
			this.Size = new System.Drawing.Size(544, 336);
			this.Load += new System.EventHandler(this.TextCodeEditor_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextCodeEditor_MouseDown);
			this.ResumeLayout(false);

		}


		#endregion

		private void textEditorControl_Load(object sender, System.EventArgs e)
		{
			
		}

		

		#region --[PROPIEDADES]--

		// <summary>
		/// Supported Languages.
		/// </summary>
		public  enum TipoLenguaje 
		{
			
			CSHARP=2,
			C64CHARP=3,
			CPP =4,
			HTML=5,
			JAVA=6,
			JAVASCRIPT=7,
			
			Text=9,
			VBNET=10,
			VBSCRIPT=11,
			XML=12}
																 

		private TipoLenguaje m_Lenguaje = TipoLenguaje.C64CHARP ;

		[Browsable(true),Category("Propertie"),
		Description("Texto enriqucido del control text code editor.-"),
		 System.ComponentModel.DesignOnly(false)]
		public override string Text
		{
			set
			{
				textEditorControl.Refresh();
				textEditorControl.Document.TextContent = value;
//				ICSharpCode.TextEditor.TextAreaControl ta = new TextAreaControl (textEditorControl);
//				textEditorControl.Document.FormattingStrategy.IndentLines(ta.TextArea,0,textEditorControl.Document.TotalNumberOfLines-1);
				IndentLines();
				
			}
			get
			{
				textEditorControl.Refresh();
				return textEditorControl.Document.TextBufferStrategy.GetText(0, textEditorControl.Document.TextLength);
			}
		}

	
		[Browsable(true),Category("Propertie"),
		Description("Titulo del text code editor"),
		Bindable(true)]
		public string TitleText
		{
			get{return lblTitle.Text;}
			set{lblTitle.Text = value;}
		}


		[Browsable(true),Category("Propertie"),
		Description("Determina si se muestra el titulo del control"),
		Bindable(true)]
		public bool TitleVisible
		{
			get{return lblTitle.Visible ;}
			set
			{
				int X = 0, Y = 16;
				if(value) //Visible
				{
					Y = 16;
					
				}
				else//No Visible
				{
					Y = 0;
					
				}
				System.Drawing.Point p = new Point (X,Y);
				textEditorControl.Location = p; //lblTitle.Height + 2;
				lblTitle.Visible = value;
			}
		}


		[Browsable(true),Category("Propertie"),
		Description("Lenguaje de formato para el texto.-"),
		Bindable(true)]
		public  TipoLenguaje Lenguaje
	
		{
			get	{return m_Lenguaje;}
			set
			{
				m_Lenguaje = value;
				SetLenguaje();
			}
		}
	
		
 
		#endregion

		#region --[METODOS]--
		
		private void InitializeTextEditor()
		{
			
			string s = "public void MiMetodo() ";
			s += Environment.NewLine;
			s += "{strng msg = \" Texto solo para Prueba \"";
			s += Environment.NewLine;
			s += "{ if(msg != string.Empty)";
			s += Environment.NewLine;
			s +="  foreach ";

			textEditorControl.Document.TextContent  = s;

			//SetLenguaje();
			
		
		}

		private void SetLenguaje()
		{
			switch (m_Lenguaje)
			{
				case TipoLenguaje.Text:
				{break;}

				case TipoLenguaje.CSHARP: case TipoLenguaje.C64CHARP:
				{

					ICSharpCode.TextEditor.Document.IFormattingStrategy  oFormatting = 
						new CSharpBinding.FormattingStrategy.CSharpFormattingStrategy();
					textEditorControl.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
					textEditorControl.Document.FormattingStrategy = oFormatting;
					//oFormatting.Document = textEditorControl.Document;
					break;
				}
				case TipoLenguaje.VBNET: case TipoLenguaje.VBSCRIPT:
				{
					ICSharpCode.TextEditor.Document.IFormattingStrategy  oFormatting = 
						new VBBinding.FormattingStrategy.VBFormattingStrategy ();
					textEditorControl.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("VBNET");
					textEditorControl.Document.FormattingStrategy = oFormatting;
					break;
				}
				case TipoLenguaje.CPP: 
				{
					ICSharpCode.TextEditor.Document.IFormattingStrategy  oFormatting = 
						new CPPBinding.FormattingStrategy.CSharpFormattingStrategy ();
					textEditorControl.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C++.NET");
					textEditorControl.Document.FormattingStrategy = oFormatting;
					break;
				}
				case TipoLenguaje.JAVA: case TipoLenguaje.JAVASCRIPT:
				{
					ICSharpCode.TextEditor.Document.IFormattingStrategy  oFormatting = 
						new JavaBinding.FormattingStrategy.JavaFormattingStrategy ();
					textEditorControl.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("Java");
					textEditorControl.Document.FormattingStrategy = oFormatting;
					
					break;
				}
			}
		}
	

		private void IndentLines()
		{
			ICSharpCode.TextEditor.TextAreaControl ta = new TextAreaControl (textEditorControl);
			switch (m_Lenguaje)
			{
				case TipoLenguaje.Text:
				{break;}

				case TipoLenguaje.CSHARP: case TipoLenguaje.C64CHARP:
				{
					
					CSharpBinding.FormattingStrategy.CSharpFormattingStrategy Formating  = new CSharpBinding.FormattingStrategy.CSharpFormattingStrategy ();
					Formating.IndentLines(ta.TextArea,0,textEditorControl.Document.TotalNumberOfLines-1);
					break;
				}
				case TipoLenguaje.VBNET: case TipoLenguaje.VBSCRIPT:
				{
					VBBinding.FormattingStrategy.VBFormattingStrategy Formating = new VBBinding.FormattingStrategy.VBFormattingStrategy ();
					Formating.IndentLines(ta.TextArea,0,textEditorControl.Document.TotalNumberOfLines-1);
					break;
				}
				case TipoLenguaje.CPP: 
				{
					CPPBinding.FormattingStrategy.CSharpFormattingStrategy Formating  = new CPPBinding.FormattingStrategy.CSharpFormattingStrategy ();
					Formating.IndentLines(ta.TextArea,0,textEditorControl.Document.TotalNumberOfLines-1);
					break;
				}
				case TipoLenguaje.JAVA: case TipoLenguaje.JAVASCRIPT:
				{
					JavaBinding.FormattingStrategy.JavaFormattingStrategy  Formating  = new JavaBinding.FormattingStrategy.JavaFormattingStrategy ();
					Formating.IndentLines(ta.TextArea,0,textEditorControl.Document.TotalNumberOfLines-1);
					break;
				}
			}
			
		}
		#endregion

		#region --[EVENTOS]--
		

		

		
		#endregion

	

		private void textEditorControl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				System.Drawing.Point wPoint = new Point (e.X,e.Y);
				Menu.Show(this,wPoint);
			}
		}

		
		private void TextCodeEditor_Load(object sender, System.EventArgs e)
		{
		
		}

		private void TextCodeEditor_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				System.Drawing.Point wPoint = new Point (e.X,e.Y);
				Menu.Show(this,wPoint);
			}
		}

		private void textEditorControl_Changed(object sender, System.EventArgs e)
		{
		
			
		}


		#region --[Menu]--
		private void Menu_Popup(object sender, System.EventArgs e)
		{
			
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			m_Lenguaje = TipoLenguaje.CPP; 
			SetLenguaje();
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			m_Lenguaje = TipoLenguaje.C64CHARP; 
			SetLenguaje();
		}

		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			m_Lenguaje = TipoLenguaje.VBNET; 
			SetLenguaje();
		}

		private void menuItem13_Click(object sender, System.EventArgs e)
		{
			m_Lenguaje = TipoLenguaje.VBSCRIPT; 
			SetLenguaje();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			m_Lenguaje = TipoLenguaje.XML; 
			SetLenguaje();
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			m_Lenguaje = TipoLenguaje.CPP; 
			SetLenguaje();
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			m_Lenguaje = TipoLenguaje.JAVA; 
			SetLenguaje();
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			m_Lenguaje = TipoLenguaje.JAVASCRIPT; 
			SetLenguaje();
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			m_Lenguaje = TipoLenguaje.HTML; 
			SetLenguaje();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			m_Lenguaje = TipoLenguaje.Text; 
			SetLenguaje();
		}
		#endregion
	}
}
