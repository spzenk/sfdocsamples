using EpironChatLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Common;
using WebChat.Common.BE;
using WebChat.Common.Models;
using WebChat.Data;
using WebChat.Logic;
using WebChat.Logic.BC;
using WebChat.Logic.DAC;

namespace WebChat.Controllers
{
    public class EpironChatSendChatByEmailController : Controller
    {
        //
        // GET: /Rep/
        public ActionResult Index()
        {

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tel"> Es el parámetro numérico ingresado al comienzo de la charla con Sofia.</param>
        /// <param name="url">Es el link q nos permite visualizar la primera interacción del cliente con Sofia, previamente a la derivación al chat. Actualmente este URL está permitiendo ver una charla del dia actual, no de días anteriores.  Por ej te paso una de hace un rato para q puedas ver, de hoy: http://ar-movistar.agentbot.net/messages/?hash=86610-897638-98202_1421062641</param>
        /// <param name="@case">Es un número correlativo q AIVO [dueños de Sofia] nos envía también para q controlemos mejor sus envios y nuestras recepciones. </param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Chat(string phone, string url, string @case)
        {
            int userId = -1;
            int chatRoomId = -1;

            try
            {
                EpironChatBC.CreateChatRoom_FromUrl(phone ,url, @case, out chatRoomId, out userId);
                return View("Chat");
                //return Json(new { Result = "OK", userId = userId, chatRoomId = chatRoomId });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }
        [HttpPost]
        public JsonResult OnlineUsers_Count(ChatRoomCreationModel model)
        {
            int count = -1;
            try
            {
                ChatConfigBE chatConfigBE = ChatConfigDAC.GetByParam(model.ChatConfigId);
               count = EpironChatDAC.OnlineUsers_Count(model.ChatConfigId);
               return Json(new { Result = "OK", count = count});
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }
        [HttpPost]
        public JsonResult CreateChatRoom(ChatRoomCreationModel model)
        {
            int userId = -1;
            int chatRoomId = -1;
            int count = -1;
            try
            {
                ChatConfigBE chatConfigBE = ChatConfigDAC.GetByParam(model.ChatConfigId);
                count = EpironChatDAC.OnlineUsers_Count(chatConfigBE.ChatConfigGuid);
                
                if (count == 0)
                {
                    return Json(new { Result = "NO-OPERATORS" });
 
                }

                EpironChatBC.CreateChatRoom(model, out chatRoomId, out userId);
                return Json(new { Result = "OK", userId = userId, roomId = chatRoomId });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult RetriveMessages(RetriveAllMessage retriveAllMessage)
        {
            WebChat.Common.Enumerations.ChatRoomStatus wChatRoomStatus = Enumerations.ChatRoomStatus.Active; 
           
            List<Message> result = null;
            try
            {
                result = EpironChatBC.RecieveComments(retriveAllMessage.RoomId, retriveAllMessage.RecordId, out wChatRoomStatus);

                //EpironChatBC.ChatRoom_UpdateTTL(retriveAllMessage.chatRoomId);

                return Json(new { Result = "OK", Data = result, ChatRoomStatus = wChatRoomStatus });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult GetRecordId(int userId,int roomId)
        {
            int? recordId = -1;
            int? chatRoomStatusFromEtl = null;
            try
            {
                recordId = EpironChatDAC.GetRecordId(roomId, out chatRoomStatusFromEtl);

                if (recordId != null)
                    EpironChatBC.ChatRoom_UpdateStatus(userId, recordId.Value, WebChat.Common.Enumerations.ChatRoomStatus.Active);
                
                return Json(new { Result = "OK", recordId = recordId });
            }
            catch (Exception ex)
            {
                
                return Json(new { Result = "ERROR", Message =  Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult SendMessage(SendMessageModel msg)
        {
            try
            {
                EpironChatBC.InsertMessage(msg.RoomId,msg.UserId, msg.Message, msg.RecordId);

                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR",Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult LeaveChatRoom(int chatRoomId, int recordId)
        {
            try
            {
                EpironChatBC.LeaveChatRoom(chatRoomId);
                return Json(new { Result = "OK", Message = "Sala de chat cerrada por el cliente" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }
    }
}
