using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Epiron.Back.Bases.ISVC.RetriveCaptionsByCultureInfo;
using System.Globalization;
using Epiron.Back.Bases;
using Epiron.Front.Bases.Controls;

namespace Epiron.Front.Bases
{
    public partial class MultilanguageSetting : Component
    {


        public MultilanguageSetting()
        {
            InitializeComponent();
        }

        public MultilanguageSetting(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        ContainerControl ParentContainerControl()
        {
            ContainerControl wParentContainerControl = null;

            IDesignerHost host = this.Site.GetService(typeof(IDesignerHost)) as IDesignerHost;

            if (host != null)
            {
                IComponent componentHost = host.RootComponent;
                if (componentHost is ContainerControl)
                {
                    wParentContainerControl = componentHost as ContainerControl;

                }
            }
            return wParentContainerControl;
        }


        #region Language settings
        protected static UILanguageValues _UILanguageValues = null;
        public void Initialize(Boolean refresh = false)
        {


            if (_UILanguageValues != null && refresh == false)
                return;

            //Aquí entra solo si if(refresh==true) o ui_captionsList == null
            RetriveCaptionsByCultureInfoReq req = new RetriveCaptionsByCultureInfoReq();
            req.BusinessData.Culture = CultureInfo.CurrentCulture.Name;
            //RetriveCaptionsByCultureInfoRes res =              req.ExecuteService<RetriveCaptionsByCultureInfoReq, RetriveCaptionsByCultureInfoRes>(req);
            //ui_captionsList = res.BusinessData.Captions;

            #region test only
            _UILanguageValues = new UILanguageValues();

            _UILanguageValues.Add(new UILanguageValue { key = "lbl_Tittle", TextValue = "Wellcome to tijuana", TooltipValue = "Esto es un label" });
            _UILanguageValues.Add(new UILanguageValue { key = "chkFace_Ocion1", TextValue = "Opcion 1", TooltipValue = "" });
            _UILanguageValues.Add(new UILanguageValue { key = "chkFace_Ocion2", TextValue = "Opcion 2", TooltipValue = "" });
            _UILanguageValues.Add(new UILanguageValue { key = "chkFace_Ocion3", TextValue = "Opcion 3", TooltipValue = "" });



            #endregion
        }
        [Obsolete("No usar todavia esta en desarrollo")]
        public void AdjustCulture()
        {
            Control.ControlCollection parentControls = ParentContainerControl().Controls;
            AdjustCulture(parentControls);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControls"></param>
        public void AdjustCulture(Control.ControlCollection parentControls)
        {

            String key = String.Empty;
            foreach (Control c in parentControls)
            {
                if (c.Name.ToLower().Contains("PictureEdit1".ToLower()))
                {
                    continue;
                }

                if (c.Controls.Count != 0)
                    AdjustCulture(c.Controls);


                //if (typeof(IEpironControl).IsAssignableFrom(c.GetType()))
                //{
                //    key = ((IEpironControl)c).TextUICode;
                //}
                //else
                //    if (c.Tag != null)
                //    {
                //        if (!string.IsNullOrEmpty(c.Tag.ToString()))
                //            key = c.Tag.ToString();
                //    }
               // Ajusta la cultura unicamente d los controles que implementan IEpironControl
                if (typeof(IEpironControl).IsAssignableFrom(c.GetType()))
                {
                    key = ((IEpironControl)c).TextUICode;
                    if (Fwk.HelperFunctions.TypeFunctions.TypeInheritFrom(c.GetType(), typeof(BaseEdit))
                        //c.GetType().BaseType == typeof(DevExpress.XtraEditors.BaseEdit)
                        //|| c.GetType().BaseType.BaseType == typeof(BaseControl)
                        || Fwk.HelperFunctions.TypeFunctions.TypeInheritFrom(c.GetType(), typeof(BaseControl))
                        || Fwk.HelperFunctions.TypeFunctions.TypeInheritFrom(c.GetType(), typeof(XtraPanel)))
                    {
                        SetControl(c, key);
                        continue;
                    }
                    if (c.GetType() == typeof(DevExpress.XtraEditors.SimpleButton))
                    {
                        SetControl((DevExpress.XtraEditors.SimpleButton)c, key);
                        continue;
                    }

                    //RadioButton,Button ,CheckBox
                    if (Fwk.HelperFunctions.TypeFunctions.TypeInheritFrom(c.GetType(), typeof(ButtonBase))
                        || c.GetType() == typeof(System.Windows.Forms.Label))
                    {
                        SetControl(c, key);
                        continue;
                    }
                }

                if (c.GetType() == typeof(DevExpress.XtraTab.XtraTabControl))
                {
                    SetControl((DevExpress.XtraTab.XtraTabControl)c);
                    continue;
                }
                if (c.GetType() == typeof(DevExpress.XtraPivotGrid.PivotGridControl))
                {
                    SetControl((DevExpress.XtraPivotGrid.PivotGridControl)c);
                    continue;
                }
                if (c.GetType().BaseType == typeof(DevExpress.XtraGrid.GridControl)
                           || c.GetType() == typeof(DevExpress.XtraGrid.GridControl))
                {
                    SetControl((DevExpress.XtraGrid.GridControl)c);
                    continue;
                }


            }

        }
        /// <summary>
        /// XtraTabControl
        /// </summary>
        /// <param name="c"></param>
        void SetControl(DevExpress.XtraTab.XtraTabControl c)
        {
            foreach (DevExpress.XtraTab.XtraTabPage page in c.TabPages)
            {
                if (c.Tag != null)
                    if (ui_captionsList_ContainsKey(c.Tag.ToString()))
                    {
                        var v = ui_captionsList_get(c.Tag.ToString());
                        c.Text = v.TextValue;
                    }

            }


        }

        void SetControl(DevExpress.XtraPivotGrid.PivotGridControl c)
        {
            foreach (DevExpress.XtraPivotGrid.PivotGridField field in c.Fields)
            {
                if (c.Tag != null)

                    if (ui_captionsList_ContainsKey(c.Tag.ToString()))
                    {
                        var v = ui_captionsList_get(field.Tag.ToString());
                        c.Text = v.TextValue;
                    }
            }

        }

        void SetControl(DevExpress.XtraEditors.SimpleButton c, string key)
        {
            if (ui_captionsList_ContainsKey(key))
            {
                var v = ui_captionsList_get(key);
                c.Text = v.TextValue;
                c.ToolTip = v.TooltipValue;
            }
        }


        void SetControl(DevExpress.XtraGrid.GridControl gridControl)
        {
            gridControl.SuspendLayout();
            gridControl.BeginInit();
            foreach (DevExpress.XtraGrid.Views.Grid.GridView gridView in gridControl.Views)
            {
                if (ui_captionsList_ContainsKey("GroupPanelText"))
                {
                    var v = ui_captionsList_get("GroupPanelText");
                    gridView.GroupPanelText = v.TextValue;
                }
                foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in gridView.Columns)
                {

                    if (gridColumn.Tag != null)
                    {
                        if (!string.IsNullOrEmpty(gridColumn.Tag.ToString().Trim()))
                        {
                            if (ui_captionsList_ContainsKey(gridColumn.Tag.ToString()))
                            {
                                var v = ui_captionsList_get(gridColumn.Tag.ToString());
                                gridColumn.Caption = v.TextValue;

                                gridColumn.ToolTip = v.TooltipValue;
                            }
                        }
                    }
                }
            }
            gridControl.EndInit();
            gridControl.ResumeLayout();
        }

        /// <summary>
        /// label
        /// </summary>
        /// <param name="c"></param>
        void SetControl(Control c, string key)
        {
            if (ui_captionsList_ContainsKey(key))
                c.Text = ui_captionsList_get(key).TextValue;
        }




        #endregion
        Boolean ui_captionsList_ContainsKey(string key)
        {
            if (_UILanguageValues == null)
                Initialize();

            return _UILanguageValues.Any(k => k.key.Equals(key));

        }
        UILanguageValue ui_captionsList_get(string key)
        {
            if (_UILanguageValues == null)
                Initialize();

            var v = _UILanguageValues.Where(k => k.key.Equals(key)).FirstOrDefault();
            return v;

        }
    }
}
