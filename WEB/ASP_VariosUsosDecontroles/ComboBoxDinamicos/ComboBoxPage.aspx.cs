using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BigBang.Common.Survey.BE;

namespace WebApplication1.ComboBoxDinamicos
{
    public partial class ComboBoxPage : System.Web.UI.Page
    {
        QuestionList _QuestionList;

        protected void Page_Load(object sender, EventArgs e)
        {
           
           
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            System.Web.UI.Control control = GetPostBackControl();
            if (control != null)
            {
                if (control.ClientID.ToString() == "btnLoad")
                { 
                
                }
            
            }

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if(IsPostBack)
                FillQuestions();

        }
       


        private System.Web.UI.Control GetPostBackControl()
        {
            System.Web.UI.Control wPostBackControl = null;
            String wPostBackControlName = Request.Params.Get("__EVENTTARGET");
            if (!string.IsNullOrEmpty(wPostBackControlName))
            {
                wPostBackControl = Page.FindControl(wPostBackControlName);
            }
            else
            {
                foreach (Control c in Page.Controls)
                {
                    if (c.GetType().Name == typeof(System.Web.UI.WebControls.Button).Name)
                        wPostBackControl = c;
                }
            }


            return wPostBackControl;
        }

        void FillQuestions()
        {
            GetItemQuestionList();
            MicrosoftCombocontrol wWebQuestion;
            foreach (Question wQuestion in _QuestionList)
            {
                Literal lit = new Literal();
                lit.Text ="Pregunta N° :" + wQuestion.QuestionId.ToString(); ;

                this.ContentPanel.Controls.Add(lit );
                foreach (ItemQuestion item in wQuestion.ItemQuestionList)
                {
                    wWebQuestion = (MicrosoftCombocontrol)Page.LoadControl("~/ComboBoxDinamicos/MicrosoftCombocontrol.ascx");
                    wWebQuestion.Item = item;
                    wWebQuestion.Populate(wQuestion.TagValue);

                    this.ContentPanel.Controls.Add(wWebQuestion);
                }
            }

        }

        void GetItemQuestionList()
        {
            if (Session["_QuestionList"] != null)
            {
                _QuestionList = (QuestionList)Session["_QuestionList"];
            }
            else
            {
                string strXml = Fwk.HelperFunctions.FileFunctions.OpenTextFile(@"C:\Projects\Desarrollo\DocEjemplos\.Net\VS2008\ASP\Pruebas\WebApplication1\ComboBoxDinamicos\Items.xml");
                _QuestionList = (QuestionList)QuestionList.GetObjectFromXml(typeof(QuestionList), strXml);
                Session["QuestionList"] = _QuestionList;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string strId = "ctl04_cmbTest";
               object combo = ViewState[strId];
            }

           //manejado en pre init
        }

        protected void ScriptManager1_PreRender(object sender, EventArgs e)
        {

        }
    }
}
