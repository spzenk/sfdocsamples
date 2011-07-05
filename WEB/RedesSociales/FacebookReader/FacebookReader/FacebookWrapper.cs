using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Fwk.SocialNetworks.Facebook.Configuration;
using System.Xml;
using System.Xml.Serialization;
using Fwk.HelperFunctions;

namespace  Fwk.SocialNetworks.Facebook
{
    public class FacebookWrapper
    {
        #region Properties

        /// <summary>
        /// Proxy de la red para hacer el request HTTP, puede estar en null
        /// </summary>
        public static WebProxy Proxy = null;
         static string execfaceQuery = "https://api.facebook.com/method/fql.query?query={0}";
         static string sp_stream_by_sourceid_updatedtime = "SELECT updated_time, post_id, created_time, actor_id, target_id, permalink, message, comments FROM stream WHERE source_id = {0} AND updated_time > {1}";
         static string sp_comment_by_post_id = "SELECT fromid, time, text, id FROM comment WHERE post_id = '{0}'"; 
        static string  sp_user_uid ="SELECT pic_small,uid,name FROM user WHERE uid = {0}";

        static string sp_thread_by_folderid_time = "SELECT thread_id, folder_id, subject, recipients, updated_time, parent_message_id, parent_thread_id, message_count, snippet, snippet_author, object_id, unread, viewer_id FROM thread WHERE folder_id = 0 AND updated_time > {0}";

        static string sp_message_by_Threadid_time = "SELECT message_id, thread_id, author_id, body, created_time FROM message WHERE thread_id = {0} AND created_time > {1}";

        static string sp_page_by_pageid= "SELECT page_id, name, pic_small FROM page WHERE page_id = {0}";
        #endregion

        /// <summary>
        /// Ejecuta cualquier query de FQL
        /// </summary>
        /// <param name="wQuery"></param>
        /// <returns></returns>
         private static fql_query_response ExecuteQuery(String pQuery, String accessToken, int? limit)
         {
             fql_query_response res = null;
             error_response er = null;
             String wUrlString = string.Format(execfaceQuery, pQuery);
             if (limit.HasValue)
             {
                 wUrlString = string.Concat(wUrlString, string.Format(" LIMIT {0}", limit.Value));
             }
             wUrlString = string.Concat(wUrlString, string.Format("&access_token={0}", accessToken));
             Uri wUrl = new Uri(wUrlString);
             StreamReader wReader = HttpGet(wUrl);
             res = Helper.DeserializeResponse(wReader, out er);
             if (er != null)
                 throw Helper.MapErrorAndThrowException(er);
             return res;
         }

        /// <summary>
        /// Se conecta a la URI y te devuelve un reader para leer los resultados de la consulta.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static StreamReader HttpGet(Uri pUrl)
        {
            HttpWebRequest wRequest = (HttpWebRequest)WebRequest.Create(pUrl);

            if (Proxy != null)
            {
                wRequest.Proxy = Proxy;
            }

            HttpWebResponse wResponse = (HttpWebResponse)wRequest.GetResponse();

            StreamReader wReader = new StreamReader(wResponse.GetResponseStream());

            return wReader;
        }

        public static StreamReader HttpPost(Uri pUrl)
        {
            HttpWebRequest wRequest = (HttpWebRequest)WebRequest.Create(pUrl);

            if (Proxy != null)
            {
                wRequest.Proxy = Proxy;
            }

            ASCIIEncoding wEncoding = new ASCIIEncoding();
            Byte[] wByte = wEncoding.GetBytes(pUrl.ToString());

            wRequest.Method = "POST";
            wRequest.ContentType = "application/x-www-form-urlencoded";
            wRequest.ContentLength = wByte.Length;

            Stream wRequestStream = wRequest.GetRequestStream();
            wRequestStream.Write(wByte, 0, wByte.Length);
            wRequestStream.Close();

            return HttpGet(pUrl);
        }

        /// <summary>
        /// Query the stream table to obtain the following stream posts:
        /// Public posts (viewable to anyone on Facebook).
        ///     Posts visible to a specific user after user grants the read_stream extended permission.
        ///     Per-post impression data of a Page after a Page owner grants the read_insights extended permission.
        ///     
        /// The stream table is limited to the last 30 days or 50 posts, whichever is greater.
        /// </summary>
        /// <param name="timeStamp">
        /// updated_time The time the post was last updated, which occurs when a user comments on the post.</param>
        /// <param name="userAccessToken"></param>
        /// <param name="pSourceId">source_id (int)
        /// The ID of the user, Page, group, or event whose posts you want to retrieve.
        /// This includes both posts that the user or Page has authored (that is, the actor_id is the source_id) 
        /// and posts that have been directed at this target user, Page, group, or event (that is, the target_id is the source_id).
        /// </param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static fql_query_response GetNewerStream(Int64 timeStamp, String userAccessToken, long sourceId, int? limit)
        {
           return ExecuteQuery( String.Format(sp_stream_by_sourceid_updatedtime, sourceId, timeStamp), userAccessToken, limit);
        }

