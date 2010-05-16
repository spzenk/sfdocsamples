using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Reflection;
using System.IO;
using System.Windows;

namespace WCFDirectHost
{
    public static class PhotoExtensions
    {
        public static BitmapSource ConverToBitmapSource(this Bitmap b)
        {
            try
            {
                //Use existing Interop functionality to perform conversion
                IntPtr HBitmap = ((System.Drawing.Bitmap)b).GetHbitmap();

                System.Windows.Media.Imaging.BitmapSizeOptions sizeOptions =
                  System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions();

                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                  HBitmap, IntPtr.Zero, Int32Rect.Empty, sizeOptions);
            }
            catch
            {
                return null;
            }
            
           
        }
    }
}
