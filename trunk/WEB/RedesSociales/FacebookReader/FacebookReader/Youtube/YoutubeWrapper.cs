using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.YouTube;
using Google.GData.Extensions.MediaRss;
using Google.GData.Client;

using System.Net;

namespace Fwk.SocialNetworks.Youtube
{
    public class YoutubeWrapper
    {
        internal static WebProxy Proxy = null;
          




        static YoutubeWrapper()
        {
            WebProxy wWebProxy = new WebProxy("http://proxy", 3128);

            wWebProxy.Credentials = new System.Net.NetworkCredential("moviedo", "Lincelin6", "ALLUS-AR");


            Proxy = wWebProxy;
        }

        public static string PrintVideoFeed(Feed<Video> feed)
        {
            StringBuilder str = new StringBuilder();
            foreach (Video entry in feed.Entries)
            {
                str.AppendLine( PrintVideoEntry(entry));
            }

            return str.ToString();
        }

        public static string PrintVideoEntry(Video video)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("Title: " + video.Title);
            str.AppendLine(video.Description);
            str.AppendLine("Keywords: " + video.Keywords);
            str.AppendLine("Uploaded by: " + video.Uploader);
            if (video.YouTubeEntry.Location != null)
            {
                str.AppendLine("Latitude: " + video.YouTubeEntry.Location.Latitude);
                str.AppendLine("Longitude: " + video.YouTubeEntry.Location.Longitude);
            }
            if (video.Media != null && video.Media.Rating != null)
            {
                str.AppendLine("Restricted in: " + video.Media.Rating.Country);
            }

            if (video.IsDraft)
            {
                str.AppendLine("Video is not live.");
                string stateName = video.Status.Name;
                if (stateName == "processing")
                {
                    str.AppendLine("Video is still being processed.");
                }
                else if (stateName == "rejected")
                {
                    Console.Write("Video has been rejected because: ");
                    str.AppendLine(video.Status.Value);
                    Console.Write("For help visit: ");
                    str.AppendLine(video.Status.Help);
                }
                else if (stateName == "failed")
                {
                    Console.Write("Video failed uploading because:");
                    str.AppendLine(video.Status.Value);

                    Console.Write("For help visit: ");
                    str.AppendLine(video.Status.Help);
                }

                if (video.ReadOnly == false)
                {
                    str.AppendLine("Video is editable by the current user.");
                }

                if (video.RatingAverage != -1)
                {
                    str.AppendLine("Average rating: " + video.RatingAverage);
                }
                if (video.ViewCount != -1)
                {
                    str.AppendLine("View count: " + video.ViewCount);
                }

                str.AppendLine("Thumbnails:");
                foreach (MediaThumbnail thumbnail in video.Thumbnails)
                {
                    str.AppendLine("\tThumbnail URL: " + thumbnail.Url);
                    str.AppendLine("\tThumbnail time index: " + thumbnail.Time);
                }

                str.AppendLine("Media:");
                foreach (Google.GData.YouTube.MediaContent mediaContent in video.Contents)
                {
                    str.AppendLine("\tMedia Location: " + mediaContent.Url);
                    str.AppendLine("\tMedia Type: " + mediaContent.Format);
                    str.AppendLine("\tDuration: " + mediaContent.Duration);
                }


            }

            return str.ToString();


        }

        static string feed_video_q_starti_max_v = " http://gdata.youtube.com/feeds/api/videos?q={0}&start-index={1}&max-results={2}&v={3}";
        static string feeds_uploads = "http://gdata.youtube.com/feeds/api/users/{0}/uploads";
        /// <summary>
        /// Un feed de vídeos puede contener un máximo de 999 entradas
        /// </summary>
        /// <param name="filter">skateboarding+dog</param>
        /// <param name="startIndex">12</param>
        /// <param name="maxResults">11 resultados</param>
        /// <returns></returns>
        internal static string Get_Url_Feed_Video(string filter, int startIndex, int maxResults)
        {

            string feedUrl = String.Format("http://gdata.youtube.com/feeds/api/users/{0}/uploads?orderby=published","moviedomof");


            feedUrl = String.Format(feeds_uploads,"moviedomof");

        ///http://gdata.youtube.com/feeds/api/users/GoogleDevelopers/uploads
            return feedUrl ;
        }

        internal static string Get_Video()
        {

            string feedUrl = "http://gdata.youtube.com/feeds/api/users/GoogleDevelopers/uploads";



      
            return feedUrl;
        }


        /// <summary>
        /// OAuth in the Google Data Protocol Client Libraries 
        /// http://code.google.com/intl/es-AR/apis/gdata/docs/auth/oauth.html
        /// </summary>
        /// <returns></returns>
        internal static string FetchingReqToken()
        { 
         
            string CONSUMER_KEY = "pelsoft";
            string CONSUMER_SECRET = "lincelince"; 
            string SCOPE ="http://gdata.youtube.com";
            // Multi-scoped token. string SCOPE = "https://www.google.com/calendar/feeds/ https://www.google.com/m8/feeds/";
            //OAuthParameters parameters = new OAuthParameters()
            //{
            //    ConsumerKey = CONSUMER_KEY,
            //    ConsumerSecret = CONSUMER_SECRET,
            //    Scope = SCOPE,
            //    Callback = "http://muniadelia.com/access_token",
            //    SignatureMethod = "HMAC-SHA1"
            //};
            Uri u = new Uri(@"http://www.muniadelia.com/access_token");
            string str = OAuthUtil.GenerateHeader(u, CONSUMER_KEY, CONSUMER_SECRET, "HMAC-SHA1");

            return str;
        }
    }
}
