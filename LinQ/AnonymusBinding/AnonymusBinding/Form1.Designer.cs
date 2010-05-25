namespace AnonymusBinding
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.authorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.au_lname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colau_fname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colphone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coladdress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colzip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcontract = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraVertGridBlending1 = new DevExpress.XtraVerticalGrid.Blending.XtraVertGridBlending();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.title_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.au_ord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.authorBindingSource;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(659, 44);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(450, 368);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // authorBindingSource
            // 
            this.authorBindingSource.DataSource = typeof(AnonymusBinding.author);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.au_lname,
            this.colau_fname,
            this.colphone,
            this.coladdress,
            this.colcity,
            this.colstate,
            this.colzip,
            this.colcontract});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "city", null, "", "<Null>")});
            this.gridView1.Name = "gridView1";
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colstate, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // au_lname
            // 
            this.au_lname.Caption = "Nombre";
            this.au_lname.FieldName = "au_lname";
            this.au_lname.Name = "au_lname";
            this.au_lname.Visible = true;
            this.au_lname.VisibleIndex = 0;
            // 
            // colau_fname
            // 
            this.colau_fname.Caption = "Apellido";
            this.colau_fname.FieldName = "au_fname";
            this.colau_fname.Name = "colau_fname";
            this.colau_fname.Visible = true;
            this.colau_fname.VisibleIndex = 2;
            // 
            // colphone
            // 
            this.colphone.Caption = "phone";
            this.colphone.FieldName = "phone";
            this.colphone.Name = "colphone";
            this.colphone.Visible = true;
            this.colphone.VisibleIndex = 1;
            // 
            // coladdress
            // 
            this.coladdress.Caption = "address";
            this.coladdress.FieldName = "address";
            this.coladdress.Name = "coladdress";
            this.coladdress.Visible = true;
            this.coladdress.VisibleIndex = 3;
            // 
            // colcity
            // 
            this.colcity.Caption = "city";
            this.colcity.FieldName = "city";
            this.colcity.Name = "colcity";
            this.colcity.Visible = true;
            this.colcity.VisibleIndex = 4;
            // 
            // colstate
            // 
            this.colstate.Caption = "state";
            this.colstate.FieldName = "state";
            this.colstate.Name = "colstate";
            this.colstate.Visible = true;
            this.colstate.VisibleIndex = 5;
            // 
            // colzip
            // 
            this.colzip.Caption = "zip";
            this.colzip.FieldName = "zip";
            this.colzip.Name = "colzip";
            this.colzip.Visible = true;
            this.colzip.VisibleIndex = 5;
            // 
            // colcontract
            // 
            this.colcontract.Caption = "contract";
            this.colcontract.FieldName = "contract";
            this.colcontract.Name = "colcontract";
            this.colcontract.Visible = true;
            this.colcontract.VisibleIndex = 6;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(659, 15);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(96, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Get authors";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(1, 6);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(130, 32);
            this.simpleButton2.TabIndex = 4;
            this.simpleButton2.Text = "Get titles";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // gridControl3
            // 
            this.gridControl3.EmbeddedNavigator.Name = "";
            this.gridControl3.Location = new System.Drawing.Point(1, 40);
            this.gridControl3.MainView = this.gridView4;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(527, 217);
            this.gridControl3.TabIndex = 5;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4,
            this.gridView5});
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn1});
            this.gridView4.GridControl = this.gridControl3;
            this.gridView4.GroupCount = 1;
            this.gridView4.Name = "gridView4";
            this.gridView4.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "author";
            this.gridColumn5.FieldName = "au_fname";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "title_id";
            this.gridColumn2.FieldName = "title_id";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "au_ord";
            this.gridColumn3.FieldName = "au_ord";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "royaltyper";
            this.gridColumn4.FieldName = "royaltyper";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "state";
            this.gridColumn1.FieldName = "state";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // gridView5
            // 
            this.gridView5.GridControl = this.gridControl3;
            this.gridView5.Name = "gridView5";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.title_id,
            this.State,
            this.au_ord,
            this.author});
            this.dataGridView1.Location = new System.Drawing.Point(12, 277);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(516, 175);
            this.dataGridView1.TabIndex = 6;
            // 
            // title_id
            // 
            this.title_id.DataPropertyName = "title_id";
            this.title_id.HeaderText = "title_id";
            this.title_id.Name = "title_id";
            // 
            // State
            // 
            this.State.DataPropertyName = "state";
            this.State.HeaderText = "State";
            this.State.Name = "State";
            // 
            // au_ord
            // 
            this.au_ord.DataPropertyName = "au_ord";
            this.au_ord.HeaderText = "au_ord";
            this.au_ord.Name = "au_ord";
            // 
            // author
            // 
            this.author.DataPropertyName = "au_fname";
            this.author.HeaderText = "Author";
            this.author.Name = "author";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 538);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gridControl3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControl1);
            this.Name = "Form1";
            this.Text = "Binnding with anonymus type";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.Blending.XtraVertGridBlending xtraVertGridBlending1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.BindingSource authorBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colau_fname;
        private DevExpress.XtraGrid.Columns.GridColumn colphone;
        private DevExpress.XtraGrid.Columns.GridColumn coladdress;
        private DevExpress.XtraGrid.Columns.GridColumn colcity;
        private DevExpress.XtraGrid.Columns.GridColumn colstate;
        private DevExpress.XtraGrid.Columns.GridColumn colzip;
        private DevExpress.XtraGrid.Columns.GridColumn colcontract;

        private DevExpress.XtraGrid.Columns.GridColumn au_lname;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn title_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn au_ord;
        private System.Windows.Forms.DataGridViewTextBoxColumn author;
    }
}

