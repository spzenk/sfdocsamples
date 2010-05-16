using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Slickthought.MVP;
using WCFDirectHost.Services;
using WCFDirectHost.ViewModels;
using System.Collections.ObjectModel;

namespace WCFDirectHost.Presenters
{
    public class AgentStatusPresenter : PresenterBase
    {
        public ObservableCollection<AgentViewModel> Agents { get; set; }

        public AgentStatusPresenter()
            : base()
        {
            this.Agents = new ObservableCollection<AgentViewModel>();
        }

        public void OnAgentStatusChanged(object sender, IntelEventArgs args)
        {
            switch (args.EventType)
            {
                case IntelEventType.AgentEnter:
                    var offline = (from a in this.Agents where a.IsOnline == false select a).ToArray();

                    foreach (var a in offline)
                        this.Agents.Remove(a);

                    AgentViewModel agentViewModel = new AgentViewModel(args.AgentProfile);
                    agentViewModel.IsOnline = true;
                    this.Agents.Add(agentViewModel);
                    break;
                case IntelEventType.AgentLeave:
                    var agent = (from a in this.Agents where a.Agent == args.AgentProfile.Agent select a).First();
                    if (agent != null)
                        agent.IsOnline = false;            
                   
                    break;
            }
        }
    }
}
