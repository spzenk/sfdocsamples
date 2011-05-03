using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Poisoned.WcfService
{
    [Serializable]
    public class SysEventMessage:Fwk.Bases.Entity
    {
        private Int32 _IdEventDetected;
        private DateTime _EventDate;
        private String _HostName;
        private String _HostDescription;
        private String _HostIP;
        private Int32 _IdEvent;
        private Decimal _EventValue;
        private String _EventDescription;
        private String _UserLogin;
        private String _UserDomain;
        private DateTime _HostNotification;
        private String _MACAddress;
        private String _SerialNumber;


        public String SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }

        public String MACAddress
        {
            get
            {
                return _MACAddress;
            }
            set 
            {
                _MACAddress = value; 
            }
        }

		public DateTime HostNotification
		{
			get
			{
				return _HostNotification;
			}
			set
			{
				_HostNotification = value;
			}
		}

		public String UserDomain
		{
			get
			{
				return _UserDomain;
			}
			set
			{
				_UserDomain = value;
			}
		}

		public String UserLogin
		{
			get
			{
				return _UserLogin;
			}
			set
			{
				_UserLogin = value;
			}
		}

		public String EventDescription
		{
			get
			{
				return _EventDescription;
			}
			set
			{
				_EventDescription = value;
			}
		}

        public Decimal EventValue
		{
			get
			{
				return _EventValue;
			}
			set
			{
				_EventValue = value;
			}
		}

		public Int32 IdEvent
		{
			get
			{
				return _IdEvent;
			}
			set
			{
				_IdEvent = value;
			}
		}

		public String HostIP
		{
			get
			{
				return _HostIP;
			}
			set
			{
				_HostIP = value;
			}
		}

		public String HostDescription
		{
			get
			{
				return _HostDescription;
			}
			set
			{
				_HostDescription = value;
			}
		}

		public String HostName
		{
			get
			{
				return _HostName;
			}
			set
			{
				_HostName = value;
			}
		}

		public DateTime EventDate
		{
			get
			{
				return _EventDate;
			}
			set
			{
				_EventDate = value;
			}
		}

		public Int32 IdEventDetected
		{
			get
			{
				return _IdEventDetected;
			}
			set
			{
				_IdEventDetected = value;
			}
		}

    }
}
