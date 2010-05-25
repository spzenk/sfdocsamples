using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


namespace Perioricidad
{
	/// <summary>
	/// Descripción breve de Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button ultraButton1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtFechaDesde;
		private System.Windows.Forms.TextBox txtFechaFin;
	
		
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtSetDeDias;

		private System.Windows.Forms.RadioButton radioDiaria;
		private System.Windows.Forms.RadioButton radioSemanal;
		private System.Windows.Forms.RadioButton radioMensual;
		private System.Windows.Forms.Label lblPerioricidad;
        private System.Windows.Forms.Label ultraLabel1;
		private System.Windows.Forms.TextBox txtCada;

		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCadaMensual;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox grpMensual;
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
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.BackColor = Color.Transparent;

			FillCombo();

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
		

			this.lblPerioricidad = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtFechaDesde = new System.Windows.Forms.TextBox();
			this.txtFechaFin = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioMensual = new System.Windows.Forms.RadioButton();
			this.radioSemanal = new System.Windows.Forms.RadioButton();
			this.radioDiaria = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.txtSetDeDias = new System.Windows.Forms.TextBox();
		
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();

			this.label7 = new System.Windows.Forms.Label();
			this.grpMensual = new System.Windows.Forms.GroupBox();

			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtCada)).BeginInit();
	
			((System.ComponentModel.ISupportInitialize)(this.txtCadaMensual)).BeginInit();
			this.grpMensual.SuspendLayout();
			this.SuspendLayout();
			// 
			// ultraButton1
			// 
			

			this.ultraButton1.Location = new System.Drawing.Point(440, 354);
			this.ultraButton1.Name = "ultraButton1";
			this.ultraButton1.Size = new System.Drawing.Size(106, 24);
			this.ultraButton1.TabIndex = 0;
			this.ultraButton1.Text = "Mostrar Fechas";
			this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
		
			

			// lblPerioricidad
			// 
			this.lblPerioricidad.BackColor = System.Drawing.Color.Beige;
			this.lblPerioricidad.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(22)), ((System.Byte)(82)), ((System.Byte)(139)));
			this.lblPerioricidad.Location = new System.Drawing.Point(255, 162);
			this.lblPerioricidad.Name = "lblPerioricidad";
			this.lblPerioricidad.Size = new System.Drawing.Size(73, 16);
			this.lblPerioricidad.TabIndex = 15;
			this.lblPerioricidad.Text = "Dias";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Beige;
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(22)), ((System.Byte)(82)), ((System.Byte)(139)));
			this.label3.Location = new System.Drawing.Point(131, 163);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 15);
			this.label3.TabIndex = 14;
			this.label3.Text = "Repetir Cada";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Beige;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(22)), ((System.Byte)(82)), ((System.Byte)(139)));
			this.label2.Location = new System.Drawing.Point(273, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 13;
			this.label2.Text = "Fecha Inicio";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Beige;
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(22)), ((System.Byte)(82)), ((System.Byte)(139)));
			this.label1.Location = new System.Drawing.Point(128, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 14);
			this.label1.TabIndex = 12;
			this.label1.Text = "Fecha Inicio";
			// 
			// txtFechaDesde
			// 
			this.txtFechaDesde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFechaDesde.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(22)), ((System.Byte)(82)), ((System.Byte)(139)));
			this.txtFechaDesde.Location = new System.Drawing.Point(125, 46);
			this.txtFechaDesde.Name = "txtFechaDesde";
			this.txtFechaDesde.Size = new System.Drawing.Size(134, 20);
			this.txtFechaDesde.TabIndex = 10;
			this.txtFechaDesde.Text = "10/10/2004";
			// 
			// txtFechaFin
			// 
			this.txtFechaFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFechaFin.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(22)), ((System.Byte)(82)), ((System.Byte)(139)));
			this.txtFechaFin.Location = new System.Drawing.Point(271, 46);
			this.txtFechaFin.Name = "txtFechaFin";
			this.txtFechaFin.Size = new System.Drawing.Size(134, 20);
			this.txtFechaFin.TabIndex = 9;
			this.txtFechaFin.Text = "12/12/2004";
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.Beige;
			this.groupBox2.Controls.Add(this.radioMensual);
			this.groupBox2.Controls.Add(this.radioSemanal);
			this.groupBox2.Controls.Add(this.radioDiaria);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(22)), ((System.Byte)(82)), ((System.Byte)(139)));
			this.groupBox2.Location = new System.Drawing.Point(7, 32);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(98, 97);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Frecuencia";
			// 
			// radioMensual
			// 
			this.radioMensual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.radioMensual.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(22)), ((System.Byte)(82)), ((System.Byte)(139)));
			this.radioMensual.Location = new System.Drawing.Point(8, 67);
			this.radioMensual.Name = "radioMensual";
			this.radioMensual.Size = new System.Drawing.Size(83, 15);
			this.radioMensual.TabIndex = 19;
			this.radioMensual.Text = "Mensual";
			this.radioMensual.CheckedChanged += new System.EventHandler(this.radioMensual_CheckedChanged);
			// 
			// radioSemanal
			// 
			this.radioSemanal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.radioSemanal.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(22)), ((System.Byte)(82)), ((System.Byte)(139)));
			this.radioSemanal.Location = new System.Drawing.Point(8, 43);
			this.radioSemanal.Name = "radioSemanal";
			this.radioSemanal.Size = new System.Drawing.Size(83, 15);
			this.radioSemanal.TabIndex = 18;
			this.radioSemanal.Text = "Semanal";
			this.radioSemanal.CheckedChanged += new System.EventHandler(this.radioSemanal_CheckedChanged);
			// 
			// radioDiaria
			// 
			this.radioDiaria.Checked = true;
			this.radioDiaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.radioDiaria.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(22)), ((System.Byte)(82)), ((System.Byte)(139)));
			this.radioDiaria.Location = new System.Drawing.Point(9, 19);
			this.radioDiaria.Name = "radioDiaria";
			this.radioDiaria.Size = new System.Drawing.Size(83, 15);
			this.radioDiaria.TabIndex = 17;
			this.radioDiaria.TabStop = true;
			this.radioDiaria.Text = "Diaria";
			this.radioDiaria.CheckedChanged += new System.EventHandler(this.radioDiaria_CheckedChanged);
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.LemonChiffon;
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(22)), ((System.Byte)(82)), ((System.Byte)(139)));
			this.label6.Location = new System.Drawing.Point(357, 162);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 17);
			this.label6.TabIndex = 14;
			this.label6.Text = "Set de dias";
			this.label6.Visible = false;
			// 
			// txtSetDeDias
			// 
			this.txtSetDeDias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSetDeDias.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(22)), ((System.Byte)(82)), ((System.Byte)(139)));
			this.txtSetDeDias.Location = new System.Drawing.Point(422, 157);
			this.txtSetDeDias.MaxLength = 7;
			this.txtSetDeDias.Name = "txtSetDeDias";
			this.txtSetDeDias.Size = new System.Drawing.Size(53, 20);
			this.txtSetDeDias.TabIndex = 11;
			this.txtSetDeDias.Text = "1000010";
			this.txtSetDeDias.Visible = false;
			
			this.ultraLabel1.Location = new System.Drawing.Point(126, 72);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(279, 4);
			this.ultraLabel1.TabIndex = 16;
			// 
			// txtCada
			// 
		
	
			this.txtCada.Location = new System.Drawing.Point(199, 158);
			
			
			this.txtCada.Name = "txtCada";
			
			this.txtCada.Size = new System.Drawing.Size(53, 19);
			
			this.txtCada.TabIndex = 17;
		

			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Beige;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(22)), ((System.Byte)(82)), ((System.Byte)(139)));
			this.label4.Location = new System.Drawing.Point(7, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(17, 16);
			this.label4.TabIndex = 20;
			this.label4.Text = "El";
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.LemonChiffon;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(22)), ((System.Byte)(82)), ((System.Byte)(139)));
			this.label5.Location = new System.Drawing.Point(230, 31);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(39, 16);
			this.label5.TabIndex = 21;
			this.label5.Text = ", cada";
			// 
			// txtCadaMensual
			// 
		
			this.txtCadaMensual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtCadaMensual.Location = new System.Drawing.Point(271, 28);
			
			this.txtCadaMensual.Name = "txtCadaMensual";
			
			this.txtCadaMensual.Size = new System.Drawing.Size(53, 19);
		
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.LemonChiffon;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(22)), ((System.Byte)(82)), ((System.Byte)(139)));
			this.label7.Location = new System.Drawing.Point(329, 31);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(42, 16);
			this.label7.TabIndex = 22;
			this.label7.Text = "meses";
			// 
			// grpMensual
			// 
			this.grpMensual.BackColor = System.Drawing.Color.LemonChiffon;
			this.grpMensual.Controls.Add(this.label5);
			this.grpMensual.Controls.Add(this.txtCadaMensual);
			this.grpMensual.Controls.Add(this.label7);
			this.grpMensual.Controls.Add(this.label4);

			this.grpMensual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpMensual.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(22)), ((System.Byte)(82)), ((System.Byte)(139)));
			this.grpMensual.Location = new System.Drawing.Point(112, 134);
			this.grpMensual.Name = "grpMensual";
			this.grpMensual.Size = new System.Drawing.Size(390, 70);
			this.grpMensual.TabIndex = 24;
			this.grpMensual.TabStop = false;
			this.grpMensual.Text = "Mensual";
			this.grpMensual.Visible = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ClientSize = new System.Drawing.Size(778, 386);
			this.Controls.Add(this.grpMensual);
			this.Controls.Add(this.txtCada);
			this.Controls.Add(this.ultraLabel1);
			this.Controls.Add(this.txtSetDeDias);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.groupBox2);
		
			this.Controls.Add(this.ultraButton1);
			this.Controls.Add(this.txtFechaDesde);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtFechaFin);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblPerioricidad);
			
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Perioricidad";
			this.Load += new System.EventHandler(this.Form1_Load);
	
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtCada)).EndInit();
		
			((System.ComponentModel.ISupportInitialize)(this.txtCadaMensual)).EndInit();
			this.grpMensual.ResumeLayout(false);
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

		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			DataTable oDts = new DataTable ();

			if (radioDiaria.Checked ) oDts = GetDiaCada(Convert.ToDateTime (txtFechaDesde.Text),Convert.ToDateTime (txtFechaFin.Text),Convert.ToDouble(txtCada.Text)); 
			if (radioSemanal.Checked ) oDts = this.GetSemanaCada(Convert.ToDateTime (txtFechaDesde.Text),Convert.ToDateTime (txtFechaFin.Text),Convert.ToDouble(txtCada.Text),txtSetDeDias.Text );  
			if (radioMensual.Checked )
			{
                //int wOrden = Convert.ToInt32 (cmbOrden.Items [cmbOrden.SelectedIndex ].DataValue );
                //DayOfWeek wDia =   (DayOfWeek)(cmbSelectOption.Items[cmbSelectOption.SelectedIndex ].DataValue);

                //oDts = this.GetMesOrden(Convert.ToDateTime (txtFechaDesde.Text),Convert.ToDateTime (txtFechaFin.Text),Convert.ToInt32(txtCadaMensual.Value ) ,wDia,wOrden);  
			}
			FillGrid(oDts);
		}
		
		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void radioDiaria_CheckedChanged(object sender, System.EventArgs e)
		{
			lblPerioricidad.Text = "Dias";
			label6.Visible = false;
			txtSetDeDias.Visible = false;

			label3.Visible = true ;
			txtCada.Visible = true;
			lblPerioricidad.Visible = true;
			label6.Visible = true;
			txtSetDeDias.Visible = true;

			grpMensual.Visible =false;
		
		}

		private void radioSemanal_CheckedChanged(object sender, System.EventArgs e)
		{
			lblPerioricidad.Text = "Semanas el";
			label6.Visible = true;
			txtSetDeDias.Visible = true;

			label3.Visible = true ;
			txtCada.Visible = true;
			lblPerioricidad.Visible = true;
			label6.Visible = true;
			txtSetDeDias.Visible = true;

			grpMensual.Visible =false;
//			label4.Visible = false;
//			cmbOrden.Visible = false;
//			cmbSelectOption.Visible = false;
//			label5.Visible = false;
//			txtCadaMensual.Visible =false;
//			label7.Visible = false;
		}

		private void radioMensual_CheckedChanged(object sender, System.EventArgs e)
		{
			label6.Visible = false;
			txtSetDeDias.Visible = false;

			label3.Visible = false ;
			txtCada.Visible = false;
			lblPerioricidad.Visible = false;
			label6.Visible = false;
			txtSetDeDias.Visible = false;

			grpMensual.Visible =true;
//			label4.Visible = true;
//			cmbOrden.Visible = true;
//			cmbSelectOption.Visible = true;
//			label5.Visible = true;
//			txtCadaMensual.Visible =true;
//			label7.Visible = true;
 
		}


		#region --[Metodos Get]--

		private DataTable GetSemanaCada (DateTime pDateStart, DateTime pDateFinish,double pCada,string pSetOfDays)
		{
			string wSet = "";
			bool	wAddDate;	
			DataTable wDtt = new DataTable ("Fechas");
			DataColumn oDC = new DataColumn();

			oDC.ColumnName = "Fecha";
			wDtt.Columns.Add(oDC);
			DateTime wFecha = pDateStart;
			
            //ultraDataSource1.Rows.Clear (); 
			
			while (wFecha <= pDateFinish)
			{
		
				//Busco si la fecha esta contenida en los dias de la semana establecidos "BitSet"
				for (int i = 0 ;i<=6;i++)
				{
					wSet = pSetOfDays.Substring (i,1);
					wAddDate = SetDay(wSet,wFecha,pDateFinish,i);
					//no agrego la fecha si no se encontro  o se paso del limite 
					if  (wAddDate == true ) 
					{
						DataRow wDtr = wDtt.NewRow ();
						wDtr["Fecha"]= wFecha.ToString ();
						wDtt.Rows.Add (wDtr); 

						break;
					}
				}
				//Si es el ultimo dia de la semana = "Sabado" agrego la cantidad de semanas establecida por "Cada"
				if (wFecha.DayOfWeek == DayOfWeek.Saturday )  
				{
					wFecha = wFecha.AddDays ((pCada * 7) + 1); //agrego "pCada" semanas e incremento un dia
						
				}
				else
				{
					//Paso al proximo dia
					wFecha = wFecha.AddDays (1);
				}
			}
			return wDtt;
		}

		private DataTable GetDiaCada(DateTime pDateStart, DateTime pDateFinish,double pCada)
		{
			DateTime wFecha = pDateStart;
			DataTable wDtt = new DataTable ("Fechas");
			DataColumn oDC = new DataColumn();
			oDC.ColumnName = "Fecha";
			wDtt.Columns.Add(oDC);

			while (wFecha <= pDateFinish)
			{
				wFecha = wFecha.AddDays (pCada);
				DataRow wDtr = wDtt.NewRow ();
					wDtr["Fecha"]= wFecha.ToString ();
				wDtt.Rows.Add (wDtr); 
			}
			return wDtt;
 	}

		private DataTable GetMesOrden(DateTime pDateStart, DateTime pDateFinish,int pCada,System.DayOfWeek pDay,int pOrder )
		{
			string   Month;
			int wOrderCount;
			DataTable wDtt = new DataTable ("Fechas");
			DataColumn oDC = new DataColumn();
			oDC.ColumnName = "Fecha";
			wDtt.Columns.Add(oDC);
			DateTime wFecha = pDateStart;
			
			DateTime DateMesStart = Convert.ToDateTime ("01/" + wFecha.Month.ToString () +"/" +  wFecha.Year.ToString () );
			
			while (wFecha <= pDateFinish)
			{
				Month = wFecha.Month.ToString () ;
				wOrderCount= 1;
				//Recorro todo este mes (tengo en cuenta el primer mes como incluido)
				while (wFecha.Month.ToString () == Month)
				{
					//(DateMesStart >= pDateStart ) me indica que solo se agregara la fecha si esta dentro del 
					//rango de fechas establecido 
					//Esto se hace para que no se me agreguen fechas que comiencen por ej a mediados de mes con un orden 1
					if  (wFecha.DayOfWeek  == pDay) 
					{
						if ((DateMesStart >= pDateStart))
						{
							if (pOrder == wOrderCount )
							{
								DataRow wDtr = wDtt.NewRow ();
								wDtr["Fecha"]= wFecha.ToString ();
								wDtt.Rows.Add (wDtr); 
							}
						}
						wOrderCount +=1;
					}
					//incremento la fecha
					wFecha = wFecha.AddDays (1);
					//Incremento esta fecha asta alcanzar el rango admitido
					DateMesStart = DateMesStart.AddDays (1);
				}
				//aqui termino el mes		
				wFecha = wFecha.AddMonths(pCada ); //agrego "pCada" meses
			}
			return wDtt;
		}

		#endregion

		#region --[Metodos Set]--
	
		private bool SetDay(string pSet,DateTime  pDate,DateTime pDateFinish,int pDayNumbrer) 
		{
			
			if (pDate > pDateFinish)
			{
				return false;
			}
			switch(pDayNumbrer)
			{
				case 0://Lunes
				{
					if (pSet == "1" && pDate.DayOfWeek == DayOfWeek.Monday ) 	return true;
					break;
				}
				case 1://Martes
				{
					if (pSet == "1" && pDate.DayOfWeek == DayOfWeek.Tuesday ) return true;
					break;
				}
				case 2://Miercoles
				{
					if (pSet == "1" && pDate.DayOfWeek ==DayOfWeek.Wednesday ) return true;
					break;	
				}
				case 3://Jueves
				{
					if (pSet == "1" && pDate.DayOfWeek == DayOfWeek.Thursday ) return true;
					break;	
				}
				case 4://Viernes
				{
					if (pSet == "1" && pDate.DayOfWeek == DayOfWeek.Friday ) return true;
					break;	
				}
				case 5://Sabado
				{
					if (pSet == "1" && pDate.DayOfWeek == DayOfWeek.Saturday  )	return true;

					break;	
				}
				case 6://Domingo
				{
					if (pSet == "1" && pDate.DayOfWeek == DayOfWeek.Sunday) return true;
					break;			
				}
			}
			//retorna el menor valor de una fecha admitido por el sistema 
			//este valor se interpreta como que no se establecio ningun dia de la semana = "0000000"
			return false;
		}


		#endregion

		#region --[Metodos Fill]--
		private void FillCombo()
		{
            //cmbSelectOption.Items.Add(DayOfWeek.Sunday,"Domingo");
            //cmbSelectOption.Items.Add(DayOfWeek.Monday,"Lunes");
            //cmbSelectOption.Items.Add(DayOfWeek.Wednesday,"Martes");
            //cmbSelectOption.Items.Add(DayOfWeek.Wednesday,"Miercoles");
            //cmbSelectOption.Items.Add(DayOfWeek.Thursday,"Jueves");
            //cmbSelectOption.Items.Add(DayOfWeek.Friday,"Viernes");
            //cmbSelectOption.Items.Add(DayOfWeek.Saturday,"Sabado");
            //cmbSelectOption.SelectedIndex = 0; 
            //cmbOrden.Items.Add(1,"Primer");
            //cmbOrden.Items.Add(2,"Segundo");
            //cmbOrden.Items.Add(3,"Tercer");
            //cmbOrden.Items.Add(4,"Cuarto");
            //cmbOrden.Items.Add(5,"Quinto");
            //cmbOrden.SelectedIndex =0;
		}

		private void FillGrid(DataTable pTablaFechas)
		{
            //int wRowIndex = 0;
            //UltraDataRow wDRow;
            //ultraDataSource1.Rows.Clear();

            //foreach (DataRow oDtr in pTablaFechas.Rows)
            //{
            //    wDRow = ultraDataSource1.Rows.Insert(wRowIndex);
            //    wDRow["Fecha"] = Convert.ToDateTime(oDtr["Fecha"]);
            //    wRowIndex += 1;
            //}
		}
 
		#endregion

	}
}
