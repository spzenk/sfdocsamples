namespace Allus.Cnn.Common.Reports
{
    partial class UC_rpt_Leidos
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel1 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PiePointOptions piePointOptions1 = new DevExpress.XtraCharts.PiePointOptions();
            DevExpress.XtraCharts.PiePointOptions piePointOptions2 = new DevExpress.XtraCharts.PiePointOptions();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel2 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView2 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            this.chartLeidos = new DevExpress.XtraCharts.ChartControl();
            this.resultGraficosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartLeidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultGraficosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chartLeidos
            // 
            this.chartLeidos.DataSource = this.resultGraficosBindingSource;
            this.chartLeidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartLeidos.Location = new System.Drawing.Point(0, 0);
            this.chartLeidos.Name = "chartLeidos";
            this.chartLeidos.PaletteName = "AllusGreenRed";
            this.chartLeidos.PaletteRepository.Add("AllusGreenRed", new DevExpress.XtraCharts.Palette("AllusGreenRed", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(168)))), ((int)(((byte)(9))))), System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(201)))), ((int)(((byte)(67)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(76)))), ((int)(((byte)(27))))), System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(118)))), ((int)(((byte)(72))))))}));
            series1.ArgumentDataMember = "Descripcion";
            series1.DataFilters.ClearAndAddRange(new DevExpress.XtraCharts.DataFilter[] {
            new DevExpress.XtraCharts.DataFilter("Descripcion", "System.String", DevExpress.XtraCharts.DataFilterCondition.Equal, "Leidos"),
            new DevExpress.XtraCharts.DataFilter("Descripcion", "System.String", DevExpress.XtraCharts.DataFilterCondition.Equal, "No Leidos")});
            series1.DataFiltersConjunctionMode = DevExpress.XtraCharts.ConjunctionTypes.Or;
            pieSeriesLabel1.Antialiasing = true;
            pieSeriesLabel1.LineVisible = true;
            pieSeriesLabel1.OverlappingOptionsTypeName = "OverlappingOptions";
            series1.Label = pieSeriesLabel1;
            piePointOptions1.PointView = DevExpress.XtraCharts.PointView.Argument;
            piePointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
            piePointOptions1.ValueNumericOptions.Precision = 0;
            series1.LegendPointOptions = piePointOptions1;
            series1.Name = "Series 1";
            piePointOptions2.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
            piePointOptions2.ValueNumericOptions.Precision = 0;
            series1.PointOptions = piePointOptions2;
            series1.SynchronizePointOptions = false;
            series1.ValueDataMembersSerializable = "Cantidad";
            pieSeriesView1.RuntimeExploding = false;
            series1.View = pieSeriesView1;
            this.chartLeidos.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            pieSeriesLabel2.LineVisible = true;
            pieSeriesLabel2.OverlappingOptionsTypeName = "OverlappingOptions";
            this.chartLeidos.SeriesTemplate.Label = pieSeriesLabel2;
            pieSeriesView2.RuntimeExploding = false;
            this.chartLeidos.SeriesTemplate.View = pieSeriesView2;
            this.chartLeidos.Size = new System.Drawing.Size(400, 260);
            this.chartLeidos.TabIndex = 1;
            chartTitle1.Text = "Mensajes Leidos";
            chartTitle2.Font = new System.Drawing.Font("Tahoma", 14F);
            chartTitle2.Text = "T�tulo del mensaje";
            this.chartLeidos.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1,
            chartTitle2});
            // 
            // resultGraficosBindingSource
            // 
            this.resultGraficosBindingSource.DataSource = typeof(Allus.Cnn.ISVC.SearchRpt_ReadConfirmed.ResultGraficos);
            // 
            // UC_rpt_Leidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartLeidos);
            this.Name = "UC_rpt_Leidos";
            this.Size = new System.Drawing.Size(400, 260);
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLeidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultGraficosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource resultGraficosBindingSource;
        private DevExpress.XtraCharts.ChartControl chartLeidos;
    }
}
