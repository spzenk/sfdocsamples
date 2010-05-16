using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Slickthought.MVP;
using WCFDirectHost.Services;
using System.Threading;

namespace WCFDirectHost.Presenters
{
    public class MainPresenter : PresenterBase
    {
        private IntelService _intelService;

        public ServicePresenter Service { get; private set; }
        public AgentStatusPresenter AgentStatus { get; private set; }
        public ImageryPresenter Imagery { get; private set; }

        public MainPresenter(SynchronizationContext syncContext)
        {
            _intelService = new IntelService(syncContext);
            this.Service = new ServicePresenter(_intelService, new IntelServiceHost(new PeerRegistrationService()));

            this.AgentStatus = new AgentStatusPresenter();
            this.Imagery = new ImageryPresenter();

            this.Service.IntelService.AgentStatusChanged += this.AgentStatus.OnAgentStatusChanged;
            this.Service.IntelService.IntelReceived += this.Imagery.OnImageryReceived;
          
        }

        public override void Close()
        {
            this.Service.Close();
            base.Close();
        }
    }
}
