using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BigBang.Common.Survey.BE;

namespace WebApplication1.ComboBoxDinamicos
{
    public partial class ComboBoxControl : System.Web.UI.UserControl
    {
        private ItemQuestion _Item;
        public ItemQuestion Item
        {
            get
            {
                return _Item;
            }
            set
            {
                _Item = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        internal void Populate(List<String> pComboValues)
        {
     
            this.UpdatePanel1.ID = string.Concat("UpdatePanel_" ,_Item.ItemQuestionId);
            this.lblItemQuestionId.Text = _Item.ItemQuestionId;

            this.cmbTest.DataSource = pComboValues;
            this.cmbTest.ID = string.Concat(this.cmbTest.ID , _Item.ItemQuestionId ,_Item.QuestionId);

            this.cmbTest.DataBind();

            this.cmbTest.SelectedIndex = 0;
            cmbTest.SelectedIndexChanged +=new EventHandler(cmbTest_SelectedIndexChanged);
        }

       
        protected void cmbTest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmbTest_PreRender(object sender, EventArgs e)
        {

        }

        protected void cmbTest_Callback(object source, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {

        }
    }
}