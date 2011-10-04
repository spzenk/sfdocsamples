//using System;
//using System.Collections.Generic;

//using Fwk.SocialNetworks.Config;
//using System.Net;
//using System.Linq;
//using System.Text;
//using TweetSharp.Twitter.Fluent;
//using TweetSharp.Twitter.Model;
//using TweetSharp.Extensions;
//using TweetSharp.Twitter.Extensions;
//using TweetSharp;

//namespace Fwk.SocialNetworks.Twitter
//{
//    public class TwitterWrapper
//    {
//        #region [Members]


//        /// <summary>
//        /// Proxy de la red para hacer el request HTTP, puede estar en null
//        /// </summary>
//        public static WebProxy Proxy = null;

        
//       static TwitterConfig configSection;


//        public static TwitterConfig Config
//        {
//            get { return configSection; }
//        }

//        static TwitterWrapper()
//        {
            
//            try
//            {
//                configSection = (System.Configuration.ConfigurationManager.GetSection("TwitterConfig") as TwitterConfig);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error al intentar levantar la configuración de la seccion [TwitterConfig] de Twitter", ex);
//            }

//            if (configSection.Proxy != null)
//            {
//                if (configSection.Proxy.IsBypassed)
//                {
//                    WebProxy wWebProxy = new WebProxy(configSection.Proxy.Name, configSection.Proxy.Port);

//                    wWebProxy.Credentials = new System.Net.NetworkCredential(configSection.Proxy.UserName, configSection.Proxy.Password, configSection.Proxy.Domain);


//                    TwitterWrapper.Proxy = wWebProxy;
//                }
//            }
//        }
//        #endregion

 

    

      


//        #region [Private Methods]

//        private static TwitterStatusCollection GetStatuses(decimal? pSinceStatusId, decimal? pMaxStatusId,string providerName)
//        {
//            //Verifica si el restante de consultas permitidas es menor al minimo configurado.
//            //Y es menor. Deja de consultar y devuelve una colección vacia para que deje de buscar.
//            if (HasExceededLimit(providerName)) { return new TwitterStatusCollection(); }

//            TimelineOptions wTimelineOptions = new TimelineOptions();
//            wTimelineOptions.Count = configSection.StatusesCount;
//            wTimelineOptions.IncludeRetweets = true;
//            wTimelineOptions.Proxy = Proxy;

//            if (pMaxStatusId.HasValue)
//            {
//                wTimelineOptions.MaxStatusId = pMaxStatusId.Value;
//            }

//            if (pSinceStatusId.HasValue)
//            {
//                wTimelineOptions.SinceStatusId = pSinceStatusId.Value;
//            }

//            TwitterStatusCollection result = TwitterTimeline.UserTimeline(configSection.GetOAuthTokens(providerName), wTimelineOptions);

//            if (result == null) {CheckForErrors(); }

//            return result;
//        }

//        private static TwitterStatusCollection GetMentions(decimal? pSinceStatusId, decimal? pMaxStatusId, string providerName)
//        {
//            //Verifica si el restante de consultas permitidas es menor al minimo configurado.
//            //Y es menor. Deja de consultar y devuelve una colección vacia para que deje de buscar.
//            if (HasExceededLimit(providerName)) { return new TwitterStatusCollection(); }

//            TimelineOptions wTimelineOptions = new TimelineOptions();
//            wTimelineOptions.Count = configSection.StatusesCount;
//            wTimelineOptions.IncludeRetweets = true;
//            wTimelineOptions.Proxy = Proxy;

//            if (pMaxStatusId.HasValue)
//            {
//                wTimelineOptions.MaxStatusId = pMaxStatusId.Value;
//            }

//            if (pSinceStatusId.HasValue)
//            {
//                wTimelineOptions.SinceStatusId = pSinceStatusId.Value;
//            }

//            TwitterStatusCollection result = TwitterTimeline.Mentions(configSection.GetOAuthTokens(providerName), wTimelineOptions);

//            if (result == null) {CheckForErrors(); }

//            return result;
//        }

