using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.GData.Extensions.MediaRss;
using Google.YouTube;
using Fwk.SocialNetworks.Youtube;


namespace Fwk.SocialNetworks.Data
{
    public partial class FrmYoutube : Form
    {
        string developerKey = "AI39si4vdjfNiGLb-a_6bys-gi_eyyWcDb9uOg_mWvUNYlFbd1fHYBs00yiACHhq8JhNktfNmjRGcftD7pnVN9m2qJ5rzmTvWw";
        public FrmYoutube()
        {
            InitializeComponent();
        }


        void GET(string inURL)
        {
            HttpWebRequest myHttpWebRequest = null;     //Declare an HTTP-specific implementation of the WebRequest class.
            HttpWebResponse myHttpWebResponse = null;   //Declare an HTTP-specific implementation of the WebResponse class

            try
            {
                //Create Request
                myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(inURL);
                myHttpWebRequest.Method = "GET";
                myHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";

                //Get Response
                myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            }
            catch (Exception myException)
            {
                throw new Exception("Error Occurred in AuditAdapter.getXMLDocumentFromXMLTemplate()", myException);
            }
            finally
            {
                myHttpWebRequest = null;
                myHttpWebResponse = null;

            }


        }
        void Authenticate(string userName, string password)
        {


            YouTubeService service = new YouTubeService("pelsoft", developerKey);

            service.setUserCredentials(userName, password);
            //textbox1 contains username and maskedTextBox1 contains password
            try
            {
                service.QueryClientLoginToken();
            }
            catch (System.Net.WebException e)
            { MessageBox.Show(e.Message); }
        }

        YouTubeRequest GetYouTubeRequest(string userName, string password)
        {
            string authSubUrl = AuthSubUtil.getRequestUrl(@"http://www.allus.com", "http://gdata.youtube.com", false, false);

            //http://www.allus.com/?token=1/jWsaQjdCeZQKYQc3HKQ0Pzy5Oxm8VUiPLVsexE7Wp0A
            //http://www.allus.com/?token=1/4dfiL65QdZmpvOmUr-CJfIwvhK0XE3mcEgFljwBPAxQ
            YouTubeRequestSettings settings = null;// new YouTubeRequestSettings("pelsoft", developerKey, userName, password);

            settings = new YouTubeRequestSettings("http://www.allus.com", developerKey, "4dfiL65QdZmpvOmUr-CJfIwvhK0XE3mcEgFljwBPAxQ");
            settings.Timeout = 1000000;
            YouTubeRequest wYouTubeRequest = new YouTubeRequest(settings);
            wYouTubeRequest.Proxy = YoutubeWrapper.Proxy;

            return wYouTubeRequest;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Authenticate("moviedomof","lincelince");
            YouTubeRequest request = GetYouTubeRequest("moviedomof", "lincelince");

            //request.GetComments(
            //http://gdata.youtube.com/feeds/api/videos


            string s = YoutubeWrapper.FetchingReqToken();
            //Authorization: OAuth o
            //auth_version="1.0",
            //oauth_nonce="77d5b9ce50f34ab8a36da1288d9ed800",
            //oauth_timestamp="1314909000",
            //oauth_consumer_key="pelsoft",
            //oauth_signature_method="HMAC-SHA1",
            //oauth_signature="a%2BH3lyDwMVPzUWJBQk3nCJv1s%2FY%3D"


            //Displaying a feed of videos
            Feed<Video> videoFeed = request.Get<Video>(new Uri(YoutubeWrapper.Get_Video()));

            txtRes.Text = YoutubeWrapper.PrintVideoFeed(videoFeed);


        }






    }
}