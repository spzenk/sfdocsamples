using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.PeerToPeer;
using System.ComponentModel;
using System.Windows;
using System.Diagnostics;
using System.Collections;
using PNRPRegistration.ViewModel;

namespace PNRPRegistration.Core
{
    public class PnrpManager : INotifyPropertyChanged
    {
        PnrpScope _currerntScope = PnrpScope.SiteLocal; // Set to value we do not support so initialization works correctly
        PeerNameResolver _resolver = new PeerNameResolver();
        CloudInfo _globalCloud;
        CloudInfo _linklocalCloud;
        ObservableCollection<CloudInfo> _clouds;
        ReadOnlyObservableCollection<CloudInfo> _readonlyClouds;
        ObservableCollection<CloudInfo> _scopedClouds;
        ReadOnlyObservableCollection<CloudInfo> _readonlyScopedClouds;
        ObservableCollection<PeerNameRegistration> _registrations;
        ReadOnlyObservableCollection<PeerNameRegistration> _readonlyRegistrations;
        ObservableCollection<PeerNameRegistration> _scopedRegistrations;
        ReadOnlyObservableCollection<PeerNameRegistration> _readonlyScopeRegistrations;


        #region Properties

        public PnrpScope CurrentScope
        {
            get
            {
                return _currerntScope;
            }
            set
            {
                if (value == PnrpScope.SiteLocal)
                    throw new ArgumentException("SiteLocal not supported");
               
                if (value != _currerntScope)
                {
                    _currerntScope = value;
                    ProcessRegistrations(_currerntScope);
                    OnPropertyChanged("CurrentScope");
                }
            }
        }

        public ReadOnlyObservableCollection<PeerNameRegistration> AllRegistrations
        {
            get { return _readonlyRegistrations; }
        }

        public ReadOnlyObservableCollection<PeerNameRegistration> RegistrationsInScope
        {
            get { return _readonlyScopeRegistrations; }
        }

        public ReadOnlyObservableCollection<CloudInfo> CloudsInScope
        {
            get  { return _readonlyScopedClouds;  }
        }

        public ReadOnlyObservableCollection<CloudInfo> AllClouds
        {
            get { return _readonlyClouds; }

        }
        #endregion

        #region Public Methods

        public PnrpManager()
        { 
             _resolver = new PeerNameResolver();

             InitializeRegistrations();
             InitializeClouds();
             this.CurrentScope = PnrpScope.All;
             
        }

        public PeerNameRegistration CreateRegistration(PeerName peerName, int port)
        {
            if (peerName == null)              // in most cases, have a null peername does not make a lot of sense
                throw new ArgumentException("Cannot have null or empty peerName");

            Cloud regCloud;

            switch (_currerntScope)
            {
                case PnrpScope.Global:
                    regCloud = Cloud.Global;
                    break;
                case PnrpScope.LinkLocal:
                    regCloud = Cloud.AllLinkLocal;
                    break;
                default:
                    regCloud = Cloud.Available;
                    break;
            }

            PeerNameRegistration registration = new PeerNameRegistration(peerName, port, regCloud);

            registration.Comment = "Comment for " + peerName.Classifier;

            registration.Start();
            _registrations.Add(registration);
            SetScopedRegistrations(this.CurrentScope);
            ProcessRegistrations(this.CurrentScope);
            return registration;
        }


        public PeerNameRecordCollection LookupRegistration(string classifier, PeerNameType peerType)
        {
            PeerName peerName = new PeerName(classifier, peerType);
            return LookupRegistration(peerName);
        }



        public PeerNameRecordCollection LookupRegistration(PeerName peerName)
        {
            if (peerName == null)
                throw new ArgumentException("Cannot have null or empty peerName");

            return _resolver.Resolve(peerName);
        }

        public void LookupRegistrationAsync(PeerName peerName, EventHandler<ResolveProgressChangedEventArgs> progressChanged, EventHandler<ResolveCompletedEventArgs> completed)
        {
            if (peerName == null)
                throw new ArgumentException("Cannot have null PeerName");


            _resolver = new PeerNameResolver();

            _resolver.ResolveCompleted += new EventHandler<ResolveCompletedEventArgs>(completed);
            _resolver.ResolveProgressChanged += new EventHandler<ResolveProgressChangedEventArgs>(progressChanged);
            Debug.WriteLine(string.Format("Resolving: {0}", peerName.ToString()));
            _resolver.ResolveAsync(peerName, peerName);

        }

        public void CancelLookup(PeerName peerName)
        {
            _resolver = new PeerNameResolver();
            _resolver.ResolveAsyncCancel(peerName);
        }



        public bool DeleteRegistration(PeerNameRegistration registration)
        {
            _registrations.Remove(registration);
            ProcessRegistrations(this.CurrentScope);

            return false;
        }
        #endregion

        #region Private Methods

        private void SetScopedClouds(PnrpScope scope)
        {
            _scopedClouds.Clear();
            foreach (CloudInfo cloud in this.AllClouds)
            {
                if (cloud.Scope == scope || scope == PnrpScope.All)
                    _scopedClouds.Add(cloud);
            }
        }

        private void SetScopedRegistrations(PnrpScope scope)
        {
            _scopedRegistrations.Clear();

            foreach (PeerNameRegistration reg in _registrations)
            {
                if (scope == PnrpScope.All || reg.Cloud.Scope == PnrpScope.All || reg.Cloud.Scope == scope)
                    _scopedRegistrations.Add(reg);
            }

        }

        private void InitializeRegistrations()
        {
            _registrations = new ObservableCollection<PeerNameRegistration>();
            _readonlyRegistrations = new ReadOnlyObservableCollection<PeerNameRegistration>(_registrations);

            _scopedRegistrations = new ObservableCollection<PeerNameRegistration>();
            _readonlyScopeRegistrations = new ReadOnlyObservableCollection<PeerNameRegistration>(_scopedRegistrations);

        }

        private void InitializeClouds()
        {
            _globalCloud = new CloudInfo(Cloud.Global);
            _linklocalCloud = new CloudInfo(Cloud.AllLinkLocal);

            _clouds = new ObservableCollection<CloudInfo>();
            foreach (Cloud cloud in Cloud.GetAvailableClouds())
                _clouds.Add(new CloudInfo(cloud));

            _readonlyClouds = new ReadOnlyObservableCollection<CloudInfo>(_clouds);

            _scopedClouds = new ObservableCollection<CloudInfo>();
            _readonlyScopedClouds = new ReadOnlyObservableCollection<CloudInfo>(_scopedClouds);

        }

        

        private void ProcessRegistrations(PnrpScope scope)
        {
            SetScopedClouds(scope);
            SetScopedRegistrations(scope);

            foreach (CloudInfo cloud in this.CloudsInScope)
            {
                cloud.HasRegistrations = false;
                cloud.HasSecureRegistrations = false;

                var registrations = from r in this.RegistrationsInScope where r.Cloud.Scope == scope || r.Cloud.Scope == PnrpScope.All select r;
                if (registrations.Count() > 0)
                    cloud.HasRegistrations = true;

                var secure = from r in registrations where r.PeerName.IsSecured select r;

                if (secure.Count() > 0)
                    cloud.HasSecureRegistrations = true;
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion
    }
}
