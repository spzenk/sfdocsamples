using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using Fwk.Exceptions;
using Fwk.Security.Common;

namespace Epiron.Front.Bases
{
    public partial class UserContrlManager : Component
    {
        public Xtra_UC_Base CurrentControl = null;
        private List<string> controls = new List< string>();
       
        DevExpress.XtraEditors.XtraForm _ParentForm;

        public DevExpress.XtraEditors.XtraForm ParentForm
        {
            get
            {
                System.ComponentModel.Design.IDesignerHost designerHost = this.GetService(typeof(System.ComponentModel.Design.IDesignerHost)) as System.ComponentModel.Design.IDesignerHost;
                _ParentForm = designerHost.RootComponent as XtraForm;
                if (_ParentForm == null) throw new ApplicationException("A Form host must be a top-level form.");
                return _ParentForm;
            }
            set { _ParentForm = value; }
        }
        public UserContrlManager()
        {
            InitializeComponent();
        }

        public UserContrlManager(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

        
        }


        public void AddContronToPannel(PanelEnum panelEnum, Xtra_UC_Base userControl, object obj)
        {

            var panel = ((IfrmMainBase)_ParentForm).Get_Panel(panelEnum);
            using (WaitCursorHelper w = new WaitCursorHelper(_ParentForm))
            {

                Type T = userControl.GetType();

                ///Si no fue agregado lo agega al contenedor
                if (!controls.Contains(userControl.Key))
                {

                    userControl.ParentPanel = panel;

                    panel.Controls.Add(userControl);
                    controls.Add(userControl.Key);

                    userControl.Dock = System.Windows.Forms.DockStyle.Fill;
                    userControl.OnExitControlEvent += new ExitControlHandler(ctrl_OnExitControlEvent);
                    userControl.OnLunchUserControlEvent += ctrl_OnLunchUserControlEvent;
                    userControl.Populate(obj);
                }

                CurrentControl = userControl;
                userControl.BringToFront();
                userControl.Refresh();
            }
        }

        public void AddContronToPannel(PanelEnum panelEnum, String assemblyInfo, object obj)
        {
            Fwk.UI.Controls.Menu.Tree.MenuItem item = new Fwk.UI.Controls.Menu.Tree.MenuItem();
            item.AssemblyInfo = assemblyInfo;
            PanelControl wPanelControl = ((IfrmMainBase)_ParentForm).Get_Panel(panelEnum); 
            AddContronToPannel(wPanelControl, item, obj);
        }

        public void AddContronToPannel(PanelEnum panelEnum, Fwk.UI.Controls.Menu.Tree.MenuItem item, object obj)
        {
            PanelControl wPanelControl = ((IfrmMainBase)_ParentForm).Get_Panel(panelEnum);
            AddContronToPannel(wPanelControl, item, obj);
        }

        public void AddContronToPannel(DevExpress.XtraEditors.PanelControl panel, Fwk.UI.Controls.Menu.Tree.MenuItem item, object obj)
        {
            using (WaitCursorHelper w = new WaitCursorHelper(_ParentForm))
            {
                Xtra_UC_Base ctrl = null;
                Type T = null;
                try
                {
                    T = Fwk.HelperFunctions.ReflectionFunctions.CreateType(item.AssemblyInfo);
                }

                catch (FileNotFoundException fe)
                {

                    TechnicalException te = new Fwk.Exceptions.TechnicalException(String.Concat("No se puede cargar el user control por q falta el archivo ", fe.FileName, "\r\n o alguna dependencia"));
                    throw te;

                }
                catch (System.TypeLoadException)
                {
                    TechnicalException te = null;
                    if (item.AssemblyInfo.Split(',').Count() == 2)
                        te = new Fwk.Exceptions.TechnicalException(String.Concat("No se puede cargar el user control [", item.AssemblyInfo.Split(',')[0], "] en el archivo ", item.AssemblyInfo.Split(',')[1]));

                    te = new Fwk.Exceptions.TechnicalException(String.Concat("No se puede cargar el user control definido en [", item.AssemblyInfo, "]"));
                    throw te;

                }
                catch (Exception ex)
                {
                    TechnicalException te = new TechnicalException(String.Concat("No se puede cargar el user control ", item.AssemblyInfo, " ", ex.Message));
                    throw te;
                }

                
                if (!controls.Contains(string.Concat(T.FullName, item.ID)))
                {
                    ctrl = (Xtra_UC_Base)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(item.AssemblyInfo);
                    ctrl.ParentPanel = panel;
                    ctrl.Tag = item.Tag;
                    ctrl.Key = item.ID.ToString();

                    panel.Controls.Add(ctrl);
                    controls.Add(ctrl.Key);
                    ctrl.Dock = System.Windows.Forms.DockStyle.Fill;
                    ctrl.OnExitControlEvent += new ExitControlHandler(ctrl_OnExitControlEvent);
                    ctrl.OnLunchUserControlEvent += ctrl_OnLunchUserControlEvent;
                    ctrl.Populate(obj);

                }
                else
                {
                    ctrl = GetControlFromPanel(string.Concat(T.FullName, item.ID), panel);
                }
                CurrentControl = ctrl;
                ctrl.BringToFront();
                ctrl.Refresh();
            }
        }


