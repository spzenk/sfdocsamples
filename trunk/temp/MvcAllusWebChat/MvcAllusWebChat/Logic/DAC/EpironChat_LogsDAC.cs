using EpironChatLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChat.Common;
using WebChat.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using WebChat.Common.BE;

namespace WebChat.Logic
{
    public class EpironChat_LogsDAC
    {
        static int? operatorIdConfig = null;
        static int? destinationPhoneId = null;
        static EpironChat_LogsDAC()
        {

            
        }
        internal static void SetSMSConfig()
        {
            if (operatorIdConfig.HasValue == false)
            {
                using (EpironChat_logsDataContext db = new EpironChat_logsDataContext())
                {
                    var x = db.SMSConfig.FirstOrDefault();
                    if (x != null)

                    {
                        var item = db.SMSConfig.FirstOrDefault();
                        operatorIdConfig = item.IdConfig;
                        destinationPhoneId = item.PhoneId;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        internal static int CheckPhoneId(string phoneNumber,String clientName)
        {
            SetSMSConfig();

            Phones wPhones = GetPhoneId(phoneNumber, clientName);

            if (wPhones != null)
                return wPhones.PhoneId;

            wPhones = new Phones();
           
           wPhones.Phone = phoneNumber;
           wPhones.PhoneName = clientName;
           
            using (EpironChat_logsDataContext db = new EpironChat_logsDataContext())
            {
                db.Phones.InsertOnSubmit(wPhones);
                db.SubmitChanges();
                
            }

            return wPhones.PhoneId;
        }
       
       /// <summary>
       /// 
       /// </summary>
       /// <param name="phone"></param>
       /// <param name="clientName"></param>
       /// <returns></returns>
        static Phones GetPhoneId(string phoneNumber, String clientName)
        {

            //String id = String.Concat(clientName, "$", phone);
            EpironChat_logsDataContext db = new EpironChat_logsDataContext();
            var phone = db.Phones.Where(p => p.Phone.Equals(phoneNumber.Trim())
                 ).FirstOrDefault<Phones>();

            if (phone != null)
            {
                //Si esta en null directamtente le seteamos el clientName (este caso no deberia existir pero fisicamente es posible)
                if (String.IsNullOrEmpty( phone.PhoneName))
                {
                    phone.PhoneName = phoneNumber;
                    db.SubmitChanges();
                    return  phone;
                }
                //Actualiza el nombre del cliente si es necesario
                if (phone.PhoneName.Trim().CompareTo(clientName.Trim()) != 0)
                {
                    phone.PhoneName = clientName;
                    db.SubmitChanges();
                }
                return phone;
            }
            else
                return null;
        }

       
         internal static void LeaveChatRoom(int smsId)
         {
             using (EpironChat_logsDataContext db = new EpironChat_logsDataContext())
             {
                 var wSMSMessage = db.SMSMessage.Where(s => s.SMSId == smsId).FirstOrDefault();
                 if (wSMSMessage != null)
                 {
                     wSMSMessage.ChatRoomStatus = (int)Enumerations.ChatRoomStatus.ClosedByOwner;
                     wSMSMessage.CheckOutTime = DateTime.Now;
                     db.SubmitChanges();
                 }

             }
         }

     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneId"></param>
        
        /// <returns></returns>
        internal static SMSMessage GetSSID_IfNotExpired(int phoneId )
        {
            using (EpironChat_logsDataContext db = new EpironChat_logsDataContext())
            {
                var wSMSMessage = db.SMSMessage.Where(s => s.HomePhone == phoneId 
                    && s.ChatRoomStatus == (int)WebChat.Common.Enumerations.ChatRoomStatus.Active
                    ).FirstOrDefault();
                if (wSMSMessage != null)

                    return wSMSMessage;
                else
                    return null;
            }
        }


        /// <summary>
        /// Trae los datos sobre la cuenta de email con que se deben mandar los correos
        /// </summary>
        /// <param name="pChatConfigGuid">id configuración de la cuenta</param>
        /// <returns></returns>
        public static ChatMailSenderBE GetChatMailSenderByCongGuid(Guid pChatConfigGuid)
        {
            ChatMailSenderBE wChatMailSender =null;
            Database database = null;
            int? recordId = null;
            try
            {
                database = DatabaseFactory.CreateDatabase("EpironChatLogConnectionString");
                using (DbCommand cmd = database.GetStoredProcCommand("[Chat].[ChatMailSender_s_ByChatConfigGuid]"))
                {
                    database.AddInParameter(cmd, "ChatConfigGuid", DbType.Guid, pChatConfigGuid);
                    using (IDataReader reader = database.ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            wChatMailSender = new ChatMailSenderBE();

                            if (reader["Email"] != DBNull.Value)
                                wChatMailSender.Email = Convert.ToString(reader["Email"]);

                            if (reader["Password"] != DBNull.Value)
                                wChatMailSender.Password = Convert.ToString(reader["Password"]);

                            if (reader["UserName"] != DBNull.Value)
                                wChatMailSender.UserName = Convert.ToString(reader["UserName"]);

                            if (reader["SMTPServer"] != DBNull.Value)
                                wChatMailSender.SMTPServer = Convert.ToString(reader["SMTPServer"]);

                            if (reader["SMTPPort"] != DBNull.Value)
                                wChatMailSender.SMTPPort = Convert.ToInt32(reader["SMTPPort"]);

                            if (reader["EnableSSL"] != DBNull.Value)
                                wChatMailSender.EnableSSL = Convert.ToBoolean(reader["EnableSSL"]);

                            if (reader["TagStartWith"] != DBNull.Value)
                                wChatMailSender.TagStartWith = Convert.ToString(reader["TagStartWith"]);

                            if (reader["TagEndWith"] != DBNull.Value)
                                wChatMailSender.TagEndWith = Convert.ToString(reader["TagEndWith"]);
                        }
                    }
                }
                return wChatMailSender;
            }
            catch (Exception ex)
            {
                throw SecPortalException.ProcessException(ex, typeof(EpironChatDAC), "EpironChatConnectionString");
            }
        }


       

        /// <summary>
        /// Inserta en ChatMessage
        /// </summary>
        /// <param name="pChatMessage">Entidad a insertar</param>
        /// <returns></returns>
        public static bool InsertChatMessage(WebChat.Common.BE.ChatMessageBE pChatMessage)
        {
            ChatUser wChatUser = new ChatUser();
            Database database = null;
            int newId = 0;
            try
            {
                database = DatabaseFactory.CreateDatabase("EpironChatLogConnectionString");
                using (DbCommand cmd = database.GetStoredProcCommand("[Chat].[ChatMessage]"))
                {
                    database.AddInParameter(cmd, "ChatMessage", DbType.String, pChatMessage.ChatMessageText);
                    database.AddInParameter(cmd, "ChatRoomId", DbType.Int32, pChatMessage.ChatRoomId);
                    database.AddInParameter(cmd, "ChatUserId", DbType.Int32, pChatMessage.ChatUserId);
                    newId = (int)database.ExecuteScalar(cmd);
                    if (newId > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw SecPortalException.ProcessException(ex, typeof(EpironChatDAC), "EpironChatConnectionString");
            }
        }
    }
}