using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Common.BE;
using WebChat.Logic;
using WebChat.Logic.BC;
using WebChat.Common.Models;
using WebChat.Logic.DAC;
namespace WebChat.Controllers
{
    public class EpironChatEmailController : Controller
    {

        public ActionResult SendEmail(string cellPhone, string email, string emailBody, bool toTheClientFlag, string pGuid, int pRoomId, int pIsNoOperator)
        {

            try
            {
                ChatMailSenderBE wChatMailSenderBE = null;
                if (pGuid == "0")
                {
                    ChatConfigBE chatConfigBE = ChatConfigDAC.GetByParam(null);
                    wChatMailSenderBE = EpironChatEmailBC.GetChatMailSenderByCongGuid(chatConfigBE.ChatConfigGuid);
                }
                else
                {
                    Guid wGuid = new Guid(pGuid);
                    wChatMailSenderBE = EpironChatEmailBC.GetChatMailSenderByCongGuid(wGuid);
                }

                ChatUserBE wChatUserBE = new ChatUserBE();
                wChatUserBE.ChatUserEmail = email; //<--usaremos el email que el usuario nos provee, aunque este tenga uno previo, no lo modificaremos en la base

                if (toTheClientFlag)
                {
                    string css = @"
<style>.bubbleOwn
    {
        position: relative;
        width: 60%;
        /*height: 35px;*/
        padding: 5px;
        background-color: #71C837;
        -webkit-border-radius: 3px;
        -moz-border-radius: 3px;
        border-radius: 3px;
        left: 1px;
        clear: both;
       margin:6px 0px 1px 8px;
        border: 1px solid #CCC;
        /*min-height: 35px;*/
    }

    .bubbleThey
    {
        position: relative;
        width: 60%;
        /*height: 35px;*/
        padding: 2px;
        background: white;
        border: 1px solid #CCC;
        -webkit-border-radius: 3px;
        -moz-border-radius: 3px;
        border-radius: 3px;
        float: right;
        margin-right: 1px;
        clear: both;
        margin:6px 8px 1px 0px;
        /*min-height: 35px;*/
    }

._time {
float: right;
font-size: 10px;
}
</style>";
                    emailBody = css + emailBody;
                }





                bool isSent = EmailHelper.SentEmail(emailBody, toTheClientFlag, wChatMailSenderBE, wChatUserBE);

                if (isSent)
                {
                    //se registra en la base que se ha enviado un email
                    ChatEmailMessageBE wChatEmailMessageBE = new ChatEmailMessageBE();
                    // pIsNoOperator <-- Indica si este email se envia tras no encontrar operadores disponibles
                    wChatEmailMessageBE.ChatDescription = pIsNoOperator == 1 ? "SIN-OPERADORES" : null;
                    wChatEmailMessageBE.EmailFrom = wChatMailSenderBE.Email;
                    if (pRoomId != 0)
                        wChatEmailMessageBE.ChatRoomId = pRoomId;
                    else
                        wChatEmailMessageBE.ChatRoomId = null;

                    wChatEmailMessageBE.Body = emailBody;
                    if (toTheClientFlag)
                    {
                        wChatEmailMessageBE.Subject = "-Subject-";
                        wChatEmailMessageBE.DeliveredTo = wChatUserBE.ChatUserEmail;
                       
                    }
                    else
                    {
                        wChatEmailMessageBE.Subject = wChatMailSenderBE.TagStartWith + wChatUserBE.ChatUserEmail + wChatMailSenderBE.TagEndWith;
                        wChatEmailMessageBE.DeliveredTo = wChatMailSenderBE.Email;
                    }


                    bool saved = EpironChatEmailBC.InsertChatEmailMessage(wChatEmailMessageBE);

                    if (saved)
                    {
                        return Json(new { Result = "OK", Message = "Correo enviado correctamente" });
                    }
                    else
                    {
                        return Json(new { Result = "OK", Message = "Error al Guardar el Email" }); //<-- Revisar si se debe o no avisar al cliente
                    }

                }
                else
                {
                    return Json(new { Result = "OK", Message = "Error al Enviar Correo" }); //<-- Revisar si se debe o no avisar al cliente
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }

        }

    }
}
