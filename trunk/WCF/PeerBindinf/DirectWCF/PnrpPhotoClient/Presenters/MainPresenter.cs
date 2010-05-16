using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Slickthought.MVP;
using WCFDirectClient.Services;

namespace WCFDirectClient.Presenters
{
    public class MainPresenter : PresenterBase
    {
        public ServicePresenter Service { get; private set; }
        public IntelDataPresenter IntelData { get; private set; }

        public MainPresenter(IIntelClient intelClient)
        {
            this.Service = new ServicePresenter(intelClient);
            this.IntelData = new IntelDataPresenter(intelClient);
        }

        public override void Close()
        {
            this.Service.Close();
            this.IntelData.Close();
            base.Close();
        }
    }
}
