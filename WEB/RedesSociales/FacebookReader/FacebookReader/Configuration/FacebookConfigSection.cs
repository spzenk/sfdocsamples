using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.SocialNetworks.Facebook.Configuration
{
    public class FacebookConfig : ConfigurationSection
    {
        public FacebookConfig() { }

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

        [ConfigurationProperty("limit", IsRequired = false)]
        public int? Limit
        {
            get
            {
                return (int?)this["limit"];
            }
        }

        [ConfigurationProperty("Providers", IsDefaultCollection = false)]
        public FacebookProviders Providers
        {
            get
            {
                return (FacebookProviders)base["Providers"];
            }
        }

        [ConfigurationProperty("Proxy", IsRequired = false)]
        public ProxyElement Proxy
        {
            get
            {
                return (ProxyElement)base["Proxy"];
            }
        }


        public FacebookProvider GetProvider(string name)
        {
            //return this.Providers[name];

            if (string.IsNullOrEmpty(name))
                return this.DefaultProvider;
            foreach (FacebookProvider wElement in this.Providers)
            {
                if (name.CompareTo(wElement.Name) == 0)
                {
                    return wElement;
                }

            }
            return null;
        }

        public FacebookProvider DefaultProvider
        {
            get { return this.GetProvider((string)base["defaultProviderName"]); }
        }
    }
}