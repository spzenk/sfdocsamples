using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingCart;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JQ_GridTest
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ProductBE> _Catalogo = ProductsDelfinDAC.Retrive_Produts(1629);
           string json = JsonConvert.SerializeObject(_Catalogo);
           Label1.Text = json;

          //JObject obj = JObject.Parse(json);
          //JArray a = JArray.Parse(json);

            

        }
    }
}
