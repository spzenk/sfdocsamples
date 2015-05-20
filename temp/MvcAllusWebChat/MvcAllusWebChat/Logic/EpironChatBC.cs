using System;
using System.Collections.Generic;
using System.Linq;
using WebChat.Common;
using WebChat.Common.BE;
using WebChat.Common.Models;
using WebChat.Logic.DAC;

namespace WebChat.Logic.BC
{
    public class EpironChatBC
    {
        internal static void ChatRoom_UpdateStatus(int chatRoomId, int recordId, WebChat.Common.Enumerations.ChatRoomStatus status)
        {
            ChatRoomDAC.Update(chatRoomId, recordId, (int)status);
        }

        internal static void ChatRoom_UpdateSurvey(int pChatRoomId, string pRandomGuid)
        {
            ChatRoomDAC.UpdateChatRoomSurveyRandomId(pChatRoomId, pRandomGuid);
        }

        internal static int CheckPhoneId(string phoneNumber, String clientName, String email)
        {

            ChatUserBE wChatUserBE = GetChatUser(phoneNumber, clientName);
            if (wChatUserBE != null)
                return wChatUserBE.ChatUserId;

            wChatUserBE = new ChatUserBE();
            /// Si no existe lo crea
            wChatUserBE.ChatUserPhone = phoneNumber;
            wChatUserBE.ChatUserName = clientName;
            wChatUserBE.ChatUserEmail = email;

            ChatUserDAC.Insert(wChatUserBE);

            return wChatUserBE.ChatUserId;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="clientName"></param>
        /// <returns></returns>
        static ChatUserBE GetChatUser(string phoneNumber, String clientName)
        {
            bool needUpdate = false;
            //String id = String.Concat(clientName, "$", phone);
            ChatUserBE userBE = ChatUserDAC.GetByParams(phoneNumber);


            if (userBE != null)
            {
                //Si esta en null directamtente le seteamos el clientName (este caso no deberia existir pero fisicamente es posible)
                //if (String.IsNullOrEmpty(userBE.ChatUserPhone))
                //{
                //    userBE.ChatUserPhone = phoneNumber;
                //    needUpdate = true;
                //}
                //Actualiza el nombre del cliente si es necesario
                if (!String.IsNullOrEmpty(clientName))
                    if (userBE.ChatUserName.Trim().CompareTo(clientName.Trim()) != 0)
                    {
                        userBE.ChatUserName = clientName;
                        needUpdate = true;
                    }

                if (needUpdate)
                    ChatUserDAC.Update(userBE);

                return userBE;
            }
            else
                return null;
        }


        internal static int InsertMessage(int chatRoomId, int userId, String message, int? recordId)
        {
            return ChatMessageDAC.InsertMessage(chatRoomId, userId, message, recordId);
        }


        /// <summary>
        /// REaliza la creacion de chatroom nuevo. Adicionalmente verifica si existen chatrooms activos por el usuario y los cierra
        /// </summary>
        /// <param name="model"></param>
        /// <param name="roomId"></param>
        /// <param name="userId"></param>
        internal static void CreateChatRoom_FromUrl(string phone, string url, string @case, out int roomId, out int userId, out int messageId, out bool userIsAlreadyUsed)
        {
            roomId = -1;

            //Busca el cliente relacionado al telefono Este debe existir
            userId = EpironChatBC.CheckPhoneId(phone, String.Empty, String.Empty);

            ChatConfigBE chatConfigBE = ChatConfigDAC.GetByParam(null);
            userIsAlreadyUsed = GetChatRoom_IfNotExpired(userId, chatConfigBE);
            if (userIsAlreadyUsed)
            {
                messageId = 0;
                return;
            }
               

            roomId = ChatRoomDAC.CreateChatRoom(chatConfigBE.ChatConfigId, (int)Common.Enumerations.ChatRoomStatus.Waiting, @case, url); 
            //[08:55:38 a.m.]yulygasp:  se lo concatenemos al mensaje es que no podemos pasarlo en otro campo
            //porque el etl no esta preparado para recibirlo
            //model.InitialMessage = String.Concat(model.InitialMessage, "|", model.ClientName);
           messageId = EpironChatBC.InsertMessage(roomId, userId, string.Empty, null);
        }

        /// <summary>
        /// Raliza la creación de un chatRoom para un No Operators
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="url"></param>
        /// <param name="@case"></param>
        internal static void CreateChatRoom_NoOperators(string phone, string url, string @case, string menssage)
        {
            //Busca el cliente relacionado al telefono Este debe existir
            int userId = EpironChatBC.CheckPhoneId(phone, String.Empty, String.Empty);

            ChatConfigBE chatConfigBE = ChatConfigDAC.GetByParam(null);

            int roomId = ChatRoomDAC.CreateChatRoom(chatConfigBE.ChatConfigId, (int)Common.Enumerations.ChatRoomStatus.ClosedLoggedOutRep, @case, url);
            //[08:55:38 a.m.]yulygasp:  se lo concatenemos al mensaje es que no podemos pasarlo en otro campo
            //porque el etl no esta preparado para recibirlo
            //model.InitialMessage = String.Concat(model.InitialMessage, "|", model.ClientName);
            int messageId = EpironChatBC.InsertMessage(roomId, userId, menssage, null);
        }

        /// <summary>
        /// REaliza la creacion de chatroom nuevo. Adicionalmente verifica si existen chatrooms activos por el usuario y los cierra
        /// </summary>
        /// <param name="model"></param>
        /// <param name="roomId"></param>
        /// <param name="userId"></param>
        internal static void CreateChatRoom(ChatRoomCreationModel model, out int roomId, out int userId, out int messageId, out bool userIsAlreadyUsed, out bool EmailAvailable)
        {
            roomId = -1;
            messageId = -1;
            //Busca el cliente relacionado al telefono
            userId = EpironChatBC.CheckPhoneId(model.Phone, model.ClientName, model.ClientEmail);

            ChatConfigBE chatConfigBE = ChatConfigDAC.GetByParam(model.ChatConfigId);
            userIsAlreadyUsed = GetChatRoom_IfNotExpired(userId, chatConfigBE);
            EmailAvailable = chatConfigBE.EmailAvailable;
            if (userIsAlreadyUsed)
            {
                return;
            }
         
            roomId = ChatRoomDAC.CreateChatRoom(chatConfigBE.ChatConfigId, (int)Common.Enumerations.ChatRoomStatus.Waiting, String.Empty, null); 
            //[08:55:38 a.m.]yulygasp:  se lo concatenemos al mensaje es que no podemos pasarlo en otro campo
            //porque el etl no esta preparado para recibirlo
            //model.InitialMessage = String.Concat(model.InitialMessage, "|", model.ClientName);
            messageId= EpironChatBC.InsertMessage(roomId, userId, model.InitialMessage, null);
        }

        /// <summary>
        /// Este se usa para casos donde el cliente (ej TP) tienbe su propio formulario de carga de dato y genera la URL . 
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="phone"></param>
        /// <param name="initialMessage"></param>
        /// <param name="roomId"></param>
        /// <param name="userId"></param>
        /// <author>moviedo</author>
        internal static void CreateChatRoom(ChatRoomFromUrlModel model,
            String phone,String  initialMessage,
            out int roomId, out int userId, 
            out int messageId, out bool userIsAlreadyUsed, 
            out bool EmailAvailable)
        {
            roomId = -1;
            messageId = -1;
            //Busca el cliente relacionado al telefono
            userId = EpironChatBC.CheckPhoneId(phone, model.ClientName, model.ClientEmail);

            ChatConfigBE chatConfigBE = ChatConfigDAC.GetByParam(model.ChatConfigId);
            userIsAlreadyUsed = GetChatRoom_IfNotExpired(userId, chatConfigBE);
            EmailAvailable = chatConfigBE.EmailAvailable;
            if (userIsAlreadyUsed)
            {
                return;
            }

            roomId = ChatRoomDAC.CreateChatRoom(chatConfigBE.ChatConfigId, (int)Common.Enumerations.ChatRoomStatus.Waiting, String.Empty, null);

            messageId = EpironChatBC.InsertMessage(roomId, userId, initialMessage, null);
        }
        /// <summary>
        /// Verificar chat activos del usuario.. Chaquea si expiraron y los actualiza en la bd
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="configBE"></param>
        /// <returns></returns>
        internal static bool GetChatRoom_IfNotExpired(int userId, ChatConfigBE configBE)
        {
            List<ActiveChatRoomBE> chatroomList = ChatRoomDAC.RetriveActiveChatRooms(userId);

            return chatroomList.Count > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatRoomId"></param>
        /// <param name="recordId"></param>
        /// <param name="chatRoomStatus"></param>
        /// <returns></returns>
        internal static List<Message> RecieveComments(int chatRoomId, int recordId, out Enumerations.ChatRoomStatus chatRoomStatus, out Boolean operatorWriting, out string pNameOperator)
        {
            chatRoomStatus = Enumerations.ChatRoomStatus.Active;
            int? chatRoomStatusFromEtl = null;
             operatorWriting = false;
             List<Message> result = EpironChatDAC.RecieveComments(recordId, out chatRoomStatusFromEtl, out operatorWriting, out pNameOperator);
            if (chatRoomStatusFromEtl.HasValue)
                if (Common.Common.ClosedStatus.Any(p => p.Equals(chatRoomStatusFromEtl.Value)))
                {
                    ChatRoomDAC.Update(chatRoomId, recordId, (int)WebChat.Common.Enumerations.ChatRoomStatus.ClosedByOperator);
                    chatRoomStatus = WebChat.Common.Enumerations.ChatRoomStatus.ClosedByOperator;
                }

            return result;
        }

        internal static void TimeOutChatRoom(int chatRoomId, int recordId)
        {
            ChatRoomDAC.Update(chatRoomId, recordId, (int)WebChat.Common.Enumerations.ChatRoomStatus.ChatAbandoned);
        }

        internal static void LeaveChatRoom(int chatRoomId, int recordId)
        {
            ChatRoomDAC.Update(chatRoomId, recordId, (int)WebChat.Common.Enumerations.ChatRoomStatus.ClosedByOwner);
        }

        internal static void ClosedByRecordIdNotFound(int chatRoomId)
        {
            ChatRoomDAC.Update(chatRoomId, null, (int)WebChat.Common.Enumerations.ChatRoomStatus.ClosedByRecordIdNotFound);
        }
        

        [Obsolete("todavia no se usa")]
        internal static void ChatRoom_UpdateTTL(int chatRoomId)
        {
            ChatRoomDAC.UpdateTTL(chatRoomId);
        }
    }
}