        /// <summary>
        /// Obtiene los comentarios de un determinado post
        /// </summary>
        /// <param name="pPostId"></param>
        /// <param name="accessToken"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static fql_query_response GetCommentBySourcePostId(String pPostId, String accessToken, int? limit)
        {
            return ExecuteQuery(sp_comment_by_post_id, accessToken, limit);
        }

        /// <summary>
        /// Trae el XML de 1 User de FB
        /// </summary>
        /// <param name="pUserID"></param>
        /// <returns></returns>
        public static fql_query_response GetUser(String sourceUserID, String accessToken, int? limit)
        {
            return ExecuteQuery( String.Format(sp_user_uid, sourceUserID), accessToken, limit);

        }

        /// <summary>
        /// Trae el XML de 1 Page de FB
        /// </summary>
        /// <param name="pUserID"></param>
        /// <returns></returns>
        public static fql_query_response GetPage(String sourceUserID, String accessToken, int? limit)
        {
            return ExecuteQuery( String.Format(sp_page_by_pageid, sourceUserID), accessToken, limit);
        }


        /// <summary>
        /// Obtine hilos de mensages de un usuario o app
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <param name="accessToken"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static fql_query_response GetThreadList(Int64 timeStamp, String accessToken, int? limit)
        {
            return ExecuteQuery(String.Format(sp_thread_by_folderid_time, timeStamp), accessToken, limit);
    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="threadId"></param>
        /// <param name="timeStamp"></param>
        /// <param name="accessToken"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static fql_query_response GetMessagesInThread(String threadId, Int64 timeStamp, String accessToken, int? limit)
        {
            
            return ExecuteQuery(String.Format(string.Format(sp_message_by_Threadid_time, threadId, timeStamp)), accessToken, limit);


        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="pMessage"></param>
        /// <param name="provider">Establece PageAccessToken y  SourceId (app id)</param>
        /// <param name="pSection"></param>
        /// <returns></returns>
        public stream_post PublishToWall(String pMessage, FacebookProvider provider, FacebookConfig pSection)
        {
            String wPublishString = String.Concat(string.Format(@"https://graph.facebook.com/{0}/feed?message={1}", provider.SourceId, pMessage), string.Concat("&access_token=", provider.PageAccessToken));

            Uri wUrl = new Uri(wPublishString);

            //Posteamos a Facebook
            StreamReader wStreamReader = FacebookWrapper.HttpPost(wUrl);

            //Obtenemos en un string todo lo anterior a lo posteado
            string wStreamReaderString = wStreamReader.ReadToEnd();

            //Pasamos a Xml el string obtenido
            XmlDocument wXml = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(wStreamReaderString, "root");

            //Obtenemos la fecha de creación del último post
            string wLastdateString = wXml.FirstChild.FirstChild["created_time"].InnerXml;

            //Pasamos la fecha a fecha universal
            DateTime wLastDate = Convert.ToDateTime(wLastdateString).ToUniversalTime();

            //Obtenemos el post recién ingresado a partir de la fecha.
            long sourceId = provider.SourceId;
            string accessToken = provider.UserAccessToken;
            long unixDateTime = DateFunctions.DateTimeToUnixTimeStamp(wLastDate);
            fql_query_response wLastPost = FacebookWrapper.GetNewerStream(unixDateTime, accessToken, sourceId, pSection.Limit);

            //Si no es null devolvemos el Post recién ingresado
            if (wLastPost.stream_post != null && wLastPost.stream_post.Count() == 1)
            {
                return wLastPost.stream_post[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPostId"></param>
        /// <param name="pMessage"></param>
        /// <param name="provider">Establece PageAccessToken y  SourceId (app id)</param>
        /// <param name="pSection"></param>
        /// <returns></returns>
        public comment CommentPost(String pPostId, String pMessage, FacebookProvider provider, FacebookConfig pSection)
        {
            //StringBuilder wPublishString = new StringBuilder();

            //wPublishString.Append(string.Format(@"https://graph.facebook.com/{0}/comments?message={1}", pPostId, pMessage));

            //wPublishString.Append(string.Format("&access_token={0}", provider.PageAccessToken));

            String wPublishString = String.Concat(string.Format(@"https://graph.facebook.com/{0}/feed?message={1}", provider.SourceId, pMessage), string.Concat("&access_token=", provider.PageAccessToken));

            Uri wUrl = new Uri(wPublishString.ToString());

            //Postea en el muro de Facebook.
            FacebookWrapper.HttpPost(wUrl);

            //Obtiene todos los comentarios del Post recibido por parámetro
            int? limit = pSection.Limit;
            string accessToken = provider.UserAccessToken;

            fql_query_response wPost =  FacebookWrapper.GetCommentBySourcePostId(pPostId, accessToken, limit);


            //Si no es null devuelve el último comentario (es el comentario recién ingresado)
            if (wPost.comment != null)
            {
                return wPost.comment[wPost.comment.Count() - 1];
            }
            else
            {
                return null;
            }
        }
       
         
    }

   


  
}