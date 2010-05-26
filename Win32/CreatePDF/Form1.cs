using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using PDFCreate;

namespace EjemplosCreatePDF
{
	/// <summary>
	/// Descripción breve de Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.RichTextBox rh1;
		private System.Windows.Forms.Button btCrearPDF;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
			InitializeComponent();

			//
			// TODO: Agregar código de constructor después de llamar a InitializeComponent
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Método necesario para admitir el Diseñador, no se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.rh1 = new System.Windows.Forms.RichTextBox();
			this.btCrearPDF = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// rh1
			// 
			this.rh1.Name = "rh1";
			this.rh1.Size = new System.Drawing.Size(352, 272);
			this.rh1.TabIndex = 0;
			this.rh1.Text = "Escribe aquí";
			// 
			// btCrearPDF
			// 
			this.btCrearPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btCrearPDF.Location = new System.Drawing.Point(72, 280);
			this.btCrearPDF.Name = "btCrearPDF";
			this.btCrearPDF.Size = new System.Drawing.Size(200, 23);
			this.btCrearPDF.TabIndex = 1;
			this.btCrearPDF.Text = "&Crear PDF";
			this.btCrearPDF.Click += new System.EventHandler(this.btCrearPDF_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(354, 314);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btCrearPDF,
																		  this.rh1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Punto de entrada principal de la aplicación.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void btCrearPDF_Click(object sender, System.EventArgs e)
		{
			//Creamos  una instancia del objeto NewPDF
			NewPDF docpdf = new NewPDF("./ejemplo.pdf");
			//El parametro hace referencia al path de destino del documento
			docpdf.Create();
			//Se crea instancia al documento, si se usa CreateNew y el archivo existe provocará un error que tendríamos que cachear
			docpdf.AddCabecera("Ejemplo de como usar CreatePDF para programadores .NET",true);
			//insertamos la cabecera con borde
			docpdf.AddPiePagina("Página nº:",false);
			//insertamos el pie de página sin borde
			docpdf.AddCapitulo("Texto con formato",NewPDF.TipoFuente.Times_Cursiva,10,NewPDF.TipoColor.Azul,"Como usar CreatePDF para insertar Texto con formato",NewPDF.TipoColor.Rojo,10);
			//insertamos el capítulo,tiene 4 sobrecargas se ha usado la más completa(insercion de capitulo con formato de texto y una seccion)
			
			docpdf.AddTexto("\nEsto es AddText(string Texto).Introduce texto sin formato ni color específicos");
			docpdf.AddTexto("\u2022 Ahora con los formatos de letra \u2022");
			docpdf.AddTexto(" Texto en Helvetica tamaño 12 y color negro",12,NewPDF.TipoFuente.Helvetica,NewPDF.TipoColor.Negro);
			docpdf.AddTexto(" Texto en Helvetica cursiva  tamaño 12 y color negro",12,NewPDF.TipoFuente.Helvetica_Cursiva,NewPDF.TipoColor.Negro);
			docpdf.AddTexto(" Texto en Helvetica negrita tamaño 12 y color negro",12,NewPDF.TipoFuente.Helvetica_Negrita ,NewPDF.TipoColor.Negro);
			docpdf.AddTexto(" Texto en Courier tamaño 12 y color negro",12,NewPDF.TipoFuente.Courier ,NewPDF.TipoColor.Negro);
			docpdf.AddTexto(" Texto en Courier Cursiva tamaño 12 y color negro",12,NewPDF.TipoFuente.Courier_Cursiva,NewPDF.TipoColor.Negro);
			docpdf.AddTexto(" Texto en Courier negrita tamaño 12 y color negro",12,NewPDF.TipoFuente.Courier_Negrita,NewPDF.TipoColor.Negro);
			docpdf.AddTexto(" Texto en Times tamaño 12 y color negro",12,NewPDF.TipoFuente.Times  ,NewPDF.TipoColor.Negro);
			docpdf.AddTexto(" Texto en Times cursiva tamaño 12 y color negro",12,NewPDF.TipoFuente.Times_Cursiva,NewPDF.TipoColor.Negro);
			docpdf.AddTexto(" Texto en Times negrita tamaño 12 y color negro",12,NewPDF.TipoFuente.Times_Negrita,NewPDF.TipoColor.Negro);
			docpdf.AddTexto(" Texto en Times_NEW_ROMAN tamaño 12 y color negro",12,NewPDF.TipoFuente.Times_New_Roman,NewPDF.TipoColor.Negro);
			docpdf.NuevaPagina();
			//insertamos una nueva página
			docpdf.AddCapitulo("Inserción de tablas y Listas",NewPDF.TipoFuente.Times_Cursiva,10,NewPDF.TipoColor.Azul,"Ejemplo insertar tablas y listas",NewPDF.TipoColor.Rojo,10);
			//insertamos otro capítulo
			docpdf.AddTexto("\n Tabla");
			string[] valores = new String[4];
			valores[0] = "Valor 1";
			valores[1] = "Valor 2";
			valores[2] = "Valor 3";
			valores[3] = "Valor 4";
			docpdf.AddTabla(2,2,valores);
			//insercion de una tabla tb 4 sobrecargas
			docpdf.AddTexto("Lista ordenada");
			//insercion de lista ordenada
			docpdf.AddLista(true,4,valores,"\u2022");
			docpdf.AddTexto("Lista no ordenada");
			//insercion de lista desordenada
			docpdf.AddLista(false,4,valores,"\u2022");
			docpdf.NuevaPagina();
			docpdf.AddCapitulo("Inserción de Imagenes y Links",NewPDF.TipoFuente.Times_Cursiva,10,NewPDF.TipoColor.Azul,"Como usar CreatePDF para insertar imagenes y WebLinks",NewPDF.TipoColor.Rojo,10);
			docpdf.AddTexto("\n");
			docpdf.AddEnlaceWeb("Enlace a google","http://www.google.com","Google");
			docpdf.AddTexto("\n");
			docpdf.AddImagen("tourlogo.gif",NewPDF.AlineacionImagen.Centrado,".NET","CreatePDF es un PE para programadores .NET.By Unai Zorrilla Castro 'molotess'");
			docpdf.NuevaPagina();
			docpdf.AddCapitulo("Inserción del texto del RichBoxText",NewPDF.TipoFuente.Times_Cursiva,10,NewPDF.TipoColor.Azul,"Como usar CreatePDF para insertar texto de un RichBoxText y similares",NewPDF.TipoColor.Rojo,10);
			docpdf.AddTexto(rh1.Text,14,NewPDF.TipoFuente.Times_New_Roman,NewPDF.TipoColor.Verde);
			docpdf.Dispose();
			MessageBox.Show("Documento Creado");
			//La  no implementacion de Dispose provocará un error de lectura en el documento -->("Mejora en construccion")
		
		}
	}
}
