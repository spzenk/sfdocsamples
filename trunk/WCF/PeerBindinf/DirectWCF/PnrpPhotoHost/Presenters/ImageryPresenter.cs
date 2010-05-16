using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Slickthought.MVP;
using WCFDirectHost.ViewModels;
using System.Collections.ObjectModel;
using WCFDirectHost.Services;

namespace WCFDirectHost.Presenters
{
    public class ImageryPresenter  : PresenterBase
    {

        public ObservableCollection<ImageryViewModel> Imagery { get; set; }

        private ImageryViewModel _recentImagery = null;
        public ImageryViewModel MostRecentImagery { 
            get { return _recentImagery; }
            private set
            {
                if (_recentImagery != null && _recentImagery.Equals(value))
                    return;

                _recentImagery = value;
                OnPropertyChanged("MostRecentImagery");
            }
        }

        public ImageryPresenter() : base()
        {
            this.Imagery = new ObservableCollection<ImageryViewModel>();
        }

        public void OnImageryReceived(object sender, IntelEventArgs args)
        {
            ImageryViewModel imageViewModel = new ImageryViewModel(args.AgentProfile.Agent, args.Image, args.Caption);
            this.MostRecentImagery = imageViewModel;
            this.Imagery.Add(imageViewModel);
        }
    }
}
