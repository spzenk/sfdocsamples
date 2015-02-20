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

namespace WebChat.Controllers
{
    public class EpironChatRelojController : Controller
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
            int firstMessageId = -1;
            try
            {
                EpironChatBC.CreateChatRoom(model, out chtRoomId, out userId, out firstMessageId);

                //[08:55:38 a.m.]yulygasp:  se lo concatenemos al mensaje es que no podemos pasarlo en otro campo
                //porque el etl no esta preparado para recibirlo
                model.InitialMessage = String.Concat(model.InitialMessage, "|", model.ClientName);
                chtRoomId = EpironChatBC.InsertMessage(chtRoomId, userId, model.InitialMessage, null);

                DateTime serverCreationTime = DateTime.Now.AddMinutes(-3);
                TimeSpan timeDifference = DateTime.Now - serverCreationTime;
                int differenceInSeconds = (int)timeDifference.TotalSeconds;

                return Json(new { Result = "OK", userId = userId, chtRoomId = chtRoomId, messageId = firstMessageId });
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
            List<Message> result = new List<Message>();
            try
            {
                //result = EpironChatDAC.RecieveComments(pRetriveAllMessage.recordId, out chatRoomStatusFromEtl);
                //if (chatRoomStatusFromEtl.HasValue)
                //    if (Common.Common.ClosedStatus.Any(p => p.Equals(chatRoomStatusFromEtl.Value)))
                //    {
                //        EpironChat_LogsDAC.UpdateStatus(pRetriveAllMessage.userId,pRetriveAllMessage.recordId, WebChat.Common.Enumerations.ChatRoomStatus.ClosedByOperator);
                //        wChatRoomStatus = WebChat.Common.Enumerations.ChatRoomStatus.ClosedByOperator;
                //    }

                return Json(new { Result = "OK", Data = result, ChatRoomStatus = 201 });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult GetRecordId(int userId)
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

                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
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
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult LeaveChatRoom(int recordId, int roomId)
        {
            try
            {
                //EpironChat_LogsDAC.LeaveChatRoom(roomId);
                return Json(new { Result = "OK", Message = "Sala de chat cerrada por el cliente" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }
    }
}
