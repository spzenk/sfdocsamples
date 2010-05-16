using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.PeerToPeer;
using Slickthought.MVP;
using PNRPRegistration.Core;

namespace PNRPRegistration.Presenters
{
    public class RegistrationListPresenter : PresenterBase
    {
        PnrpManager _service;

        public ReadOnlyObservableCollection<PeerNameRegistration> RegistrationsInScope { get { return _service.RegistrationsInScope; } }

        public PresenterCommand DeleteRegistrationCommand { get; set; }

        public RegistrationListPresenter(PnrpManager service) 
        {
            _service = service;     
        }

        protected override void InitializeCommands()
        {
            this.DeleteRegistrationCommand = new PresenterCommand
            {
                CanExecuteDelegate = code => true,
                ExecuteDelegate = code =>
                {
                    PeerNameRegistration reg = code as PeerNameRegistration;
                    if (reg != null)
                    {
                        _service.DeleteRegistration(reg);
                    }
                }
            };
        }

       
    }
}
