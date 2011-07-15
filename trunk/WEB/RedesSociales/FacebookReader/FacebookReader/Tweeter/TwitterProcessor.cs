using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.XPath;
using System.Configuration;
using Fwk.SocialNetworks.Config;
using TweetSharp.Twitter.Fluent;
using TweetSharp.Twitter.Model;
using TweetSharp.Extensions;
using TweetSharp.Twitter.Extensions;
using TweetSharp;
using Fwk.SocialNetworks.Data;
namespace Fwk.SocialNetworks.Twitter
{
    public class TwitterProcessor 
    {
        #region [Members]

        SocialNetwork socialNetwork;


        #endregion

        #region [Constructor]
        public void InitSettings()
        {


            if (socialNetwork == null)
            {
                //Busca la red social correspondiente.
                socialNetwork = DataCore.GetSocialNetwork(Enums.SocialNetwork.Twitter);
            }
            
        }



        #endregion

        //public void StoreNewStream(string userName)
        //{
        //    //TO DO: unificar las funciones.
        //    List<StreamSchema.status> wList = new List<StreamSchema.status>();
        //    List<StreamSchema.status> wTempList = new List<StreamSchema.status>();

        //   

        //    wTempList.AddRange(TweetSharp.GetUserStatuses(userName, null).status);

        //    while (wTempList.Count > 0)
        //    {
        //        wList.AddRange(wTempList);

        //        long beforeId = long.Parse(wTempList.Last().id);

        //        wTempList.Clear();

        //        wTempList.AddRange(TweetSharp.GetUserStatuses(userName, beforeId).status);

        //        wTempList.Remove(wTempList.Last());
        //    }

        //    using (CoreDataContext wCoreDataContext = new CoreDataContext(Constants.PortalMovistarConnectionString))
        //    {

        //    }
        //}

        public void StoreNewStream(string token, string tokenSecret)
        {
      
            List<StreamSchema.status> wList = new List<StreamSchema.status>();

            wList.AddRange(TweetSharp.GetAllUserMentions(Constants.LogSince));

            wList.AddRange(TweetSharp.GetAllUserStatuses(Constants.LogSince));


            Post wPost;
            List<Post> wPostList = new List<Post>();
            foreach (StreamSchema.status item in wList.OrderBy(r => r.id))
            {
                wPost = this.ParseStatus(item);
                wPostList.Add(wPost);
            }

            DataCore.CreatePost(wPostList);

        }


        #region [CoreDataContext Methods]

        private User GetTwitterizerUser(decimal pUserId, string pScreenName,string providerName)
        {
            //Busca el usuario en DB.
            User wUser = DataCore.GetUser(pUserId.ToString(), Enums.SocialNetwork.Twitter);

            if (wUser == null)
            {
                //Si no lo encuentra en DB lo busca en twitter.

                global::Twitterizer.TwitterUser wTwitterUser = TwitterWrapper.GetUser(pUserId, providerName);

                if (wTwitterUser != null)
                {
                    //Si lo encuentra en twitter, lo crea.
                    wUser = new User()
                    {
                        Active = true,
                        Name = wTwitterUser.Name,
                        UserName = wTwitterUser.ScreenName,
                        SourceUserID = wTwitterUser.Id.ToString(),
                        ImageUrl = wTwitterUser.ProfileImageLocation,
                        CreationDate = wTwitterUser.CreatedDate.Value,
                        Followers = (int)wTwitterUser.NumberOfFollowers,
                        SocialNetwork = socialNetwork
                    };
                }
                else
                {
                    //Si  no lo encuentra en twitter, lo crea con los datos basicos.
                    wUser = new User()
                    {
                        Active = true,
                        Name = pScreenName,
                        UserName = pScreenName,
                        SourceUserID = pUserId.ToString(),
                        CreationDate = DateTime.Today,
                        SocialNetwork = socialNetwork,
                        ImageUrl = string.Empty,
                        Followers = 0
                    };
                }
                DataCore.CreateUser(wUser);
                //_CoreDataContext.Users.InsertOnSubmit(wUser);
            }
            else
            {
                if (wUser.UserName != pScreenName)
                {
                    wUser.UserName = pScreenName;
                }
            }

            return wUser;
        }

        private User GetTwitterizerUser(global::Twitterizer.TwitterUser pTwitterUser)
        {
            //Busca el usuario en la DB.
            User wUser = DataCore.GetUser(pTwitterUser.Id.ToString(), Enums.SocialNetwork.Twitter);

            if (wUser == null)
            {
                //Si no lo encuentra en DB, lo crea
                wUser = new User()
                {
                    Active = true,
                    Name = pTwitterUser.Name,
                    UserName = pTwitterUser.ScreenName,
                    SourceUserID = pTwitterUser.Id.ToString(),
                    ImageUrl = pTwitterUser.ProfileImageLocation,
                    CreationDate = pTwitterUser.CreatedDate.Value,
                    Followers = (int)pTwitterUser.NumberOfFollowers,
                    SocialNetwork = socialNetwork
                };

                DataCore.CreateUser(wUser);
            }
            else
            {
                //Si el usuario existe, actualiza los nombre o la cantidad de seguidores (en caso de que hayan cambiado).
                if (pTwitterUser.Name != null && wUser.Name != pTwitterUser.Name)
                {
                    wUser.Name = pTwitterUser.Name;
                }
                if (wUser.UserName != pTwitterUser.ScreenName)
                {
                    wUser.UserName = pTwitterUser.ScreenName;
                }
                if (wUser.Followers != pTwitterUser.NumberOfFollowers)
                {
                    wUser.Followers = (int)pTwitterUser.NumberOfFollowers;
                }
            }

            return wUser;
        }

