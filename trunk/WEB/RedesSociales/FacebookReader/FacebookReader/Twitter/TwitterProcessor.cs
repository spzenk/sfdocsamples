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

        Fwk.SocialNetworks.Enums.SocialNetworkEnum _SocialNetwork = Enums.SocialNetworkEnum.Twitter;
        
        #endregion

        #region [Constructor]
        CoreDataContext _CoreDataContext;
        public TwitterProcessor()
        {
           
        }

        #endregion

        #region [Get User Methods]

        private User GetTwitterizerUser(decimal pUserId, string pScreenName)
        {
            //Busca el usuario en DB.
            User wUser = DataCore.GetUser(pUserId.ToString(), Enums.SocialNetworkEnum.Twitter, _CoreDataContext);

            if (wUser == null)
            {
                //Si no lo encuentra en DB lo busca en twitter.
                Twitterizer wTwitterizer = new Twitterizer();
                global::Twitterizer.TwitterUser wTwitterUser = wTwitterizer.GetUser(pUserId);

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
                        SocialNetworkID = (int)_SocialNetwork,
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
                       SocialNetworkID = (int)_SocialNetwork,
                        ImageUrl = string.Empty,
                        Followers = 0
                    };
                }

                _CoreDataContext.Users.InsertOnSubmit(wUser);
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
            User wUser = DataCore.GetUser(pTwitterUser.Id.ToString(), Enums.SocialNetworkEnum.Twitter,_CoreDataContext);

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
                    SocialNetworkID = (int)_SocialNetwork,
                };
                _CoreDataContext.Users.InsertOnSubmit(wUser);
                _CoreDataContext.SubmitChanges();
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

        //private User GetTweetSharpUser(String userId)
        //{
        //    User wUser = DataCore.GetUser(userId, Enums.SocialNetworkEnum.Twitter, _CoreDataContext);

        //    if (wUser == null)
        //    {   
        //        TweetSharp wTweetSharp = new TweetSharp();
        //        UserSchema.user wuser = wTweetSharp.GetUser(userId);

        //        wUser = new User()
        //        {
        //            Active = true,
        //            UserName = wuser.name,
        //            SourceUserID = wuser.id,
        //            ImageUrl = wuser.profile_image_url,
        //            CreationDate = DateTime.Parse(wuser.created_at),
        //            SocialNetworkID =(int) _SocialNetwork,
        //        };

        //        DataCore.CreateUser(wUser, _CoreDataContext);
        //    }

        //    return wUser;
        //}

     

        //private Post CastPost(StreamSchema.status pstatus)
        //{
        //    Post wPost = new Post()
        //    {
        //        Message = pstatus.text,
        //        SourcePostID = pstatus.id,
        //        SocialNetworkID = (int)_SocialNetwork,
        //        CreationDate = DateTime.Parse(pstatus.created_at),
        //        ToUserID = this.GetTweetSharpUser(pstatus.in_reply_to_user_id).UserID,
        //        FromUserID = this.GetTweetSharpUser(pstatus.user.id).UserID,
        //        Permlink = string.Format(@"http://twitter.com/{0}/status/{1}", pstatus.user.screen_name, pstatus.id)
        //    };

        //    if (string.IsNullOrEmpty(pstatus.in_reply_to_status_id) == false)
        //    {
        //        wPost.ParentPost = DataCore.GetPost(pstatus.in_reply_to_status_id, Enums.SocialNetworkEnum.Twitter,_CoreDataContext);
        //    }

        //    return wPost;
        //}


        #endregion

   
        #region [Entities Methods]
        private Post CastPost(global::Twitterizer.TwitterStatus pTwitterStatus)
        {
            Post wPost = new Post();

            wPost.Message = pTwitterStatus.Text;
            wPost.SourcePostID = pTwitterStatus.Id.ToString();
            wPost.SocialNetworkID = (int) _SocialNetwork;
            wPost.CreationDate = pTwitterStatus.CreatedDate;
            wPost.FromUserID = this.GetTwitterizerUser(pTwitterStatus.User).UserID;
            wPost.Permlink = string.Format(@"http://twitter.com/{0}/status/{1}", pTwitterStatus.User.ScreenName, pTwitterStatus.Id.ToString());

            if (pTwitterStatus.InReplyToStatusId.HasValue)
            {
                wPost.ParentPost = DataCore.GetPost(pTwitterStatus.InReplyToStatusId.Value.ToString(), Enums.SocialNetworkEnum.Twitter,_CoreDataContext);
            }

            if (pTwitterStatus.InReplyToUserId.HasValue)
            {
                wPost.ToUserID = this.GetTwitterizerUser(pTwitterStatus.InReplyToUserId.Value, pTwitterStatus.InReplyToScreenName).UserID;
                
            }

            return wPost;
        }
      

        private Message ParseDirectMessage(global::Twitterizer.TwitterDirectMessage pTwitterDirectMessage)
        {
            Message wMessage = new Message();
            Recipient wRecipient = new Recipient();
            wMessage.Text = pTwitterDirectMessage.Text;
            wMessage.CreatedDate = pTwitterDirectMessage.CreatedDate;
            wMessage.SourceMessageID = pTwitterDirectMessage.Id.ToString();
            wMessage.SocialNetworkID = 2;// _SocialNetwork;
            wMessage.MailboxUserID = Twitterizer.Config.DefaultProvider.UserId;
            wMessage.SenderUser = this.GetTwitterizerUser(pTwitterDirectMessage.Sender);
            wRecipient.RecipientUser = this.GetTwitterizerUser(pTwitterDirectMessage.Recipient);
            wMessage.Recipients.Add(wRecipient);
            return wMessage;
        }


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

            TwitterResult wTwitterResult = leafNode.Configuration.UseProxy(Twitterizer.Proxy.Address.ToString()).Request();

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

            TwitterResult wTwitterResult = leafNode.Configuration.UseProxy(Twitterizer.Proxy.Address.ToString()).Request();

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

        #region TweetSharp

        //TODO: Ver si se usa StoreNewStream
