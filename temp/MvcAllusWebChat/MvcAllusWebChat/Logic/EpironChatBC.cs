using System;
using System.Collections.Generic;
using System.Linq;
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

        internal static int CheckPhoneId(string phoneNumber, String clientName,String email)
        {

          ChatUserBE wChatUserBE =  GetChatUser(phoneNumber, clientName);
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
            ChatUserBE userBE =   ChatUserDAC.GetByParams(null, phoneNumber);
           

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


        internal static int InsertMessage(int chatRoomId ,int userId, String message,int recordId)
        {
            return ChatMessageDAC.InsertMessage(chatRoomId,userId, message, recordId);
        }

        internal static ChatConfigBE GetChatConfig(Guid chatConfigId )
        {
            return ChatConfigDAC.GetByParam(chatConfigId);
        }


        internal static void CreateChatRoom(ChatRoomCreationModel model, out int  roomId,out int?  userId )
        {
             userId = null;
            roomId = -1;
            int? chatRoomStatusFromEtl = null;
            userId = EpironChatBC.CheckPhoneId(model.Phone, model.ClientName, model.ClientEmail);

            ChatConfigBE chatConfigBE = EpironChatBC.GetChatConfig(model.ChatConfigId);

            model.InitialMessage = String.Concat(model.InitialMessage, "|", model.ClientName);
            chtRoomId = EpironChatBC.InsertMessage(userId.Value, model.InitialMessage, sessionId, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        internal static ChatRoom GetChatRoom_IfNotExpired(int userId)
        {

          List<ActiveChatRoomBE> chatroomList = ChatRoomDAC.RetriveActiveChatRooms(userId);

          foreach (ActiveChatRoomBE item in chatroomList)
          {
 
          }

            //using (EpironChat_logsDataContext db = new EpironChat_logsDataContext())
            //{
            //    var wSMSMessage = db.SMSMessage.Where(s => s.HomePhone == phoneId
            //        && s.ChatRoomStatus == (int)WebChat.Common.Enumerations.ChatRoomStatus.Active
            //        ).FirstOrDefault();
            //    if (wSMSMessage != null)

            //        return wSMSMessage;
            //    else
            //        return null;
            //}
        }
    }
}