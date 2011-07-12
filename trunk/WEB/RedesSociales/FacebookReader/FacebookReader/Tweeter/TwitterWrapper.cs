using System;
using System.Collections.Generic;

using Fwk.SocialNetworks.Twitter.Configuration;
using System.Net;
using System.Linq;
using System.Text;
using Twitterizer;

namespace Fwk.SocialNetworks.Twitter
{
    public class TwitterWrapper
    {
        #region [Members]

        WebProxy _WebProxy;
        OAuthTokens _OAuthTokens;
        TwitterConfigElement _DefaultProvider;
        TwitterConfig _TwitterConfigSection;

        #endregion

 

    

        public TwitterWrapper(WebProxy proxy)
        {
            _WebProxy = proxy;

            this.InitializeClass();
        }



        #region [Private Methods]

        private TwitterStatusCollection GetStatuses(decimal? pSinceStatusId, decimal? pMaxStatusId)
        {
            //Verifica si el restante de consultas permitidas es menor al minimo configurado.
            //Y es menor. Deja de consultar y devuelve una colección vacia para que deje de buscar.
            if (this.HasExceededLimit()) { return new TwitterStatusCollection(); }

            TimelineOptions wTimelineOptions = new TimelineOptions();
            wTimelineOptions.Count = _TwitterConfigSection.StatusesCount;
            wTimelineOptions.IncludeRetweets = true;
            wTimelineOptions.Proxy = _WebProxy;

            if (pMaxStatusId.HasValue)
            {
                wTimelineOptions.MaxStatusId = pMaxStatusId.Value;
            }

            if (pSinceStatusId.HasValue)
            {
                wTimelineOptions.SinceStatusId = pSinceStatusId.Value;
            }

            TwitterStatusCollection result = TwitterTimeline.UserTimeline(_OAuthTokens, wTimelineOptions);

            if (result == null) { this.CheckForErrors(); }

            return result;
        }

        private TwitterStatusCollection GetMentions(decimal? pSinceStatusId, decimal? pMaxStatusId)
        {
            //Verifica si el restante de consultas permitidas es menor al minimo configurado.
            //Y es menor. Deja de consultar y devuelve una colección vacia para que deje de buscar.
            if (this.HasExceededLimit()) { return new TwitterStatusCollection(); }

            TimelineOptions wTimelineOptions = new TimelineOptions();
            wTimelineOptions.Count = _TwitterConfigSection.StatusesCount;
            wTimelineOptions.IncludeRetweets = true;
            wTimelineOptions.Proxy = _WebProxy;

            if (pMaxStatusId.HasValue)
            {
                wTimelineOptions.MaxStatusId = pMaxStatusId.Value;
            }

            if (pSinceStatusId.HasValue)
            {
                wTimelineOptions.SinceStatusId = pSinceStatusId.Value;
            }

            TwitterStatusCollection result = TwitterTimeline.Mentions(_OAuthTokens, wTimelineOptions);

            if (result == null) { this.CheckForErrors(); }

            return result;
        }

        private TwitterDirectMessageCollection GetDirectMessages(decimal? pSinceStatusId, decimal? pMaxStatusId)
        {
            //Verifica si el restante de consultas permitidas es menor al minimo configurado.
            //Y es menor. Deja de consultar y devuelve una colección vacia para que deje de buscar.
            if (this.HasExceededLimit()) { return new TwitterDirectMessageCollection(); }

            DirectMessagesOptions wDirectMessagesOptions = new DirectMessagesOptions() { Proxy = _WebProxy };

            if (pMaxStatusId.HasValue)
            {
                wDirectMessagesOptions.MaxStatusId = pMaxStatusId.Value;
            }

            if (pSinceStatusId.HasValue)
            {
                wDirectMessagesOptions.SinceStatusId = pSinceStatusId.Value;
            }

            TwitterDirectMessageCollection result = TwitterDirectMessage.DirectMessages(_OAuthTokens, wDirectMessagesOptions);

            if (result == null) { this.CheckForErrors(); }

            return result;
        }

        private TwitterDirectMessageCollection GetDirectMessagesSent(decimal? pSinceStatusId, decimal? pMaxStatusId)
        {
            //Verifica si el restante de consultas permitidas es menor al minimo configurado.
            //Y es menor. Deja de consultar y devuelve una colección vacia para que deje de buscar.
            if (this.HasExceededLimit()) { return new TwitterDirectMessageCollection(); }

            DirectMessagesSentOptions wDirectMessagesSentOptions = new DirectMessagesSentOptions() { Proxy = _WebProxy };

            if (pMaxStatusId.HasValue)
            {
                wDirectMessagesSentOptions.MaxStatusId = pMaxStatusId.Value;
            }

            if (pSinceStatusId.HasValue)
            {
                wDirectMessagesSentOptions.SinceStatusId = pSinceStatusId.Value;
            }

            TwitterDirectMessageCollection result = TwitterDirectMessage.DirectMessagesSent(_OAuthTokens, wDirectMessagesSentOptions);

            if (result == null) { this.CheckForErrors(); }

            return result;
        }

