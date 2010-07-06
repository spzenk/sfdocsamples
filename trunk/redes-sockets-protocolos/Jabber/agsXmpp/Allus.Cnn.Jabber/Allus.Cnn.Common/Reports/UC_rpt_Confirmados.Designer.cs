namespace Allus.Cnn.Common.Reports
{
    partial class UC_rpt_Confirmados
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
            DevExpress.XtraCharts.SeriesTitle seriesTitle1 = new DevExpress.XtraCharts.SeriesTitle();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel2 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PiePointOptions piePointOptions3 = new DevExpress.XtraCharts.PiePointOptions();
            DevExpress.XtraCharts.PiePointOptions piePointOptions4 = new DevExpress.XtraCharts.PiePointOptions();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView2 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.SeriesTitle seriesTitle2 = new DevExpress.XtraCharts.SeriesTitle();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel3 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView3 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            this.chartConfirmados = new DevExpress.XtraCharts.ChartControl();
            this.resultGraficosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.resultGraficosBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartConfirmados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultGraficosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultGraficosBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // chartConfirmados
            // 
            this.chartConfirmados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartConfirmados.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.chartConfirmados.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;
            this.chartConfirmados.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartConfirmados.Location = new System.Drawing.Point(0, 0);
            this.chartConfirmados.Name = "chartConfirmados";
            this.chartConfirmados.PaletteName = "AllusVerdeNaranjaRojo";
            this.chartConfirmados.PaletteRepository.Add("AllusVerdeNaranjaRojo", new DevExpress.XtraCharts.Palette("AllusVerdeNaranjaRojo", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(168)))), ((int)(((byte)(9))))), System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(168)))), ((int)(((byte)(9)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(146)))), ((int)(((byte)(30))))), System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(146)))), ((int)(((byte)(30)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(76)))), ((int)(((byte)(27))))), System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(118)))), ((int)(((byte)(72))))))}));
            series1.ArgumentDataMember = "Descripcion";
            series1.DataFilters.ClearAndAddRange(new DevExpress.XtraCharts.DataFilter[] {
            new DevExpress.XtraCharts.DataFilter("Descripcion", "System.String", DevExpress.XtraCharts.DataFilterCondition.Equal, "No Leidos"),
            new DevExpress.XtraCharts.DataFilter("Descripcion", "System.String", DevExpress.XtraCharts.DataFilterCondition.Equal, "Confirmados"),
            new DevExpress.XtraCharts.DataFilter("Descripcion", "System.String", DevExpress.XtraCharts.DataFilterCondition.Equal, "No confirmados")});
            series1.DataFiltersConjunctionMode = DevExpress.XtraCharts.ConjunctionTypes.Or;
            series1.DataSource = this.resultGraficosBindingSource;
            pieSeriesLabel1.Antialiasing = true;
            pieSeriesLabel1.LineVisible = true;
            pieSeriesLabel1.OverlappingOptionsTypeName = "OverlappingOptions";
            series1.Label = pieSeriesLabel1;
            piePointOptions1.PointView = DevExpress.XtraCharts.PointView.Argument;
            piePointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
            piePointOptions1.ValueNumericOptions.Precision = 0;
            series1.LegendPointOptions = piePointOptions1;
            series1.Name = "Confirmados";
            piePointOptions2.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
            piePointOptions2.ValueNumericOptions.Precision = 0;
            series1.PointOptions = piePointOptions2;
            series1.SynchronizePointOptions = false;
            series1.ValueDataMembersSerializable = "Cantidad";
            pieSeriesView1.RuntimeExploding = false;
            seriesTitle1.Font = new System.Drawing.Font("Tahoma", 8F);
            seriesTitle1.Text = "Mensajes confirmados";
            pieSeriesView1.Titles.AddRange(new DevExpress.XtraCharts.SeriesTitle[] {
            seriesTitle1});
            series1.View = pieSeriesView1;
            series2.ArgumentDataMember = "Descripcion";
            series2.DataFilters.ClearAndAddRange(new DevExpress.XtraCharts.DataFilter[] {
            new DevExpress.XtraCharts.DataFilter("Descripcion", "System.String", DevExpress.XtraCharts.DataFilterCondition.Equal, "Confirmados"),
            new DevExpress.XtraCharts.DataFilter("Descripcion", "System.String", DevExpress.XtraCharts.DataFilterCondition.Equal, "No confirmados")});
            series2.DataFiltersConjunctionMode = DevExpress.XtraCharts.ConjunctionTypes.Or;
            series2.DataSource = this.resultGraficosBindingSource;
            pieSeriesLabel2.Antialiasing = true;
            pieSeriesLabel2.LineVisible = true;
            pieSeriesLabel2.OverlappingOptionsTypeName = "OverlappingOptions";
            series2.Label = pieSeriesLabel2;
            piePointOptions3.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
            piePointOptions3.ValueNumericOptions.Precision = 0;
            series2.LegendPointOptions = piePointOptions3;
            series2.Name = "SoloConfirmaciones";
            piePointOptions4.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
            piePointOptions4.ValueNumericOptions.Precision = 0;
            series2.PointOptions = piePointOptions4;
            series2.ShowInLegend = false;
            series2.SynchronizePointOptions = false;
            series2.ValueDataMembersSerializable = "Cantidad";
            pieSeriesView2.RuntimeExploding = false;
            seriesTitle2.Font = new System.Drawing.Font("Tahoma", 8F);
            seriesTitle2.Text = "Mensajes Confirmados (s�lo l�idos)";
            pieSeriesView2.Titles.AddRange(new DevExpress.XtraCharts.SeriesTitle[] {
            seriesTitle2});
            series2.View = pieSeriesView2;
            this.chartConfirmados.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            pieSeriesLabel3.LineVisible = true;
            pieSeriesLabel3.OverlappingOptionsTypeName = "OverlappingOptions";
            this.chartConfirmados.SeriesTemplate.Label = pieSeriesLabel3;
            pieSeriesView3.RuntimeExploding = false;
            this.chartConfirmados.SeriesTemplate.View = pieSeriesView3;
            this.chartConfirmados.Size = new System.Drawing.Size(436, 337);
            this.chartConfirmados.TabIndex = 0;
            chartTitle1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartTitle1.Text = "Confirmaci�n Mensajes";
            chartTitle2.Font = new System.Drawing.Font("Tahoma", 14F);
            chartTitle2.Text = "T�tulo del mensaje";
            this.chartConfirmados.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1,
            chartTitle2});
            // 
            // resultGraficosBindingSource
            // 
            this.resultGraficosBindingSource.DataSource = typeof(Allus.Cnn.ISVC.SearchRpt_ReadConfirmed.ResultGraficos);
            // 
            // resultGraficosBindingSource2
            // 
            this.resultGraficosBindingSource2.AllowNew = true;
            this.resultGraficosBindingSource2.DataSource = typeof(Allus.Cnn.ISVC.SearchRpt_ReadConfirmed.ResultGraficos);
            // 
            // UC_rpt_Confirmados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartConfirmados);
            this.Name = "UC_rpt_Confirmados";
            this.Size = new System.Drawing.Size(436, 337);
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartConfirmados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultGraficosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultGraficosBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartConfirmados;
        private System.Windows.Forms.BindingSource resultGraficosBindingSource;
        private System.Windows.Forms.BindingSource resultGraficosBindingSource2;
    }
}
