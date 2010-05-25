using System;
using System.Xml.Serialization;

namespace ObjectStorePart1
{    
    public enum AddressType
    {
        Home,
        Work,
        Other
    }

    public class EmployeeAddress
    {
        private string _streetAddress = null;
        private string _city = null;
        private string _state = null;
        private string _zip = null;
        private AddressType _type;

        public EmployeeAddress(){}

        public EmployeeAddress(AddressType type, string streetAddress, string city, string state, string zip)
        {
            _type = type;
            _streetAddress = streetAddress;
            _city = city;
            _state = state;
            _zip = zip;
        }

        public string Street
        {
            get { return _streetAddress; }
            set {  _streetAddress = value; }
        }

        public string City
        {
            get { return _city; }
            set {  _city = value; }
        }
        
        public string State
        {
            get { return _state; }
            set {  _state = value; }
        }

        public string Zip
        {
            get { return _zip; }
            set {  _zip = value; }
        }

        public AddressType Type
        {
            get { return _type; }
            set {  _type = value; }
        }

    }
}
