using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.XPath;
using System.Configuration;
using TweetSharp.Twitter.Fluent;
using TweetSharp.Twitter.Model;
using TweetSharp.Extensions;
using TweetSharp.Twitter.Extensions;
using TweetSharp;
using Fwk.SocialNetworks.Config;

namespace Fwk.SocialNetworks.Twitter
{
    internal class TweetSharp
    {
      



        string proxyUrl;
        internal TweetSharp()
        {
            if (Fwk.SocialNetworks.Twitter.Twitterizer.Proxy!=null)
                proxyUrl = Fwk.SocialNetworks.Twitter.Twitterizer.Proxy.Address.ToString(); ;
        }



        public UserSchema.user DeserializeUserResponse(string userResponse)
        {
            TextReader wTextReader = new StringReader(userResponse);

            XmlSerializer wSerializer = new XmlSerializer(typeof(UserSchema.user));

            return (UserSchema.user)wSerializer.Deserialize(wTextReader);
        }

        public StreamSchema.statuses DeserializeStatusesResponse(string statusesResponse)
        {
            TextReader wTextReader = new StringReader(statusesResponse);

            XmlSerializer wSerializer = new XmlSerializer(typeof(StreamSchema.statuses));

            return (StreamSchema.statuses)wSerializer.Deserialize(wTextReader);
        }


        public StreamSchema.statuses GetUserStatuses(string userName, long? beforeId)
        {
            IFluentTwitter request = FluentTwitter.CreateRequest();

            ITwitterStatuses statuses = request.Statuses();

            ITwitterUserTimeline userTimeLine;

            if (beforeId.HasValue)
            {
                userTimeLine = statuses.OnUserTimeline().For(userName).Before(beforeId.Value);
            }
            else
            {
                userTimeLine = statuses.OnUserTimeline().For(userName);
            }

            ITwitterLeafNode leafNode = userTimeLine.AsXml();
            ///TODO: Ver proxy
            TwitterResult wTwitterResult = leafNode.Configuration.UseProxy(proxyUrl).Request();

            if (wTwitterResult.IsTwitterError)
            {
                throw new Exception(wTwitterResult.Exception.Message);
            }
            else if (wTwitterResult.IsFailWhale || wTwitterResult.TimedOut)
            {
                throw new Exception("IsFailWhale || TimedOut");
            }
            else
            {
                return DeserializeStatusesResponse(wTwitterResult.Response);
            }
        }

        public StreamSchema.statuses GetUserMentions(long? beforeId)
        {
            //IFluentTwitter request = FluentTwitter.CreateRequest().AuthenticateAs(userName, password);            
            IFluentTwitter request = FluentTwitter.CreateRequest().AuthenticateWith(Fwk.SocialNetworks.Twitter.Twitterizer.Config.ConsumerKey,
                                                                                           Fwk.SocialNetworks.Twitter.Twitterizer.Config.ConsumerSecret,
                                                                                           Fwk.SocialNetworks.Twitter.Twitterizer.Config.DefaultProvider.AccessToken,
                                                                                           Fwk.SocialNetworks.Twitter.Twitterizer.Config.DefaultProvider.AccessTokenSecret);


            ITwitterStatuses statuses = request.Statuses();

            ITwitterStatusMentions statusMentions;

            if (beforeId.HasValue)
            {
                statusMentions = statuses.Mentions().Before(beforeId.Value);
            }
            else
            {
                statusMentions = statuses.Mentions();
            }

            ITwitterLeafNode leafNode = statusMentions.AsXml();

            TwitterResult wTwitterResult = leafNode.Configuration.UseProxy(proxyUrl).Request();

            if (wTwitterResult.IsTwitterError)
            {
                throw new Exception(wTwitterResult.Exception.Message);
            }
            else if (wTwitterResult.IsFailWhale || wTwitterResult.TimedOut)
            {
                throw new Exception("IsFailWhale || TimedOut");
            }
            else
            {

                return DeserializeStatusesResponse(wTwitterResult.Response);
            }
        }

        public StreamSchema.statuses GetUserStatuses(long? beforeId)
        {
            //IFluentTwitter request = FluentTwitter.CreateRequest().AuthenticateAs(userName, password);
            IFluentTwitter request = FluentTwitter.CreateRequest().AuthenticateWith(Fwk.SocialNetworks.Twitter.Twitterizer.Config.ConsumerKey,
                                                                                       Fwk.SocialNetworks.Twitter.Twitterizer.Config.ConsumerSecret,
                                                                                       Fwk.SocialNetworks.Twitter.Twitterizer.Config.DefaultProvider.AccessToken,
                                                                                       Fwk.SocialNetworks.Twitter.Twitterizer.Config.DefaultProvider.AccessTokenSecret);


            ITwitterStatuses statuses = request.Statuses();

            ITwitterUserTimeline userTimeLine;

            if (beforeId.HasValue)
            {
                userTimeLine = statuses.OnUserTimeline().Before(beforeId.Value);
            }
            else
            {
                userTimeLine = statuses.OnUserTimeline();
            }

            ITwitterLeafNode leafNode = userTimeLine.AsXml();

            TwitterResult wTwitterResult = leafNode.Configuration.UseProxy(proxyUrl).Request();

            if (wTwitterResult.IsTwitterError)
            {
                throw new Exception(wTwitterResult.Exception.Message);
            }
            else if (wTwitterResult.IsFailWhale || wTwitterResult.TimedOut)
            {
                throw new Exception("IsFailWhale || TimedOut");
            }
            else
            {
                return DeserializeStatusesResponse(wTwitterResult.Response);
            }
        }

        public List<StreamSchema.status> GetAllUserStatuses(DateTime logSince)
        {
            List<StreamSchema.status> wList = new List<StreamSchema.status>();
            List<StreamSchema.status> wTempList = new List<StreamSchema.status>();

            wTempList.AddRange(GetUserStatuses(null).status);

            while (wTempList.Count > 0)
            {
                wList.AddRange(wTempList);

                long beforeId = long.Parse(wTempList.Last().id);

                wTempList.Clear();

                wTempList.AddRange(GetUserStatuses(beforeId).status);

                wTempList.Remove(wTempList.Last());

                wTempList.RemoveAll(r => DateTime.Parse(r.created_at) < logSince);
            }

            return wList;
        }

        public List<StreamSchema.status> GetAllUserMentions(DateTime logSince)
        {
            List<StreamSchema.status> wList = new List<StreamSchema.status>();
            List<StreamSchema.status> wTempList = new List<StreamSchema.status>();

            wTempList.AddRange(GetUserMentions(null).status);

            while (wTempList.Count > 0)
            {
                wList.AddRange(wTempList);

                long beforeId = long.Parse(wTempList.Last().id);

                wTempList.Clear();

                wTempList.AddRange(GetUserMentions(beforeId).status);

                wTempList.Remove(wTempList.Last());

                wTempList.RemoveAll(r => DateTime.Parse(r.created_at) < logSince);
            }

            return wList;
        }

        public UserSchema.user GetUser(string userId)
        {
            IFluentTwitter request = FluentTwitter.CreateRequest();

            ITwitterUsersShow user = request.Users().ShowProfileFor(Convert.ToInt32(userId));

            ITwitterLeafNode leafNode = user.AsXml();

            TwitterResult wTwitterResult = leafNode.Configuration.UseProxy(proxyUrl).Request();

            return DeserializeUserResponse(wTwitterResult.Response);
        }
    }
    
}
