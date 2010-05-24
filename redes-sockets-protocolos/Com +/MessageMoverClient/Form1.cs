using System;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using PelsoftComponent;


namespace MessageMoverClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button moveSucceeds;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtXmlMessage;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox txtEmployeeID;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtEmployeeName;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.DataGrid dataGridEmpleado;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblDestinoCount;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox lblOrigenCount;
		
	private Helper wHelper = null;
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			CheckCounts();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			wHelper = new Helper ();

			this.moveSucceeds = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.txtXmlMessage = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.txtEmployeeName = new System.Windows.Forms.TextBox();
			this.txtEmployeeID = new System.Windows.Forms.TextBox();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.dataGridEmpleado = new System.Windows.Forms.DataGrid();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lblOrigenCount = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lblDestinoCount = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridEmpleado)).BeginInit();
			this.SuspendLayout();
			// 
			// moveSucceeds
			// 
			this.moveSucceeds.BackColor = System.Drawing.Color.LightSteelBlue;
			this.moveSucceeds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.moveSucceeds.ForeColor = System.Drawing.Color.Maroon;
			this.moveSucceeds.Location = new System.Drawing.Point(0, 8);
			this.moveSucceeds.Name = "moveSucceeds";
			this.moveSucceeds.Size = new System.Drawing.Size(136, 23);
			this.moveSucceeds.TabIndex = 0;
			this.moveSucceeds.Text = "Insertar en Cola Origen";
			this.moveSucceeds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.moveSucceeds.Click += new System.EventHandler(this.moveSucceeds_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(0, 40);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(136, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Extraer de Cola Origen";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtXmlMessage
			// 
			this.txtXmlMessage.Location = new System.Drawing.Point(232, 152);
			this.txtXmlMessage.Multiline = true;
			this.txtXmlMessage.Name = "txtXmlMessage";
			this.txtXmlMessage.Size = new System.Drawing.Size(656, 168);
			this.txtXmlMessage.TabIndex = 5;
			this.txtXmlMessage.Text = "";
			this.txtXmlMessage.TextChanged += new System.EventHandler(this.txtXmlMessage_TextChanged);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.SlateGray;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.ForeColor = System.Drawing.Color.White;
			this.button2.Location = new System.Drawing.Point(0, 120);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(232, 23);
			this.button2.TabIndex = 9;
			this.button2.Text = "Serializar Empleado e Inserta en DESTINO";
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.AccessibleDescription = "EFSDF";
			this.button3.BackColor = System.Drawing.Color.SlateGray;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button3.ForeColor = System.Drawing.Color.White;
			this.button3.Location = new System.Drawing.Point(0, 88);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(232, 24);
			this.button3.TabIndex = 10;
			this.button3.Text = "Deserialize Empleado de la cola DESTINO";
			this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(8, 336);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(176, 23);
			this.button4.TabIndex = 11;
			this.button4.Text = "Crear Empleado";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// txtEmployeeName
			// 
			this.txtEmployeeName.Location = new System.Drawing.Point(64, 240);
			this.txtEmployeeName.Name = "txtEmployeeName";
			this.txtEmployeeName.Size = new System.Drawing.Size(104, 20);
			this.txtEmployeeName.TabIndex = 12;
			this.txtEmployeeName.Text = "";
			// 
			// txtEmployeeID
			// 
			this.txtEmployeeID.Location = new System.Drawing.Point(64, 208);
			this.txtEmployeeID.Name = "txtEmployeeID";
			this.txtEmployeeID.Size = new System.Drawing.Size(104, 20);
			this.txtEmployeeID.TabIndex = 13;
			this.txtEmployeeID.Text = "";
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(64, 264);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(104, 20);
			this.txtTitle.TabIndex = 14;
			this.txtTitle.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 272);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(24, 16);
			this.label3.TabIndex = 15;
			this.label3.Text = "Id";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 240);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 16;
			this.label4.Text = "Name";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 272);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 14);
			this.label5.TabIndex = 17;
			this.label5.Text = "Title";
			// 
			// dataGridEmpleado
			// 
			this.dataGridEmpleado.DataMember = "";
			this.dataGridEmpleado.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridEmpleado.Location = new System.Drawing.Point(232, 328);
			this.dataGridEmpleado.Name = "dataGridEmpleado";
			this.dataGridEmpleado.Size = new System.Drawing.Size(656, 200);
			this.dataGridEmpleado.TabIndex = 18;
			// 
			// button5
			// 
			this.button5.BackColor = System.Drawing.Color.LightSteelBlue;
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button5.Location = new System.Drawing.Point(208, 40);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(136, 23);
			this.button5.TabIndex = 20;
			this.button5.Text = "Extraer de Cola Destino";
			this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.BackColor = System.Drawing.Color.LightSteelBlue;
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button6.ForeColor = System.Drawing.Color.Maroon;
			this.button6.Location = new System.Drawing.Point(208, 8);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(136, 23);
			this.button6.TabIndex = 19;
			this.button6.Text = "Insertar en Cola Destino";
			this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button7
			// 
			this.button7.BackColor = System.Drawing.Color.LightSteelBlue;
			this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button7.ForeColor = System.Drawing.Color.Maroon;
			this.button7.Location = new System.Drawing.Point(408, 8);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(136, 23);
			this.button7.TabIndex = 21;
			this.button7.Text = "Mover de Origen a Destino";
			this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label1.Location = new System.Drawing.Point(0, 512);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 14);
			this.label1.TabIndex = 23;
			this.label1.Text = "Elementos en Destino";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// lblOrigenCount
			// 
			this.lblOrigenCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblOrigenCount.Location = new System.Drawing.Point(120, 488);
			this.lblOrigenCount.Multiline = true;
			this.lblOrigenCount.Name = "lblOrigenCount";
			this.lblOrigenCount.Size = new System.Drawing.Size(24, 16);
			this.lblOrigenCount.TabIndex = 26;
			this.lblOrigenCount.Text = "";
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label2.Location = new System.Drawing.Point(0, 488);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 14);
			this.label2.TabIndex = 25;
			this.label2.Text = "Elementos en Origen";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// lblDestinoCount
			// 
			this.lblDestinoCount.BackColor = System.Drawing.Color.AliceBlue;
			this.lblDestinoCount.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lblDestinoCount.Location = new System.Drawing.Point(120, 512);
			this.lblDestinoCount.Name = "lblDestinoCount";
			this.lblDestinoCount.Size = new System.Drawing.Size(24, 16);
			this.lblDestinoCount.TabIndex = 27;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.AliceBlue;
			this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label6.Location = new System.Drawing.Point(436, 258);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(24, 16);
			this.label6.TabIndex = 28;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(896, 533);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.lblDestinoCount);
			this.Controls.Add(this.lblOrigenCount);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.dataGridEmpleado);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtTitle);
			this.Controls.Add(this.txtEmployeeID);
			this.Controls.Add(this.txtEmployeeName);
			this.Controls.Add(this.txtXmlMessage);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.moveSucceeds);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridEmpleado)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void moveSucceeds_Click(object sender, System.EventArgs e)
		{
			try
			{
				wHelper.InsertIntoQueue(Helper.QUEUE_PATCHS.RUTA_COLA_ORIGEN,txtXmlMessage.Text);
			
				MessageBox.Show("Listo andó de luxe mono");
				CheckCounts();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				
				MessageBox.Show(wHelper.ExtractFromQueue(Helper.QUEUE_PATCHS.RUTA_COLA_ORIGEN));
				CheckCounts();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			
			string ruta = AppDomain.CurrentDomain.BaseDirectory + @"..\..\Empleado.xml";

			StreamReader sr = new StreamReader(ruta);

			Employee m_Empleado =   wHelper.DeserializeEmpleado(sr.ReadToEnd ());


			try
			{
				string strEmpleado = wHelper.SerealizeToXML(m_Empleado);
			
				wHelper.InsertIntoQueue(Helper.QUEUE_PATCHS.RUTA_COLA_ORIGEN,strEmpleado);

				wHelper.MoveOrigenToDestino();

				txtXmlMessage.Text = strEmpleado;
				dataGridEmpleado.DataSource = wHelper.SerealizeToDataSet(m_Empleado);
	
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
			}

		}

		
		

		

		/// <summary>
		/// Deserialize Empleado: Creaa un Objeto Empleado apartir del xml almacenado en la cola
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button3_Click(object sender, System.EventArgs e)
		{
			XmlDocument xmlDoc = new XmlDocument ();
			
			try
			{
			
				string xmlEmpleado =wHelper.ExtractFromQueue(Helper.QUEUE_PATCHS.RUTA_COLA_DESTINO);
				xmlDoc.LoadXml(xmlEmpleado);
	
				//creo el empleado deserializandolo
				Employee t = wHelper.DeserializeEmpleado(xmlDoc.OuterXml);

				//Muestro los datos del objeto Deserializado
				txtEmployeeName.Text = t.LastName +", " + t.FirstName;
				txtEmployeeID.Text += t.Id;
				txtTitle.Text += t.Title;

				txtXmlMessage.Text = xmlEmpleado;

				CheckCounts();
				
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			PelsoftComponentTransac wPelsoftComponentTransac = new PelsoftComponentTransac ();
			wPelsoftComponentTransac.CrearEmpleado (txtXmlMessage.Text);
		}

		private void txtXmlMessage_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			try
			{
				wHelper.InsertIntoQueue(Helper.QUEUE_PATCHS.RUTA_COLA_DESTINO,txtXmlMessage.Text);
			
				MessageBox.Show("Listo andó de luxe mono");
				CheckCounts();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			try
			{
				
				MessageBox.Show(wHelper.ExtractFromQueue(Helper.QUEUE_PATCHS.RUTA_COLA_DESTINO));
				CheckCounts();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			try
			{
				wHelper.MoveOrigenToDestino();
				CheckCounts();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
			lblDestinoCount.Text = wHelper.GetQueeuElementsCount(Helper.QUEUE_PATCHS.RUTA_COLA_DESTINO).ToString();
		}

		private void label2_Click(object sender, System.EventArgs e)
		{
			lblOrigenCount.Text = wHelper.GetQueeuElementsCount(Helper.QUEUE_PATCHS.RUTA_COLA_ORIGEN).ToString();
		
		}


		private void CheckCounts()
		{
			lblDestinoCount.Text = wHelper.GetQueeuElementsCount(Helper.QUEUE_PATCHS.RUTA_COLA_DESTINO).ToString();
			lblOrigenCount.Text = wHelper.GetQueeuElementsCount(Helper.QUEUE_PATCHS.RUTA_COLA_ORIGEN).ToString();
		}
 
	}
}
