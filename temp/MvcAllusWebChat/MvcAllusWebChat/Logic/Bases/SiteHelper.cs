using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using WebChat.Common.Security;


namespace WebChat.Common
{
    public class SiteHelper
    {
        /// <summary>
        /// Obtener UserSession almacenado en cookie
        /// </summary>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        public static UserSession Get_UserSession_From_Cookies(ActionExecutedContext filterContext)
        {
            return Get_UserSession_From_Cookies(filterContext.RequestContext.HttpContext.Request); 
        }

        /// <summary>
        /// Obtener UserSession almacenado en cookie
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static UserSession Get_UserSession_From_Cookies(HttpRequestBase request)
        {
            UserSession wUserSession = null;
            if (request.IsAuthenticated)
            {
                var cookie = request.Cookies[FormsAuthentication.FormsCookieName];

                if (cookie == null)
                    return null;

                var decrypted = FormsAuthentication.Decrypt(cookie.Value);

                if (!string.IsNullOrEmpty(decrypted.UserData))
                    wUserSession = JsonConvert.DeserializeObject<UserSession>(decrypted.UserData);
            }

            return wUserSession;

        }
        /// <summary>
        /// Returns the name of the virtual folder where our project lives
        /// </summary>
        internal static string VirtualFolder
        {
            get { return HttpContext.Current.Request.ApplicationPath; }
        }

