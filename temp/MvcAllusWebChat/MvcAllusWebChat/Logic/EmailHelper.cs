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
        private ChatMailSenderBE _ChatMailSender { get; set; }
        private ChatUserBE _ChatUser { get; set; }

        public EmailHelper(Guid configId, int chatUserID)
        {
           this._ChatMailSender  =  EpironChat_LogsDAC.GetChatMailSenderByCongGuid(configId);
           this._ChatUser = ChatUserDAC.GetByParams(chatUserID,String.Empty);
        }

        public bool SentEmail(string pMessage, bool wToTheClientFlag)
        {
            try
            {
                if (_ChatMailSender == null || _ChatUser == null)
                    return false;

                System.Net.Mail.MailMessage wMessage = new System.Net.Mail.MailMessage() ;

                SmtpClient wSmtpClient = new SmtpClient(_ChatMailSender.SMTPServer, _ChatMailSender.SMTPPort);

                //Configuraciones de la cuenta          
                wSmtpClient.Credentials = new System.Net.NetworkCredential(_ChatMailSender.UserName, _ChatMailSender.Password);
                
                wSmtpClient.Timeout = 300000;
                wSmtpClient.EnableSsl = _ChatMailSender.EnableSSL;
                wSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                
              
                //Configuraciones del email 
                wMessage = new System.Net.Mail.MailMessage() { Body = pMessage,BodyEncoding = Encoding.UTF8, IsBodyHtml = true };


                //Configuro el FROM y TO . 
                wMessage.From = new MailAddress(_ChatMailSender.Email);

                string wSubject = string.Empty;
                if (wToTheClientFlag)
                {
                    wMessage.To.Add(new MailAddress(_ChatUser.ChatUserEmail));  //En el caso de que sea desde la empresa para el cliente
                    wMessage.Subject = string.Empty; //<--- completar
                }
                else
                {
                    wMessage.To.Add(new MailAddress(_ChatMailSender.Email));//En el caso de que sea desde el cliente para la empresa 
                    //El asunto o subject del email para el caso wToTheClientFlag == false, se conforma con el formtamo [TAG]@Email_del_cliente[/TAG]
                    wMessage.Subject = _ChatMailSender.TagStartWith + _ChatUser.ChatUserEmail + _ChatMailSender.TagEndWith;
                }

                System.Net.Mail.Attachment wAttachFile = null; //<--- por ahora sin attachments

                wSmtpClient.Send(wMessage);

                //return EpironChat_LogsDAC.InsertChatMessage(pMessage); //<-- registro el movimiento 
            }
            catch (Exception ex)
            {

            }
            return true;
        
        }

    }

   


}