        private User GetTweetSharpUser(String userId)
        {
            User wUser = DataCore.GetUser(userId, Enums.SocialNetwork.Twitter);

            if (wUser == null)
            {

                UserSchema.user wuser = TweetSharp.GetUser(userId);

                wUser = new User()
                {
                    Active = true,
                    UserName = wuser.name,
                    SourceUserID = wuser.id,
                    ImageUrl = wuser.profile_image_url,
                    CreationDate = DateTime.Parse(wuser.created_at),
                    SocialNetwork = socialNetwork,
                };

                DataCore.CreateUser(wUser);
            }

            return wUser;
        }

        private Post ParseStatus(StreamSchema.status pstatus)
        {
            Post wPost = new Post()
            {
                Message = pstatus.text,
                SourcePostID = pstatus.id,
                SocialNetwork = socialNetwork,
                CreationDate = DateTime.Parse(pstatus.created_at),
                To = this.GetTweetSharpUser(pstatus.in_reply_to_user_id),
                From = this.GetTweetSharpUser(pstatus.user.id),
                Permlink = string.Format(@"http://twitter.com/{0}/status/{1}", pstatus.user.screen_name, pstatus.id)
            };

            if (!string.IsNullOrEmpty(pstatus.in_reply_to_status_id) )
            {
                wPost.ParentPost = DataCore.GetPost(pstatus.in_reply_to_status_id, Enums.SocialNetwork.Twitter);
            }

            return wPost;
        }

        private Post ParseStatus(global::Twitterizer.TwitterStatus pTwitterStatus, string providerName)
        {
            Post wPost = new Post();

            wPost.Message = pTwitterStatus.Text;
            wPost.SourcePostID = pTwitterStatus.Id.ToString();
            wPost.SocialNetwork = socialNetwork;
            wPost.CreationDate = pTwitterStatus.CreatedDate;
            wPost.From = this.GetTwitterizerUser(pTwitterStatus.User);
            wPost.Permlink = string.Format(@"http://twitter.com/{0}/status/{1}", pTwitterStatus.User.ScreenName, pTwitterStatus.Id.ToString());

            if (pTwitterStatus.InReplyToStatusId.HasValue)
            {
                wPost.ParentPost = DataCore.GetPost(pTwitterStatus.InReplyToStatusId.Value.ToString(), Enums.SocialNetwork.Twitter);
            }

            if (pTwitterStatus.InReplyToUserId.HasValue)
            {
                wPost.To = this.GetTwitterizerUser(pTwitterStatus.InReplyToUserId.Value, pTwitterStatus.InReplyToScreenName, providerName);
            }

            return wPost;
        }

        private Message ParseDirectMessage(global::Twitterizer.TwitterDirectMessage pTwitterDirectMessage, string providerName)
        {
            Message wMessage = new Message();
            Recipient wRecipient = new Recipient();
            wMessage.Text = pTwitterDirectMessage.Text;
            wMessage.CreatedDate = pTwitterDirectMessage.CreatedDate;
            wMessage.SourceMessageID = pTwitterDirectMessage.Id.ToString();
            wMessage.SocialNetwork = socialNetwork;
            wMessage.MailboxUserID = TwitterWrapper.Config.Providers[providerName].UserId;
            wMessage.SenderUser = this.GetTwitterizerUser(pTwitterDirectMessage.Sender);
            wRecipient.RecipientUser = this.GetTwitterizerUser(pTwitterDirectMessage.Recipient);
            wMessage.Recipients.Add(wRecipient);
            return wMessage;
        }

        #endregion

        #region [Entities Methods]

