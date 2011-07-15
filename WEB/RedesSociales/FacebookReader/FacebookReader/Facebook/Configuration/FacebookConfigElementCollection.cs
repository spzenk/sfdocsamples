using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.SocialNetworks.Config
{
    public class FacebookProviders : ConfigurationElementCollection
    {
        public FacebookProviders() { }

        public new int Count
        {
            get { return base.Count; }
        }

        public FacebookProvider this[int pIndex]
        {
            get { return (FacebookProvider)BaseGet(pIndex); }
        }

        public FacebookProvider this[object pKey]
        {
            get { return (FacebookProvider)BaseGet(pKey); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new FacebookProvider();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FacebookProvider)element).Name;
        }

        public int IndexOf(FacebookProvider pElement)
        {
            return BaseIndexOf(pElement);
        }
    }
}