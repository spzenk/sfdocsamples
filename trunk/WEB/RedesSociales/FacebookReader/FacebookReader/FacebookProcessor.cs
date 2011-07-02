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
using Fwk.SocialNetworks.Facebook.Configuration;
using System.Transactions;


namespace Fwk.SocialNetworks.Facebook
{
    public class FacebookProcessor
    {
        Timer _Timer;

        #region [Members & Constructor]

        SocialNetwork _SocialNetwork = null;
        FacebookConfig _FacebookConfigSection;

      
        #endregion



        public void InitSettings()
        {

            try
            {
                _FacebookConfigSection = (System.Configuration.ConfigurationManager.GetSection("FacebookConfig") as FacebookConfig);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar levantar la configuración de la seccion [FacebookConfig] de Facebook", ex);
            }

            if (_SocialNetwork == null)
            {
                //Busca la red social correspondiente.
                _SocialNetwork = DataCore.GetSocialNetwork(Enums.SocialNetwork.Facebook);
            }


            if (_FacebookConfigSection.Proxy != null)
            {
                if (_FacebookConfigSection.Proxy.IsBypassed)
                {
                    WebProxy wWebProxy = new WebProxy(_FacebookConfigSection.Proxy.Name, _FacebookConfigSection.Proxy.Port);

                    wWebProxy.Credentials = new System.Net.NetworkCredential(_FacebookConfigSection.Proxy.UserName, _FacebookConfigSection.Proxy.Password, _FacebookConfigSection.Proxy.Domain);


                    FacebookWrapper.Proxy = wWebProxy;
                }
            }
           
        }
 



        #region [Store new post an stream methods]

