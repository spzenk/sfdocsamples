using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using WCFDirectHost.Services;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Reflection;
using System.IO;
using System.Windows;

namespace WCFDirectHost.ViewModels
{
    public class AgentViewModel : INotifyPropertyChanged
    {
        private AgentProfile _agentProfile;

        private bool _isOnline = false;
        public bool IsOnline {
            get { return _isOnline; }
            set {
                if (value != _isOnline)
                {
                    _isOnline = value;
                    OnPropertyChanged("IsOnline");
                }
            }
        }

        public string Agent { get { return _agentProfile.Agent; } }
       
        public BitmapSource Image
        {
            get
            {
                if (_agentProfile.Image == null)
                {
                    Assembly myAssembly = Assembly.GetExecutingAssembly();
                    Stream myStream = myAssembly.GetManifestResourceStream("WCFDirectHost.Images.pnrp.jpg");
                    _agentProfile.Image = new Bitmap(myStream);
                }

                //Validate object being converted
                if (_agentProfile.Image is System.Drawing.Bitmap)
                {
                    //Use existing Interop functionality to perform conversion
                    IntPtr HBitmap = ((System.Drawing.Bitmap)_agentProfile.Image).GetHbitmap();


                    System.Windows.Media.Imaging.BitmapSizeOptions sizeOptions =
                      System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions();



                    return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                      HBitmap, IntPtr.Zero, Int32Rect.Empty, sizeOptions);
                }
                else
                {
                    //We don't want the conversion to fail if it's not valid
                    return null;
                }

            }
        }

        public AgentViewModel(AgentProfile agentProfile)
        {
            if (agentProfile == null)
                throw new ArgumentException("Cannot have null AgentProfile");

            if (string.IsNullOrEmpty(agentProfile.Agent))
                throw new ArgumentException("AgentProfile cannot have null or empty Agent string");

            _agentProfile = agentProfile;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
