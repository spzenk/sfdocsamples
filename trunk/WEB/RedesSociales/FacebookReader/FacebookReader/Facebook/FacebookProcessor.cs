using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Transactions;
using Fwk.HelperFunctions;
using Fwk.SocialNetworks.Data;


namespace Fwk.SocialNetworks
{
    public class FacebookProcessor
    {
       

        #region [Members & Constructor]
        Fwk.SocialNetworks.Enums.SocialNetworkEnum _SocialNetwork = Enums.SocialNetworkEnum.Twitter;
        
        CoreDataContext _CoreDataContext;
        FacebookProvider provider = null;

        public  FacebookProcessor()
        {
           provider = FacebookWrapper.Config.GetProvider(string.Empty);
        }
        public FacebookProcessor(string providerName)
        {
            provider = FacebookWrapper.Config.GetProvider(providerName);
        }
 
        #endregion


   




        #region [Store new post an stream methods]

        

        /// <summary>
        /// Almacenar nuevo post o agregar comentario a un post existente.
        /// </summary>
        public void StoreNewStream()
        {

            using (_CoreDataContext = new CoreDataContext(Constants.Cnnstring))
            {
                //Busca la mayor fecha (convertida a timestamp) almacenada en DB.
                Int64 wLastStoredPostTimeStamp = DataCore.GetLastPost();
                //Busca los posts mayores a la fecha obtenida anteriormente.
                fql_query_response wResponses = FacebookWrapper.GetNewerStream(wLastStoredPostTimeStamp, provider.UserAccessToken, provider.SourceId, FacebookWrapper.Config.Limit);
                //Si no encuentra nuevos posts, no hace nada.
                if (wResponses.stream_post == null) { return; }

                Post wPost = null;
                //Por cada post encontrado...
                foreach (stream_post wItem in wResponses.stream_post)
                {
                    try
                    {
                        _CoreDataContext.Transaction = _CoreDataContext.Connection.BeginTransaction();
                        //Inserta el post o agrega un comentario a un post existente segun corresponda.
                        InsertPostOrAddComment(wLastStoredPostTimeStamp, wPost, wItem);
                        _CoreDataContext.Transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        _CoreDataContext.Transaction.Rollback();
                        throw new Exception("Error al transaccionar los nuevos posts", ex);
                    }
                }
            }

        }



        /// <summary>
        /// Almacena nuevos mensajes en la BD
        /// </summary>
        public void StoreNewMessages()
        {
            fql_query_response wThreadResponse = null;
            fql_query_response wMessageResponse = null;
            using (_CoreDataContext = new CoreDataContext(Constants.Cnnstring))
            {
                //Busca la mayor fecha (convertida a timestamp) almacenada en DB.
                Int64 wLastStoredPostTimeStamp = DataCore.GetLastMessage(Enums.SocialNetworkEnum.Facebook);

                //busca los hilos de mensajes mayores a la fecha obtenida anteriormente.
                wThreadResponse = FacebookWrapper.GetThreadList(wLastStoredPostTimeStamp, provider.UserAccessToken, FacebookWrapper.Config.Limit);




                //Por cada hilo de mensajes...
                foreach (thread wThread in wThreadResponse.thread)
                {
                    //... Busca los mensajes propiamente dichos del hilo.
                    wMessageResponse = FacebookWrapper.GetMessagesInThread(wThread.thread_id, wLastStoredPostTimeStamp, provider.UserAccessToken, FacebookWrapper.Config.Limit);


                    //Si el hilo no tiene mensajes, pasa al siguiente hilo.
                    if (wMessageResponse.message == null) { continue; }

                    //Transaccionar
                    //Por cada mensaje del hilo...
                    foreach (message wMessage in wMessageResponse.message)
                    {
                        try
                        {
                            _CoreDataContext.Transaction = _CoreDataContext.Connection.BeginTransaction();
                            //Crea y guarda el mensaje.
                            this.InsertMessageAndRecipients(wThread, wMessage, provider.UserId);
                            _CoreDataContext.Transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            _CoreDataContext.Transaction.Rollback();
                            throw new Exception("Error al transaccionar los nuevos mensajes", ex);
                        }
                    }
                }
            }
        }



        #endregion



        #region [Methods]





