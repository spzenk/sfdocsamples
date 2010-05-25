using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AjaxWithDynamicControls
{
    public partial class UControl : System.Web.UI.UserControl
    {
    
        CheckObjet _CheckObjet;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Populate(CheckObjet pCheckObjet)
        {
           
            _CheckObjet = pCheckObjet;
            this.UpdatePanel1.ID = "UpdatePanel1" + pCheckObjet.Id;
            this.lbltitle.Text += pCheckObjet.Id;
            this.CheckBox1.Checked = pCheckObjet.Chk1;
            this.CheckBox1.ID += pCheckObjet.Id;
            this.CheckBox2.Checked = pCheckObjet.Chk2;
            this.CheckBox2.ID += pCheckObjet.Id;
            this.CheckBox3.Checked = pCheckObjet.Chk3;
            this.CheckBox3.ID += pCheckObjet.Id;



            //AsyncPostBackTrigger apt = new AsyncPostBackTrigger();
            //apt.ControlID = CheckBox1.ClientID.ToString();
            //apt.EventName = string.Concat(CheckBox1.ID, "_CheckedChanged");
            //this.UpdatePanel1.Triggers.Add(apt);


            //apt = new AsyncPostBackTrigger();
            //apt.ControlID = CheckBox2.ClientID.ToString();
            //apt.EventName = string.Concat(CheckBox2.ID, "_CheckedChanged");
            //this.UpdatePanel1.Triggers.Add(apt);

            //apt = new AsyncPostBackTrigger();
            //apt.ControlID = CheckBox3.ClientID.ToString();
            //apt.EventName = string.Concat(CheckBox3.ID, "_CheckedChanged");
            //this.UpdatePanel1.Triggers.Add(apt);


        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            _CheckObjet.Chk1 = CheckBox1.Checked;



        }



        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            _CheckObjet.Chk2 = CheckBox2.Checked;
        }
        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            _CheckObjet.Chk3 = CheckBox3.Checked;
        }

    }
}