using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Epiron.Front.Bases
{
    public delegate void LunchUserControlHandler(Xtra_UC_Base luncherControl, PanelEnum panelEnum, Fwk.UI.Controls.Menu.Tree.MenuItem menuItem, Object populateObject);
    public delegate void ExitControlHandler(Xtra_UC_Base luncherControl, DevExpress.XtraEditors.PanelControl panel);

    public partial class Xtra_UC_Base : XtraUserControl
    {
        /// <summary>
        /// Envento lanzado por el control al Parent form para indicar que se a precionado algun boton de salir
        /// u ocurrio alguna señal qeu cerrar el user control
        /// </summary>
        public event ExitControlHandler OnExitControlEvent;

        /// <summary>
        /// Evento que indica la accion por parte del UserControl (A) de crear e incluir OTRO user control (B) en algun pannel container (PanelControl) 
        /// del formulario donde esta ya  incluido el usercontrol (A)  que lanza el evento.
        /// De este modo un formulario que atrape este evento , tambien detectara la intencion del usercontrol (A) de 
        /// lanzar otro usercontrol . El formulario prinsipal (main) luego realizara las operaciones necesarias para incluir dicho user control
        /// en el Panel espesificado por el parametro panel
        /// </summary>
        public event LunchUserControlHandler OnLunchUserControlEvent;



        /// <summary>
        /// Instancia del panel que lo contiene
        /// </summary>
        public DevExpress.XtraEditors.PanelControl ParentPanel { get; set; }

        /// <summary>
        /// Indica el tipo de panel que donde se agregara el control en el Main form .-
        /// </summary>
        public PanelEnum PanelContainer { get; set; }
     
        public Xtra_UC_Base()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Metoido que permite a un UserControl (A)  crear e incluir OTRO user control (B) en algun panel container (PanelControl) 
        /// del formulario donde esta ya  incluido el usercontrol (A)  que lanza el evento
        /// De este modo un formulario que atrape este evento , tambien detectara la intencion del usercontrol (A) de 
        /// lanzar otro usercontrol . El formulario prinsipal (main) luego realizara las operaciones necesarias para incluir dicho user control
        /// en el Panel espesificado por el parametro panel.
        /// </summary>
        /// <param name="panelEnum">Panel donde se incluira el usercontrol</param>
        /// <param name="menuItem"></param>
        /// <param name="populateObject">Parametros paara el Populate del usercontrol</param>
        protected void LunchUserControl(PanelEnum panelEnum, Fwk.UI.Controls.Menu.Tree.MenuItem menuItem,Object populateObject)
        {
            if (OnLunchUserControlEvent != null)
                OnLunchUserControlEvent(this, panelEnum, menuItem, populateObject);
        }

        private void Xtra_UC_Base_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                this.Refresh();
            }
        }
        private string _Key = string.Empty;

        /// <summary>
        /// Sirve para identificar un usercontrol en un contenedor de controles,
        /// por ejemplo un panel control
        /// Retorna Assembly Info + Key
        /// Si key es null retorna solamente assembly info.
        /// </summary
        [Browsable(true), Category("Epiron.Gestion.Libs"), DefaultValue(typeof(String), "")]
        public string Key
        {
            get
            {
                if (!string.IsNullOrEmpty(_Key))
                    return String.Concat(this.GetType().FullName, _Key);
                else
                    return this.GetType().FullName;
            }
            set { _Key = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual void AceptChanges(bool this_will_close) { }
        /// <summary>
        /// 
        /// </summary>
        public virtual void CancelChanges() { }


        /// <summary>
        /// 
        /// </summary>
        public virtual void Exit() 
        {
            if (OnExitControlEvent != null)
                OnExitControlEvent(this, ParentPanel);
        }


        /// <summary>
        /// Método virtual que implementará c/programador cuando nececite poblar los controles de un user control
        /// </summary>
        /// <param name="initialObject">Cualquier objeto necesario para iniciar el poblado de controles </param>
        public virtual void Populate(object initialObject) { }



        public void AdjustCulture()
        {
           multilanguageSetting1.AdjustCulture(this.Controls);
        }
        public void ShowWaitForm()
        {
            Common.ShowWaitForm();

        }
        public void CloseWaitForm()
        {
            Common.CloseWaitForm();
        }
    }
}