        public Entities.Statuses GetStatuses(string userName, long? beforeId)
        {
            IFluentTwitter request = FluentTwitter.CreateRequest();

            ITwitterStatuses statuses = request.Statuses();

            ITwitterUserTimeline userTimeLine;

            if (beforeId.HasValue)
            {
                userTimeLine = statuses.OnUserTimeline().For(userName).Before(beforeId.Value);
            }
            else
            {
                userTimeLine = statuses.OnUserTimeline().For(userName);
            }

            ITwitterLeafNode leafNode = userTimeLine.AsXml();

            TwitterResult wTwitterResult = leafNode.Configuration.UseProxy("http://proxyallus:3030").Request();

            if (wTwitterResult.IsTwitterError)
            {
                throw new Exception(wTwitterResult.Exception.Message);
            }
            else if (wTwitterResult.IsFailWhale || wTwitterResult.TimedOut)
            {
                throw new Exception("IsFailWhale || TimedOut");
            }
            else
            {
                try
                {
                    return Entities.Statuses.GetFromXml<Entities.Statuses>(wTwitterResult.Response);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Entities.Statuses GetStatuses(string userName, string password, long? beforeId)
        {
            IFluentTwitter request = FluentTwitter.CreateRequest();

            ITwitterStatuses statuses = request.Statuses();

            ITwitterUserTimeline userTimeLine;

            if (beforeId.HasValue)
            {
                userTimeLine = statuses.OnUserTimeline().For(userName).Before(beforeId.Value);
            }
            else
            {
                userTimeLine = statuses.OnUserTimeline().For(userName);
            }

            ITwitterLeafNode leafNode = userTimeLine.AsXml();

            TwitterResult wTwitterResult = leafNode.Configuration.UseProxy("http://proxyallus:3030").Request();

            if (wTwitterResult.IsTwitterError)
            {
                throw new Exception(wTwitterResult.Exception.Message);
            }
            else if (wTwitterResult.IsFailWhale || wTwitterResult.TimedOut)
            {
                throw new Exception("IsFailWhale || TimedOut");
            }
            else
            {
                return Entities.Statuses.GetFromXml<Entities.Statuses>(wTwitterResult.Response);
            }
        }

        #endregion

        #region [Statuses Methods]



        #region Twiterizer

        public void LogStatuses(string providerName)
        {
            //Verifica si el proveedor por defecto esta habilitado y si no lo esta no loguea.
            //if (configSection.DefaultProvider.Enabled == false) { return; }

            List<global::Twitterizer.TwitterStatus> wList = new List<global::Twitterizer.TwitterStatus>();

         

            decimal? wSinceStatusId = null;

            string wMaxSourcePostId = DataCore.GetLastStoredSourcePostId(Enums.SocialNetwork.Twitter);

            if (wMaxSourcePostId != null)
            {
                wSinceStatusId = Convert.ToDecimal(wMaxSourcePostId);
            }

            wList.AddRange(TwitterWrapper.GetAllUserMentions(wSinceStatusId, Constants.LogSince, providerName));

            wList.AddRange(TwitterWrapper.GetAllUserStatuses(wSinceStatusId, Constants.LogSince, providerName));

            if (wList.Count > 0)
            {
                this.SaveStatuses(wList,providerName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pList"></param>
        private void SaveStatuses(List<global::Twitterizer.TwitterStatus> pList, string providerName)
        {
            Post wPost;
            List<Post> wPostList = new List<Post>();
       
            try
            {
                foreach (global::Twitterizer.TwitterStatus item in pList.OrderBy(r => r.Id))
                {
                     wPost = this.ParseStatus(item,providerName);
                }

                DataCore.CreatePost(wPostList);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la transacción de datos al grabar los tweets.", ex);
            }
        }

        //private void SaveStatus(global::Twitterizer.TwitterStatus wTwitterStatus)
        //{
        //    try
        //    {
        //        _CoreDataContext.Transaction = _CoreDataContext.Connection.BeginTransaction();

        //        Post wPost = this.ParseStatus(wTwitterStatus);

        //        _CoreDataContext.Posts.InsertOnSubmit(wPost);

        //        _CoreDataContext.SubmitChanges();

        //        _CoreDataContext.Transaction.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        //_CoreDataContext.Transaction.Rollback();

        //        throw new Exception("Error en la transacción de datos al grabar los tweets.", ex);
        //    }
        //}

        #endregion

        #endregion

        #region [Messages Methods]

        public void LogMessages(string providerName)
        {
            //Verifica si el proveedor por defecto esta habilitado y si no lo esta no loguea.
            //if (configSection.DefaultProvider.Enabled == false) { return; }

            List<global::Twitterizer.TwitterDirectMessage> wList = new List<global::Twitterizer.TwitterDirectMessage>();


            decimal? wSinceStatusId = null;

            string wMaxSourceMessageId = DataCore.GetLastStoredMessageId(Enums.SocialNetwork.Twitter);

            if (wMaxSourceMessageId != null)
            {
                wSinceStatusId = Convert.ToDecimal(wMaxSourceMessageId);
            }

            wList.AddRange(TwitterWrapper.GetAllUserMessages(wSinceStatusId, Constants.LogSince, providerName));

            wList.AddRange(TwitterWrapper.GetAllUserMessagesSent(wSinceStatusId, Constants.LogSince, providerName));

            if (wList.Count > 0)
            {
                this.SaveMessages(wList,providerName);
            }
        }

        private void SaveMessages(List<global::Twitterizer.TwitterDirectMessage> pList, string providerName)
        {



            foreach (global::Twitterizer.TwitterDirectMessage item in pList.OrderBy(r => r.Id))
            {
                this.SaveMessage(item,providerName);
            }

        }

        private void SaveMessage(global::Twitterizer.TwitterDirectMessage item, string providerName)
        {
            try
            {


                Message wMessage = this.ParseDirectMessage(item,providerName);
                DataCore.CreateMessage(wMessage);

            }
            catch (Exception ex)
            {
             
               throw new Exception("Error en la transacción de datos al grabar los mensajes directos.", ex);
            }
        }

        #endregion






    }
}