/*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        public void StoreNewStream(string userName)
        {
            
            //TO DO: unificar las funciones.
            List<StreamSchema.status> wList = new List<StreamSchema.status>();
            List<StreamSchema.status> wTempList = new List<StreamSchema.status>();

            TweetSharp wTweetSharp = new TweetSharp();
            wTempList.AddRange(wTweetSharp.GetUserStatuses(userName, null).status);

            while (wTempList.Count > 0)
            {
                wList.AddRange(wTempList);

                long beforeId = long.Parse(wTempList.Last().id);

                wTempList.Clear();

                wTempList.AddRange(wTweetSharp.GetUserStatuses(userName, beforeId).status);

                wTempList.Remove(wTempList.Last());
            }

           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="tokenSecret"></param>
        public void StoreNewStream(string token, string tokenSecret)
        {
            List<StreamSchema.status> wList = new List<StreamSchema.status>();

            TweetSharp wTweetSharp = new TweetSharp();

            wList.AddRange(wTweetSharp.GetAllUserMentions(Constants.LogSince));

            wList.AddRange(wTweetSharp.GetAllUserStatuses(Constants.LogSince));
            Post wPost;
            List<Post> wPostList = new List<Post>();
            using (_CoreDataContext = new CoreDataContext(Constants.Cnnstring))
            {
                try
                {

                    _CoreDataContext.Connection.Open();

                    _CoreDataContext.Transaction = _CoreDataContext.Connection.BeginTransaction();

                    foreach (StreamSchema.status item in wList.OrderBy(r => r.id))
                    {
                        wPost = this.ParseStatus(item);
                        wPostList.Add(wPost);
                        _CoreDataContext.Posts.InsertOnSubmit(wPost);
                    }
                    DataCore.CreatePost(wPostList, _CoreDataContext);
                    _CoreDataContext.SubmitChanges();

                    _CoreDataContext.Transaction.Commit();
                }
                catch (Exception)
                {
                    _CoreDataContext.Transaction.Rollback();
                }
            }

        }
        */
        #endregion

        #region Twiterizer

        /// <summary>
        /// Busca y almacena nuevos Statuses y Mentions
        /// </summary>
        public void LogStatuses()
        {
            

            //Verifica si el proveedor por defecto esta habilitado y si no lo esta no loguea.
            if (Twitterizer.Config.DefaultProvider.Enabled == false) { return; }

            List<global::Twitterizer.TwitterStatus> wList = new List<global::Twitterizer.TwitterStatus>();

            Twitterizer wTwitterizer = new Twitterizer();

            decimal? wSinceStatusId = null;

            //Busca el ultimo Post en la base de datos para twitter
            string wMaxSourcePostId = DataCore.GetLastStoredSourcePostId(Enums.SocialNetworkEnum.Twitter);

            if (!string.IsNullOrEmpty(wMaxSourcePostId))
                wSinceStatusId = Convert.ToDecimal(wMaxSourcePostId);
            else
                wSinceStatusId = 0;
              wList.AddRange(wTwitterizer.GetAllUserMentions(wSinceStatusId, Constants.LogSince));
                wList.AddRange(wTwitterizer.GetAllUserStatuses(wSinceStatusId, Constants.LogSince));
           
            if (wList.Count > 0)
            {
                this.SaveStatuses(wList);
            }

                
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pList"></param>
         void SaveStatuses(List<global::Twitterizer.TwitterStatus> pList)
        {
            Post wPost = null;

            List<Post> postList = new List<Post>();
            using (_CoreDataContext = new CoreDataContext(Constants.Cnnstring))
            {
                _CoreDataContext.Connection.Open();
                try
                {
                    _CoreDataContext.Transaction = _CoreDataContext.Connection.BeginTransaction();

                    foreach (global::Twitterizer.TwitterStatus item in pList.OrderBy(r => r.Id))
                    {
                        wPost = this.CastPost(item);
                        _CoreDataContext.Posts.InsertOnSubmit(wPost);
                    }
                    _CoreDataContext.SubmitChanges();
                    _CoreDataContext.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    _CoreDataContext.Transaction.Rollback();

                    Helper.Log("Error en la transacción de datos al grabar los tweets.", ex);
                }
                finally
                {
                    _CoreDataContext.Connection.Close();
                }
            }

        }

       

        #endregion

        #endregion

        #region [Messages Methods]

         public void LogMessages()
         {
             //Verifica si el proveedor por defecto esta habilitado y si no lo esta no loguea.
             if (Twitterizer.Config.DefaultProvider.Enabled == false) { return; }

             List<global::Twitterizer.TwitterDirectMessage> wList = new List<global::Twitterizer.TwitterDirectMessage>();

             Twitterizer wTwitterizer = new Twitterizer();

             decimal? wSinceStatusId = null;

             string wMaxSourceMessageId = DataCore.GetLastStoredMessageId(Enums.SocialNetworkEnum.Twitter);

             if (!string.IsNullOrEmpty(wMaxSourceMessageId))
                 wSinceStatusId = Convert.ToDecimal(wMaxSourceMessageId);
             else
                 wSinceStatusId = 0;

             wList.AddRange(wTwitterizer.GetAllUserMessages(wSinceStatusId, Constants.LogSince));
             wList.AddRange(wTwitterizer.GetAllUserMessagesSent(wSinceStatusId, Constants.LogSince));

             if (wList.Count > 0)
             {
                 this.SaveMessages(wList);
             }
         }

         void SaveMessages(List<global::Twitterizer.TwitterDirectMessage> pList)
        {
            using (_CoreDataContext = new CoreDataContext(Constants.Cnnstring))
            {
                _CoreDataContext.Connection.Open();
                try
                {
                    _CoreDataContext.Transaction = _CoreDataContext.Connection.BeginTransaction();

                    foreach (global::Twitterizer.TwitterDirectMessage item in pList.OrderBy(r => r.Id))
                    {
                        Message wMessage = this.ParseDirectMessage(item);
                        _CoreDataContext.Messages.InsertOnSubmit(wMessage);
                    }
                    _CoreDataContext.SubmitChanges();
                    _CoreDataContext.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    _CoreDataContext.Transaction.Rollback();

                    Helper.Log("Error en la transacción de datos al grabar los tweets.", ex);
                }
                finally
                {
                    _CoreDataContext.Connection.Close();
                }
            }
        }

        public void LogSavedSearches()
        {

        }

        #endregion

    }
}