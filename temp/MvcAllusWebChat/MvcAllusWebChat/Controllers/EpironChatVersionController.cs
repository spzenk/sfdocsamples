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
    public class EpironChatVersionController : Controller
    {
        //
        // GET: /EpironChatVersion/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChatSession(int UserId, int RoomId, int MessageId,int RecordID, string UserName)
        {
            SendMessageModel wSendMessageModel = new SendMessageModel();
            wSendMessageModel.UserId = UserId;
            wSendMessageModel.RoomId = RoomId;
            wSendMessageModel.RecordId = RecordID;
            wSendMessageModel.UserName = UserName;
            return View("ChatSession",wSendMessageModel);
        }

        [HttpPost]
        public JsonResult CreateChatRoom(ChatRoomCreationModel model)
        {
            int userId = -1;
            int messageId = -1;
            int chatRoomId = -1;
            int count = 0;
            try
            {
                ChatConfigBE chatConfigBE = ChatConfigDAC.GetByParam(model.ChatConfigId);
                count = EpironChatDAC.OnlineUsers_Count(chatConfigBE.ChatConfigGuid);
                count = 1;
                if (count == 0)
                {
                    return Json(new { Result = "NO-OPERATORS" });
                }

                EpironChatBC.CreateChatRoom(model, out chatRoomId, out userId, out messageId);
                return Json(new { Result = "OK", userId = userId, roomId = chatRoomId, messageId = messageId, UserName = model.ClientName });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult GetRecordId(int userId, int roomId, int messageId)
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

                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult LeaveChatRoom(int recordId, int roomId)
        {
            try
            {
                EpironChatBC.LeaveChatRoom(roomId);
                return Json(new { Result = "OK", Message = "Sala de chat cerrada por el cliente" });
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
                EpironChatBC.InsertMessage(msg.RoomId, msg.UserId, msg.Message, msg.RecordId);

                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }
        public ActionResult x()
        {
            return View();
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

    }
}
