using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.PeerToPeer;
using System.Diagnostics;
using Slickthought.MVP;
using Slickthought.MVP.Services;

namespace PNRPRegistration.Presenters
{
    public class LookupPresenter :PresenterBase
    {
        PeerName _currentPeerName;
        Core.PnrpManager _manager;

        public PresenterCommand CancelLookupCommand { get; set; }

        private bool _isReady = true;
        public bool IsReady
        {
            get { return _isReady
                ; }
            private set
            {
                if (_isReady == value)
                    return;
                _isReady = value;
                this.IsWorking = !_isReady;
                OnPropertyChanged("IsReady");
            }
        }

        private bool _isWorking = false;
        public bool IsWorking
        {
            get
            {
                return _isWorking;
            }
            private set
            {
                if (_isWorking == value)
                    return;
                _isWorking = value;
                OnPropertyChanged("IsWorking");
            }
        }

        private PeerNameRecordCollection _records;
        public PeerNameRecordCollection Records {
            get { return _records; }
            private set
            {
                _records = value;
                OnPropertyChanged("Records");
            }
        }

        public LookupPresenter(PeerName peerName, Core.PnrpManager manager) : base()
        {
            _currentPeerName = peerName;
            _manager = manager;
            _manager.LookupRegistrationAsync(_currentPeerName, resolver_ResolveProgressChanged, resolver_ResolveCompleted);
        }

        void resolver_ResolveProgressChanged(object sender, ResolveProgressChangedEventArgs e)
        {
            Debug.WriteLine("Progress: " + e.PeerNameRecord.PeerName);
            this.IsReady = false;
        }

        void resolver_ResolveCompleted(object sender, ResolveCompletedEventArgs e)
        {
            Debug.WriteLine("Completed Count: " + e.PeerNameRecordCollection.Count.ToString());
            this.Records = e.PeerNameRecordCollection;
            this.IsReady = true;
        }

        protected override void InitializeCommands()
        {
            this.CancelLookupCommand = new PresenterCommand()
            {
                CanExecuteDelegate = code => true,
                ExecuteDelegate = code =>
                {
                    _manager.CancelLookup(_currentPeerName);
                    this.Close();
                }
            };
        }
    }
}
