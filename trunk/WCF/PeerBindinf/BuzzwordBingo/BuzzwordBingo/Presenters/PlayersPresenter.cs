using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Slickthought.MVP;
using BuzzwordBingo.Interfaces;
using BuzzwordBingo.Core;
using System.Collections.ObjectModel;

namespace BuzzwordBingo.Presenters
{
    public class PlayersPresenter : PresenterBase
    {
        IBingoGameEvents _bingoEvents;

        public ObservableCollection<Profile> Players { get; private set; }

        public PlayersPresenter(IBingoGameEvents bingoEvents)
            : base()
        {
            this.Players = new ObservableCollection<Profile>();

            _bingoEvents = bingoEvents;

            _bingoEvents.PlayerJoined += new EventHandler<BuzzwordBingo.Core.PlayerEventArgs>(_bingoEvents_PlayerJoined);
            _bingoEvents.PlayeredDeparted += new EventHandler<BuzzwordBingo.Core.PlayerEventArgs>(_bingoEvents_PlayeredDeparted);
            _bingoEvents.GameEnded += new EventHandler(_bingoEvents_GameEnded);
        }

        void _bingoEvents_GameEnded(object sender, EventArgs e)
        {
            this.Players.Clear();
        }

        void _bingoEvents_PlayeredDeparted(object sender, BuzzwordBingo.Core.PlayerEventArgs e)
        {           
            if (this.Players.Contains(e.PlayerProfile))
                this.Players.Remove(e.PlayerProfile);
        }

        void _bingoEvents_PlayerJoined(object sender, BuzzwordBingo.Core.PlayerEventArgs e)
        {
            this.Players.Add(e.PlayerProfile);
        }
    }
}
