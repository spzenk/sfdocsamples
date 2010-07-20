using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Sockets;


namespace FTPTest
{

    public class FTPFactory
    {

        public static void Upload(string localfile, string ftpUrl, bool bin)
        {
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(ftpUrl);
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.UseBinary = bin;
            
            if (bin)
            {
                Stream instm = new FileStream(localfile, FileMode.Open,
                FileAccess.Read);
                Stream outstm = req.GetRequestStream();
                byte[] b = new byte[10000];
                int n;
                while ((n = instm.Read(b, 0, b.Length)) > 0)
                {
                    outstm.Write(b, 0, n);
                }
                instm.Close();
                outstm.Close();
            }
            else
            {
                StreamReader sr = new StreamReader(localfile);
                StreamWriter sw = new StreamWriter(req.GetRequestStream());
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sw.WriteLine(line);
                }
                sr.Close();
                sw.Close();
            }
            FtpWebResponse resp = (FtpWebResponse)req.GetResponse();
            //Console.WriteLine(resp.StatusCode);
        }

        public static bool DeleteFileOnServer(Uri serverUri)
        {
            // The serverUri parameter should use the ftp:// scheme.
            // It contains the name of the server file that is to be deleted.
            // Example: ftp://contoso.com/someFile.txt.
            // 

            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Method = WebRequestMethods.Ftp.DeleteFile;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("Delete status: {0}", response.StatusDescription);
            response.Close();
            return true;
        }




    }
}
