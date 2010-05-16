using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuzzwordBingo.Core;

namespace BuzzwordBingo.Interfaces
{
    public interface IBingoGameEvents
    {
        event EventHandler<PlayerEventArgs> PlayerJoined;
        event EventHandler<PlayerEventArgs> PlayeredDeparted;
        event EventHandler GameEnded;
        event EventHandler<UpdateEventArgs> GameStarted;
        event EventHandler<UpdateEventArgs> UpdateReceived;
        event EventHandler<PlayerEventArgs> BingoReceived;

    }
}
