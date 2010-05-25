using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

namespace AjaxWithDynamicControls
{
    public partial class _Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.TextBox1.Text = System.DateTime.Now.ToString();

            
        }


        void Page_PreInit(object sender, EventArgs e)
        {
            //Control control = GetPostBackControl(this.Page);
            //if (control != null)
            //{
            //}
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitControls();
        }
       
        Control GetPostBackControl(Page page)
        {
            Control control = null;
            String controlName= page.Request.Params.Get ("__EVENTTARGET");

            if (!string.IsNullOrEmpty(controlName))
                control = page.FindControl(controlName);

            if (control == null)
            {
                foreach (string items in page.Request.Form)
                {
                    if (items != null)
                    {
                        Control c = page.FindControl(items);
                        if (control != null)
                        {
                            if (c.GetType() == typeof(UControl))
                            {
                                control = c;
                            }
                        }
                    }
                }
            }

            return control;
        }

        void InitControls()
        {
            if (SessionProxy.CurrentSession == null)
                    SessionProxy.CurrentSession = this.Session;
            
            FillList();
            foreach (CheckObjet obj in SessionProxy.List)
            {
                LoadControl(obj);
            }
        }

        void LoadControl(CheckObjet pCheckObjet)
        {
         
            System.Web.UI.UserControl wUCWeb;
         
            wUCWeb = (System.Web.UI.UserControl)Page.LoadControl("~/UControl.ascx");
       
            ((UControl)wUCWeb).Populate(pCheckObjet);
            

            this.pnlContent.Controls.Add(wUCWeb);
        }

        void FillList()
        {
            if (SessionProxy.List != null) return;
             CheckObjetLis _lista = new CheckObjetLis ();
            _lista.Add(new CheckObjet(false,false,true,"1"));
            _lista.Add(new CheckObjet(false, false, true, "2"));
            _lista.Add(new CheckObjet(false, false, true, "3"));
            _lista.Add(new CheckObjet(true, true, true, "4"));
     
            SessionProxy.List = _lista;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

          Control c =  Page.FindControl("ctl05_CheckBox12");
            GridView1.DataSource = SessionProxy.List;
            GridView1.DataBind();
        }


    }
}
