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
        //[HttpGet]
        //public JsonResult CreateChatRoom(ChatRoomCreationModel model)
        //{
        //    int userId = -1;
        //    int chatRoomId = -1;

        //    try
        //    {
        //        EpironChatBC.CreateChatRoom(model, out chatRoomId, out userId);
        //        return Json(new { Result = "OK", userId = userId, chatRoomId = chatRoomId });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
        //    }
        //}
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
                return Json(new { Result = "OK", userId = userId, chatRoomId = chatRoomId });
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

                //EpironChatBC.ChatRoom_UpdateTTL(retriveAllMessage.chatRoomId);

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
        public JsonResult LeaveChatRoom(int chatRoomId)
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
