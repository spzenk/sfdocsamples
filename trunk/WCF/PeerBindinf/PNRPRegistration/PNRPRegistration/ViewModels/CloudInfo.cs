using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net.PeerToPeer;
using System.Collections.ObjectModel;

namespace PNRPRegistration.ViewModel
{
    public class CloudInfo : INotifyPropertyChanged
    {
        ObservableCollection<PeerNameRegistration> _registrations = null;

        Cloud _baseCloud = null;
        bool _hasRegistrations = false;
        bool _hasSecureRegistrations = false;

        public string Name { get { return _baseCloud.Name; } }
        public PnrpScope Scope { get { return _baseCloud.Scope; } }
        public int ScopeId { get { return _baseCloud.ScopeId; } }
        public Cloud Cloud { get { return _baseCloud; } }

        public bool HasRegistrations {
            get { return _hasRegistrations; }
            set
            {
                if (value != _hasRegistrations)
                {
                    _hasRegistrations = value;
                    OnPropertyChanged("HasRegistrations");
                }
            }
        }

        public bool HasSecureRegistrations { 
            get { return _hasSecureRegistrations; }
            set
            {
                if (value != _hasSecureRegistrations)
                {
                    _hasSecureRegistrations = value;
                    OnPropertyChanged("HasSecureRegistrations");

                    if (_hasSecureRegistrations)
                        this.HasRegistrations = true;
                }
            }
        }

        public ReadOnlyObservableCollection<PeerNameRegistration> Registrations
        {
            get { return new ReadOnlyObservableCollection<PeerNameRegistration>(_registrations); }
        }

        public CloudInfo(Cloud baseCloud)
        {
            _baseCloud = baseCloud;
            _registrations = new ObservableCollection<PeerNameRegistration>();
        }

        public void AddRegistration(PeerNameRegistration registration)
        {
            if (registration == null)
                throw new ArgumentException("Cannot have null registration.");

            if (registration.PeerName == null)
                throw new ArgumentException("Cannot send in uninitialized registration.");

            _registrations.Add(registration);
            this.HasRegistrations = true;
            if (registration.PeerName.IsSecured)
                this.HasSecureRegistrations = true;
        }

        public void DeleteRegistration(PeerNameRegistration registration)
        {
            if (_registrations.Remove(registration))
            {

                if (_registrations.Count == 0)
                {
                    this.HasRegistrations = false;
                    this.HasSecureRegistrations = false;
                }

                var secureRegs = from r in _registrations where r.PeerName.IsSecured select r;

                if (secureRegs != null)
                    this.HasSecureRegistrations = true;
                else
                    this.HasSecureRegistrations = false;
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        #endregion
    }
}