//        private static TwitterDirectMessageCollection GetDirectMessages(decimal? pSinceStatusId, decimal? pMaxStatusId, string providerName)
//        {
//            //Verifica si el restante de consultas permitidas es menor al minimo configurado.
//            //Y es menor. Deja de consultar y devuelve una colección vacia para que deje de buscar.
//            if (HasExceededLimit(providerName)) { return new TwitterDirectMessageCollection(); }

//            DirectMessagesOptions wDirectMessagesOptions = new DirectMessagesOptions() { Proxy = Proxy };

//            if (pMaxStatusId.HasValue)
//            {
//                wDirectMessagesOptions.MaxStatusId = pMaxStatusId.Value;
//            }

//            if (pSinceStatusId.HasValue)
//            {
//                wDirectMessagesOptions.SinceStatusId = pSinceStatusId.Value;
//            }

//            TwitterDirectMessageCollection result = TwitterDirectMessage.DirectMessages(configSection.GetOAuthTokens(providerName), wDirectMessagesOptions);

//            if (result == null) { CheckForErrors(); }

//            return result;
//        }

//        private static TwitterDirectMessageCollection GetDirectMessagesSent(decimal? pSinceStatusId, decimal? pMaxStatusId,string providerName)
//        {
//            //Verifica si el restante de consultas permitidas es menor al minimo configurado.
//            //Y es menor. Deja de consultar y devuelve una colección vacia para que deje de buscar.
//            if (HasExceededLimit(providerName)) { return new TwitterDirectMessageCollection(); }

//            DirectMessagesSentOptions wDirectMessagesSentOptions = new DirectMessagesSentOptions() { Proxy = Proxy };

//            if (pMaxStatusId.HasValue)
//            {
//                wDirectMessagesSentOptions.MaxStatusId = pMaxStatusId.Value;
//            }

//            if (pSinceStatusId.HasValue)
//            {
//                wDirectMessagesSentOptions.SinceStatusId = pSinceStatusId.Value;
//            }

//            TwitterDirectMessageCollection result = TwitterDirectMessage.DirectMessagesSent(configSection.GetOAuthTokens(providerName), wDirectMessagesSentOptions);

//            if (result == null) { CheckForErrors(); }

//            return result;
//        }

//        private static bool HasExceededLimit(string providerName)
//        {
//            return (GetRateLimitStatus(providerName).RemainingHits < configSection.MinRemainingHits);
//        }

       

//        #endregion

//        #region [Public Methods]

//        public static TwitterUser GetUser(decimal userId,string providerName)
//        {
//            OptionalProperties wOptionalProperties;
//            wOptionalProperties = new OptionalProperties();
//            wOptionalProperties.Proxy = Proxy;

//            TwitterUser wTwitterUser = TwitterUser.Show(configSection.GetOAuthTokens(providerName), userId, wOptionalProperties);

//            if (wTwitterUser == null) { CheckForErrors(); }

//            return wTwitterUser;
//        }

//        public static TwitterUser GetUser(string userName,string providerName)
//        {
//            OptionalProperties wOptionalProperties;
//            wOptionalProperties = new OptionalProperties();
//            wOptionalProperties.Proxy = Proxy;

//            TwitterUser wTwitterUser = TwitterUser.Show(configSection.GetOAuthTokens(providerName), userName, wOptionalProperties);

//            if (wTwitterUser == null) { CheckForErrors(); }

//            return wTwitterUser;
//        }

//        public static List<TwitterStatus> GetAllUserMentions(decimal? pSinceStatusId, DateTime logSince, string providerName)
//        {
//            TwitterStatusCollection wTwitterStatusCollection;
//            List<TwitterStatus> wList = new List<TwitterStatus>();
//            List<TwitterStatus> wTempList = new List<TwitterStatus>();

//            wTwitterStatusCollection = GetMentions(pSinceStatusId, null, providerName);

//            if (wTwitterStatusCollection != null)
//            {
//                wTempList.AddRange(wTwitterStatusCollection);
//            }

//            while (wTempList.Count > 0)
//            {
//                wList.AddRange(wTempList);

//                decimal wMaxStatusId = wTempList.Last().Id;

