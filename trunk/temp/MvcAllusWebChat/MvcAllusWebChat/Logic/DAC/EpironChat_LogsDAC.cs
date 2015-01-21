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


      
    }
}