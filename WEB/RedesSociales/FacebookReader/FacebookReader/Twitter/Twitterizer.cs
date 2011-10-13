using System;
using System.Collections.Generic;

using System.Net;
using System.Linq;
using System.Text;
using Fwk.SocialNetworks.Config;
using Twitterizer;


namespace Fwk.SocialNetworks.Twitter
{
    public class TwitterizerWrap
    {
        #region [Members]


        /// <summary>
        /// Proxy de la red para hacer el request HTTP, puede estar en null
        /// </summary>
        public static WebProxy Proxy = null;

        
       static TwitterConfig configSection;


        public static TwitterConfig Config
        {
            get { return configSection; }
        }

        static TwitterizerWrap()
        {
            
            try
            {
                configSection = (System.Configuration.ConfigurationManager.GetSection("TwitterConfig") as TwitterConfig);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar levantar la configuración de la seccion [TwitterConfig] de Twitter", ex);
            }

            if (configSection.Proxy != null)
            {
                if (configSection.Proxy.IsBypassed)
                {
                    WebProxy wWebProxy = new WebProxy(configSection.Proxy.Name, configSection.Proxy.Port);

                    wWebProxy.Credentials = new System.Net.NetworkCredential(configSection.Proxy.UserName, configSection.Proxy.Password, configSection.Proxy.Domain);


                    Proxy = wWebProxy;
                }
            }
        }
        OAuthTokens _OAuthTokens;
        
        #endregion

        #region [Constructors]

        public TwitterizerWrap()
        {
            _OAuthTokens = TwitterizerWrap.Config.GetOAuthTokens(TwitterizerWrap.Config.DefaultProvider.Name);
        }

       

        #endregion

        

        #region [Private Methods]

        private TwitterStatusCollection GetStatuses(decimal? pSinceStatusId, decimal? pMaxStatusId)
        {
            //Verifica si el restante de consultas permitidas es menor al minimo configurado.
            //Y es menor. Deja de consultar y devuelve una colección vacia para que deje de buscar.
            if (this.HasExceededLimit()) { return new TwitterStatusCollection(); }
           

            UserTimelineOptions wUserTimelineOptions = new UserTimelineOptions();
            wUserTimelineOptions.Count = TwitterizerWrap.Config.StatusesCount;
            wUserTimelineOptions.IncludeRetweets = true;
            wUserTimelineOptions.Proxy = TwitterizerWrap.Proxy;

            if (pMaxStatusId.HasValue)
            {
                wUserTimelineOptions.MaxStatusId = pMaxStatusId.Value;
            }

            if (pSinceStatusId.HasValue)
            {
                wUserTimelineOptions.SinceStatusId = pSinceStatusId.Value;
            }

            TwitterStatusCollection result = TwitterTimeline.UserTimeline(_OAuthTokens, wUserTimelineOptions).ResponseObject;

            if (result == null) { this.CheckForErrors(); }

            return result;
        }

