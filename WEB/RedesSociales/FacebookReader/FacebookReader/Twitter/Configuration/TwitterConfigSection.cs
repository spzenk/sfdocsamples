using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twitterizer;


namespace Fwk.SocialNetworks.Config
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

        [ConfigurationProperty("Proxy", IsRequired = false)]
        public ProxyElement Proxy
        {
            get
            {
                return (ProxyElement)base["Proxy"];
            }
        }

       
        public TwitterConfigElement GetProvider(string name)
        {
            if (string.IsNullOrEmpty(name))
                return this.DefaultProvider;
            foreach (TwitterConfigElement wElement in this.Providers)
            {
                if (name.CompareTo(wElement.Name) == 0)
                {
                    return wElement;
                }

            }
            return null;
        }

        public TwitterConfigElement DefaultProvider
        {
            get { return this.GetProvider((string)base["defaultProviderName"]); }
        }



        public OAuthTokens GetOAuthTokens(string providerName)
        {
            TwitterConfigElement provider = this.GetProvider(providerName);
            OAuthTokens wOAuthTokens = new OAuthTokens();
            wOAuthTokens.AccessToken = provider.AccessToken;
            wOAuthTokens.AccessTokenSecret = provider.AccessTokenSecret;

            wOAuthTokens.ConsumerKey = this.ConsumerKey;
            wOAuthTokens.ConsumerSecret = this.ConsumerSecret;
            return wOAuthTokens;
        }
    }
}