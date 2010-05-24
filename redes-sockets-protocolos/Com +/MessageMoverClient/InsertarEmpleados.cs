using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PelsoftComponent;
using System.Xml;

namespace MessageMoverClient
{
	/// <summary>
	/// Summary description for InsertarEmpleados.
	/// </summary>
	public class InsertarEmpleados : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.TextBox txtEmployeeID;
		private System.Windows.Forms.TextBox txtEmployeeName;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button moveSucceeds;
		private System.Windows.Forms.TextBox txtXmlEmpleado;
		private System.Windows.Forms.Button button2;
		private Helper wHelper= new Helper ();
		private System.Windows.Forms.TextBox lblOrigenCount;
		private System.Windows.Forms.Label lblDestino;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtLastName;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public InsertarEmpleados()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new InsertarEmpleados());
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtLastName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.txtEmployeeID = new System.Windows.Forms.TextBox();
			this.txtEmployeeName = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.moveSucceeds = new System.Windows.Forms.Button();
			this.txtXmlEmpleado = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.lblOrigenCount = new System.Windows.Forms.TextBox();
			this.lblDestino = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtLastName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtTitle);
			this.groupBox1.Controls.Add(this.txtEmployeeID);
			this.groupBox1.Controls.Add(this.txtEmployeeName);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.SteelBlue;
			this.groupBox1.Location = new System.Drawing.Point(16, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 152);
			this.groupBox1.TabIndex = 25;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Datos Empleado";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 33;
			this.label2.Text = "Apellido";
			// 
			// txtLastName
			// 
			this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtLastName.BackColor = System.Drawing.Color.FloralWhite;
			this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtLastName.Location = new System.Drawing.Point(88, 88);
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.Size = new System.Drawing.Size(120, 20);
			this.txtLastName.TabIndex = 2;
			this.txtLastName.Text = "";
			this.txtLastName.Leave += new System.EventHandler(this.txtLastName_Leave);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 31;
			this.label1.Text = "IdEmpleado";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(46, 14);
			this.label5.TabIndex = 30;
			this.label5.Text = "Title";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 29;
			this.label4.Text = "Nombre";
			// 
			// txtTitle
			// 
			this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtTitle.BackColor = System.Drawing.Color.FloralWhite;
			this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTitle.Location = new System.Drawing.Point(88, 120);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(120, 20);
			this.txtTitle.TabIndex = 3;
			this.txtTitle.Text = "";
			this.txtTitle.Leave += new System.EventHandler(this.txtTitle_Leave);
			// 
			// txtEmployeeID
			// 
			this.txtEmployeeID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtEmployeeID.BackColor = System.Drawing.Color.FloralWhite;
			this.txtEmployeeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtEmployeeID.Location = new System.Drawing.Point(88, 24);
			this.txtEmployeeID.Name = "txtEmployeeID";
			this.txtEmployeeID.Size = new System.Drawing.Size(120, 20);
			this.txtEmployeeID.TabIndex = 0;
			this.txtEmployeeID.Text = "";
			this.txtEmployeeID.TextChanged += new System.EventHandler(this.txtEmployeeID_TextChanged);
			this.txtEmployeeID.Leave += new System.EventHandler(this.txtEmployeeID_Leave);
			// 
			// txtEmployeeName
			// 
			this.txtEmployeeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtEmployeeName.BackColor = System.Drawing.Color.FloralWhite;
			this.txtEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtEmployeeName.Location = new System.Drawing.Point(88, 56);
			this.txtEmployeeName.Name = "txtEmployeeName";
			this.txtEmployeeName.Size = new System.Drawing.Size(120, 20);
			this.txtEmployeeName.TabIndex = 1;
			this.txtEmployeeName.Text = "";
			this.txtEmployeeName.Leave += new System.EventHandler(this.txtEmployeeName_Leave);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.AliceBlue;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.SteelBlue;
			this.button1.Location = new System.Drawing.Point(288, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(144, 23);
			this.button1.TabIndex = 27;
			this.button1.Text = "Extraer de Cola Origen";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// moveSucceeds
			// 
			this.moveSucceeds.BackColor = System.Drawing.Color.AliceBlue;
			this.moveSucceeds.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.moveSucceeds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.moveSucceeds.ForeColor = System.Drawing.Color.SteelBlue;
			this.moveSucceeds.Location = new System.Drawing.Point(16, 208);
			this.moveSucceeds.Name = "moveSucceeds";
			this.moveSucceeds.Size = new System.Drawing.Size(144, 23);
			this.moveSucceeds.TabIndex = 26;
			this.moveSucceeds.Text = "Insertar en Cola Origen";
			this.moveSucceeds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.moveSucceeds.Click += new System.EventHandler(this.moveSucceeds_Click);
			// 
			// txtXmlEmpleado
			// 
			this.txtXmlEmpleado.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.txtXmlEmpleado.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtXmlEmpleado.Location = new System.Drawing.Point(0, 245);
			this.txtXmlEmpleado.Multiline = true;
			this.txtXmlEmpleado.Name = "txtXmlEmpleado";
			this.txtXmlEmpleado.Size = new System.Drawing.Size(832, 416);
			this.txtXmlEmpleado.TabIndex = 28;
			this.txtXmlEmpleado.Text = "";
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.AliceBlue;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button2.ForeColor = System.Drawing.Color.SteelBlue;
			this.button2.Location = new System.Drawing.Point(168, 208);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(152, 23);
			this.button2.TabIndex = 29;
			this.button2.Text = "Insertar Base De Datos";
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// lblOrigenCount
			// 
			this.lblOrigenCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblOrigenCount.Location = new System.Drawing.Point(800, 8);
			this.lblOrigenCount.Multiline = true;
			this.lblOrigenCount.Name = "lblOrigenCount";
			this.lblOrigenCount.Size = new System.Drawing.Size(24, 16);
			this.lblOrigenCount.TabIndex = 32;
			this.lblOrigenCount.Text = "";
			// 
			// lblDestino
			// 
			this.lblDestino.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lblDestino.Location = new System.Drawing.Point(680, 8);
			this.lblDestino.Name = "lblDestino";
			this.lblDestino.Size = new System.Drawing.Size(112, 14);
			this.lblDestino.TabIndex = 31;
			this.lblDestino.Text = "Elementos en Origen";
			// 
			// InsertarEmpleados
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(832, 661);
			this.Controls.Add(this.lblOrigenCount);
			this.Controls.Add(this.lblDestino);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.txtXmlEmpleado);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.moveSucceeds);
			this.Controls.Add(this.groupBox1);
			this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.Name = "InsertarEmpleados";
			this.Text = "InsertarEmpleados";
			this.Load += new System.EventHandler(this.InsertarEmpleados_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void InsertarEmpleados_Load(object sender, System.EventArgs e)
		{
		
		}

		private void moveSucceeds_Click(object sender, System.EventArgs e)
		{
			wHelper.InsertIntoQueue(Helper.QUEUE_PATCHS.RUTA_COLA_ORIGEN,txtXmlEmpleado.Text);
			
			MessageBox.Show("Listo andó de luxe mono");
			CheckCounts();
		}

		private void txtEmployeeID_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void CheckCounts()
		{
		 //lblDestinoCount.Text = wHelper.GetQueeuElementsCount(Helper.QUEUE_PATCHS.RUTA_COLA_DESTINO).ToString();
		 lblOrigenCount.Text = wHelper.GetQueeuElementsCount(Helper.QUEUE_PATCHS.RUTA_COLA_ORIGEN).ToString();
		}
		private void txtEmployeeID_Leave(object sender, System.EventArgs e)
		{
				SetearEmppledoFromControles();
		
		}
		private void SetearEmppledoFromControles()
		{
			Employee emp = new Employee ();

			//Muestro los datos del objeto Deserializado
			emp.FirstName = txtEmployeeName.Text;
			emp.LastName = txtLastName.Text;
			emp.Id = txtEmployeeID.Text;
			emp.Title = txtTitle.Text;
						
			txtXmlEmpleado.Text = wHelper.SerealizeToXML(emp);

		}

		private void label5_Click(object sender, System.EventArgs e)
		{
		
		}

		private void txtEmployeeName_Leave(object sender, System.EventArgs e)
		{
			SetearEmppledoFromControles();
		}

		private void txtLastName_Leave(object sender, System.EventArgs e)
		{
			SetearEmppledoFromControles();
		}

		private void txtTitle_Leave(object sender, System.EventArgs e)
		{
			SetearEmppledoFromControles();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			PelsoftComponentTransac wPelsoftComponentTransac = new PelsoftComponentTransac ();
			wPelsoftComponentTransac.CrearEmpleado (txtXmlEmpleado.Text);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				
				txtXmlEmpleado.Text = wHelper.ExtractFromQueue(Helper.QUEUE_PATCHS.RUTA_COLA_ORIGEN);
				CheckCounts();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}
	}
}