        private TwitterStatusCollection GetMentions(decimal? pSinceStatusId, decimal? pMaxStatusId)
        {
            //Verifica si el restante de consultas permitidas es menor al minimo configurado.
            //Y es menor. Deja de consultar y devuelve una colección vacia para que deje de buscar.
            if (this.HasExceededLimit()) { return new TwitterStatusCollection(); }

            TimelineOptions wTimelineOptions = new TimelineOptions();
            wTimelineOptions.Count = TwitterizerWrap.Config.StatusesCount;
            wTimelineOptions.IncludeRetweets = true;
            wTimelineOptions.Proxy = TwitterizerWrap.Proxy;

            if (pMaxStatusId.HasValue)
            {
                wTimelineOptions.MaxStatusId = pMaxStatusId.Value;
            }

            if (pSinceStatusId.HasValue)
            {
                wTimelineOptions.SinceStatusId = pSinceStatusId.Value;
            }

            TwitterStatusCollection result = TwitterTimeline.Mentions(_OAuthTokens, wTimelineOptions).ResponseObject;

            if (result == null) { this.CheckForErrors(); }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSinceStatusId"></param>
        /// <param name="pMaxStatusId"></param>
        /// <returns></returns>
        private TwitterDirectMessageCollection GetDirectMessages(decimal? pSinceStatusId, decimal? pMaxStatusId)
        {
            //Verifica si el restante de consultas permitidas es menor al minimo configurado.
            //Y es menor. Deja de consultar y devuelve una colección vacia para que deje de buscar.
            if (this.HasExceededLimit()) { return new TwitterDirectMessageCollection(); }

            DirectMessagesOptions wDirectMessagesOptions = new DirectMessagesOptions() { Proxy = TwitterizerWrap.Proxy };

            if (pMaxStatusId.HasValue)
            {
                wDirectMessagesOptions.MaxStatusId = pMaxStatusId.Value;
            }

            if (pSinceStatusId.HasValue)
            {
                wDirectMessagesOptions.SinceStatusId = pSinceStatusId.Value;
            }
            TwitterResponse<TwitterDirectMessageCollection> result = TwitterDirectMessage.DirectMessages(_OAuthTokens, wDirectMessagesOptions);
            
            if (result == null) { this.CheckForErrors(); }

            return result.ResponseObject;
        }

        private TwitterDirectMessageCollection GetDirectMessagesSent(decimal? pSinceStatusId, decimal? pMaxStatusId)
        {
            //Verifica si el restante de consultas permitidas es menor al minimo configurado.
            //Y es menor. Deja de consultar y devuelve una colección vacia para que deje de buscar.
            if (this.HasExceededLimit()) { return new TwitterDirectMessageCollection(); }

            DirectMessagesSentOptions wDirectMessagesSentOptions = new DirectMessagesSentOptions() { Proxy = TwitterizerWrap.Proxy };

            if (pMaxStatusId.HasValue)
            {
                wDirectMessagesSentOptions.MaxStatusId = pMaxStatusId.Value;
            }

            if (pSinceStatusId.HasValue)
            {
                wDirectMessagesSentOptions.SinceStatusId = pSinceStatusId.Value;
            }

            TwitterDirectMessageCollection result = TwitterDirectMessage.DirectMessagesSent(_OAuthTokens, wDirectMessagesSentOptions).ResponseObject;

            if (result == null) { this.CheckForErrors(); }

            return result;
        }

        public List<TwitterSavedSearch> Get_SavedSearches()
        {
            DirectMessagesSentOptions wDirectMessagesSentOptions = new DirectMessagesSentOptions() { Proxy = TwitterizerWrap.Proxy };
            TwitterResponse<TwitterSavedSearchCollection> result = TwitterSavedSearch.SavedSearches(_OAuthTokens, wDirectMessagesSentOptions);
            if (result == null) { this.CheckForErrors(); }
            return result.ResponseObject.ToList<TwitterSavedSearch>();
        }

        /// <summary>
        /// sample: _Twitterizer.Search(txtSearch.Text, 124444492202909696, null);
        /// </summary>
        /// <param name="query"></param>
        /// <param name="sinceId"></param>
        /// <param name="pMaxId"></param>
        /// <returns></returns>
        public List<TwitterSearchResult> Search(string query, decimal? sinceId, decimal? pMaxId)
        {
            SearchOptions opt = new SearchOptions() { Proxy = TwitterizerWrap.Proxy };

            if (sinceId.HasValue)
                opt.SinceId = (long)sinceId.Value;

            if (pMaxId.HasValue)
                opt.MaxId = (long)pMaxId.Value;

            TwitterResponse<TwitterSearchResultCollection> result = TwitterSearch.Search(_OAuthTokens, query, opt);

            if (result == null) { this.CheckForErrors(); }

            return result.ResponseObject.ToList<TwitterSearchResult>();
        }
        private bool HasExceededLimit()
        {
            return (this.GetRateLimitStatus().RemainingHits < TwitterizerWrap.Config.MinRemainingHits);
        }

       

        #endregion

        #region [Public Methods]

        public TwitterUser GetUser(decimal userId)
        {
            OptionalProperties wOptionalProperties;
            wOptionalProperties = new OptionalProperties();
            wOptionalProperties.Proxy = TwitterizerWrap.Proxy;

            TwitterUser wTwitterUser = TwitterUser.Show(_OAuthTokens, userId, wOptionalProperties).ResponseObject;

            if (wTwitterUser == null) { this.CheckForErrors(); }

            return wTwitterUser;
        }

        public TwitterUser GetUser(string userName)
        {
            OptionalProperties wOptionalProperties;
            wOptionalProperties = new OptionalProperties();
            wOptionalProperties.Proxy = TwitterizerWrap.Proxy;

            TwitterUser wTwitterUser = TwitterUser.Show(_OAuthTokens, userName, wOptionalProperties).ResponseObject;

            if (wTwitterUser == null) { this.CheckForErrors(); }

            return wTwitterUser;
        }
        
        public List<TwitterStatus> GetAllUserMentions(decimal? pSinceStatusId, DateTime logSince)
        {
            TwitterStatusCollection wTwitterStatusCollection;
            List<TwitterStatus> wList = new List<TwitterStatus>();
            List<TwitterStatus> wTempList = new List<TwitterStatus>();

            wTwitterStatusCollection = this.GetMentions(pSinceStatusId, null);

            if (wTwitterStatusCollection != null)
            {
                wTempList.AddRange(wTwitterStatusCollection);
            }

            while (wTempList.Count > 0)
            {
                wList.AddRange(wTempList);

                decimal wMaxStatusId = wTempList.Last().Id;

                wTempList.Clear();

                wTwitterStatusCollection = this.GetMentions(pSinceStatusId, wMaxStatusId);

                if (wTwitterStatusCollection != null && wTwitterStatusCollection.Count > 0)
                {
                    wTempList.AddRange(wTwitterStatusCollection);

                    wTempList.Remove(wTempList.First());

                    wTempList.RemoveAll(r => r.CreatedDate < logSince);
                }
            }

            return wList;
        }

        public List<TwitterStatus> GetAllUserStatuses(decimal? pSinceStatusId, DateTime logSince)
        {
            TwitterStatusCollection wTwitterStatusCollection;
            List<TwitterStatus> wList = new List<TwitterStatus>();
            List<TwitterStatus> wTempList = new List<TwitterStatus>();

            wTwitterStatusCollection = this.GetStatuses(pSinceStatusId, null);

            if (wTwitterStatusCollection != null)
            {
                wTempList.AddRange(wTwitterStatusCollection);
            }

            while (wTempList.Count > 0)
            {
                wList.AddRange(wTempList);

                decimal wMaxStatusId = wTempList.Last().Id;

                wTempList.Clear();

                wTwitterStatusCollection = this.GetStatuses(pSinceStatusId, wMaxStatusId);

                if (wTwitterStatusCollection != null && wTwitterStatusCollection.Count > 0)
                {
                    wTempList.AddRange(wTwitterStatusCollection);

                    wTempList.Remove(wTempList.First());

                    wTempList.RemoveAll(r => r.CreatedDate < logSince);
                }
            }

            return wList;
        }

        public List<TwitterDirectMessage> GetAllUserMessages(decimal? pSinceStatusId, DateTime logSince)
        {
            TwitterDirectMessageCollection wTwitterDirectMessageCollection;
            List<TwitterDirectMessage> wList = new List<TwitterDirectMessage>();
            List<TwitterDirectMessage> wTempList = new List<TwitterDirectMessage>();

            wTwitterDirectMessageCollection = this.GetDirectMessages(pSinceStatusId, null);

            if (wTwitterDirectMessageCollection != null)
            {
                wTempList.AddRange(wTwitterDirectMessageCollection);
            }

            while (wTempList.Count > 0)
            {
                wList.AddRange(wTempList);

                decimal wMaxStatusId = wTempList.Last().Id;

                wTempList.Clear();

                wTwitterDirectMessageCollection = this.GetDirectMessages(pSinceStatusId, wMaxStatusId);

                if (wTwitterDirectMessageCollection != null && wTwitterDirectMessageCollection.Count > 0)
                {
                    wTempList.AddRange(wTwitterDirectMessageCollection);

                    wTempList.Remove(wTempList.First());

                    wTempList.RemoveAll(r => r.CreatedDate < logSince);
                }
            }

            return wList;
        }

        public List<TwitterDirectMessage> GetAllUserMessagesSent(decimal? pSinceStatusId, DateTime logSince)
        {
            TwitterDirectMessageCollection wTwitterDirectMessageCollection;
            List<TwitterDirectMessage> wList = new List<TwitterDirectMessage>();
            List<TwitterDirectMessage> wTempList = new List<TwitterDirectMessage>();

            wTwitterDirectMessageCollection = this.GetDirectMessagesSent(pSinceStatusId, null);

            if (wTwitterDirectMessageCollection != null)
            {
                wTempList.AddRange(wTwitterDirectMessageCollection);
            }

            while (wTempList.Count > 0)
            {
                wList.AddRange(wTempList);

                decimal wMaxStatusId = wTempList.Last().Id;

                wTempList.Clear();

                wTwitterDirectMessageCollection = this.GetDirectMessagesSent(pSinceStatusId, wMaxStatusId);

                if (wTwitterDirectMessageCollection != null && wTwitterDirectMessageCollection.Count > 0)
                {
                    wTempList.AddRange(wTwitterDirectMessageCollection);

                    wTempList.Remove(wTempList.First());

                    wTempList.RemoveAll(r => r.CreatedDate < logSince);
                }
            }

            return wList;
        }
           
        
        public TwitterRateLimitStatus GetRateLimitStatus()
        {
            OptionalProperties wOptionalProperties = new OptionalProperties() { Proxy = TwitterizerWrap.Proxy };
            return TwitterRateLimitStatus.GetStatus(_OAuthTokens, wOptionalProperties).ResponseObject;
        }



        public void CheckForErrors()
        {
           


            
            //if (global::Twitterizer.RequestStatus.LastRequestStatus.Status != RequestResult.Success)
            //{
            //    string errorMessage = null;

            //    string status = global::Twitterizer.RequestStatus.LastRequestStatus.Status.ToString();

            //    if (global::Twitterizer.RequestStatus.LastRequestStatus.ErrorDetails != null)
            //    {
            //        errorMessage = global::Twitterizer.RequestStatus.LastRequestStatus.ErrorDetails.ErrorMessage;
            //    }

            //    throw new Exception(string.Format("{0}: {1}", status, errorMessage));
            //}
        }

        /// <summary>
        /// Actualiza el status del usuario autenticado.
        /// </summary>
        /// <param name="pText">Texto del status, inferior a 140 caracteres.</param>
        /// <param name="pInReplayToStatudId">Opcional: Identificador del status padre a responder.</param>
        /// <remarks>
        /// Si el status es una respuesta, ademas del identificador del status padre a 
        /// responder, debe contener la mencion del usuario remitente del mensaje padre.
        /// </remarks>
        /// <returns>El status creado.</returns>
        public TwitterStatus Update(string pText, decimal? pInReplayToStatudId)
        {
            StatusUpdateOptions wStatusUpdateOptions = new StatusUpdateOptions() { Proxy = TwitterizerWrap.Proxy };

            if (pInReplayToStatudId.HasValue)
            {

                wStatusUpdateOptions.InReplyToStatusId = pInReplayToStatudId.Value;
            }

            TwitterResponse<TwitterStatus> wTwitterStatus = TwitterStatus.Update(_OAuthTokens, pText, wStatusUpdateOptions);

            this.CheckForErrors();

            return wTwitterStatus.ResponseObject;
        }

        /// <summary>
        /// Envia un mensaje directo al identificador del usuario recibido por parametro
        /// </summary>
        /// <param name="pUserId">Identificador del usuario</param>
        /// <param name="pText">Texto del mensaje, inferior a 140 caracteres.</param>
        /// <returns>El mensaje directo enviado.</returns>
        public TwitterDirectMessage SendDirectMessage(decimal pUserId, string pText)
        {
            OptionalProperties wOptionalProperties = new OptionalProperties() { Proxy = TwitterizerWrap.Proxy };

            TwitterResponse<TwitterDirectMessage> wTwitterDirectMessage = TwitterDirectMessage.Send(_OAuthTokens, pUserId, pText, wOptionalProperties);

            this.CheckForErrors();

            return wTwitterDirectMessage.ResponseObject;
        }

        /// <summary>
        /// Envia un mensaje directo al screen name del usuario recibido por parametro.
        /// </summary>
        /// <param name="pScreenName">Screen Name del usuario</param>
        /// <param name="pText">Texto del mensaje, inferior a 140 caracteres.</param>        
        /// <returns>El mensaje directo enviado.</returns>
        public TwitterDirectMessage SendDirectMessage(string pScreenName, string pText)
        {
            OptionalProperties wOptionalProperties = new OptionalProperties() { Proxy = TwitterizerWrap.Proxy };

            TwitterResponse<TwitterDirectMessage> wTwitterDirectMessage = TwitterDirectMessage.Send(_OAuthTokens, pScreenName, pText, wOptionalProperties);

            this.CheckForErrors();

            return wTwitterDirectMessage.ResponseObject;
        }

        #endregion
    }
}