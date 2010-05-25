using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicControls_NoAutopostBack
{
    public partial class _Default : System.Web.UI.Page
    {
        private System.Collections.Generic.List<CheckObjet> _lista;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                InitControls();
            }
        }

        void InitControls()
        {
            FillList();
            foreach (CheckObjet obj in _lista)
            {
                LoadControl(obj);
            }
        }

        void LoadControl(CheckObjet pCheckObjet)
        {

            System.Web.UI.UserControl wUCAttribute;
            wUCAttribute = (System.Web.UI.UserControl)Page.LoadControl("~/UControl.ascx");
            ((UControl)wUCAttribute).Populate(pCheckObjet);


            this.pnlContent.Controls.Add(wUCAttribute);
        }

        void FillList()
        {
            _lista = new List<CheckObjet>();
            _lista.Add(new CheckObjet(false, false, true, "1"));
            _lista.Add(new CheckObjet(false, false, true, "2"));
            _lista.Add(new CheckObjet(false, false, true, "3"));
            _lista.Add(new CheckObjet(true, true, true, "4"));

            Session["list"] = _lista;
        }
    }
}
