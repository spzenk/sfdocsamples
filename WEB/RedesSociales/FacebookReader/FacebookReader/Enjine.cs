using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.Configuration;
using System.Net.Mail;

namespace Fwk.SocialNetworks.Twitter
{
    public partial class Enjine : Component
    {

        Timer _Timer; 

        public Enjine()
        {
            InitializeComponent();
        }

        public Enjine(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Start()
        {
            int interval = 0;
            if (ConfigurationManager.AppSettings["ClockInterval"] != null)
             interval = Convert.ToInt32(ConfigurationManager.AppSettings["ClockInterval"]);

            _Timer = new Timer(interval * 1000 * 60);
            //Agrega el manejador del evento de timer.
            _Timer.Elapsed += new ElapsedEventHandler(_Timer_Elapsed);
            //Inicia el timer.
            _Timer.Start();

            
        }

        /// <summary>
        /// Perform twitter logs only
        /// </summary>
        public void Start_Twitter_WithoutTimer()
        {
            this.LogTwitter();
        }
        public void Stop()
        {
            _Timer.Stop();
           // _Timer.Elapsed -=       
        }


        private void _Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _Timer.Enabled = false;

            try
            {
                this.LogFacebook();

                this.LogTwitter();
            }
            finally
            {
                _Timer.Enabled = true;
            }
        }

        #region [Methods]

        /// <summary>
        /// Loguea los post y los mensajes de Facebook en la DB.
        /// </summary>
        private void LogFacebook()
        {
            FacebookProcessor wFacebookFactory = new FacebookProcessor();

            try
            {
                wFacebookFactory.StoreNewStream();
            }
            catch (Exception ex)
            {
                Helper.Log("Facebook Posts", ex);
            }

            try
            {
                wFacebookFactory.StoreNewMessages();
            }
            catch (Exception ex)
            {

                Helper.Log("Facebook Messages", ex);
            }
        }

        /// <summary>
        /// Loguea los tweets y los directmessages de twitter en la DB.
        /// </summary>
        private void LogTwitter()
        {
            TwitterProcessor wTwitterFactory = new TwitterProcessor();

            try
            {
                wTwitterFactory.LogStatuses();
            }
            catch (Exception ex)
            {
                Helper.Log("Twitter LogStatuses", ex);
            }

            try
            {
               wTwitterFactory.LogMessages();
            }
            catch (Exception ex)
            {
                Helper.Log("Twitter LogMessages", ex);
            }
        }

       
 
     
        #endregion
    }
}