        /// <summary>
        /// Inserta o agrega un comentario a un post existente
        /// </summary>
        /// <param name="pLastStoredPostTimeStamp"></param>
        /// <param name="pPost"></param>
        /// <param name="pItem"></param>
        /// <param name="pCoreDataContext"></param>
        private void InsertPostOrAddComment(Int64 pLastStoredPostTimeStamp, Post pPost, stream_post pItem)
        {
            User userFrom = null;
            //Busca los comentarios del post recibido por parametro.
            fql_query_response wCommentResponses = FacebookWrapper.GetCommentBySourcePostId(pItem.post_id, provider.UserAccessToken, FacebookWrapper.Config.Limit);


            if (Convert.ToInt64(pItem.created_time) > pLastStoredPostTimeStamp)
            {
                // Post nuevo. Se registra un nuevo post padre y todos sus comentarios.
                pPost = ParseNewPost(pItem);
                _CoreDataContext.Posts.InsertOnSubmit(pPost);

                if (wCommentResponses.comment != null)
                {
                    foreach (comment wItemComment in wCommentResponses.comment)
                    {
                        userFrom = GetUser_From_Database(wItemComment.fromid);
                        DataCore.AddComment(pPost, wItemComment, userFrom, _SocialNetwork, _CoreDataContext);
                    }
                }
            }
            else
            {
                // Post que ya debería estar en la DB. Se ingresan solo los comentarios.
                pPost = DataCore.GetPost(pItem.post_id, Enums.SocialNetworkEnum.Facebook, _CoreDataContext);

                if (wCommentResponses.comment != null)
                {
                    foreach (comment wItemComment in wCommentResponses.comment)
                    {
                        if (Convert.ToInt64(wItemComment.time) > pLastStoredPostTimeStamp)
                        {
                            userFrom = GetUser_From_Database(wItemComment.fromid);
                            DataCore.AddComment(pPost, wItemComment, userFrom, _SocialNetwork, _CoreDataContext);

                        }
                    }
                }
            }
        }
    
