using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Common.BE;
using WebChat.Logic;
using WebChat.Logic.BC;
using WebChat.Common.Models;

namespace WebChat.Controllers
{
    public class EpironChatEmailController : Controller
    {
        //
        // GET: /EpironChatEmail/

        public ActionResult Index()
        {
            SentEmailModel wSentEmailModel = new SentEmailModel();
            wSentEmailModel.UserMessage = "las pizzas? donde están mis pizzas?";
            return View(wSentEmailModel);
        }

        public ActionResult SendEmail(string cellPhone, string email, string emailBody, bool toTheClientFlag, string pGuid, int pchatUserId,  int pRoomId)
        {
            try
          {
                Guid wGuid = new Guid("8F482C36-993F-4751-9299-E3E2BE1B8D68");

                ChatMailSenderBE wChatMailSenderBE = EpironChatEmailBC.GetChatMailSenderByCongGuid(wGuid);

                int chatUserId = 1;

                ChatUserBE wChatuserBE = EpironChatEmailBC.GetChatUserByParams(chatUserId, string.Empty);

                wChatuserBE.ChatUserEmail = email; //<--usaremos el email que el usuario nos provee, aunque este tenga uno previo, no lo modificaremos en la base

                bool isSent = EmailHelper.SentEmail(emailBody, toTheClientFlag, wChatMailSenderBE, wChatuserBE);

                if (isSent)
                {
                    //se registra en la base que se ha enviado un email
                    ChatEmailMessageBE wChatEmailMessageBE = new ChatEmailMessageBE();
                    wChatEmailMessageBE.EmailFrom = wChatMailSenderBE.Email;
                    wChatEmailMessageBE.ChatRoomId = pRoomId;
                    wChatEmailMessageBE.Body = emailBody;
                    if (toTheClientFlag)
                    {
                        wChatEmailMessageBE.Subject = "-Subject-";
                        wChatEmailMessageBE.DeliveredTo = wChatuserBE.ChatUserEmail; 
                    }
                    else
                    {
                        wChatEmailMessageBE.Subject = wChatMailSenderBE.TagStartWith + wChatuserBE.ChatUserEmail + wChatMailSenderBE.TagEndWith;
                        wChatEmailMessageBE.DeliveredTo = wChatMailSenderBE.Email;
                    }


                    bool saved = EpironChatEmailBC.InsertChatEmailMessage(wChatEmailMessageBE);

                    if (saved)
                    {
                        return Json(new { Result = "OK" });
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
