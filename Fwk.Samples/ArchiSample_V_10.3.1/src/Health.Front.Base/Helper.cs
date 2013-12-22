using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Fwk.HelperFunctions;
using System.Drawing.Imaging;


namespace Health.Front.Bases
{
   public class Helper
   {
       public static Fwk.UI.Controls.Menu.Tree.TreeMenu LoadMenuFromFile(String pFullFileName)
       {
           //Application.StartupPath
           if (String.IsNullOrEmpty(pFullFileName))
               return null;
           if (!System.IO.File.Exists(pFullFileName))
               return null;

           String wXml = Fwk.HelperFunctions.FileFunctions.OpenTextFile(pFullFileName);
           return Fwk.UI.Controls.Menu.Tree.TreeMenu.GetFromXml<Fwk.UI.Controls.Menu.Tree.TreeMenu>(wXml);

       }
        public static Byte[] LoadImage(Image pImage, string pExtension)
        {
            Byte[] imgByte = null;
            switch (pExtension.ToLower())
            {
                case "":
                case null:
                case ".jpeg":
                case ".jpg":
                    {
                        imgByte = TypeFunctions.ConvertImageToByteArray(pImage, ImageFormat.Jpeg);
                        break;
                    }
                case ".gif":
                    {
                        imgByte = TypeFunctions.ConvertImageToByteArray(pImage, ImageFormat.Gif);
                        break;
                    }
                case ".png":
                    {
                        imgByte = TypeFunctions.ConvertImageToByteArray(pImage, ImageFormat.Png);
                        break;
                    }
                case ".icon":
                    {
                        imgByte = TypeFunctions.ConvertImageToByteArray(pImage, ImageFormat.Icon);
                        break;
                    }
                case ".tiff":
                    {
                        imgByte = TypeFunctions.ConvertImageToByteArray(pImage, ImageFormat.Tiff);
                        break;
                    }
            }


            return imgByte;
        }
    }
   
}
