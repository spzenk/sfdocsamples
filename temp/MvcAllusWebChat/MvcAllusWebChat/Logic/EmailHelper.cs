using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using WebChat.Common.BE;
using WebChat.Logic.DAC;


namespace WebChat.Logic
{
    public class EmailHelper
    {
        public static bool SentEmail(string pMessage, bool wToTheClientFlag, ChatMailSenderBE pChatMailSender, ChatUserBE pChatUser)
        {
            try
            {
                if (pChatMailSender == null || pChatUser == null)
                    return false;

                System.Net.Mail.MailMessage wMessage = new System.Net.Mail.MailMessage() ;

                SmtpClient wSmtpClient = new SmtpClient(pChatMailSender.SMTPServer, pChatMailSender.SMTPPort);

                //Configuraciones de la cuenta          
                wSmtpClient.Credentials = new System.Net.NetworkCredential(pChatMailSender.UserName, pChatMailSender.Password);
                
                wSmtpClient.Timeout = 300000;
                wSmtpClient.EnableSsl = pChatMailSender.EnableSSL;
                wSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                
              
                //Configuraciones del email 
                wMessage = new System.Net.Mail.MailMessage() { Body = pMessage,BodyEncoding = Encoding.UTF8, IsBodyHtml = true };


                //Configuro el FROM y TO . 
                wMessage.From = new MailAddress(pChatMailSender.Email);

                string wSubject = string.Empty;
                if (wToTheClientFlag)
                {
                    wMessage.To.Add(new MailAddress(pChatUser.ChatUserEmail));  //En el caso de que sea desde la empresa para el cliente
                    wMessage.Subject = "- [Chat Epiron] - "; //<--- completar
                }
                else
                {
                    wMessage.To.Add(new MailAddress(pChatMailSender.Email));//En el caso de que sea desde el cliente para la empresa 
                    //El asunto o subject del email para el caso wToTheClientFlag == false, se conforma con el formtamo [TAG]@Email_del_cliente[/TAG]
                    wMessage.Subject = pChatMailSender.TagStartWith + pChatUser.ChatUserEmail + pChatMailSender.TagEndWith;
                }

                System.Net.Mail.Attachment wAttachFile = null; //<--- por ahora sin attachments

                wSmtpClient.Send(wMessage);

            }
            catch (Exception ex)
            {

            }
            return true;
        
        }

    }

   


}