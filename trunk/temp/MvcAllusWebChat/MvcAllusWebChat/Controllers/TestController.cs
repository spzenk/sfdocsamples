using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Common.BE;
using WebChat.Common.Models;
using WebChat.Logic;
using WebChat.Logic.BC;
using WebChat.Logic.DAC;

namespace WebChat.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        
        public ActionResult Index()
        {
            //var chatConfigList = ChatConfigDAC.RetriveAll();

            ChatConfigList chatConfigList = new ChatConfigList();
            var c = new ChatConfigBE();
            c.ChatConfigName = "C1";
            c.ChatConfigGuid = Guid.NewGuid();
            chatConfigList.Add(c);
            c = new ChatConfigBE();
            c.ChatConfigName = "C2";
            c.ChatConfigGuid = Guid.NewGuid();
            chatConfigList.Add(c);
            List<SelectListItem> li = new List<SelectListItem>();

            foreach (var chatConfig in chatConfigList)
            {
                li.Add(new SelectListItem { Text = chatConfig.ChatConfigName, Value = chatConfig.ChatConfigGuid.ToString() });
            }
            ViewData["ChatConfigList"] = li;
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
        public ActionResult Chat(string tel, string url, string @case, Boolean? isAjaxCall)
        {
            int chatRoomId = -1;
            int userId = -1;
            int messageId = -1;
            ChatRoomFromUrlModel model = new ChatRoomFromUrlModel();
            try
            {
                ChatConfigBE chatConfigBE = ChatConfigDAC.GetByParam(null);
                model.OperatrCount = EpironChatDAC.OnlineUsers_Count(chatConfigBE.ChatConfigGuid);

                if (model.OperatrCount > 0)
                    EpironChatBC.CreateChatRoom_FromUrl(tel, url, @case, out chatRoomId, out userId,out messageId);
                ///TODO: preguntar si ya hay un recodset creado para chatear..


                model.ChatConfigId = chatConfigBE.ChatConfigGuid;
                model.UserId = userId;
                model.RoomId = chatRoomId;


                if (isAjaxCall.HasValue)
                    return Json(new { Result = "OK", userId = userId, roomId = chatRoomId, count = model.OperatrCount }, JsonRequestBehavior.AllowGet);


                return View("chat", model);
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
            int count = 0;
            int firstMessageId = -1;
            try
            {
                ChatConfigBE chatConfigBE = ChatConfigDAC.GetByParam(model.ChatConfigId);
                count = EpironChatDAC.OnlineUsers_Count(chatConfigBE.ChatConfigGuid);

                if (count == 0)
                {
                    return Json(new { Result = "NO-OPERATORS" });

                }

                EpironChatBC.CreateChatRoom(model, out chatRoomId, out userId, out firstMessageId);
                return Json(new { Result = "OK", userId = userId, roomId = chatRoomId, firstMessageId = firstMessageId });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
        }

        public ActionResult Emoticons()
        {
            return View();
        }
        /// <summary>
        /// Ambas funcionan =
        /// http://localhost:30250/test/chat/?tk=page1
        /// http://localhost:30250/test/chat/page2
        ///  routes.MapRoute(
           ///     name: "Default",
              ///  url: "{controller}/{action}/{tk}",
                ///defaults: new { controller = "EpironChat", action = "Index", tk = UrlParameter.Optional }
        ///);
        /// Esto es debido a Ropute
        /// </summary>
        /// <param name="tk"></param>
        /// <returns></returns>
        //[HttpGet]
        //public ActionResult Chat(string tk)

        //{
        //    if (String.IsNullOrEmpty(tk))
        //        return View("Index");
        //    if (tk.CompareTo("page1")==0)
        //        return View("page1");
        //    if (tk.CompareTo("page2")==0)
        //        return View("page2");

        //    return View();
        //}
        [HttpGet]
        public ActionResult Dialogs(string tk)
        {
        

            return View();
        }
    }
}
