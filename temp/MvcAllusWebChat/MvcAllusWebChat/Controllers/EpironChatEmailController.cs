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

        public ActionResult SendEmail(string cellPhone, string email, string emailBody, bool toTheClientFlag, string pGuid, int pchatUserId)
        {
            try
            {
                Guid wGuid =  new Guid("8f482c36-993f-4751-9299-e3e2be1b8d6");

                ChatMailSenderBE wChatMailSenderBE= EpironChatEmailBC.GetChatMailSenderByCongGuid(wGuid);

                int chatUserId = 1;

                ChatUserBE wChatuserBE = EpironChatEmailBC.GetChatUserByParams(chatUserId, string.Empty);

                wChatuserBE.ChatUserEmail = email; //<--usaremos el email que el usuario nos provee, aunque este tenga uno previo, no lo modificaremos en la base

                bool isSent = EmailHelper.SentEmail(emailBody, toTheClientFlag, wChatMailSenderBE, wChatuserBE);

                if (isSent)
                {
                    //se registra en la base que se ha enviado un email
                    ChatMessageBE wChatMessageBE = new ChatMessageBE();
                    wChatMessageBE.ChatMessageText = emailBody;
                    wChatMessageBE.ChatRoomId = 1; //<--- CAMBIAR
                    wChatMessageBE.ChatUserId = wChatuserBE.ChatUserId;

                    bool saved = EpironChatEmailBC.InsertChatMessage(wChatMessageBE);

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
