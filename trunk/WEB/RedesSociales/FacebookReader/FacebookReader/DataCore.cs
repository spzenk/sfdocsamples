using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.HelperFunctions;
using Fwk.SocialNetworks.Data;
using System.Data.Common;
using System.Data;
namespace Fwk.SocialNetworks.Data
{
    public class DataCore
    {

        public static void CreateUser(User pUser)
        {
            using (CoreDataContext dc = new CoreDataContext(Constants.Cnnstring))
            {   
                
                dc.Users.InsertOnSubmit(pUser);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Busca el usuario que se corresponde con el identificador recibido por parametro de la red social recibida por parametro.
        /// </summary>
        /// <param name="pSourceUserId">Identificador del usuario</param>
        /// <param name="pCoreDataContext">DataContext</param>
        /// <param name="pSocialNetwork">Red Social a la que pertence el usuario</param>
        /// <returns></returns>
        public static User GetUser(String pSourceUserId, Enums.SocialNetwork pSocialNetwork)
        {
            User wUser = null;
            using (CoreDataContext wCoreDataContext = new CoreDataContext(Constants.Cnnstring))
            {
                var wData = from user in wCoreDataContext.Users
                            where user.SourceUserID == pSourceUserId & user.SocialNetworkID == (int)pSocialNetwork
                            select user;

                if (wData.Count<User>() > 0)
                {
                    wUser = wData.First<User>();
                }

                return wUser;
            }
        }

        /// <summary>
        /// Busca el post que se corresponde con el identificador recibido por parametro de la red social recibida por parametro.
        /// </summary>        
        /// <param name="pSourcePostID">Identificador del Post</param>
        /// <param name="pCoreDataContext">DataContext</param>
        /// <returns></returns>
        public static Post GetPost(String pSourcePostID, Enums.SocialNetwork pSocialNetwork)
        {
            Post wPost = null;
            using (CoreDataContext wCoreDataContext = new CoreDataContext(Constants.Cnnstring))
            {
                var wData = from p in wCoreDataContext.Posts
                            where p.SourcePostID == pSourcePostID & p.SocialNetworkID == (int)pSocialNetwork
                            select p;

                if (wData.Count<Post>() > 0)
                {
                    wPost = wData.First<Post>();
                }

                return wPost;
            }
        }

        /// <summary>
        /// Obtiene la red social de la BD.
        /// </summary>
        ///<param name="pCoreDataContext">DataContext</param>
        /// <param name="pSocialNetwork">Red social</param>
        /// <returns></returns>
        public static SocialNetwork GetSocialNetwork(Enums.SocialNetwork pSocialNetwork)
        {
            SocialNetwork wSocialNetwork = null;
            using (CoreDataContext wCoreDataContext = new CoreDataContext(Constants.Cnnstring))
            {
                

                var wData = from sn in wCoreDataContext.SocialNetworks
                            where sn.SocialNetworkID == (int)pSocialNetwork
                            select sn;

                if (wData.Count<SocialNetwork>() > 0)
                {
                    wSocialNetwork = wData.First<SocialNetwork>();
                }

                return wSocialNetwork;
            }
        }

        /// <summary>
        /// Obtiene el ultrimo SourcePostID de la DB de la red social recibida por parametro.
        /// </summary>
        /// <param name="pSocialNetwork">Red social</param>
        /// <param name="pCoreDataContext">DataContext</param>
        /// <returns></returns>
        public static string GetLastStoredSourcePostId(Enums.SocialNetwork pSocialNetwork)
        {
            String wRetSourcePostId = null;
            using (CoreDataContext wCoreDataContext = new CoreDataContext(Constants.Cnnstring))
            {
                Int32? wPostId = (from sn in wCoreDataContext.Posts
                                  where sn.SocialNetworkID == (int)pSocialNetwork
                                  select (Nullable<Int32>)sn.PostID).Max();

                if (wPostId.HasValue)
                {
                    System.Linq.IQueryable<String> wSourcePostID = (from sn in wCoreDataContext.Posts
                                                                    where sn.PostID == wPostId.Value
                                                                    select sn.SourcePostID);

                    wRetSourcePostId = wSourcePostID.First<String>();
                }

                return wRetSourcePostId;
            }
        }

        /// <summary>
        /// Obtiene el identificador del ultimo mensaje logueado en la DB de la red social recibida por parametro.
        /// </summary>
        /// <param name="pSocialNetwork">Red social</param>
        /// <param name="pCoreDataContext">DataContext</param>
        /// <returns></returns>
        public static string GetLastStoredMessageId(Enums.SocialNetwork pSocialNetwork)
        {
            String wRetSourceMessageID = null;
            using (CoreDataContext wCoreDataContext = new CoreDataContext(Constants.Cnnstring))
            {
                Int32? wMessageID = (from sn in wCoreDataContext.Messages
                                     where sn.SocialNetworkID == (int)pSocialNetwork
                                     select (Nullable<Int32>)sn.MessageID).Max();

                if (wMessageID.HasValue)
                {
                    System.Linq.IQueryable<String> wSourceMessageID = (from sn in wCoreDataContext.Messages
                                                                       where sn.MessageID == wMessageID.Value
                                                                       select sn.SourceMessageID);

                    wRetSourceMessageID = wSourceMessageID.First<String>();
                }

                return wRetSourceMessageID;
            }
        }


        /// <summary>
        /// Obtiene la fecha de creación del ultimo post logueado en la base de datos de la red social recibida por parámetro.
        /// </summary>
        /// <param name="pSocialNetwork">Red social</param>
        /// <param name="pCoreDataContext">DataContext</param>
        /// <returns></returns>
        public static Int64 GetLastStoredPostTimestamp(Enums.SocialNetwork pSocialNetwork)
        {
            using (CoreDataContext dc = new CoreDataContext(Constants.Cnnstring))
            {
                Nullable<DateTime> wDate = (from sn in dc.Posts
                                            where sn.SocialNetworkID == (int)pSocialNetwork
                                            select (Nullable<DateTime>)sn.CreationDate).Max();

                if (wDate.HasValue)
                {
                    return DateFunctions.DateTimeToUnixTimeStamp(wDate.Value);
                }

                return 0;
            }
        }

        /// <summary>
        /// Obtiene la fecha de creación del ultimo mensaje logueado en la base de datos de la red social recibida por parámetro.
        /// </summary>
        /// <param name="pSocialNetwork">Red social</param>
        /// <returns></returns>
        public static Int64 GetLastStoredMessageTimestamp(Enums.SocialNetwork pSocialNetwork)
        {
            using (CoreDataContext dc = new CoreDataContext(Constants.Cnnstring))
            {
                Nullable<DateTime> wDate = (from sn in dc.Messages
                                            where sn.SocialNetworkID == (int)pSocialNetwork
                                            select (Nullable<DateTime>)sn.CreatedDate).Max();

                if (wDate.HasValue)
                {
                    return DateFunctions.DateTimeToUnixTimeStamp(wDate.Value);
                }

                return 0;
            }
        }

        #region [Transactionals Methods]

        internal static void AddComment(Post pPost, comment pItemComment,User userFrom , SocialNetwork pSocialNetwork)
        {
           
            using (CoreDataContext dc = new CoreDataContext(Constants.Cnnstring))
            {
                Post pc = ParsePostFromFBComment(pItemComment, userFrom ,pSocialNetwork);
                pc.ParentPost = pPost;
                dc.Posts.InsertOnSubmit(pc);
                dc.SubmitChanges();
            }
        }

        /// <summary>
        /// Inserta lote de posts en una transaccion ReadCommitted
        /// </summary>
        /// <param name="posts"></param>
        internal static void CreatePost(List<Post> posts)
        {

            using (CoreDataContext dc = new CoreDataContext(Constants.Cnnstring))
            using (DbTransaction transaction = dc.Connection.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    foreach (Post wPost in posts)
                    {
                        dc.Posts.InsertOnSubmit(wPost);
                    }
                    dc.SubmitChanges();
                    dc.Transaction.Commit();
                }
                catch (Exception)
                {
                    dc.Transaction.Rollback();
                }
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        internal static void CreatePost(Post post)
        {
            using (CoreDataContext dc = new CoreDataContext(Constants.Cnnstring))
            {
                dc.Posts.InsertOnSubmit(post);
                dc.SubmitChanges();
            }
        }


        internal static void CreateMessage(Message pMessage)
        {
            using (CoreDataContext dc = new CoreDataContext(Constants.Cnnstring))
            {

                dc.Messages.InsertOnSubmit(pMessage);
                dc.SubmitChanges();
            }
        }
        internal static void CreateRecipients(Recipient pRecipient)
        {
            using (CoreDataContext dc = new CoreDataContext(Constants.Cnnstring))
            {

                dc.Recipients.InsertOnSubmit(pRecipient);
                dc.SubmitChanges();
            }
        }
        

        #endregion

        #region [CoreDataContext Methods]

        /// <summary>
        /// Obtiene el último post en la Base de Datos
        /// </summary>

        /// <returns></returns>
        internal static Int64 GetLastPost()
        {
            Int64 wLastStoredPostTimeStamp = DateFunctions.DateTimeToUnixTimeStamp(Constants.LogSince);
            Int64 wLastStoredInDB = DataCore.GetLastStoredPostTimestamp(Enums.SocialNetwork.Facebook);

            if (wLastStoredInDB > 0)
            {
                wLastStoredPostTimeStamp = wLastStoredInDB;
            }

            return wLastStoredPostTimeStamp;
        }

        /// <summary>
        /// Obtiene el último mensaje en la Base de Datos
        /// </summary>
        /// <param name="pCoreDataContext"></param>
        /// <returns></returns>
        internal static Int64 GetLastMessage(Enums.SocialNetwork pSocialNetwork)
        {
            Int64 wLastStoredMessageTimeStamp = DateFunctions.DateTimeToUnixTimeStamp(Constants.LogSince);
            Int64 wLastStoredInDB = DataCore.GetLastStoredMessageTimestamp(pSocialNetwork);

            if (wLastStoredInDB > 0)
            {
                wLastStoredMessageTimeStamp = wLastStoredInDB;
            }

            return wLastStoredMessageTimeStamp;
        }


        /// <summary>
        /// Mapea un comentario de FB con el Post de Base de datos
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="itemcomment"></param>
        /// <returns></returns>
        private static Post ParsePostFromFBComment(comment pItemComment,User user, SocialNetwork pSocialNetwork)
        {
            Post wPost = new Post()
            {
                CreationDate = DateFunctions.UnixTimeStampToDateTime(Convert.ToInt64(pItemComment.time)),
                From = user,
                Message = pItemComment.text,
                SocialNetwork = pSocialNetwork,
                SourcePostID = pItemComment.id
            };

            return wPost;
        }



        #endregion

       
    }
}
