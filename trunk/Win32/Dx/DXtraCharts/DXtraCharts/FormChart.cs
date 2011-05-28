using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Drawing.Imaging;
using DevExpress.LookAndFeel;
using DevExpress.DXperience.Demos;
using DevExpress.XtraCharts.Demos;
using DevExpress.XtraCharts;
namespace DXtraCharts
{
    public partial class FormChart : Form
    {
        public FormChart()
        {
            InitializeComponent();
            CreatePrintAndExportToMenu();
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        IEnumerable<TotalAmountSalesByYear> wTotalAmountSalesByYear;
                        using (TotalAmountSalesByYearDataContext dc = new TotalAmountSalesByYearDataContext())
                        {
                            wTotalAmountSalesByYear = from s in dc.TotalAmountSalesByYears select s;
                            totalAmountSalesByYearBindingSource.DataSource = wTotalAmountSalesByYear;
                        }
                        propertyGrid1.SelectedObject = this.chartControl1;

                        break;
                    }
                case 1:
                    {
                        
                        IEnumerable<TotalAmountByProductByYear> wTotalAmountByProductByYear;
                        using (TotalAmountByProductByYearDataContext dc = new TotalAmountByProductByYearDataContext())
                        {
                            int[] productList = new int[] { 707, 708, 715 ,717 };

                            wTotalAmountByProductByYear = from s in dc.TotalAmountByProductByYears where productList.Contains(s.ProductID) select s;
                            totalAmountByProductByYearBindingSource.DataSource = wTotalAmountByProductByYear;
                        }
                        break;
                    }
            }
        }

        private void chartControl2_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = this.chartControl2;
            propertyGrid2.SelectedObject = this.chartControl2.SeriesTemplate; 
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = this.chartControl1;
            propertyGrid2.SelectedObject = this.chartControl1.SeriesTemplate; 
        }

        BarSubItem miPrintAndExport;
        void CreatePrintAndExportToMenu()
        {
            BarItem miExportToPdf = new ButtonBarItem(this.barManager1, "Export to PDF", new ItemClickEventHandler(miExportToPdf_Click));
            BarItem miExportToHtml = new ButtonBarItem(this.barManager1, "Export to HTML", new ItemClickEventHandler(miExportToHtml_Click));
            BarItem miExportToMht = new ButtonBarItem(this.barManager1, "Export to MHT", new ItemClickEventHandler(miExportToMht_Click));
            BarItem miExportToXls = new ButtonBarItem(this.barManager1, "Export to XLS", new ItemClickEventHandler(miExportToXls_Click));
            BarItem miPrintPreview = new ButtonBarItem(this.barManager1, "Print Preview", new ItemClickEventHandler(miPrintPreview_Click));

            BarSubItem miExportToImage = new BarSubItem(this.barManager1, "Export to Image");
            AddImageFormat(miExportToImage, ImageFormat.Bmp);
            AddImageFormat(miExportToImage, ImageFormat.Emf);
            AddImageFormat(miExportToImage, ImageFormat.Exif);
            AddImageFormat(miExportToImage, ImageFormat.Gif);
            AddImageFormat(miExportToImage, ImageFormat.Icon);
            AddImageFormat(miExportToImage, ImageFormat.Jpeg);
            AddImageFormat(miExportToImage, ImageFormat.Png);
            AddImageFormat(miExportToImage, ImageFormat.Tiff);
            AddImageFormat(miExportToImage, ImageFormat.Wmf);

            miPrintAndExport = new BarSubItem(this.barManager1, "&Print and Export");
            miPrintAndExport.ItemLinks.AddRange(new BarItem[] {
																  miExportToPdf,
																  miExportToHtml,
																  miExportToMht,
																  miExportToXls,
																  miExportToImage
															  });
            miPrintAndExport.ItemLinks.Add(miPrintPreview).BeginGroup = true;
        }
        void AddImageFormat(BarSubItem biImagesMenuItem, ImageFormat format)
        {
            ImageCodecInfo codecInfo = FindImageCodec(format);
            if (codecInfo == null)
                return;
            BarExportToImageItem item = new BarExportToImageItem(this.barManager1, format, codecInfo);
            item.ItemClick += new ItemClickEventHandler(OnExportImageClick);
            biImagesMenuItem.AddItem(item);
        }
        ImageCodecInfo FindImageCodec(ImageFormat format)
        {
            ImageCodecInfo[] infos = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo item in infos)
            {
                if (item.FormatID.Equals(format.Guid))
                    return item;
            }
            return null;
        }
        void miPrintPreview_Click(object sender, ItemClickEventArgs e)
        {
            DemosInfo.PrintPreview();
        }
        void miExportToHtml_Click(object sender, ItemClickEventArgs e)
        {
            DemosInfo.ExportToHtml();
        }
        void miExportToMht_Click(object sender, ItemClickEventArgs e)
        {
            DemosInfo.ExportToMht();
        }
        void miExportToPdf_Click(object sender, ItemClickEventArgs e)
        {
            DemosInfo.ExportToPdf();
        }
        void miExportToXls_Click(object sender, ItemClickEventArgs e)
        {
            DemosInfo.ExportToXls();
        }
        void miRunChartWizard_Click(object sender, ItemClickEventArgs e)
        {
            DemosInfo.RunChartWizard();
        }
        void OnExportImageClick(object sender, ItemClickEventArgs e)
        {
            BarExportToImageItem item = e.Item as BarExportToImageItem;
            if (item == null)
                return;
            DemosInfo.ExportToImage(item.ImageCodecInfo, item.ImageFormat);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void chartControl3_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = this.chartControl3;
            propertyGrid2.SelectedObject = this.chartControl3.SeriesTemplate; 
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
 
        }
    }
    public class ChartAppearanceMenu : DevExpress.DXperience.Demos.LookAndFeelMenu
    {
        BarSubItem miAppearances;
        BarSubItem miPalettes;
        BarSubItem miPrintAndExport;
        BarSubItem miWizard;

        string appearanceName;
        string paletteName;

        public ChartAppearanceMenu(BarManager manager, DefaultLookAndFeel lookAndFeel, string about)
            : base(manager, lookAndFeel, about)
        {
         
        
            CreatePrintAndExportToMenu();
      

       

            AddItems();
        }

        public void EnableWizardAndPrintAndAppearancesMenu(bool enable)
        {
            if (miPrintAndExport == null)
                return;
            miPrintAndExport.Enabled = enable;
            miPalettes.Enabled = enable;
            miAppearances.Enabled = enable;
            miWizard.Enabled = enable;
        }
        void UpdateMenu()
        {
            int count = miAppearances.ItemLinks.Count;
            for (int i = 0; i < count; i++)
            {
                BarCheckItem item = miAppearances.ItemLinks[i].Item as BarCheckItem;
                if (item != null)
                    item.Checked = item.Caption == appearanceName;
            }
            if (miPalettes == null)
                return;
            count = miPalettes.ItemLinks.Count;
            for (int i = 0; i < count; i++)
            {
                BarCheckItem item = miPalettes.ItemLinks[i].Item as BarCheckItem;
                if (item != null)
                    item.Checked = item.Caption == paletteName;
            }
        }
        //void SetAppearanceName(string name)
        //{
        //    if (miAppearances == null)
        //        return;
        //    appearanceName = name;
        //    string paletteName = DemosInfo.SetAppearanceName(appearanceName);
        //    if (paletteName.Length > 0)
        //        this.paletteName = paletteName;
        //    UpdateMenu();
        //}
        //void SetPaletteName(string name)
        //{
        //    if (miPalettes == null)
        //        return;
        //    paletteName = name;
        //    string appearanceName = DemosInfo.SetPaletteName(paletteName);
        //    if (appearanceName.Length > 0)
        //        this.appearanceName = appearanceName;
        //    UpdateMenu();
        //}
        //internal void UpdateAppearanceAndPalette()
        //{
        //    DemosInfo.SetAppearanceName(appearanceName);
        //    DemosInfo.SetPaletteName(paletteName);
        //}

        protected override void AddItems()
        {
            if (miPrintAndExport == null)
                return;

            MainMenu.ItemLinks.Add(miLookAndFeel);
            MainMenu.ItemLinks.Add(miView);
            MainMenu.ItemLinks.Add(miAppearances);
            MainMenu.ItemLinks.Add(miPalettes);
            MainMenu.ItemLinks.Add(miPrintAndExport);
            MainMenu.ItemLinks.Add(miWizard);
            MainMenu.ItemLinks.Add(miHelp);
            InitLookAndFeelMenu();
        }

        void CreateAppearancesMenu()
        {
            miAppearances = new BarSubItem(this.manager, "&Appearances");
            ChartControl chart = new ChartControl();
            string[] appearanceNames = chart.GetAppearanceNames();
            int naturalColorIndex = 0;
            for (int i = 0; i < appearanceNames.Length; i++)
            {
                BarItem miAppearanceName = new BarCheckItem(this.manager);
                miAppearanceName.Caption = appearanceNames[i];
                if (appearanceNames[i] == "Nature Colors")
                    naturalColorIndex = i;
                //miAppearanceName.ItemClick += new ItemClickEventHandler(this.miAppearanceName_Click);
                miAppearances.ItemLinks.Add(miAppearanceName);
            }
            chart.Dispose();
            if (appearanceNames.Length > 0)
            {
                BarCheckItem item = miAppearances.ItemLinks[naturalColorIndex].Item as BarCheckItem;
                if (miAppearances != null)
                {
                    //miAppearanceName_Click(this.manager, new ItemClickEventArgs(item, null));
                    item.Checked = true;
                }
            }
        }
  
        void CreatePrintAndExportToMenu()
        {
            BarItem miExportToPdf = new ButtonBarItem(this.manager, "Export to PDF", new ItemClickEventHandler(miExportToPdf_Click));
            BarItem miExportToHtml = new ButtonBarItem(this.manager, "Export to HTML", new ItemClickEventHandler(miExportToHtml_Click));
            BarItem miExportToMht = new ButtonBarItem(this.manager, "Export to MHT", new ItemClickEventHandler(miExportToMht_Click));
            BarItem miExportToXls = new ButtonBarItem(this.manager, "Export to XLS", new ItemClickEventHandler(miExportToXls_Click));
            BarItem miPrintPreview = new ButtonBarItem(this.manager, "Print Preview", new ItemClickEventHandler(miPrintPreview_Click));

            BarSubItem miExportToImage = new BarSubItem(this.manager, "Export to Image");
            AddImageFormat(miExportToImage, ImageFormat.Bmp);
            AddImageFormat(miExportToImage, ImageFormat.Emf);
            AddImageFormat(miExportToImage, ImageFormat.Exif);
            AddImageFormat(miExportToImage, ImageFormat.Gif);
            AddImageFormat(miExportToImage, ImageFormat.Icon);
            AddImageFormat(miExportToImage, ImageFormat.Jpeg);
            AddImageFormat(miExportToImage, ImageFormat.Png);
            AddImageFormat(miExportToImage, ImageFormat.Tiff);
            AddImageFormat(miExportToImage, ImageFormat.Wmf);

            miPrintAndExport = new BarSubItem(this.manager, "&Print and Export");
            miPrintAndExport.ItemLinks.AddRange(new BarItem[] {
																  miExportToPdf,
																  miExportToHtml,
																  miExportToMht,
																  miExportToXls,
																  miExportToImage
															  });
            miPrintAndExport.ItemLinks.Add(miPrintPreview).BeginGroup = true;
        }

        void AddImageFormat(BarSubItem biImagesMenuItem, ImageFormat format)
        {
            ImageCodecInfo codecInfo = FindImageCodec(format);
            if (codecInfo == null)
                return;
            BarExportToImageItem item = new BarExportToImageItem(this.manager, format, codecInfo);
            item.ItemClick += new ItemClickEventHandler(OnExportImageClick);
            biImagesMenuItem.AddItem(item);
        }
        ImageCodecInfo FindImageCodec(ImageFormat format)
        {
            ImageCodecInfo[] infos = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo item in infos)
            {
                if (item.FormatID.Equals(format.Guid))
                    return item;
            }
            return null;
        }

        //void miAppearanceName_Click(object sender, ItemClickEventArgs e)
        //{
        //    frmMain parentForm = this.manager.Form as frmMain;
        //    if (parentForm == null)
        //        return;
        //    BarItem item = e.Item;
        //    if (item == null)
        //        return;
        //    SetAppearanceName(item.Caption);
        //}
        //void miPaletteName_Click(object sender, ItemClickEventArgs e)
        //{
        //    frmMain parentForm = this.manager.Form as frmMain;
        //    if (parentForm == null)
        //        return;
        //    BarItem item = e.Item;
        //    if (item == null)
        //        return;
        //    SetPaletteName(item.Caption);
        //}
        void miPrintPreview_Click(object sender, ItemClickEventArgs e)
        {
            DemosInfo.PrintPreview();
        }
        void miExportToHtml_Click(object sender, ItemClickEventArgs e)
        {
            DemosInfo.ExportToHtml();
        }
        void miExportToMht_Click(object sender, ItemClickEventArgs e)
        {
            DemosInfo.ExportToMht();
        }
        void miExportToPdf_Click(object sender, ItemClickEventArgs e)
        {
            DemosInfo.ExportToPdf();
        }
        void miExportToXls_Click(object sender, ItemClickEventArgs e)
        {
            DemosInfo.ExportToXls();
        }
        void miRunChartWizard_Click(object sender, ItemClickEventArgs e)
        {
            DemosInfo.RunChartWizard();
        }
        void OnExportImageClick(object sender, ItemClickEventArgs e)
        {
            BarExportToImageItem item = e.Item as BarExportToImageItem;
            if (item == null)
                return;
            DemosInfo.ExportToImage(item.ImageCodecInfo, item.ImageFormat);
        }
        protected override void miAboutProduct_Click(object sender, ItemClickEventArgs e)
        {
            DevExpress.Utils.About.AboutForm.Show(typeof(DevExpress.XtraCharts.Native.Chart), DevExpress.Utils.About.ProductKind.XtraCharts, DevExpress.Utils.About.ProductInfoStage.Registered);
        }
        protected override string ProductName { get { return "XtraCharts"; } }
        protected override void biProductWebPage_Click(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.devexpress.com/Products/NET/WinForms/XtraCharts/");
        }
    }


    #region BarExportToImageItem
    public class BarExportToImageItem : BarButtonItem
    {
        ImageFormat imageFormat;
        ImageCodecInfo imageCodecInfo;
        public BarExportToImageItem(BarManager barManager, ImageFormat imageFormat, ImageCodecInfo imageCodecInfo)
            : base(barManager, String.Empty)
        {
            this.imageFormat = imageFormat;
            this.imageCodecInfo = imageCodecInfo;
            this.Caption = String.Format("{0}", this.imageCodecInfo.FormatDescription);
        }
        public ImageFormat ImageFormat { get { return imageFormat; } }
        public ImageCodecInfo ImageCodecInfo { get { return imageCodecInfo; } }
    }
    #endregion
}
