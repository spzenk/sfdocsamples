using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.SocialNetworks.Twitter.Configuration
{
    public class TwitterConfigElementCollection : ConfigurationElementCollection
    {
        public TwitterConfigElementCollection(){}

        public new int Count
        {
            get { return base.Count; }
        }

        public TwitterConfigElement this[int pIndex]
        {
            get { return (TwitterConfigElement)BaseGet(pIndex); }
        }

        public TwitterConfigElement this[object pKey]
        {
            get { return (TwitterConfigElement)BaseGet(pKey); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new TwitterConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TwitterConfigElement)element).UserId;
        }

        public int IndexOf(TwitterConfigElement pElement)
        {
            return BaseIndexOf(pElement);
        }
    }
}