        private bool HasExceededLimit()
        {
            return (this.GetRateLimitStatus().RemainingHits < _TwitterConfigSection.MinRemainingHits);
        }

        private void InitializeClass()
        {
            

            _OAuthTokens = new OAuthTokens();
            _OAuthTokens.AccessToken = _DefaultProvider.AccessToken;
            _OAuthTokens.AccessTokenSecret = _DefaultProvider.AccessTokenSecret;

            _OAuthTokens.ConsumerKey = _TwitterConfigSection.ConsumerKey;
            _OAuthTokens.ConsumerSecret = _TwitterConfigSection.ConsumerSecret;
        }

        #endregion

        #region [Public Methods]

        public TwitterUser GetUser(decimal userId)
        {
            OptionalProperties wOptionalProperties;
            wOptionalProperties = new OptionalProperties();
            wOptionalProperties.Proxy = _WebProxy;

            TwitterUser wTwitterUser = TwitterUser.Show(_OAuthTokens, userId, wOptionalProperties);

            if (wTwitterUser == null) { this.CheckForErrors(); }

            return wTwitterUser;
        }

        public TwitterUser GetUser(string userName)
        {
            OptionalProperties wOptionalProperties;
            wOptionalProperties = new OptionalProperties();
            wOptionalProperties.Proxy = _WebProxy;

            TwitterUser wTwitterUser = TwitterUser.Show(_OAuthTokens, userName, wOptionalProperties);

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
            OptionalProperties wOptionalProperties = new OptionalProperties() { Proxy = _WebProxy };
            return TwitterRateLimitStatus.GetStatus(_OAuthTokens, wOptionalProperties);
        }

        public void CheckForErrors()
        {
            if (global::Twitterizer.RequestStatus.LastRequestStatus.Status != RequestResult.Success)
            {
                string errorMessage = null;

                string status = global::Twitterizer.RequestStatus.LastRequestStatus.Status.ToString();

                if (global::Twitterizer.RequestStatus.LastRequestStatus.ErrorDetails != null)
                {
                    errorMessage = global::Twitterizer.RequestStatus.LastRequestStatus.ErrorDetails.ErrorMessage;
                }

                throw new Exception(string.Format("{0}: {1}", status, errorMessage));
            }
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
            StatusUpdateOptions wStatusUpdateOptions = new StatusUpdateOptions() { Proxy = _WebProxy };

            if (pInReplayToStatudId.HasValue)
            {

                wStatusUpdateOptions.InReplyToStatusId = pInReplayToStatudId.Value;
            }

            TwitterStatus wTwitterStatus = TwitterStatus.Update(_OAuthTokens, pText, wStatusUpdateOptions);

            this.CheckForErrors();

            return wTwitterStatus;
        }

        /// <summary>
        /// Envia un mensaje directo al identificador del usuario recibido por parametro
        /// </summary>
        /// <param name="pUserId">Identificador del usuario</param>
        /// <param name="pText">Texto del mensaje, inferior a 140 caracteres.</param>
        /// <returns>El mensaje directo enviado.</returns>
        public TwitterDirectMessage SendDirectMessage(decimal pUserId, string pText)
        {
            OptionalProperties wOptionalProperties = new OptionalProperties() { Proxy = _WebProxy };

            TwitterDirectMessage wTwitterDirectMessage = TwitterDirectMessage.Send(_OAuthTokens, pUserId, pText, wOptionalProperties);

            this.CheckForErrors();

            return wTwitterDirectMessage;
        }

        /// <summary>
        /// Envia un mensaje directo al screen name del usuario recibido por parametro.
        /// </summary>
        /// <param name="pScreenName">Screen Name del usuario</param>
        /// <param name="pText">Texto del mensaje, inferior a 140 caracteres.</param>        
        /// <returns>El mensaje directo enviado.</returns>
        public TwitterDirectMessage SendDirectMessage(string pScreenName, string pText)
        {
            OptionalProperties wOptionalProperties = new OptionalProperties() { Proxy = _WebProxy };

            TwitterDirectMessage wTwitterDirectMessage = TwitterDirectMessage.Send(_OAuthTokens, pScreenName, pText, wOptionalProperties);

            this.CheckForErrors();

            return wTwitterDirectMessage;
        }

        #endregion
    }
}