//                wTempList.Clear();

//                wTwitterStatusCollection = GetMentions(pSinceStatusId, wMaxStatusId, providerName);

//                if (wTwitterStatusCollection != null && wTwitterStatusCollection.Count > 0)
//                {
//                    wTempList.AddRange(wTwitterStatusCollection);

//                    wTempList.Remove(wTempList.First());

//                    wTempList.RemoveAll(r => r.CreatedDate < logSince);
//                }
//            }

//            return wList;
//        }

//        public static List<TwitterStatus> GetAllUserStatuses(decimal? pSinceStatusId, DateTime logSince, string providerName)
//        {
//            TwitterStatusCollection wTwitterStatusCollection;
//            List<TwitterStatus> wList = new List<TwitterStatus>();
//            List<TwitterStatus> wTempList = new List<TwitterStatus>();

//            wTwitterStatusCollection = GetStatuses(pSinceStatusId, null, providerName);

//            if (wTwitterStatusCollection != null)
//            {
//                wTempList.AddRange(wTwitterStatusCollection);
//            }

//            while (wTempList.Count > 0)
//            {
//                wList.AddRange(wTempList);

//                decimal wMaxStatusId = wTempList.Last().Id;

//                wTempList.Clear();

//                wTwitterStatusCollection = GetStatuses(pSinceStatusId, wMaxStatusId, providerName);

//                if (wTwitterStatusCollection != null && wTwitterStatusCollection.Count > 0)
//                {
//                    wTempList.AddRange(wTwitterStatusCollection);

//                    wTempList.Remove(wTempList.First());

//                    wTempList.RemoveAll(r => r.CreatedDate < logSince);
//                }
//            }

//            return wList;
//        }

//        public static List<TwitterDirectMessage> GetAllUserMessages(decimal? pSinceStatusId, DateTime logSince,string providerName)
//        {
//            TwitterDirectMessageCollection wTwitterDirectMessageCollection;
//            List<TwitterDirectMessage> wList = new List<TwitterDirectMessage>();
//            List<TwitterDirectMessage> wTempList = new List<TwitterDirectMessage>();

//            wTwitterDirectMessageCollection = GetDirectMessages(pSinceStatusId, null, providerName);

//            if (wTwitterDirectMessageCollection != null)
//            {
//                wTempList.AddRange(wTwitterDirectMessageCollection);
//            }

//            while (wTempList.Count > 0)
//            {
//                wList.AddRange(wTempList);

//                decimal wMaxStatusId = wTempList.Last().Id;

//                wTempList.Clear();

//                wTwitterDirectMessageCollection = GetDirectMessagesSent(pSinceStatusId, wMaxStatusId, providerName);

//                if (wTwitterDirectMessageCollection != null && wTwitterDirectMessageCollection.Count > 0)
//                {
//                    wTempList.AddRange(wTwitterDirectMessageCollection);

//                    wTempList.Remove(wTempList.First());

//                    wTempList.RemoveAll(r => r.CreatedDate < logSince);
//                }
//            }

//            return wList;
//        }

//        public static List<TwitterDirectMessage> GetAllUserMessagesSent(decimal? pSinceStatusId, DateTime logSince,string providerName)
//        {
//            TwitterDirectMessageCollection wTwitterDirectMessageCollection;
//            List<TwitterDirectMessage> wList = new List<TwitterDirectMessage>();
//            List<TwitterDirectMessage> wTempList = new List<TwitterDirectMessage>();

//            wTwitterDirectMessageCollection = GetDirectMessagesSent(pSinceStatusId, null, providerName);

//            if (wTwitterDirectMessageCollection != null)
//            {
//                wTempList.AddRange(wTwitterDirectMessageCollection);
//            }

//            while (wTempList.Count > 0)
//            {
//                wList.AddRange(wTempList);

//                decimal wMaxStatusId = wTempList.Last().Id;

//                wTempList.Clear();

//                wTwitterDirectMessageCollection = GetDirectMessagesSent(pSinceStatusId, wMaxStatusId,providerName);

