using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class DoPostpack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Para controlar el comportamiento de nuestro PostBack, deberemos obtener, en el evento OnLoad, los valores del eventTarget y eventArgument,
            if ((Request.Params["__EVENTTARGET"] != null) && (Request.Params["__EVENTARGUMENT"] != null))
            {
                if ((Request.Params["__EVENTTARGET"] == this.txt_desde.UniqueID) && (Request.Params["__EVENTARGUMENT"] == "actualizar_label"))
                {
                    this.lbl_hasta.Text = this.txt_desde.Text;
                }
            }
            if (IsPostBack)
            {
            }
        }
    }
}
