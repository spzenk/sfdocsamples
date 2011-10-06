//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;
//using System.Net;

//using Google.GData.Client;
//using Google.GData.Extensions;
//using Google.GData.YouTube;
//using Google.GData.Extensions.MediaRss;
//using Google.YouTube;
//using Fwk.SocialNetworks.Youtube;


//namespace Fwk.SocialNetworks.Data
//{
//    public partial class FrmYoutube : Form
//    {
//        static string developerKey = "AI39si4vdjfNiGLb-a_6bys-gi_eyyWcDb9uOg_mWvUNYlFbd1fHYBs00yiACHhq8JhNktfNmjRGcftD7pnVN9m2qJ5rzmTvWw";
//        public FrmYoutube()
//        {
//            InitializeComponent();
//        }


//        void GET(string inURL)
//        {
//            HttpWebRequest myHttpWebRequest = null;     //Declare an HTTP-specific implementation of the WebRequest class.
//            HttpWebResponse myHttpWebResponse = null;   //Declare an HTTP-specific implementation of the WebResponse class

//            try
//            {
//                //Create Request
//                myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(inURL);
//                myHttpWebRequest.Method = "GET";
//                myHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";

//                //Get Response
//                myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
//            }
//            catch (Exception myException)
//            {
//                throw new Exception("Error Occurred in AuditAdapter.getXMLDocumentFromXMLTemplate()", myException);
//            }
//            finally
//            {
//                myHttpWebRequest = null;
//                myHttpWebResponse = null;

//            }


//        }
//        void Authenticate(string userName, string password)
//        {


//            YouTubeService service = new YouTubeService("pelsoft", developerKey);

//            service.setUserCredentials(userName, password);
//            //textbox1 contains username and maskedTextBox1 contains password
//            try
//            {
//                service.QueryClientLoginToken();
//            }
//            catch (System.Net.WebException e)
//            { MessageBox.Show(e.Message); }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="userName"></param>
//        /// <param name="password"></param>
//        /// <returns></returns>
//        YouTubeRequest GetYouTubeRequest(string userName, string password)
//        {
//            string authSubUrl = AuthSubUtil.getRequestUrl("http://www.allus.com", "http://gdata.youtube.com", false, true);
//           //http://www.allus.com/?token=1/-PrMunnSjR9rgZMV5PCGvqWgPotjTEGM88QKM2Ja6QI
          
//            Init();

          
//            return null;
//        }
//        static string Token = "OM6EQdR00weJ7ijwqFMpFDJ42OFfRrRj4gJGxZfe4P8";
//        void Init()
//        {
//            GAuthSubRequestFactory authFactory = new GAuthSubRequestFactory(ServiceNames.YouTube, "YouTubeAspSample");
//            YouTubeService service = new YouTubeService(authFactory.ApplicationName,
//              "ytapi-FrankMantek-TestaccountforGD-sjgv537n-0",
//              developerKey
//              );

//            authFactory.Token = Token;
//            service.RequestFactory = authFactory;

//           var videos = GetVideos(YouTubeQuery.DefaultUploads);
                     
//        }

//        static   IEnumerable<Video> GetVideos(string videofeed)
//        {
//            YouTubeQuery query = new YouTubeQuery(videofeed);
//            return GetVideos(query);
//        }
//        private static IEnumerable<Video> GetVideos(YouTubeQuery q)
//        {
//            YouTubeRequest request = GetRequest();
//            Feed<Video> feed = null;


//            try
//            {
//                feed = request.Get<Video>(q);
//            }
//            catch (GDataRequestException gdre)
//            {
//                HttpWebResponse response = (HttpWebResponse)gdre.Response;
//            }
//            return feed != null ? feed.Entries : null;
//        }
//        public static IEnumerable<Playlist> PlayLists()
//        {
//            Feed<Playlist> feed = null;
//            YouTubeRequest request = GetRequest();


//            try
//            {
//                feed = request.GetPlaylistsFeed(null);
//            }
//            catch (GDataRequestException gdre)
//            {
//                HttpWebResponse response = (HttpWebResponse)gdre.Response;
//            }
//            return feed != null ? feed.Entries : null;
//        }

//        public static  YouTubeRequest GetRequest()
//        {
//            YouTubeRequestSettings settings = new YouTubeRequestSettings("YouTubeAspSample", developerKey, Token);
//            settings.Timeout = 1000000;
//            settings.AutoPaging = true;
//            YouTubeRequest wYouTubeRequest = new YouTubeRequest(settings);
//            wYouTubeRequest.Proxy = YoutubeWrapper.Proxy;

            
            
                
                


//                return wYouTubeRequest;
//        }
//        private void button1_Click(object sender, EventArgs e)
//        {
//            // Authenticate("moviedomof","lincelince");
//            YouTubeRequest request = GetYouTubeRequest("moviedomof", "lincelince");
//            //string s = YoutubeWrapper.FetchingReqToken();
//            //Displaying a feed of videos
//            Feed<Video> videoFeed = request.Get<Video>(new Uri(YoutubeWrapper.Get_Video()));
//            txtRes.Text = YoutubeWrapper.PrintVideoFeed(videoFeed);
//        }
//    }
//}