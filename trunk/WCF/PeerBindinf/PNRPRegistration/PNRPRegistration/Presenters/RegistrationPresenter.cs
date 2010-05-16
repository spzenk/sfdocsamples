using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Net.PeerToPeer;
using Slickthought.MVP;
using Slickthought.MVP.Services;
using PNRPRegistration.Core;
using PNRPRegistration.Views;

namespace PNRPRegistration.Presenters
{
    public class RegistrationPresenter : PresenterBase
    {
        private PnrpManager _service;
        PeerNameType _peerNameType = PeerNameType.Secured;

        public PresenterCommand CreateRegistrationCommand { get; set; }
        public PresenterCommand SetSecureCommand { get; set; }
        public PresenterCommand LookupRegistrationCommand { get; set; }

        string _peerClassifier = string.Empty;

        public string PeerClassifier {
            get { return _peerClassifier; }
            set { _peerClassifier = value; OnPropertyChanged("PeerClassifier"); }
        }

        public RegistrationPresenter(PnrpManager service)
            : base()
        {
            _service = service;
        }

        protected override void InitializeCommands()
        {
            this.CreateRegistrationCommand = new PresenterCommand()
            {
                CanExecuteDelegate = code => PeerClassifier.Length > 0,
                ExecuteDelegate = code =>
                {
                    PeerName name = new PeerName(this.PeerClassifier,_peerNameType);

                    try
                    {
                        _service.CreateRegistration(name, 8080);
                    }
                    catch (PeerToPeerException ex)
                    {
                        ServiceLocator.Resolve<IMessageBoxService>().ShowError(ex.Message);
                    }
                    finally
                    {

                        this.PeerClassifier = string.Empty;
                    }
                }
            };

            this.SetSecureCommand = new PresenterCommand()
            {
                CanExecuteDelegate = secure => true,
                ExecuteDelegate = secure =>
                    {
                        _peerNameType = ((bool)secure) ? PeerNameType.Secured : PeerNameType.Unsecured;
                    }
            };

            this.LookupRegistrationCommand = new PresenterCommand
            {
                CanExecuteDelegate = code => PeerClassifier.Length>0,
                ExecuteDelegate = code =>
                    {
                        try
                        {
                            PeerName peer = new PeerName(PeerClassifier, _peerNameType);
                            LookupPresenter presenter = new LookupPresenter(peer,_service);
                            ServiceLocator.Resolve<IDialogService>().ShowDialog("LookUpRegistration", presenter);
                        }
                        catch (PeerToPeerException ex)
                        {
                            ServiceLocator.Resolve<IMessageBoxService>().ShowError(ex.Message);
                        }
                        finally
                        {
                            this.PeerClassifier = string.Empty;
                        }
                    }
            };
        }
    }
}
