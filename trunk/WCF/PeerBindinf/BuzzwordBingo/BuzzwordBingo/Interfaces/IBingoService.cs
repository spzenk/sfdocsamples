using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using BuzzwordBingo.Core;

namespace BuzzwordBingo.Interfaces
{
    public interface IBingoManager //: IBingoGameEvents
    {
        void Initialize();
        IOnlineStatus OnlineStatus { get; }
        Profile Player { get; set; }
        IBingoSendChannel SendChannel { get; }
        IBingoGameEvents Received { get; }
    }
}
