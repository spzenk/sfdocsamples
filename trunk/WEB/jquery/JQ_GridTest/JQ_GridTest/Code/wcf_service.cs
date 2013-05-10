using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using ShoppingCart;
using System.Web;
using Newtonsoft.Json;



[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class wcf_service : Iwcf_service
{


    #region Iwcf_service Members

    public void SendMessage(string contactName, string message, string email, string phone, string city, string state)
    {
        //Esta funcion se puede usar porque  AspNetCompatibilityRequirementsMode.Allowed

        string ruta = HttpContext.Current.Server.MapPath("..");
        string file = System.IO.Path.Combine(ruta, "Email_buycart.htm");
        string txt = Fwk.HelperFunctions.FileFunctions.OpenTextFile(file);
        StringBuilder BODY = new StringBuilder(txt);
        BODY.Replace("$contactName$", contactName);
        BODY.Replace("$email$", email);
        BODY.Replace("$phone$", phone);
        BODY.Replace("$city$", city);
        BODY.Replace("$state$", state);
        BODY.Replace("$message$", message);
        StringBuilder htmlTable = new StringBuilder("<thead><tr> <td>Producto</td><td>Cantidad</td> <td>Precio</td></tr></thead><tbody>");
        var cart = (List<ProductBE>)System.Web.HttpContext.Current.Session["CARRO"];
        decimal totalprice = 0;
        foreach (ProductBE p in cart)
        {
            htmlTable.AppendLine("<tr> <td>" + p.Description + "</td><td>" + p.Count + "</td> <td>" + p.Price + "</td></tr>");
            if (p.Price.HasValue)
                totalprice += p.Price.Value;
        }
        htmlTable.AppendLine("<tr> <td>Total  </td><td>  </td> <td>" + totalprice.ToString() + "</td></tr>");
        htmlTable.AppendLine("</tbody>");
        BODY.Replace("$pedido$", htmlTable.ToString());


        //string body= String.Format(txt, contactName, email, phone, city, state, message);

        //Common.SendMail_Me(string.Concat("Nuevo pedido de ", contactName), BODY.ToString(), email);
        cart.Clear();
    }
    public String SendMessage2(string contactName, string message)
    {

        return "listo";

    }
    public List<ProductBE> AddToCart(int numberToBuy, int id, string price, string description,string marca)
    {
        decimal priceToDec= 0;
        Decimal.TryParse(price, out priceToDec);

        if (System.Web.HttpContext.Current.Session["CARRO"] != null)
        {
            var cart = (List<ProductBE>)System.Web.HttpContext.Current.Session["CARRO"];

            var item = cart.Where(p => p.Id.Equals(id)).FirstOrDefault();
            if (item == null)
            {
                item = new ProductBE();
                item.Description = description;
                item.Id = id;
                item.Count = numberToBuy;
                item.Marca = marca; 
                item.Price = priceToDec * numberToBuy;
                cart.Add(item);
            }
            else
            {
                
                item.Count = numberToBuy;
                item.Price = priceToDec * numberToBuy;
            }
            return (List<ProductBE>)cart;
        }
        return new List<ProductBE>();
        

    }


    public List<ProductBE> RetriveCart()
    {
        if (System.Web.HttpContext.Current.Session["CARRO"] != null)
        {
            var cart = (List<ProductBE>)System.Web.HttpContext.Current.Session["CARRO"];
            return cart;
        }
        return new List<ProductBE>();


    }
    public List<ProductBE> ClearCart()
    {
        if (System.Web.HttpContext.Current.Session["CARRO"] != null)
        {
            var cart = (List<ProductBE>)System.Web.HttpContext.Current.Session["CARRO"];
            cart.Clear();
            return cart;
        }
        return new List<ProductBE>();


    }

    public List<ProductBE> RetriveProducts(int categoryId)
    {
        return  ProductsDelfinDAC.Retrive_Produts(categoryId);
    }

    public String RetriveCategories()
    {
        ProductCategotyBEList list = ProductsDelfinDAC.Retrive_Categories();

        String jsonList = JsonConvert.SerializeObject(list);

        return jsonList;
    }
    #endregion
}



    [ServiceContract]
    public interface Iwcf_service
    {
        
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        void SendMessage(string contactName,string message,string email,string phone,string city,string state);
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        String SendMessage2(string contactName, string message);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        List<ProductBE> AddToCart(int numberToBuy, int id, string price, string description, string marca);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        List<ProductBE> RetriveCart();


        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        List<ProductBE> ClearCart();



        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        List<ProductBE> RetriveProducts(int categoryId);
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        String RetriveCategories();
    }

