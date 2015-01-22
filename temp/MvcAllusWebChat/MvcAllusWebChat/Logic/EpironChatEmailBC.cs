using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChat.Common.BE;
using WebChat.Logic.DAC;

namespace WebChat.Logic.BC
{
    public class EpironChatEmailBC
    {
        public static ChatMailSenderBE GetChatMailSenderByCongGuid(Guid configGuid)
        {
            return  EpironChatEmail_LogsDAC.GetChatMailSenderByCongGuid(configGuid);
        }

        public static ChatUserBE GetChatUserByParams(int? pChatUserId, string pClientPhone)
        {
            return ChatUserDAC.GetByParams(pChatUserId, pClientPhone);
        }

        public static bool InsertChatEmailMessage(ChatEmailMessageBE pChatEmailMessageBE)
        {
            return EpironChatEmail_LogsDAC.InsertChatEmailMessage(pChatEmailMessageBE);
        }
    }
}