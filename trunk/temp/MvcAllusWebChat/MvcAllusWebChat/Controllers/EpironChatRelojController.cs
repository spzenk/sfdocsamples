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
            String sessionId = ControllerContext.HttpContext.Session.SessionID;
            SMSMessage wSMSMessage = null;
            int? wPhoneId = null;
            int smsId = -1;
            int? chatRoomStatusFromEtl = null;
            try
            {
                //wPhoneId = EpironChat_LogsDAC.CheckPhoneId(model.Phone, model.ClientName);

                //wSMSMessage = EpironChat_LogsDAC.GetSSID_IfNotExpired(wPhoneId.Value);

                //// check if a session id was generated 
                //// Si noxiste se trata de un chat nuevo dado una session expirada
                //if (wSMSMessage != null)
                //{
                //    smsId = wSMSMessage.SMSId;
                //     if (wSMSMessage.RecordId.HasValue)
                //{
                //    //Chequear si el record id no esta cerrado
                //   int? recordId= EpironChatDAC.GetRecordId(smsId, out chatRoomStatusFromEtl);
                //   if (chatRoomStatusFromEtl.HasValue)
                //        if (Common.Common.ClosedStatus.Any(p => p.Equals(chatRoomStatusFromEtl.Value)))
                //        {
                //            EpironChat_LogsDAC.UpdateStatus(smsId, recordId.Value, WebChat.Common.Enumerations.ChatRoomStatus.ClosedByOperator);

                //        }
                //}

                //}
                //else
                //{
                //    //[08:55:38 a.m.]yulygasp:  se lo concatenemos al mensaje es que no podemos pasarlo en otro campo
                //    //porque el etl no esta preparado para recibirlo
                //    model.InitialMessage = String.Concat(model.InitialMessage, "|", model.ClientName);
                //    smsId = EpironChat_LogsDAC.InsertMessage(wPhoneId.Value, model.InitialMessage, sessionId,null);
                //}
                DateTime serverCreationTime = DateTime.Now.AddMinutes(-3);
                TimeSpan timeDifference = DateTime.Now - serverCreationTime;
                int differenceInSeconds = (int)timeDifference.TotalSeconds;

                return Json(new { Result = "OK", phoneId = 100, smsId = 2000, timeOnline = differenceInSeconds });
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
                //        EpironChat_LogsDAC.UpdateStatus(pRetriveAllMessage.smsId,pRetriveAllMessage.recordId, WebChat.Common.Enumerations.ChatRoomStatus.ClosedByOperator);
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
        public JsonResult GetRecordId(int smsId)
        {
            //int? recordId = -1;
            //int? chatRoomStatusFromEtl = null;
            try
            {
                //recordId = EpironChatDAC.GetRecordId(smsId, out chatRoomStatusFromEtl);

                //if (recordId != null)
                //    EpironChat_LogsDAC.UpdateStatus(smsId,recordId.Value, WebChat.Common.Enumerations.ChatRoomStatus.Active);

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
                EpironChat_LogsDAC.InsertMessage(msg.PhoneId, msg.Message, ControllerContext.HttpContext.Session.SessionID, msg.RecordId);

                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult LeaveChatRoom(int recordId, int smsId)
        {
            try
            {
                //EpironChat_LogsDAC.LeaveChatRoom(smsId);
                return Json(new { Result = "OK", Message = "Sala de chat cerrada por el cliente" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }
    }
}
