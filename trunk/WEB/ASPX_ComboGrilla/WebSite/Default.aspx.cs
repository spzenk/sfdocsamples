// Developer Express Code Central Example:
// How to filter the grid using the outside combobox
// 
// This sample demonstrates how to filter the grid using the outside combobox and
// grid custom callbacks.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E142

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using DevExpress.Web.ASPxGridView;



public partial class Advanced_CheckBox_Selection : System.Web.UI.Page {

    const string SessionCountryParameter = "ShipCountry";
    const string SessionCountryInitValue = "USA";

    protected void Page_Load(object sender, EventArgs e) {
        if(!IsPostBack && !IsCallback) {
            //Init values on the first load
            Session[SessionCountryParameter] = SessionCountryInitValue;
            cbCountries.Value = SessionCountryInitValue;
            grid.ExpandAll();
        }
    }
    protected void grid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e) {
        if((string)Session[SessionCountryParameter] == e.Parameters) return;
        Session[SessionCountryParameter] = e.Parameters;
        grid.DataBind();
        grid.ExpandAll();
    }
}
