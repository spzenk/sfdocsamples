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
using WebChat.Logic.BE;
using System.IO;
using System.Web.Routing;
namespace WebChat.Controllers
{
    public class EpironChatVersion1Controller : Controller
    {

        public ActionResult SelectionTestChatEpiron()
        {

            return View();
        }

        //[HttpGet]
        //public ActionResult Default(string tel, string url, string @case, Boolean? isAjaxCall)
        //{
        //    try
        //    {
        //        if (WebChat.Common.Common.Host_Referer != null)
        //        {
        //            if (HttpContext.Request.ServerVariables["HTTP_REFERER"].Contains(WebChat.Common.Common.Host_Referer))
        //            {
        //                return View();
        //            }
        //            else
        //            {
        //                Helper.Log("Ruta de acceso incorrecta, HTTP_REFERER distinto de" + WebChat.Common.Common.Host_Referer); //Registro que se ingreso por un lugar que no correspondería
        //                ChatRoomFromUrlModel mChatRoomFromUrlModel = new ChatRoomFromUrlModel();
        //                mChatRoomFromUrlModel.HaveException = true;
        //                return View("Chat", mChatRoomFromUrlModel); //abro el chat pero con excepcion, para detener todo.
        //            }

        //        }
        //        else
        //        {
        //            return View();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Helper.Log(ex.Message);
        //        ChatRoomFromUrlModel mChatRoomFromUrlModel = new ChatRoomFromUrlModel();
        //        mChatRoomFromUrlModel.HaveException = true;
        //        return View("Chat", mChatRoomFromUrlModel); //abro el chat pero con excepcion, para detener todo.
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            