        /// <summary>
        /// Almacenar nuevo post o agregar comentario a un post existente.
        /// </summary>
        public void StoreNewStream()
        {
   
      
            //Busca la mayor fecha (convertida a timestamp) almacenada en DB.
            Int64 wLastStoredPostTimeStamp = DataCore.GetLastPost();
            //Busca los posts mayores a la fecha obtenida anteriormente.
            fql_query_response wResponses = FacebookWrapper.GetNewerStream(wLastStoredPostTimeStamp, _FacebookConfigSection.DefaultProvider.UserAccessToken, _FacebookConfigSection.DefaultProvider.SourceId, _FacebookConfigSection.Limit);
            //Si no encuentra nuevos posts, no hace nada.
            if (wResponses.stream_post == null) { return; }

            Post wPost = null;
            //Por cada post encontrado...
            foreach (stream_post wItem in wResponses.stream_post)
            {
                try
                {
                  //Inserta el post o agrega un comentario a un post existente segun corresponda.
                    InsertPostOrAddComment(wLastStoredPostTimeStamp, wPost, wItem);

                }
                catch (Exception ex)
                {
                    throw new Exception("Error al transaccionar los nuevos posts", ex);
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

            //Busca la mayor fecha (convertida a timestamp) almacenada en DB.
            Int64 wLastStoredPostTimeStamp = DataCore.GetLastMessage();

            //busca los hilos de mensajes mayores a la fecha obtenida anteriormente.
            wThreadResponse = FacebookWrapper.GetThreadList(wLastStoredPostTimeStamp, _FacebookConfigSection.DefaultProvider.UserAccessToken, _FacebookConfigSection.Limit);



          
            //Por cada hilo de mensajes...
            foreach (thread wThread in wThreadResponse.thread)
            {
                //... Busca los mensajes propiamente dichos del hilo.
                wMessageResponse = FacebookWrapper.GetMessagesInThread(wThread.thread_id, wLastStoredPostTimeStamp, _FacebookConfigSection.DefaultProvider.UserAccessToken, _FacebookConfigSection.Limit);


                //Si el hilo no tiene mensajes, pasa al siguiente hilo.
                if (wMessageResponse.message == null) { continue; }

                //Transaccionar
                //Por cada mensaje del hilo...
                foreach (message wMessage in wMessageResponse.message)
                {
                    try
                    {
                        //Crea y guarda el mensaje.
                        this.InsertMessageAndRecipients(wThread, wMessage, _FacebookConfigSection.DefaultProvider.UserId);

                    }
                    catch (Exception ex)
                    {

                        throw new Exception("Error al transaccionar los nuevos mensajes", ex);
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
            fql_query_response wCommentResponses = FacebookWrapper.GetCommentBySourcePostId(pItem.post_id, _FacebookConfigSection.DefaultProvider.UserAccessToken, _FacebookConfigSection.Limit);


            if (Convert.ToInt64(pItem.created_time) > pLastStoredPostTimeStamp)
            {
                // Post nuevo. Se registra un nuevo post padre y todos sus comentarios.
                pPost = ParseNewPost(pItem);
                DataCore.CreatePost(pPost);

                if (wCommentResponses.comment != null)
                {
                    foreach (comment wItemComment in wCommentResponses.comment)
                    {
                        userFrom = GetUser_From_Database(wItemComment.fromid);
                        DataCore.AddComment(pPost, wItemComment, userFrom, _SocialNetwork);
                    }
                }
            }
            else
            {
                // Post que ya debería estar en la DB. Se ingresan solo los comentarios.
                pPost = DataCore.GetPost(pItem.post_id, Enums.SocialNetwork.Facebook);

                if (wCommentResponses.comment != null)
                {
                    foreach (comment wItemComment in wCommentResponses.comment)
                    {
                        if (Convert.ToInt64(wItemComment.time) > pLastStoredPostTimeStamp)
                        {
                            userFrom = GetUser_From_Database(wItemComment.fromid);
                            DataCore.AddComment(pPost, wItemComment, userFrom, _SocialNetwork);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateSince"></param>
        /// <returns></returns>
        public string GetwMessagesList(DateTime dateSince)
        {
            string messageLine = "thread_id = {0} message_id = {1} date = {2}";
            StringBuilder str = new StringBuilder();
            Int64 wLastStoredMessageTimeStamp = Helper.DateTimeToUnixTimeStamp(dateSince);
            fql_query_response wMessageResponse = null;
            fql_query_response wThreadResponse = FacebookWrapper.GetThreadList(wLastStoredMessageTimeStamp, _FacebookConfigSection.DefaultProvider.UserAccessToken, _FacebookConfigSection.Limit);
            //Por cada hilo de mensajes...
            //Por cada hilo de mensajes...
            foreach (thread wThread in wThreadResponse.thread)
            {
                str.AppendLine("----------------------------inicio thread ---------------------------" );
                str.AppendLine(string.Concat("Subjet:   ", wThread.subject));
                
                //... Busca los mensajes propiamente dichos del hilo.
                wMessageResponse = FacebookWrapper.GetMessagesInThread(wThread.thread_id, wLastStoredMessageTimeStamp, _FacebookConfigSection.DefaultProvider.UserAccessToken, _FacebookConfigSection.Limit);


                //Si el hilo no tiene mensajes, pasa al siguiente hilo.
                if (wMessageResponse.message == null) { continue; }

                //Transaccionar
                //Por cada mensaje del hilo...
                foreach (message wMessage in wMessageResponse.message)
                {
                    try
                    {

                        str.AppendLine(string.Format(messageLine, wMessage.thread_id, wMessage.message_id, Helper.UnixTimeStampToDateTime(Convert.ToInt64(wMessage.created_time)).ToLongDateString()));
                        str.AppendLine(Environment.NewLine);
                        str.AppendLine(wMessage.body);
                        str.AppendLine(Environment.NewLine);
                        //Crea y guarda el mensaje.
                        //this.InsertMessageAndRecipients(wThread, wMessage, _FacebookConfigSection.DefaultProvider.UserId);

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
                CreatedDate = Helper.UnixTimeStampToDateTime(Convert.ToInt64(pMessage.created_time)),
                SenderUser = this.GetUser_From_Database(pMessage.author_id),
                SocialNetwork = _SocialNetwork,
                MailboxUserID = pMailboxUserID
            };
            using (var trans = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted },
                           EnterpriseServicesInteropOption.Automatic))
            {

                DataCore.CreateMessage(wMessageCore);

                foreach (string item in pThread.recipients)
                {
                    wUser = this.GetUser_From_Database(item);

                    if (wUser != wMessageCore.SenderUser)
                    {
                        wRecipient = new Recipient();
                        wRecipient.Message = wMessageCore;
                        wRecipient.RecipientUser = wUser;

                        DataCore.CreateRecipients(wRecipient);
                    }
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
            wPost.CreationDate = Helper.UnixTimeStampToDateTime(Convert.ToInt64(pItem.created_time));
            wPost.SocialNetwork = _SocialNetwork;
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
            User wUser = DataCore.GetUser(pSourceUserId, Enums.SocialNetwork.Facebook);

            //Si el usuario no existe en la BD lo buscamos en Facebook e intentamos insertarlo en la BD.
            if (wUser == null)
            {
                CreateUser(pSourceUserId);
            }
            else // if (wUser.UserName == null)
            {
                //Si el usuario existe pero el username es nulo, lo actualiza.
                wResponse = FacebookWrapper.GetUser(pSourceUserId, _FacebookConfigSection.DefaultProvider.UserAccessToken, _FacebookConfigSection.Limit);



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
                    wResponse = FacebookWrapper.GetPage(pSourceUserId, _FacebookConfigSection.DefaultProvider.UserAccessToken, _FacebookConfigSection.Limit);


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
        /// 
        /// </summary>
        /// <param name="pSourceUserId"></param>
        /// <returns></returns>
        public User GetUser_From_Facebook(String pSourceUserId)
        {
            User wUser = null;
            fql_query_response wResponse = FacebookWrapper.GetUser(pSourceUserId, _FacebookConfigSection.DefaultProvider.UserAccessToken, _FacebookConfigSection.Limit);


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
                    SocialNetwork = _SocialNetwork,
                    Followers = 0
                };

                return wUser;

            }

            //Si el usuario no lo encontramos en Facebook preguntamos si es una página. Si no es una página creamos un user para mantener consistencia.
            wResponse = FacebookWrapper.GetPage(pSourceUserId, _FacebookConfigSection.DefaultProvider.UserAccessToken, _FacebookConfigSection.Limit);
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
                    SocialNetwork = _SocialNetwork,
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
                    SocialNetwork = _SocialNetwork,
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

            DataCore.CreateUser(wUser);
        }


        #endregion



    }
}