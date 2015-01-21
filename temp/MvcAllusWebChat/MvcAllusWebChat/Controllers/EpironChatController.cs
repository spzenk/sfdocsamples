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
            //String sessionId = ControllerContext.HttpContext.Session.SessionID;
            
            int? userId = null;
            int chtRoomId = -1;
            int? chatRoomStatusFromEtl = null;
            try
            {
                userId = EpironChatBC.CheckPhoneId(model.Phone, model.ClientName,model.ClientEmail);
                ChatConfigBE chatConfigBE = EpironChatBC.GetChatConfig(model.ChatConfigId);

                //wSMSMessage = EpironChat_LogsDAC.GetSSID_IfNotExpired(userId.Value);
               
                // check if a session id was generated 
                // Si noxiste se trata de un chat nuevo dado una session expirada
                //if (wSMSMessage != null)
                //{
                //    chtRoomId = wSMSMessage.SMSId;
                //     if (wSMSMessage.RecordId.HasValue)
                //{
                //    //Chequear si el record id no esta cerrado
                //   int? recordId= EpironChatDAC.GetRecordId(chtRoomId, out chatRoomStatusFromEtl);
                //   if (chatRoomStatusFromEtl.HasValue)
                //        if (Common.Common.ClosedStatus.Any(p => p.Equals(chatRoomStatusFromEtl.Value)))
                //        {
                //            EpironChatBC.ChatRoom_UpdateStatus(chtRoomId, recordId.Value, WebChat.Common.Enumerations.ChatRoomStatus.ClosedByOperator);
                            
                //        }
                //}

                //}
                //else
                //{
                    //[08:55:38 a.m.]yulygasp:  se lo concatenemos al mensaje es que no podemos pasarlo en otro campo
                    //porque el etl no esta preparado para recibirlo
                    model.InitialMessage = String.Concat(model.InitialMessage, "|", model.ClientName);
                    chtRoomId = EpironChatBC.InsertMessage(userId.Value, model.InitialMessage, sessionId, null);
                //}

                return Json(new { Result = "OK", userId = userId, chtRoomId = chtRoomId });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult RetriveMessages(RetriveAllMessage pRetriveAllMessage)
        {
            int? chatRoomStatusFromEtl= null;
            WebChat.Common.Enumerations.ChatRoomStatus wChatRoomStatus = Enumerations.ChatRoomStatus.Active;
            List<Message> result = null;
            try
            {
                result = EpironChatDAC.RecieveComments(pRetriveAllMessage.recordId, out chatRoomStatusFromEtl);
                if (chatRoomStatusFromEtl.HasValue)
                    if (Common.Common.ClosedStatus.Any(p => p.Equals(chatRoomStatusFromEtl.Value)))
                    {
                        EpironChat_LogsDAC.UpdateStatus(pRetriveAllMessage.smsId,pRetriveAllMessage.recordId, WebChat.Common.Enumerations.ChatRoomStatus.ClosedByOperator);
                        wChatRoomStatus = WebChat.Common.Enumerations.ChatRoomStatus.ClosedByOperator;
                    }

                return Json(new { Result = "OK", Data = result, ChatRoomStatus = wChatRoomStatus });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult GetRecordId(int smsId)
        {
            int? recordId = -1;
            int? chatRoomStatusFromEtl = null;
            try
            {
                recordId = EpironChatDAC.GetRecordId(smsId, out chatRoomStatusFromEtl);

                if (recordId != null)
                    EpironChat_LogsDAC.UpdateStatus(smsId,recordId.Value, WebChat.Common.Enumerations.ChatRoomStatus.Active);
                
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
                EpironChat_LogsDAC.InsertMessage(msg.UserId, msg.Message, ControllerContext.HttpContext.Session.SessionID, msg.RecordId);

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