            ChatRoomGridModel wModel = new ChatRoomGridModel();
            try
            {
                //Busco las configuraciones (salas) que llenan los combos
                var chatConfigList = ChatConfigDAC.RetriveAll();

                List<SelectListItem> li = new List<SelectListItem>();

                foreach (var chatConfig in chatConfigList)
                {
                    li.Add(new SelectListItem { Text = chatConfig.ChatConfigName, Value = chatConfig.ChatConfigGuid.ToString() });
                }

                if (li.Count > 0)
                    wModel.IsConfigavailable = true;

                ViewData["ChatConfigList"] = li; //<-- las configuraciones se envian a través del ViewData

                // Busco las appSettings
                List<ApplicationSettingBE> wAppSettingsList = ApplicationSettingBC.SearchApplicationSetting();
                wModel.RetriveMessage_Timer = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.RetriveMessage_Timer)).Value);
                wModel.GetRecord_Timer = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.GetRecord_Timer)).Value);
                wModel.VersionWeb = wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.VersionWeb)).Value;
                wModel.GetRecordIdTries = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.GetRecordIdTries)).Value);
                wModel.ClientInactivityTimeOut = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.ClientInactivityTimeOut)).Value) / 1000;
                wModel.GetRecord_TimeOut = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.GetRecord_TimeOut)).Value) / 1000;
                wModel.GetRecord_TimeOut = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.GetRecord_TimeOut)).Value) / 1000;
                wModel.MaxLength_Message = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.MaxLength_Message)).Value);
            }
            catch (Exception ex)
            {
                Helper.Log(ex.Message);
                wModel.HaveException = true;
                return View(wModel);
            }

            return View(wModel);
        }

        /// <summary>
        ///  Respond a llamadas http://localhost:30250/EpironChatVersion1/chat/?tel=213&url=http://ar-movistar.agentbot.net/messages/?hash=33270-395607-87997_1404245636&case=49396
        /// </summary>
        /// <param name="tel"> Es el parámetro numérico ingresado al comienzo de la charla con Sofia.</param>
        /// <param name="url">Es el link q nos permite visualizar la primera interacción del cliente con Sofia, previamente a la derivación al chat. 
        /// Actualmente este URL está permitiendo ver una charla del dia actual, no de días anteriores.  
        /// Por ej te paso una de hace un rato para q puedas ver, de hoy: http://ar-movistar.agentbot.net/messages/?hash=86610-897638-98202_1421062641</param>
        /// <param name="@case">Es un número correlativo q AIVO [dueños de Sofia] nos envía también para q controlemos mejor sus envios y nuestras recepciones. </param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Chat(string tel, string url, string @case, Boolean? isAjaxCall)
        {
            int chatRoomId = -1;
            int userId = -1;
            int messageId = -1;
            bool userIsAlreadyUsed = false; //<-- indica si el usuario ya tiene un chatroom activo
            ChatRoomFromUrlModel model = new ChatRoomFromUrlModel();

            try
            {
                if (WebChat.Common.Common.Host_Referer != null)//<--pregunto si el parametro esta configurado
                {
                    if (HttpContext.Request.ServerVariables["HTTP_REFERER"]==null ||!HttpContext.Request.ServerVariables["HTTP_REFERER"].Contains(WebChat.Common.Common.Host_Referer))
                    {
                        Helper.Log("Ruta de acceso incorrecta, HTTP_REFERER distinto de" + WebChat.Common.Common.Host_Referer); //Registro que se ingreso por un lugar que no correspondería
                        ChatRoomFromUrlModel mChatRoomFromUrlModel = new ChatRoomFromUrlModel();
                        mChatRoomFromUrlModel.HaveException = true;
                        return View("Chat", mChatRoomFromUrlModel); //abro el chat pero con excepcion, para detener todo.
                    }
                }
            
                    ChatConfigBE chatConfigBE = ChatConfigDAC.GetByParam(null);
                    if (chatConfigBE == null)
                    {
                        model.IsConfigavailable = false; //<--No hay configuraciones, en el cliente se mostrara un mensaje
                        return View("chat", model);
                    }
                    model.OperatrCount = EpironChatDAC.OnlineUsers_Count(chatConfigBE.ChatConfigGuid);
                    if (model.OperatrCount > 0)
                        EpironChatBC.CreateChatRoom_FromUrl(tel, url, @case, out chatRoomId, out userId, out messageId, out userIsAlreadyUsed);
                    else
                        EpironChatBC.CreateChatRoom_NoOperators(tel, url, @case, string.Empty);

                    model.ChatConfigId = chatConfigBE.ChatConfigGuid;
                    model.UserId = userId;
                    model.RoomId = chatRoomId;
                    model.MessageId = messageId;
                    model.userAlreadySigned = userIsAlreadyUsed;
                    model.IsConfigavailable = true;
                    model.EmailAvailable = chatConfigBE.EmailAvailable;
                    //Survey
                    model.SurveyAvailable = chatConfigBE.ChatSurveyConfigId != null;
                    model.ChatSurveyConfigText = chatConfigBE.ChatSurveyConfigText;
                    model.ChatSurveyConfigURL = chatConfigBE.ChatSurveyConfigURL;
                    model.ChatSurveyConfigId = chatConfigBE.ChatSurveyConfigId;

                    // Busco las appSettings
                    List<ApplicationSettingBE> wAppSettingsList = ApplicationSettingBC.SearchApplicationSetting();
                    model.RetriveMessage_Timer = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.RetriveMessage_Timer)).Value);
                    model.GetRecord_Timer = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.GetRecord_Timer)).Value);
                    model.VersionWeb = wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.VersionWeb)).Value;
                    model.GetRecordIdTries = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.GetRecordIdTries)).Value);
                    model.ClientInactivityTimeOut = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.ClientInactivityTimeOut)).Value) / 1000;
                    model.GetRecord_TimeOut = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.GetRecord_TimeOut)).Value) / 1000;
                    model.MaxLength_Message = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.MaxLength_Message)).Value);

                    if (isAjaxCall.HasValue)
                        return Json(new { Result = "OK", userId = userId, roomId = chatRoomId, count = model.OperatrCount, messageId = model.MessageId }, JsonRequestBehavior.AllowGet);


                    return View("chat", model);
              
            }
            catch (Exception ex)
            {
                Helper.Log(ex.Message);

                if (isAjaxCall.HasValue)
                {
                    return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
                }
                else
                {
                    model.HaveException = true;
                    return View("chat", model);
                }
            }
        }

        /// <summary>
        ///http://localhost:30250/EpironChatVersion1/chafrm/?tel=03595-47845&clientName=RAMON&email=rMON.VALDEZ@TUTOPIA.COM&query=Hola%20chat%20de%20este%20mundo
        /// http://localhost:30250/?tel=03595-47845&clientName=RAMON&email=rMON.VALDEZ@TUTOPIA.COM&query=Hola%20chat%20de%20este%20mundo
        /// http://personalencuestas.com/chafrm/?tel=03595-47845&clientName=RAMON&email=rMON.VALDEZ@TUTOPIA.COM&query=Hola chat de este mundo
        ///http://personalencuestas/?tel=03595-47845&clientName=RAMON&email=rMON.VALDEZ@TUTOPIA.COM&query=Hola chat de este mundo
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="clientName"></param>
        /// <param name="email"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Chatfrm(string tel, string clientName, string email, string query)
        {
            bool anyIsNull = string.IsNullOrEmpty(Request.QueryString["tel"]) ||
                string.IsNullOrEmpty(Request.QueryString["clientName"]) ||
                string.IsNullOrEmpty(Request.QueryString["email"]) ||
                string.IsNullOrEmpty(Request.QueryString["query"]);

            if (anyIsNull)
               return RedirectToAction("Index");

            ChatRoomFromUrlModel model = new ChatRoomFromUrlModel();

             int chatRoomId = -1;
            int userId = -1;
            int messageId = -1;
            bool userIsAlreadyUsed = false; //<-- indica si el usuario ya tiene un chatroom activo
            //model.Phone = tel;
            model.ClientName = clientName;
            model.ClientEmail = email;
            //model.InitialMessage = query;
            bool emailAvailable = false; //<-- indica si el envio de emails esta disponible
       
            try
            {
                if (WebChat.Common.Common.Host_Referer != null)//<--pregunto si el parametro esta configurado
                {
                    if (HttpContext.Request.ServerVariables["HTTP_REFERER"]==null ||!HttpContext.Request.ServerVariables["HTTP_REFERER"].Contains(WebChat.Common.Common.Host_Referer))
                    {
                        Helper.Log("Ruta de acceso incorrecta, HTTP_REFERER distinto de" + WebChat.Common.Common.Host_Referer); //Registro que se ingreso por un lugar que no correspondería
                        ChatRoomFromUrlModel mChatRoomFromUrlModel = new ChatRoomFromUrlModel();
                        mChatRoomFromUrlModel.HaveException = true;
                        return View("Chat", mChatRoomFromUrlModel); //abro el chat pero con excepcion, para detener todo.
                    }
                }
            
                    ChatConfigBE chatConfigBE = ChatConfigDAC.GetByParam(null);
                    if (chatConfigBE == null)
                    {
                        model.IsConfigavailable = false; //<--No hay configuraciones, en el cliente se mostrara un mensaje
                        return View("chat", model);
                    }
          
                    model.OperatrCount = EpironChatDAC.OnlineUsers_Count(chatConfigBE.ChatConfigGuid);
            

                 if (model.OperatrCount > 0)
                     EpironChatBC.CreateChatRoom(model,tel,query, out chatRoomId, out userId, out messageId, out userIsAlreadyUsed, out emailAvailable);
                 else
                     EpironChatBC.CreateChatRoom_NoOperators(tel, null, string.Empty, query);

                    model.ChatConfigId = chatConfigBE.ChatConfigGuid;
                    model.UserId = userId;
                    model.RoomId = chatRoomId;
                    model.MessageId = messageId;
                    model.userAlreadySigned = userIsAlreadyUsed;
                    model.IsConfigavailable = true;
                    model.EmailAvailable = chatConfigBE.EmailAvailable;
                    //Survey
                    model.SurveyAvailable = chatConfigBE.ChatSurveyConfigId != null;
                    model.ChatSurveyConfigText = chatConfigBE.ChatSurveyConfigText;
                    model.ChatSurveyConfigURL = chatConfigBE.ChatSurveyConfigURL;
                    model.ChatSurveyConfigId = chatConfigBE.ChatSurveyConfigId;

                    // Busco las appSettings
                    List<ApplicationSettingBE> wAppSettingsList = ApplicationSettingBC.SearchApplicationSetting();
                    model.RetriveMessage_Timer = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.RetriveMessage_Timer)).Value);
                    model.GetRecord_Timer = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.GetRecord_Timer)).Value);
                    model.VersionWeb = wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.VersionWeb)).Value;
                    model.GetRecordIdTries = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.GetRecordIdTries)).Value);
                    model.ClientInactivityTimeOut = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.ClientInactivityTimeOut)).Value) / 1000;
                    model.GetRecord_TimeOut = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.GetRecord_TimeOut)).Value) / 1000;
                    model.MaxLength_Message = int.Parse(wAppSettingsList.Find(x => x.SettingId.Equals((int)Enumerations.ApplicationSettingId.MaxLength_Message)).Value);

                    //if (isAjaxCall.HasValue)
                    //    return Json(new { Result = "OK", userId = userId, roomId = chatRoomId, count = model.OperatrCount, messageId = model.MessageId }, JsonRequestBehavior.AllowGet);


                    return View("chat", model);
              
            }
            catch (Exception ex)
            {
                Helper.Log(ex.Message);

                //if (isAjaxCall.HasValue)
                //{
                //    return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
                //}
                //else
                //{
                    model.HaveException = true;
                    return View("chat", model);
                //}
            }
            
        }

        [HttpPost]
        public JsonResult CreateChatRoom(ChatRoomCreationModel model)
        {
           
            int userId = -1;
            int messageId = -1;
            int chatRoomId = -1;
            int count = 0;
            bool EmailAvailable = false; //<-- indica si el envio de emails esta disponible
            bool userIsAlreadyUsed = false; //<-- indica si el usuario ya tiene un chatroom activo
            bool isSurveyAvailable = false; //<-- indica si las encuestas estan disponibles
            string surveyText = null;
            string surveyUrl = null;
            try
            {
                count = EpironChatDAC.OnlineUsers_Count(model.ChatConfigId);
                ChatConfigBE chatConfigBE = ChatConfigDAC.GetByParam(model.ChatConfigId);

                isSurveyAvailable = chatConfigBE.ChatSurveyConfigId != null;
                surveyText = chatConfigBE.ChatSurveyConfigText;
                surveyUrl = chatConfigBE.ChatSurveyConfigURL;
                if (count == 0)
                {
                    EpironChatBC.CreateChatRoom_NoOperators(model.Phone, null, string.Empty, model.InitialMessage);
                    return Json(new { Result = "NO-OPERATORS", EmailAvailable = chatConfigBE.EmailAvailable });
                }

                EpironChatBC.CreateChatRoom(model, out chatRoomId, out userId, out messageId, out userIsAlreadyUsed, out EmailAvailable);

                if (userIsAlreadyUsed)
                    return Json(new { Result = "USER-SIGNED" });


                return Json(new
                {
                    Result = "OK",
                    userId = userId,
                    roomId = chatRoomId,
                    messageId = messageId,
                    EmailAvailable = EmailAvailable,
                    surveyText = surveyText,
                    isSurveyAvailable = isSurveyAvailable,
                    surveyUrl = surveyUrl
                });
            }
            catch (Exception ex)
            {
                Helper.Log(ex.Message);
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }


        [HttpPost]
        public JsonResult RetriveMessages(RetriveAllMessage retriveAllMessage)
        {
            //Busca los mensajes. Todos
            WebChat.Common.Enumerations.ChatRoomStatus wChatRoomStatus = Enumerations.ChatRoomStatus.Active;

            Boolean operatorWriting = false;
            string pNameOperator = string.Empty;
            List<Message> result = null;
            try
            {
                result = EpironChatBC.RecieveComments(retriveAllMessage.RoomId, retriveAllMessage.RecordId, out wChatRoomStatus, out operatorWriting, out pNameOperator);
                return Json(new { Result = "OK", Data = result, ChatRoomStatus = wChatRoomStatus, OperatorWriting = operatorWriting, NameOperator = pNameOperator });
            }
            catch (Exception ex)
            {
                Helper.Log(ex.Message);
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult GetRecordId(int userId, int roomId, int messageId)
        {
            //int? recordId = -1;
            GetRecordIdBE wGetRecordId = new GetRecordIdBE();
            int? chatRoomStatusFromEtl = null;
            try
            {
                wGetRecordId = EpironChatDAC.GetRecordId(messageId, out chatRoomStatusFromEtl);
                if (wGetRecordId.RecordId != null)
                    EpironChatBC.ChatRoom_UpdateStatus(roomId, wGetRecordId.RecordId.Value, WebChat.Common.Enumerations.ChatRoomStatus.Active);

                return Json(new { Result = "OK", recordId = wGetRecordId.RecordId, userName = wGetRecordId.UserName });
            }
            catch (Exception ex)
            {
                Helper.Log(ex.Message);
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult SendMessage(SendMessageModel msg)
        {
            try
            {
                msg.Message = msg.Message.Length > WebChat.Common.Common.MaxLength_Message ? msg.Message.Substring(0, 500) : msg.Message; //Limitamos el mensaje del cliente a 500 caracteres
                EpironChatBC.InsertMessage(msg.RoomId, msg.UserId, msg.Message, msg.RecordId);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                Helper.Log(ex.Message);
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult LeaveChatRoom(int recordId, int roomId)
        {
            try
            {
                EpironChatBC.LeaveChatRoom(roomId, recordId);
                return Json(new { Result = "OK", Message = "Gracias por Comunicarse con nosotros" });
            }
            catch (Exception ex)
            {
                Helper.Log(ex.Message);
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

       [HttpPost]
        public JsonResult OpenSurvey(int roomId, int recordId)
        {
            try
            {
                Guid wNewRandomGuid = Guid.NewGuid();
                //ChatSurveyBC.InsertChatSurvey(roomId, wNewRandomGuid);
                string NewRandom = wNewRandomGuid.ToString().Replace("-", string.Empty).Substring(0, 13);
                EpironChatBC.ChatRoom_UpdateSurvey(roomId, NewRandom);
                return Json(new { Result = "OK", NewRandomGuid = NewRandom });
            }
            catch (Exception ex)
            {
                Helper.Log(ex.Message);
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }
        

        [HttpPost]
        public JsonResult TimeOutChatRoom(int recordId, int roomId)
        {
            try
            {
                EpironChatBC.TimeOutChatRoom(roomId, recordId);
                return Json(new { Result = "OK", Message = "Ha expirado su sesión de chat. Vuelva a iniciar una conversación" });
            }
            catch (Exception ex)
            {
                Helper.Log(ex.Message);
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        [HttpPost]
        public JsonResult ClosedByRecordIdNotFound(int recordId, int roomId)
        {
            try
            {
                EpironChatBC.ClosedByRecordIdNotFound(roomId);
                return Json(new { Result = "OK", Message = "Se ha excedido el tiempo de espera de sala. Por favor vuelva a intentarlo más tarde" });
            }
            catch (Exception ex)
            {
                Helper.Log(ex.Message);
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        public ActionResult SaveUploadedFile(int roomid)
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {

                        var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\WallImages", Server.MapPath(@"\")));

                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "imagepath");

                        var fileName1 = Path.GetFileName(file.FileName);

                        bool isExists = System.IO.Directory.Exists(pathString);

                        if (!isExists)
                            System.IO.Directory.CreateDirectory(pathString);

                        var path = string.Format("{0}\\{1}", pathString, file.FileName);
                        file.SaveAs(path);

                    }

                }

            }
            catch (Exception ex)
            {
                Helper.Log(ex.Message);
                isSavedSuccessfully = false;
            }


            if (isSavedSuccessfully)
            {
                return Json(new { Message = fName });
            }
            else
            {
                return Json(new { Message = "Error in saving file" });
            }
        }
    }
}
