using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Test
{
	/// <summary>
	/// Descripción breve de Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Pelsoft.Controls.TextCodeEditor.TextCodeEditor textCodeEditor1;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
			InitializeComponent();

			//
			// TODO: agregar código de constructor después de llamar a InitializeComponent
			//
		}

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.textCodeEditor1 = new Pelsoft.Controls.TextCodeEditor.TextCodeEditor();
			this.SuspendLayout();
			// 
			// textCodeEditor1
			// 
			this.textCodeEditor1.BackColor = System.Drawing.Color.Silver;
			this.textCodeEditor1.Lenguaje = Pelsoft.Controls.TextCodeEditor.TextCodeEditor.TipoLenguaje.C64CHARP;
			this.textCodeEditor1.Location = new System.Drawing.Point(0, 0);
			this.textCodeEditor1.Name = "textCodeEditor1";
			this.textCodeEditor1.Size = new System.Drawing.Size(544, 336);
			this.textCodeEditor1.TabIndex = 0;
			this.textCodeEditor1.TitleText = "";
			this.textCodeEditor1.TitleVisible = true;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 358);
			this.Controls.Add(this.textCodeEditor1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Punto de entrada principal de la aplicación.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
