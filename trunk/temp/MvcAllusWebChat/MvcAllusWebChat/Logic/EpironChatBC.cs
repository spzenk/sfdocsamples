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

        internal static int CheckPhoneId(string phoneNumber, String clientName, String email)
        {

            ChatUserBE wChatUserBE = GetChatUser(phoneNumber, clientName);
            if (wChatUserBE != null)
                return wChatUserBE.ChatUserId;

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
            ChatUserBE userBE = ChatUserDAC.GetByParams(null, phoneNumber);


            if (userBE != null)
            {
                //Si esta en null directamtente le seteamos el clientName (este caso no deberia existir pero fisicamente es posible)
                //if (String.IsNullOrEmpty(userBE.ChatUserPhone))
                //{
                //    userBE.ChatUserPhone = phoneNumber;
                //    needUpdate = true;
                //}
                //Actualiza el nombre del cliente si es necesario
                if (userBE.ChatUserPhone.Trim().CompareTo(clientName.Trim()) != 0)
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
        /// Obtiele chat confoig.-. 
        /// </summary>
        /// <param name="chatConfigId">Si se pasa null obtiene uno por default</param>
        /// <returns></returns>
        internal static ChatConfigBE GetChatConfig(Guid? chatConfigId)
        {
            return ChatConfigDAC.GetByParam(chatConfigId);
        }

        /// <summary>
        /// REaliza la creacion de chatroom nuevo. Adicionalmente verifica si existen chatrooms activos por el usuario y los cierra
        /// </summary>
        /// <param name="model"></param>
        /// <param name="roomId"></param>
        /// <param name="userId"></param>
        internal static void CreateChatRoom(ChatRoomCreationModel model, out int roomId, out int userId)
        {
            roomId = -1;
            //Busca el cliente relacionado al telefono
            userId = EpironChatBC.CheckPhoneId(model.Phone, model.ClientName, model.ClientEmail);

            ChatConfigBE chatConfigBE = EpironChatBC.GetChatConfig(model.ChatConfigId);
            ActiveChatRoomBE wActiveChatRoom = GetChatRoom_IfNotExpired(userId, chatConfigBE);

            model.InitialMessage = String.Concat(model.InitialMessage, "|", model.ClientName);
            EpironChatBC.InsertMessage(wActiveChatRoom.ChatRoomId, userId, model.InitialMessage, null);
        }

        /// <summary>
        /// Verificar chat activos del usuario.. Chaquea si expiraron y los actualiza en la bd
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="configBE"></param>
        /// <returns></returns>
        internal static ActiveChatRoomBE GetChatRoom_IfNotExpired(int userId, ChatConfigBE configBE)
        {
            List<ActiveChatRoomBE> chatroomList = ChatRoomDAC.RetriveActiveChatRooms(userId);
            DateTime result;
            foreach (ActiveChatRoomBE item in chatroomList)
            {
                result = item.ChatMessageDate.AddMinutes(configBE.ChatConfigTimeOut.Value);
                if (result.CompareTo(DateTime.Now) >= 0)
                {
                    item.Status = Common.Enumerations.ChatRoomStatus.ExpiredTimeout;
                    ChatRoomDAC.Update(item.ChatRoomId, (int)item.Status, null);
                }

            }

            
            var activeChatRoom = chatroomList.Where(s => s.Status.Equals(WebChat.Common.Enumerations.ChatRoomStatus.Active)).FirstOrDefault();

            return activeChatRoom;


        }

        internal static List<Message> RecieveComments(int chatRoomId, int recordId, out Enumerations.ChatRoomStatus chatRoomStatus)
        {
            chatRoomStatus = Enumerations.ChatRoomStatus.Active;
            int? chatRoomStatusFromEtl = null;
            List<Message> result = EpironChatDAC.RecieveComments(recordId, out chatRoomStatusFromEtl);
            if (chatRoomStatusFromEtl.HasValue)
                if (Common.Common.ClosedStatus.Any(p => p.Equals(chatRoomStatusFromEtl.Value)))
                {
                    ChatRoomDAC.Update(chatRoomId,(int) WebChat.Common.Enumerations.ChatRoomStatus.ClosedByOperator, null);
                    chatRoomStatus = WebChat.Common.Enumerations.ChatRoomStatus.ClosedByOperator;
                }

            return result;
        }
    }
}