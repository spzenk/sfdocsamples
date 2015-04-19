using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IdentitySample.Classes
{
    public class Helper
    {

        /// <summary>
        /// Envia mail de acuerdo a las direcciones configuradas.
        /// </summary>
        //public static void SendMail_Me(string subjet, string body, string from)
        //{
        //    if (string.IsNullOrEmpty(from))
        //        return;


        //    string path = HttpContext.Current.Server.MapPath("~/App_Data/Email_UserRegistration.htm");

        //    string txt = Fwk.HelperFunctions.FileFunctions.OpenTextFile(path);




        //    //Envia el correo electronico.
        //    try
        //    {

        //        SendMail_Me(string.Concat("Mensaje de contacto de ", from), BODY.ToString(), email);
        //    }
        //    catch (Exception ex) { throw ex; }
        //}

        String BuildContactenos(string contactName, string message, string email, string phone, string city, string state)
        {
            //Esta funcion se puede usar porque  AspNetCompatibilityRequirementsMode.Allowed


            string path = HttpContext.Current.Server.MapPath("~/App_Data/Email_contactenos.htm");
            //string file = System.IO.Path.Combine(path, @"files\inf", "Email_contactenos.htm");
            string txt = Fwk.HelperFunctions.FileFunctions.OpenTextFile(path);
            StringBuilder BODY = new StringBuilder(txt);
            BODY.Replace("$contactName$", contactName);
            BODY.Replace("$email$", email);
            BODY.Replace("$phone$", phone);
            BODY.Replace("$city$", city);
            BODY.Replace("$state$", state);
            BODY.Replace("$message$", message);
            return BODY.ToString();


        }

      
             internal static String Build_ResetPassword(string contactName, string callbackUrl)
        {


            string path = HttpContext.Current.Server.MapPath("~/App_Data/Email_UserRegistration.htm");
            string txt = Fwk.HelperFunctions.FileFunctions.OpenTextFile(path);
            StringBuilder BODY = new StringBuilder(txt);
            BODY.Replace("$contactName$", contactName);
            BODY.Replace("callbackUrl", callbackUrl);

            return BODY.ToString();

        }
        internal static String Build_UserRegistration(string contactName, string callbackUrl)
        {


            string path = HttpContext.Current.Server.MapPath("~/App_Data/Email_UserRegistration.htm");
            string txt = Fwk.HelperFunctions.FileFunctions.OpenTextFile(path);
            StringBuilder BODY = new StringBuilder(txt);
            BODY.Replace("$contactName$", contactName);
            BODY.Replace("callbackUrl", callbackUrl);

            return BODY.ToString();

        }
        /// <summary>
        /// Envia mail de acuerdo a las direcciones configuradas.
        /// </summary>
        public static Task SendMailAsynk(string subjet, string body, string from, string to)
        {
            //if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            //    return null;

            String smtp = Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "smtp");
            Int32 port = Convert.ToInt32(Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "port"));
            Boolean enableSsl = Convert.ToBoolean(Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "enableSsl"));

            String email = Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "email");
            String username = Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "username");
            String pwd = Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "username");

            if (String.IsNullOrEmpty(from))
            {
                from = email;
            }
            //Crea el nuevo correo electronico con el cuerpo del mensaje y el asutno.
            MailMessage wMailMessage = new MailMessage() { Body = body, Subject = subjet };
            wMailMessage.IsBodyHtml = true;

            //Asigna el remitente del mensaje de acuerdo a direccion obtenida en el archivo de configuracion.
            wMailMessage.From = new MailAddress(from);
            //Asigna los destinatarios del mensaje de acuerdo a las direcciones obtenidas en el archivo de configuracion.
            //foreach (string recipient in MailRecipients)
            //{
            wMailMessage.To.Add(new MailAddress(to));
            //}

            SmtpClient smtpClient = new SmtpClient(smtp, port);
            smtpClient.EnableSsl = enableSsl;
            smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            NetworkCredential cred = new NetworkCredential(username, pwd);
            smtpClient.Credentials = cred;


            //Envia el correo electronico.
            //try
            //{

            return smtpClient.SendMailAsync(wMailMessage);
            //}
            //catch (Exception) { }
        }
    }
}