        /// <summary>
        /// Lee los mensages de una cuenta (usuario o aplicacion)
        /// </summary>
        /// <param name="dateSince"></param>
        /// <returns></returns>
        public string GetwMessagesList(DateTime dateSince)
        {
            string messageLine = "thread_id = {0} message_id = {1} date = {2}";
            StringBuilder str = new StringBuilder();
            Int64 wLastStoredMessageTimeStamp = DateFunctions.DateTimeToUnixTimeStamp(dateSince);
            fql_query_response wMessageResponse = null;
            fql_query_response wThreadResponse = FacebookWrapper.GetThreadList(wLastStoredMessageTimeStamp, provider.UserAccessToken, FacebookWrapper.Config.Limit);
            //Por cada hilo de mensajes...
            foreach (thread wThread in wThreadResponse.thread)
            {
                str.AppendLine("----------------------------inicio thread ---------------------------" );
                str.AppendLine(string.Concat("Subjet:   ", wThread.subject));
                
                //... Busca los mensajes propiamente dichos del hilo.
                wMessageResponse = FacebookWrapper.GetMessagesInThread(wThread.thread_id, wLastStoredMessageTimeStamp, provider.UserAccessToken, FacebookWrapper.Config.Limit);


                //Si el hilo no tiene mensajes, pasa al siguiente hilo.
                if (wMessageResponse.message == null) { continue; }

                //Transaccionar
                //Por cada mensaje del hilo...
                foreach (message wMessage in wMessageResponse.message)
                {
                    try
                    {

                        str.AppendLine(string.Format(messageLine, wMessage.thread_id, wMessage.message_id,DateFunctions.UnixTimeStampToDateTime(Convert.ToInt64(wMessage.created_time)).ToLongDateString()));
                        str.AppendLine(Environment.NewLine);
                        str.AppendLine(wMessage.body);
                        str.AppendLine(Environment.NewLine);
                        //Crea y guarda el mensaje.
                        //this.InsertMessageAndRecipients(wThread, wMessage, _provider.UserId);

                    }
                    catch (Exception ex)
                    {

                        throw new Exception("Error al transaccionar los nuevos mensajes", ex);
                    }
                }
                str.AppendLine("-----------------------------fin thread--------------------------");
            }
            return str.ToString();
        }
        /// <summary>
        /// Obtiene lista de posts en el muro de una aplicacion o usuario
        /// </summary>
        /// <param name="dateSince"></param>
        /// <returns></returns>
        public string Get_stream_post(DateTime dateSince)
        {
            return Get_stream_post(dateSince, FacebookWrapper.Config.DefaultProviderName);
        }
        /// <summary>
        /// Obtiene lista de posts en el muro de una aplicacion o usuario
        /// </summary>
        /// <param name="dateSince"></param>
        /// <returns></returns>
        public string Get_stream_post(DateTime dateSince, string providerName)
        {
            string messageLine = "post_id = {0} message_id = {1} date = {2}";
            StringBuilder str = new StringBuilder();
            Int64 wLastStoredPostTimeStamp = DateFunctions.DateTimeToUnixTimeStamp(dateSince);
            
            fql_query_response wResponses = FacebookWrapper.GetNewerStream(wLastStoredPostTimeStamp, provider.UserAccessToken, provider.SourceId, FacebookWrapper.Config.Limit);
            
            //Por cada post encontrado...
            foreach (stream_post wItem in wResponses.stream_post)
            {
                try
                {
                    str.AppendLine("----------------------------inicio post ---------------------------");

                    str.AppendLine(string.Format(messageLine, wItem.post_id, wItem.actor_id, DateFunctions.UnixTimeStampToDateTime(Convert.ToInt64(wItem.created_time)).ToLongDateString()));
                    str.AppendLine(Environment.NewLine);
                    str.AppendLine(wItem.message);
                    str.AppendLine(Environment.NewLine);
                    str.AppendLine("-----------------------------fin post--------------------------");
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al transaccionar los nuevos posts", ex);
                }
            }
            return str.ToString();
        }
        /// <summary>
        /// Inserta los mensajes junto a sus recipientes (destinatarios) en el "InsertOnSubmit" para que luego sean insertados en la BD.
        /// </summary>
        /// <param name="pCoreDataContext"></param>
        /// <param name="pThread"></param>
        /// <param name="pMessage"></param>
        private void InsertMessageAndRecipients(thread pThread, message pMessage, string pMailboxUserID)
        {
            Message wMessageCore = null;
            Recipient wRecipient = null;
            User wUser = null;

            wMessageCore = new Message()
            {
                Text = pMessage.body,
                Subject = pThread.subject,
                SourceMessageID = pMessage.message_id,
                CreatedDate = DateFunctions.UnixTimeStampToDateTime(Convert.ToInt64(pMessage.created_time)),
                SenderUser = this.GetUser_From_Database(pMessage.author_id),
                SocialNetworkID = (int)_SocialNetwork,
                MailboxUserID = pMailboxUserID
            };


            _CoreDataContext.Transaction = _CoreDataContext.Connection.BeginTransaction();
                _CoreDataContext.Messages.InsertOnSubmit(wMessageCore);

                foreach (string item in pThread.recipients)
                {
                    wUser = this.GetUser_From_Database(item);

                    if (wUser != wMessageCore.SenderUser)
                    {
                        wRecipient = new Recipient();
                        wRecipient.Message = wMessageCore;
                        wRecipient.RecipientUser = wUser;

                        DataCore.CreateRecipients(wRecipient, _CoreDataContext);
                    }
                }

            
        }



        /// <summary>
        /// Mapea el Post de FB con el Post de Core
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        Post ParseNewPost(stream_post pItem)
        {
            Post wPost = new Post();

            wPost.AppSourceID = pItem.app_id;
            wPost.Message = pItem.message;
            wPost.Permlink = pItem.permalink;
            wPost.SocialNetworkID = Constants.SocialNetworkID;
            wPost.SourcePostID = pItem.post_id;
            wPost.CreationDate = DateFunctions.UnixTimeStampToDateTime(Convert.ToInt64(pItem.created_time));
            wPost.SocialNetworkID = (int)_SocialNetwork;
            wPost.From = this.GetUser_From_Database(pItem.actor_id);
            wPost.To = this.GetUser_From_Database(pItem.target_id);
            wPost.ParentPostID = null;

            return wPost;
        }
        #endregion


        #region [user  methods]




      

