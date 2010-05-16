using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Media.Imaging;


namespace WCFDirectHost.ViewModels
{
    public class ImageryViewModel 
    {
        private DateTime _timeStamp;

        public string Agent { get; set; }
        public Bitmap RawImage { get; set; }
        public BitmapSource Image
        {
            get
            {
                return this.RawImage.ConverToBitmapSource();
            }
        }
        public string Caption { get; set; }
        public string TimeStamp { get; set; }

        public ImageryViewModel(string agent, Bitmap image, string caption)
        {
            if (image == null)
                throw new ArgumentException("Image cannot be null");

            this.Agent = agent;
            this.RawImage = image;
            this.Caption = caption;
            _timeStamp = DateTime.Now;
            this.TimeStamp = _timeStamp.ToShortTimeString();
        }
    }
}