        internal static String CreatePhoto(Guid userId, Byte[] photo, int pNewWidth = 60, int pNewHeight = 60)
        {
            String reducedFile = System.IO.Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "ProfilePhotos", String.Concat(userId, ".jpg"));
            if (!System.IO.File.Exists(reducedFile))
            {
                Image img = Fwk.HelperFunctions.TypeFunctions.ConvertByteArrayToImage(photo);

                using (Bitmap bmpOut = new Bitmap(img, pNewWidth, pNewHeight))
                {
                    //Graphics g = Graphics.FromImage(bmpOut);
                    //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    //g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    //g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    //g.FillRectangle(Brushes.White, 0, 0, pNewWidth, pNewHeight);
                    //g.DrawImage(bmpOut, 0, 0, pNewWidth, pNewHeight);
                    bmpOut.Save(reducedFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }


            return String.Concat(BaseURL, "/ProfilePhotos/", String.Concat(userId, ".jpg"));
        }
        /// <summary>
        /// 
        /// </summary>
        internal static string BaseURL
        {
            get
            {
                try
                {
                    return string.Format("http://{0}{1}",
                                         HttpContext.Current.Request.ServerVariables["HTTP_HOST"],
                                         (VirtualFolder.Equals("/")) ? string.Empty : VirtualFolder);
                }
                catch
                {
                    // This is for design time
                    return null;
                }
            }
        }

        /// <summary>
        /// Este código se encargará de longitud / anchura en el cambio de tamaño.
        /// </summary>
        /// <param name="originalFile"></param>
        /// <param name="reducedFile"></param>
        /// <param name="lnWidth"></param>
        /// <param name="lnHeight"></param>
        /// <returns></returns>
        internal static void CreateThumbnail(string originalFile, string reducedFile, int newWidth, int newHeight)
        {
            //System.Drawing.Bitmap bmpOut = null;

            using (Bitmap originalBMP = new Bitmap(originalFile))
            {
                ImageFormat originalFormat = originalBMP.RawFormat;
                //decimal lnRatio;
                int wNewWidth = newWidth;
                int wNewHeight = newHeight;
                if (originalBMP.Width <= newWidth && originalBMP.Height <= newHeight)
                {
                    originalBMP.Save(reducedFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return;
                }

                //if (originalBMP.Width > originalBMP.Height)
                //{
                //    lnRatio = (decimal)newWidth / originalBMP.Width;
                //    lnNewWidth = newWidth;
                //    decimal lnTemp = originalBMP.Height * lnRatio;
                //    lnNewHeight = (int)lnTemp;
                //}
                //else
                //{
                //    lnRatio = (decimal)newHeight / originalBMP.Height;
                //    lnNewHeight = newHeight;
                //    decimal lnTemp = originalBMP.Width * lnRatio;
                //    lnNewWidth = (int)lnTemp;
                //}

                using (Bitmap bmpOut = new Bitmap(wNewWidth, wNewHeight))
                {
                    Graphics g = Graphics.FromImage(bmpOut);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.FillRectangle(Brushes.White, 0, 0, wNewWidth, wNewHeight);
                    g.DrawImage(originalBMP, 0, 0, wNewWidth, wNewHeight);
                    //loBMP.Dispose();



                    bmpOut.Save(reducedFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }


        public static string GetClientIpAddress(HttpRequestBase request)
        {
            try
            {
                var userHostAddress = request.UserHostAddress;

                // Attempt to parse.  If it fails, we catch below and return "0.0.0.0"
                // Could use TryParse instead, but I wanted to catch all exceptions
                IPAddress.Parse(userHostAddress);

                var xForwardedFor = request.ServerVariables["X_FORWARDED_FOR"];

                if (string.IsNullOrEmpty(xForwardedFor))
                    return userHostAddress;

                // Get a list of public ip addresses in the X_FORWARDED_FOR variable
                var publicForwardingIps = xForwardedFor.Split(',').Where(ip => !IsPrivateIpAddress(ip)).ToList();

                // If we found any, return the last one, otherwise return the user host address
                return publicForwardingIps.Any() ? publicForwardingIps.Last() : userHostAddress;
            }
            catch (Exception)
            {
                // Always return all zeroes for any failure (my calling code expects it)
                return "0.0.0.0";
            }
        }

        private static bool IsPrivateIpAddress(string ipAddress)
        {
            // http://en.wikipedia.org/wiki/Private_network
            // Private IP Addresses are: 
            //  24-bit block: 10.0.0.0 through 10.255.255.255
            //  20-bit block: 172.16.0.0 through 172.31.255.255
            //  16-bit block: 192.168.0.0 through 192.168.255.255
            //  Link-local addresses: 169.254.0.0 through 169.254.255.255 (http://en.wikipedia.org/wiki/Link-local_address)

            var ip = IPAddress.Parse(ipAddress);
            var octets = ip.GetAddressBytes();

            var is24BitBlock = octets[0] == 10;
            if (is24BitBlock) return true; // Return to prevent further processing

            var is20BitBlock = octets[0] == 172 && octets[1] >= 16 && octets[1] <= 31;
            if (is20BitBlock) return true; // Return to prevent further processing

            var is16BitBlock = octets[0] == 192 && octets[1] == 168;
            if (is16BitBlock) return true; // Return to prevent further processing

            var isLinkLocalAddress = octets[0] == 169 && octets[1] == 254;
            return isLinkLocalAddress;
        }



       
    }


    public class WebConstants
    {

        
        public const string NotAuthorizedUser_Redirect = @"~/modules/Admin/Admin_NotAuthorizedUser.aspx?id={0}";

        public const string CaptchaPageUrl_News = "~/Modules/Admin/Admin_SecCapt.aspx?t={0}";

        //public const string ImgPath = "~/store/photos";
        public const string ImgPath = "/store/photos";

        public const int ImgWidth_Small = 210;
        public const int ImgHeight_Small = 190;
        public const int ImgWidth_Medium = 470;
        public const int ImgHeight_Medium = 400;



        /// <summary>
        /// {4} id de la imagen coincide c0on el id del div q la contiene
        /// </summary>
        public const string UrlImageTemplate = "<p><img style=\"cursor:pointer;\" width=\"{3}\" height =\"{4}\" onclick=\"javascript:amply(this,'{5}')\" title=\"{0}\" src=\"{1}\" alt=\"{2}\" border=\"0\" /></p>";

        /// <summary>
        /// Obtiene 
        /// </summary>
        public const string ImageDiv = "<img id=\"{0}\" src=\"{1}\" alt=\"{2}\" />";

        /// <summary>
        /// facebook button Like
        /// {url}
        /// </summary>
        public const string fb_like = "  <fb:like href=\"{0}\" send=\"true\" width=\"450\" show_faces=\"true\" font=\"verdana\"></fb:like>";
    }
}