        /// <summary>
        /// Método que permite obtener un usuario de la BD o sino se encuentra, buscarlo en Facebook e insertarlo en la BD.
        /// 
        /// Este metodo Crea el usuario en la base de datos en caso de no encontrarce
        /// </summary>
        /// <param name="SourceUserId"></param>
        /// <returns></returns>
        public User GetUser_From_Database(String pSourceUserId)
        {
            if (string.IsNullOrEmpty(pSourceUserId)) { return null; }
            fql_query_response wResponse = null;
            User wUser = DataCore.GetUser(pSourceUserId, Enums.SocialNetworkEnum.Facebook, _CoreDataContext);

            //Si el usuario no existe en la BD lo buscamos en Facebook e intentamos insertarlo en la BD.
            if (wUser == null)
            {
                CreateUser(pSourceUserId);
            }
            else // if (wUser.UserName == null)
            {
                //Si el usuario existe pero el username es nulo, lo actualiza.
                wResponse = FacebookWrapper.GetUser(pSourceUserId, provider.UserAccessToken, FacebookWrapper.Config.Limit);



                if (wResponse.user != null)
                {
                    //Si el usuario es distinto lo actualizo
                    if (wUser.UserName != wResponse.user.username)
                    {
                        //pCoreDataContext.ExecuteCommand("User_u_UserName {0}, {1}", "", "", "");
                        wUser.UserName = wResponse.user.username;
                        //pCoreDataContext.Users.First(u => u.SourceUserID == wUser.SourceUserID).UserName = wResponse.user.username;
                    }

                    //Si el nombre es distinto lo actualizo
                    if (wUser.Name != wResponse.user.name)
                    {
                        wUser.Name = wResponse.user.name;
                    }
                }
                else
                {
                    //Si el usuario no lo encontramos en Facebook preguntamos si es una página.
                    wResponse = FacebookWrapper.GetPage(pSourceUserId, provider.UserAccessToken, FacebookWrapper.Config.Limit);


                    if (wResponse.page != null)
                    {
                        if (wUser.Name != wResponse.page.name)
                        {
                            wUser.Name = wResponse.page.name;
                            wUser.UserName = wResponse.page.name;
                        }
                    }
                }
            }

            return wUser;
        }



        /// <summary>
        /// Obtiene un usuario desde la bas de datos Facebook (tabla user del esquema de facebook)
        /// </summary>
        /// <param name="pSourceUserId"></param>
        /// <returns></returns>
        public User GetUser_From_Facebook(String pSourceUserId)
        {
            User wUser = null;
            fql_query_response wResponse = FacebookWrapper.GetUser(pSourceUserId, provider.UserAccessToken, FacebookWrapper.Config.Limit);


            if (wResponse.user != null)
            {
                wUser = new User()
                {
                    Active = true,
                    Name = wResponse.user.name,
                    UserName = wResponse.user.username,
                    CreationDate = System.DateTime.Now,
                    ImageUrl = wResponse.user.pic_small,
                    SourceUserID = wResponse.user.uid,
                    SocialNetworkID = (int)_SocialNetwork,
                    Followers = 0
                };

                return wUser;

            }

            //Si el usuario no lo encontramos en Facebook preguntamos si es una página. Si no es una página creamos un user para mantener consistencia.
            wResponse = FacebookWrapper.GetPage(pSourceUserId, provider.UserAccessToken, FacebookWrapper.Config.Limit);
            if (wResponse.page != null)
            {
                wUser = new User()
                {
                    Active = true,
                    Name = wResponse.page.name,
                    UserName = wResponse.page.name,
                    CreationDate = System.DateTime.Now,
                    ImageUrl = wResponse.page.pic_small,
                    SourceUserID = wResponse.page.page_id,
                    SocialNetworkID = (int)_SocialNetwork,
                    Followers = 0
                };
            }
            else
            {
                wUser = new User()
                {
                    Active = true,
                    Name = pSourceUserId,
                    UserName = pSourceUserId,
                    CreationDate = System.DateTime.Now,
                    ImageUrl = string.Empty,
                    SourceUserID = pSourceUserId,
                    SocialNetworkID = (int)_SocialNetwork,
                    Followers = 0
                };
            }

            return wUser;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSourceUserId"></param>
        void CreateUser(String pSourceUserId)
        {
            User wUser = GetUser_From_Facebook(pSourceUserId);
            _CoreDataContext.Users.InsertOnSubmit(wUser);
            _CoreDataContext.SubmitChanges();
            
        }


        #endregion



    }
}