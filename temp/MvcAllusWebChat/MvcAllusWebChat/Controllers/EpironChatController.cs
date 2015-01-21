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
    public class EpironChatController : Controller
    {
        //
        // GET: /Rep/
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public JsonResult CreateChatRoom(ChatRoomCreationModel model)
        {
            int userId = -1;
            int chtRoomId = -1;

            try
            {
                EpironChatBC.CreateChatRoom(model, out chtRoomId, out userId);

                //[08:55:38 a.m.]yulygasp:  se lo concatenemos al mensaje es que no podemos pasarlo en otro campo
                //porque el etl no esta preparado para recibirlo
                model.InitialMessage = String.Concat(model.InitialMessage, "|", model.ClientName);
                chtRoomId = EpironChatBC.InsertMessage(chtRoomId, userId, model.InitialMessage, null);

                return Json(new { Result = "OK", userId = userId, chtRoomId = chtRoomId });
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
                result = EpironChatBC.RecieveComments(retriveAllMessage.chatRoomId, retriveAllMessage.recordId, out wChatRoomStatus);
               

                return Json(new { Result = "OK", Data = result, ChatRoomStatus = wChatRoomStatus });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult GetRecordId(int chatRoomId)
        {
            int? recordId = -1;
            int? chatRoomStatusFromEtl = null;
            try
            {
                recordId = EpironChatDAC.GetRecordId(chatRoomId, out chatRoomStatusFromEtl);

                if (recordId != null)
                    EpironChatBC.ChatRoom_UpdateStatus(chatRoomId, recordId.Value, WebChat.Common.Enumerations.ChatRoomStatus.Active);
                
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
                EpironChatBC.InsertMessage(msg.ChatRoomID,msg.UserId, msg.Message, msg.RecordId);

                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR",Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult LeaveChatRoom(int recordId, int smsId)
        {
            try
            {
                EpironChat_LogsDAC.LeaveChatRoom(smsId);
                return Json(new { Result = "OK", Message = "Sala de chat cerrada por el cliente" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }
    }
}
