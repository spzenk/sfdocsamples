using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace DevExpress.XtraCharts.Demos.Modules {
    public partial class ChartDemoBase : DevExpress.XtraCharts.Demos.TutorialControl {
        protected DevExpress.XtraEditors.PanelControl panel;
        protected DevExpress.XtraEditors.CheckEdit checkEditShowLabels;

        protected bool CheckEditShowLabelsVisible {
            get { return checkEditShowLabels.Visible; }
            set { checkEditShowLabels.Visible = value; }
        }
        protected bool ShowLabels { get { return this.checkEditShowLabels.Checked; } set { this.checkEditShowLabels.Checked = value; } }        
        public virtual ChartControl ChartControl { get { return null; } }

        public string AppearanceName {
            get {
                return ChartControl == null ? String.Empty : ChartControl.AppearanceName;
            }
            set {
                SetAppearanceName(value);
            }
        }
        public string PaletteName {
            get {
                return ChartControl == null ? String.Empty : ChartControl.PaletteName;
            }
            set {
                if (ChartControl != null)
                    ChartControl.PaletteName = value;
            }
        }

        public ChartDemoBase() {
            InitializeComponent();
        }
        protected virtual void checkEditShowLabels_CheckedChanged(object sender, System.EventArgs e) {
            foreach (Series series in ChartControl.Series)
                series.Label.Visible = this.checkEditShowLabels.Checked;
            UpdateControls();
        }        
        protected virtual void InitControls() {
        }
        protected virtual void ChartDemoBase_Load(object sender, System.EventArgs e) {
            if (DesignMode)
                return;
            if (ChartControl != null) {
                InitControls();
                UpdateControls();
            }
        }
        protected virtual void SetAppearanceName(string appearanceName) {
            if (ChartControl != null)
                ChartControl.AppearanceName = appearanceName;
        }
        protected void SetNumericOptions(Series series, NumericFormat format, int precision) {
            series.PointOptions.ValueNumericOptions.Format = format;
            series.PointOptions.ValueNumericOptions.Precision = precision;
        }
        public virtual void UpdateControls() {            
        }        
    }
}
