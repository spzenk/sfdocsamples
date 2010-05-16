using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.PeerToPeer;
using Slickthought.MVP;
using PNRPRegistration.Core;

namespace PNRPRegistration.Presenters
{
    public class MainWorkspacePresenter : PresenterBase
    {
        public CloudPresenter Clouds { get; set; }
        public RegistrationListPresenter RegistrationManager { get; set; }
        public RegistrationPresenter Registration { get; set; }

        public MainWorkspacePresenter(PnrpManager pnrp)
            : base()
        {
            this.Clouds = new CloudPresenter(pnrp);
            this.RegistrationManager = new RegistrationListPresenter(pnrp);
            this.Registration = new RegistrationPresenter(pnrp);
        }


    }
}
