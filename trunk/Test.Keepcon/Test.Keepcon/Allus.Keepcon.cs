﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Security.Cryptography;
using System.IO;

namespace Allus.Keepcon
{
    public class KeepconSvc
    {
        //Enviando / obteniendo contenidos a moderar
        static string url_send_content_asynk = "http://service.keepcon.com/input/contentSet";
        static string url_send_content_synk = "http://sync.keepcon.com/synchronic/moderate";
        static string url_get_result = "http://service.keepcon.com/output/contentSet?contextName={0}&clientACK=true";
        static string url_ack = "http://service.keepcon.com:63081/output/contentSet/ack/{0}";


        static string user;
        static string password;
        static WebProxy Proxy = null;
        static KeepconSvc()
        {
            WebProxy wWebProxy = new WebProxy("proxyallus", 3128);
            wWebProxy.Credentials = new System.Net.NetworkCredential("moviedo", "Lincelin4", "allus-ar");
            Proxy = wWebProxy;

            user = "MovistarPostDemo";
            password = "k33pc0n12112012";
        
        }

        public static string SendContent(Allus.Keepcon.Import.Import import)
        {
            try
            {
                if(import.Contents.Count==1)
                    return HttpPUT(url_send_content_synk, import.GetXml());
                else
                return HttpPUT(url_send_content_asynk, import.GetXml());
            }
            catch (Exception ex)
            {
                return Fwk.Exceptions.ExceptionHelper.GetAllMessageException( ex);
            }
        }

        public static string RetriveResult()
        {
            try
            {
                return HttpPUT(string.Format(url_get_result, user), string.Empty);
            }
            catch (Exception ex)
            {
                return Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
        }
        public static string SendASK(string setId)
        {
            try
            {
                return HttpPUT(string.Format(url_ack, setId), string.Empty);
            }
            catch (Exception ex)
            {
                return Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
        }


        public static String HttpPUT(string url, string inputData, int? pTimeout = null)
        {

            Uri wUrl = new Uri(url);
            string wXmlRes = string.Empty; 
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(wUrl);
            req.KeepAlive = false;

            if (pTimeout.HasValue)
            {
                req.Timeout = pTimeout.Value;
                req.ServicePoint.ConnectionLeaseTimeout = pTimeout.Value;
                req.ServicePoint.MaxIdleTime = pTimeout.Value;
                req.ServicePoint.MaxIdleTime = pTimeout.Value;
                req.ReadWriteTimeout = pTimeout.Value;
            }

            if (Proxy != null)
            {
                req.Proxy = Proxy;
            }



            req.Method = "PUT";
            req.ContentType = "";//"application/x-www-form-urlencoded";

            req.Credentials = new NetworkCredential(user, password);

            ASCIIEncoding wEncoding = new ASCIIEncoding();
            Byte[] wByte = wEncoding.GetBytes(inputData);
            req.ContentLength = wByte.Length;
            using (Stream wRequestStream = req.GetRequestStream())
            {


                wRequestStream.Write(wByte, 0, wByte.Length);
                wRequestStream.Flush();
                wRequestStream.Close();
            }
            
            using (HttpWebResponse wResponse = (HttpWebResponse)req.GetResponse())
            {
                StreamReader wReader = new StreamReader(wResponse.GetResponseStream());
                 wXmlRes = Fwk.HelperFunctions.FileFunctions.GetTextFromReader(wReader);

                
            }
            return wXmlRes;
        }

    }
}