//                if (wTwitterDirectMessageCollection != null && wTwitterDirectMessageCollection.Count > 0)
//                {
//                    wTempList.AddRange(wTwitterDirectMessageCollection);

//                    wTempList.Remove(wTempList.First());

//                    wTempList.RemoveAll(r => r.CreatedDate < logSince);
//                }
//            }

//            return wList;
//        }

//        public static TwitterRateLimitStatus GetRateLimitStatus(string providerName)
//        {
//            OptionalProperties wOptionalProperties = new OptionalProperties() { Proxy = Proxy };
//            return TwitterRateLimitStatus.GetStatus(configSection.GetOAuthTokens(providerName), wOptionalProperties);
//        }

//        public static void CheckForErrors()
//        {
//            if (global::Twitterizer.RequestStatus.LastRequestStatus.Status != RequestResult.Success)
//            {
//                string errorMessage = null;

//                string status = global::Twitterizer.RequestStatus.LastRequestStatus.Status.ToString();

//                if (global::Twitterizer.RequestStatus.LastRequestStatus.ErrorDetails != null)
//                {
//                    errorMessage = global::Twitterizer.RequestStatus.LastRequestStatus.ErrorDetails.ErrorMessage;
//                }

//                throw new Exception(string.Format("{0}: {1}", status, errorMessage));
//            }
//        }

//        /// <summary>
//        /// Actualiza el status del usuario autenticado.
//        /// </summary>
//        /// <param name="pText">Texto del status, inferior a 140 caracteres.</param>
//        /// <param name="pInReplayToStatudId">Opcional: Identificador del status padre a responder.</param>
//        /// <remarks>
//        /// Si el status es una respuesta, ademas del identificador del status padre a 
//        /// responder, debe contener la mencion del usuario remitente del mensaje padre.
//        /// </remarks>
//        /// <returns>El status creado.</returns>
//        public static TwitterStatus Update(string pText, decimal? pInReplayToStatudId, string providerName)
//        {
//            StatusUpdateOptions wStatusUpdateOptions = new StatusUpdateOptions() { Proxy = Proxy };

//            if (pInReplayToStatudId.HasValue)
//            {

//                wStatusUpdateOptions.InReplyToStatusId = pInReplayToStatudId.Value;
//            }

//            TwitterStatus wTwitterStatus = TwitterStatus.Update(configSection.GetOAuthTokens(providerName), pText, wStatusUpdateOptions);

//            CheckForErrors();

//            return wTwitterStatus;
//        }

//        /// <summary>
//        /// Envia un mensaje directo al identificador del usuario recibido por parametro
//        /// </summary>
//        /// <param name="pUserId">Identificador del usuario</param>
//        /// <param name="pText">Texto del mensaje, inferior a 140 caracteres.</param>
//        /// <returns>El mensaje directo enviado.</returns>
//        public static TwitterDirectMessage SendDirectMessage(decimal pUserId, string pText,string providerName)
//        {
//            OptionalProperties wOptionalProperties = new OptionalProperties() { Proxy = Proxy };

//            TwitterDirectMessage wTwitterDirectMessage = TwitterDirectMessage.Send(configSection.GetOAuthTokens(providerName), pUserId, pText, wOptionalProperties);

//            CheckForErrors();

//            return wTwitterDirectMessage;
//        }

//        /// <summary>
//        /// Envia un mensaje directo al screen name del usuario recibido por parametro.
//        /// </summary>
//        /// <param name="pScreenName">Screen Name del usuario</param>
//        /// <param name="pText">Texto del mensaje, inferior a 140 caracteres.</param>        
//        /// <returns>El mensaje directo enviado.</returns>
//        public static TwitterDirectMessage SendDirectMessage(string pScreenName, string pText,string providerName)
//        {
//            OptionalProperties wOptionalProperties = new OptionalProperties() { Proxy = Proxy };

//            TwitterDirectMessage wTwitterDirectMessage = TwitterDirectMessage.Send(configSection.GetOAuthTokens(providerName), pScreenName, pText, wOptionalProperties);

//            CheckForErrors();

//            return wTwitterDirectMessage;
//        }

//        #endregion
//    }
//}