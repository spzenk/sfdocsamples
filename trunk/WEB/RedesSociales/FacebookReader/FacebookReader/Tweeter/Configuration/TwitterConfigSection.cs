using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.SocialNetworks.Twitter.Configuration
{
    public class TwitterConfig : ConfigurationSection
    {
        public TwitterConfig() { }

        [ConfigurationProperty("defaultProviderName", DefaultValue = "defaultProvider")]
        public string DefaultProviderName
        {
            get
            {
                return (string)base["defaultProviderName"];
            }
            set
            {
                base["defaultProviderName"] = value;
            }
        }

        [ConfigurationProperty("consumerKey")]
        public string ConsumerKey
        {
            get { return (string)base["consumerKey"]; }
        }

        [ConfigurationProperty("consumerSecret")]
        public string ConsumerSecret
        {
            get { return (string)base["consumerSecret"]; }
        }

        [ConfigurationProperty("statusesCount", DefaultValue = 0)]
        public int StatusesCount
        {
            get { return (int)base["statusesCount"]; }
        }

        [ConfigurationProperty("minRemainingHits", DefaultValue = 0)]
        public int MinRemainingHits
        {
            get { return (int)base["minRemainingHits"]; }
        }

        [ConfigurationProperty("Providers", IsDefaultCollection = false)]
        public TwitterConfigElementCollection Providers
        {
            get
            {
                return (TwitterConfigElementCollection)base["Providers"];
            }
        }

        public TwitterConfigElement GetProvider(string name)
        {
            foreach (TwitterConfigElement wElement in this.Providers)
            {
                if (name.CompareTo(wElement.Name) == 0) { return wElement; }
            }

            return null;
        }

        public TwitterConfigElement DefaultProvider
        {
            get { return this.GetProvider((string)base["defaultProviderName"]); }
        }
    }
}