        public void RemoveControlFromPannel(Xtra_UC_Base ctrl)
        {
            PanelControl panel = ctrl.ParentPanel;
            if (ctrl != null)
            {
                ctrl.Exit();
                if (panel.Contains(ctrl))
                {
                    panel.Controls.Remove(ctrl);
                    controls.Remove(ctrl.Key);

                    if (panel.Controls.Count != 0)
                    {
                        using (WaitCursorHelper w = new WaitCursorHelper(ParentForm))
                        {
                            ctrl = (Xtra_UC_Base)ctrl.ParentPanel.Controls[0];
                            ctrl.Refresh();
                        }
                    }
                }
            }



        }

        public Xtra_UC_Base GetControlFromPanel(String controlKey, PanelControl panel)
        {
            Xtra_UC_Base userControl = null;
            foreach (System.Windows.Forms.Control c in panel.Controls)
            {
                if (c.GetType().IsSubclassOf(typeof(Xtra_UC_Base)))
                {
                    if (((Xtra_UC_Base)c).Key.Equals(controlKey))
                    {
                        userControl = (Xtra_UC_Base)c;
                        break;
                    }
                }
            }

            return userControl;
        }
        void ctrl_OnExitControlEvent(Xtra_UC_Base sender, PanelControl panel)
        {
            if (panel.Contains(sender))
            {
                RemoveControlFromPannel((Xtra_UC_Base)sender);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="luncherControl"></param>
        /// <param name="panelEnum"></param>
        /// <param name="menuItem"></param>
        /// <param name="populateObject"></param>
        protected void ctrl_OnLunchUserControlEvent(Xtra_UC_Base luncherControl, PanelEnum panelEnum, Fwk.UI.Controls.Menu.Tree.MenuItem menuItem, Object populateObject)
        {

            AddContronToPannel(panelEnum, menuItem, populateObject);
        }


        public frmDialogBase GetDialog(String assemblyInfo)
        {
            frmDialogBase frm;
            try
            {
                var f = Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(assemblyInfo);
                if (f == null)
                    throw new Fwk.Exceptions.TechnicalException(String.Concat("No se puede cargar el formulario por q falta el archivo ", assemblyInfo, "\r\n verifique el nokmbre de la clase"));
                frm = (frmDialogBase)f;
            }
            catch (FileNotFoundException fe)
            {

                TechnicalException te = new Fwk.Exceptions.TechnicalException(String.Concat("No se puede cargar el formulario por q falta el archivo ", fe.FileName, "\r\n o alguna dependencia"));
                throw te;

            }
            catch (System.InvalidCastException)
            {

                TechnicalException te = new Fwk.Exceptions.TechnicalException(String.Concat("No se puede cargar el formulario por que no es de un tipo frmDialogBase valido , Debe heredar de frmDialogBase.-"));
                throw te;

            }
            catch (Exception ex)
            {

                TechnicalException te = new TechnicalException(String.Concat("No se puede cargar el formulario ", assemblyInfo, " ", ex.Message));
                throw te;
            }

            return frm;
        }
    }
}
