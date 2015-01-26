using EpironChatLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Common;
using WebChat.Common.Models;
using WebChat.Data;
using WebChat.Logic;
using WebChat.Logic.BC;
using WebChat.Logic.DAC;

namespace WebChat.Controllers
{
    public class EpironChatTestController : Controller
    {
        //
        // GET: /Rep/
        public ActionResult Index()
        {

            return View();
        }
        /// <summary>
        ///  Respond a llamadas http://localhost:30250/EpironChatTest/chat/?tel=213&url=http://ar-movistar.agentbot.net/messages/?hash=33270-395607-87997_1404245636&case=49396
        /// </summary>
        /// <param name="tel"> Es el parámetro numérico ingresado al comienzo de la charla con Sofia.</param>
        /// <param name="url">Es el link q nos permite visualizar la primera interacción del cliente con Sofia, previamente a la derivación al chat. 
        /// Actualmente este URL está permitiendo ver una charla del dia actual, no de días anteriores.  
        /// Por ej te paso una de hace un rato para q puedas ver, de hoy: http://ar-movistar.agentbot.net/messages/?hash=86610-897638-98202_1421062641</param>
        /// <param name="@case">Es un número correlativo q AIVO [dueños de Sofia] nos envía también para q controlemos mejor sus envios y nuestras recepciones. </param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Chat(string tel, string url, string @case)
        {
            int chatRoomId=-1;
            int userId = -1;
            try
            {
                

                ///TODO: preguntar si ya hay un recodset creado para chatear..
                
                EpironChatBC.CreateChatRoom_FromUrl(tel, url, @case, out chatRoomId, out userId);
                ChatRoomFromUrlModel model = new ChatRoomFromUrlModel();
                model.ChatConfigId = 111111;
                model.UserId = "55";
                model.RecordId = "1321223411111";
                model.RoomId = "534";
                return View("chat",model);
                //return Json(new { Result = "OK", userId = userId, chatRoomId = chatRoomId });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult CreateChatRoom(ChatRoomCreationModel model)
        {
            String sessionId = ControllerContext.HttpContext.Session.SessionID;
         
            try
            {
                

                return Json(new { Result = "OK", phoneId = 100, userId = 2000 });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult RetriveMessages(RetriveAllMessage pRetriveAllMessage)
        {
            //int? chatRoomStatusFromEtl= 201;
            //WebChat.Common.Enumerations.ChatRoomStatus wChatRoomStatus = Enumerations.ChatRoomStatus.Active;
            List<Message> result = new List<Message> ();
            try
            {
          

                return Json(new { Result = "OK", Data = result, ChatRoomStatus = 201 });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult GetRecordId(int userId, int roomId)
        {
            //int? recordId = -1;
            //int? chatRoomStatusFromEtl = null;
            try
            {
                //recordId = EpironChatDAC.GetRecordId(userId, out chatRoomStatusFromEtl);

                //if (recordId != null)
                //    EpironChat_LogsDAC.UpdateStatus(userId,recordId.Value, WebChat.Common.Enumerations.ChatRoomStatus.Active);
                
                return Json(new { Result = "OK", recordId = 5000 });
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
                ChatMessageDAC.InsertMessage(msg.RoomId,msg.RoomId, msg.Message,msg.RecordId);

                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR",Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult LeaveChatRoom(int recordId, int roomId)
        {
            try
            {
                //EpironChat_LogsDAC.LeaveChatRoom(userId);
                return Json(new { Result = "OK", Message = "Sala de chat cerrada por el cliente" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }
    }
}
