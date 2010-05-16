using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCFDirectClient.Services;
using Slickthought.MVP;
using System.Drawing;
using WCFDirectHost.Services;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using System.Windows;
using System.Reflection;
using System.IO;
using Slickthought.MVP.Services;

namespace WCFDirectClient.Presenters
{
    public class AgentChangedEventArgs : EventArgs
    {
        public string Agent { get; set; }
    }

    public class ServicePresenter : PresenterBase
    {
        IIntelClient _client;


        public string Agent
        {
            get { return _client.Agent; }
            set
            {
                if (_client.Agent == value)
                    return;

                _client.Agent = value;
                OnPropertyChanged("Agent");
            }
        }

        
        public Bitmap RawImage
        {
            get { return _client.AgentImage; }
            set
            {
                _client.AgentImage = value;
                OnPropertyChanged("IntelImage");
            }
        }
        public BitmapSource IntelImage
        {
            get 
            {
                if (RawImage == null)
                {
                    Assembly myAssembly = Assembly.GetExecutingAssembly();
                    Stream myStream = myAssembly.GetManifestResourceStream("WCFDirectClient.Images.pnrp.jpg");
                    this.RawImage = new Bitmap(myStream);
                }

                if (RawImage is System.Drawing.Bitmap)
                {
                    IntPtr HBitmap = ((System.Drawing.Bitmap)RawImage).GetHbitmap();

                    System.Windows.Media.Imaging.BitmapSizeOptions sizeOptions =
                      System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions();

                    return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                      HBitmap, IntPtr.Zero, Int32Rect.Empty, sizeOptions);
                }
                else
                {
                    return null;
                }
            }
        }

        private string _hostPeerName;
        public string HostClassifier {
            get { return _hostPeerName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Cannot set HostPeerName to Null or Empty.");
                
                if (_hostPeerName != value)
                {
                    _hostPeerName = value;
                    OnPropertyChanged("HostClassifier");
                }
            }
        }

        public bool IsConnected
        {
            get { return _client.IsConnected; }
        }

        public string HostUri
        {
            get { return _client.HostUri; }
        }

        public PresenterCommand StartCommand { get; private set; }
        public PresenterCommand StopCommand { get; private set; }
        public PresenterCommand OpenImageCommand { get; private set; }

        public ServicePresenter(IIntelClient client)
        {
            _client = client;
            _client.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_client_PropertyChanged);
            
        }

        public override void Close()
        {
            _client.Stop();
            base.Close();
        }

        protected override void InitializeCommands()
        {
            this.StartCommand = new PresenterCommand()
            {
                CanExecuteDelegate = (code => { return (!this.IsConnected); }),
                ExecuteDelegate = (code => { _client.Start(this.HostClassifier); })
            };

            this.StopCommand = new PresenterCommand()
            {
                CanExecuteDelegate = (code => { return this.IsConnected; }),
                ExecuteDelegate = (code => { /*_client.Leave(this.Agent); */ _client.Stop(); })
            };

            this.OpenImageCommand = new PresenterCommand()
            {
                CanExecuteDelegate = (code => { return true; }),
                ExecuteDelegate = (code => { OpenImage(); })
            };
        }

        private void OpenImage()
        {
            IOpenFile openFile = this.ServiceLocator.Resolve<IOpenFile>();
            openFile.Filter.Add("Image Files","*.jpg;*.png;*.bmp;*.gif");

            openFile.ShowDialog(false);
            string file = openFile.FileName;

            if (string.IsNullOrEmpty(file))
                return;

            RawImage = new Bitmap(file);
        }

        void _client_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "IsConnected":
                    this.OnPropertyChanged("IsConnected");
                    break;
                case "HostUri":
                    this.OnPropertyChanged("HostUri");
                    break;
            }
        }


        
    }
}
