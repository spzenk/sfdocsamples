using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCFDirectHost.Services;
using System.Drawing;
using WCFDirectClient.Services;
using Slickthought.MVP;
using Slickthought.MVP.Services;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Reflection;
using System.IO;

namespace WCFDirectClient.Presenters
{
    public class IntelDataPresenter : PresenterBase
    {
        private IIntelClient _intelClient;

        public string Caption { get; set; }

        private Bitmap _bitmap = null;
        public Bitmap RawImage {
            get { return _bitmap; }
            set
            {
                _bitmap = value;
                OnPropertyChanged("IntelImage");
                OnPropertyChanged("RawImage");
            }
        }

        public BitmapSource IntelImage
        {
            get
            {
                if (RawImage == null)
                {
                    return null;
                }

                return this.RawImage.ConverToBitmapSource();
            }
        }

        private string _agent;
        public string Agent
        {
            get { return _agent; }
            private set
            {
                if (_agent == value)
                    return;

                _agent = value;
                OnPropertyChanged("Agent");
            }
        }

        public PresenterCommand SendCommand { get; private set; }
        public PresenterCommand LoadImageCommand { get; private set; }

        public IntelDataPresenter(IIntelClient intelClient)
        {
            _intelClient = intelClient;
        }

        protected override void InitializeCommands()
        {
            SendCommand = new PresenterCommand()
            {
                CanExecuteDelegate = (code => { return  _intelClient.IsConnected; }),
                ExecuteDelegate = (code => {SendIntel();})
            };

            LoadImageCommand = new PresenterCommand()
            {
                CanExecuteDelegate = (code => { return true; }),
                ExecuteDelegate = (code => { LoadImage(); })
            };
        }

        public void OnAgentChanged(object sender, AgentChangedEventArgs e)
        {
            this.Agent = e.Agent;
        }

        private void LoadImage()
        {
            IOpenFile openFile = this.ServiceLocator.Resolve<IOpenFile>();
            openFile.Filter.Add("Image Files", "*.jpg;*.png;*.bmp;*.gif"); openFile.ShowDialog(false);
            string file = openFile.FileName;

            if (string.IsNullOrEmpty(file))
                return;

            RawImage = new Bitmap(file);
        }

        private void SendIntel()
        {
            IntelData data = new IntelData();
            data.Agent = this.Agent;
            data.Caption = this.Caption;
            data.Image = this.RawImage;

            _intelClient.SendIntel(data);
        }

        
    }
}
