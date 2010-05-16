using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.PeerToPeer;
using Slickthought.MVP;
using System.Collections.ObjectModel;
using System.Collections;
using PNRPRegistration.ViewModel;
using PNRPRegistration.Core;
using Slickthought.MVP.Services;


namespace PNRPRegistration.Presenters
{
    public class CloudPresenter :    PresenterBase
    {
        PnrpManager _pnrpService;

        public PresenterCommand SetScopeCommand { get; private set; }

        public ReadOnlyObservableCollection<CloudInfo> CloudsInScope { get { return _pnrpService.CloudsInScope; } }

        public CloudPresenter(PnrpManager pnrpService)
        {
            _pnrpService = pnrpService;
            _pnrpService.CurrentScope = PnrpScope.All;
           
        }


        protected override void InitializeCommands()
        {
            SetScopeCommand = new PresenterCommand
            {
                CanExecuteDelegate = s => true,
                ExecuteDelegate = s =>
                    {
                        string scope = (string)s;
                        PnrpScope newScope = PnrpScope.All;

                        switch (scope.ToUpper())
                        {
                            case "ALL":
                                newScope = PnrpScope.All;
                                break;
                            case "GLOBAL":
                                newScope = PnrpScope.Global;
                                break;
                            case "LINKLOCAL":
                                newScope = PnrpScope.LinkLocal;
                                break;
                        }

                        _pnrpService.CurrentScope = newScope;                  
                    }
            };
        }
    }
}
