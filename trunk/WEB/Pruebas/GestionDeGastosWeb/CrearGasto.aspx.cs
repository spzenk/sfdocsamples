using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PelsoftGastos.Back;
using PelsoftGastos.Back.Entities;
public partial class CrearGasto : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
       
        GastoBE wGastoBE = new GastoBE();
        wGastoBE.Descripcion = this.txtDescripcion.Text;
        wGastoBE.Monto = Convert.ToDecimal(this.txtMonto.Text);
        wGastoBE.IdTipoGasto = Convert.ToInt32(this.DropDownList1.SelectedValue);
        //Desbordamiento de SqlDateTime. Debe estar entre 1/1/1753 12:00:00 AM y 12/31/9999 11:59:59 PM.

        if ((this.Calendar1.SelectedDate.CompareTo(new DateTime(1753, 1, 1, 12, 0, 0)) < 0) ||
        (this.Calendar1.SelectedDate.CompareTo(new DateTime(9999, 12, 31, 11, 59, 59)) > 0))
        {
            wGastoBE.Fecha = System.DateTime.Now;
        }
        else
        {
            wGastoBE.Fecha = this.Calendar1.SelectedDate;
        }
        GastosDAC.Crear(wGastoBE);
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtFecha.Text = this.Calendar1.SelectedDate.ToString("d");
        
    }
}
