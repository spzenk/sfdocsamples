using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BuzzwordBingo.Interfaces;
using System.ServiceModel;
using BuzzwordBingo.Core;
using System.Diagnostics;
using System.Windows;

namespace BuzzwordBingo.Services
{
    [CallbackBehavior(ConcurrencyMode=ConcurrencyMode.Single)]
    public class BingoService : IBingoManager, IBingoGame, IBingoGameEvents
    {
        InstanceContext _instanceContext;
        //NetTcpBinding _tcpBinding;
        ChannelFactory<IBingoSendChannel> _channelFactory;
        IBingoSendChannel _participant;
        //IOnlineStatus _onlineStatus;


        public event EventHandler<PlayerEventArgs> PlayerJoined;
        public event EventHandler<PlayerEventArgs> PlayeredDeparted;
        public event EventHandler GameEnded;
        public event EventHandler<UpdateEventArgs> GameStarted;
        public event EventHandler<UpdateEventArgs> UpdateReceived;
        public event EventHandler<PlayerEventArgs> BingoReceived;


        public BingoService()
        {
            //_synchContext = synchContext;
            _instanceContext = new InstanceContext(this);
            _channelFactory = new DuplexChannelFactory<IBingoSendChannel>(_instanceContext, "BuzzwordBingo");
            _participant = _channelFactory.CreateChannel();
            //_onlineStatus = _participant.GetProperty<IOnlineStatus>();  

            this.Player = new Profile(string.Empty);
        }



        #region IBingoGame Members


        public void Join(Profile profile)
        {
            if (this.Player.Name == profile.Name)
                return;

            EventHandler<PlayerEventArgs> handler = this.PlayerJoined;

            if (handler != null)
                this.PlayerJoined(this,new PlayerEventArgs() { PlayerProfile=profile});
        }

        
        public void Depart(string player)
        {
            EventHandler<PlayerEventArgs> handler = this.PlayeredDeparted;

            if (handler != null)
                this.PlayeredDeparted(this, new PlayerEventArgs() { PlayerProfile=new Profile(player)  });
        }

        public void StartGame(string player, string[] buzzwords)
        {
            EventHandler<UpdateEventArgs> handler = this.GameStarted;

            if (handler != null)
                this.GameStarted(this, new UpdateEventArgs() { Buzzwords = buzzwords });
        }

        public void EndGame()
        {
            throw new NotImplementedException();
        }

        public void Update(string player, string buzzword, bool isConfirmed)
        {
            if (this.Player.Name == player)
                return;

            EventHandler<UpdateEventArgs> handler = this.UpdateReceived;
            if (handler != null)
                this.UpdateReceived(this, new UpdateEventArgs() { Buzzword = buzzword, Player = player, IsConfirmed = isConfirmed });

        }

     
        public void Bingo(string player)
        {
        }

        #endregion





        #region IBingoService Members
        
           public IOnlineStatus OnlineStatus { get { return _participant.GetProperty<IOnlineStatus>(); } }


           public IBingoSendChannel SendChannel { get {return _participant;}  }

           public void Initialize()
            {
                try
                {
                    _participant.Open();
                }
                catch (CommunicationException)
                {
                    // do something with error
                    return;
                }
            }

           public Profile Player { get; set; }

           public IBingoGameEvents Received { get { return this; } }

        #endregion
    }
}
