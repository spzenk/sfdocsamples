using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuzzwordBingo.Interfaces;
using BuzzwordBingo.Services;
using BuzzwordBingo.Core;
using System.Windows;
using System.Threading;
using Slickthought.MVP;
using System.Diagnostics;
using Slickthought.MVP.Services;
using System.IO;
using System.ServiceModel;

namespace BuzzwordBingo.Presenters
{


    public class BingoGamePresenter : PresenterBase
    {

        IBingoManager _bingoService;

        string[] _buzzwords = new string[25];

        public PresenterCommand JoinGame { get; private set; }
        public PresenterCommand StartGame { get; private set; }

        public bool IsAlone { get { return !_bingoService.OnlineStatus.IsOnline; } }

        private bool _isOnline = false;
        public bool IsOnline {
            get { return _isOnline; }
            private set
            {
                if (value == _isOnline)
                    return;

                _isOnline = value;
                OnPropertyChanged("IsOnline");
            }
        
        }

        bool _isHost = false;
        public bool IsHost
        {
            get { return _isHost; }
            private set {
                if (value == _isHost)
                    return;

                _isHost = value;
                OnPropertyChanged("IsHost");
            }
        }

        private bool _isStarted = false;
        public bool IsStarted {
            get { return _isStarted; }
            private set
            {
                if (value == _isStarted)
                    return;

                _isStarted = value;
                OnPropertyChanged("IsStarted");
            }
        }

        public Profile PlayerProfile { get { return _bingoService.Player; } }


        public BingoGamePresenter(IBingoManager bingoService) : base()
        {
            _bingoService = bingoService;
            _bingoService.OnlineStatus.Offline +=new EventHandler(OnlineStatus_Offline);
            _bingoService.OnlineStatus.Online  +=new EventHandler(OnlineStatus_Online);

            _bingoService.Received.GameStarted += new EventHandler<UpdateEventArgs>(_bingoService_GameStarted);

        }

        void _bingoService_GameStarted(object sender, UpdateEventArgs e)
        {
            this.IsStarted = true;
        }

       

        protected override void InitializeCommands()
        {
            this.JoinGame = new PresenterCommand()
            {
                CanExecuteDelegate = z => (this.IsAlone && !string.IsNullOrEmpty(this.PlayerProfile.Name)),
                ExecuteDelegate = z =>
                {
                    _bingoService.Initialize();
                    this.IsOnline = true;

                    if (!this.IsAlone)
                    {
                        _bingoService.SendChannel.Join(this.PlayerProfile);                       
                        return;
                    }

                    ConfigureNewGame();
                }
            };

            this.StartGame = new PresenterCommand()
            {
                CanExecuteDelegate = z => (!this.IsAlone && this.IsHost && !this.IsStarted),
                ExecuteDelegate = z =>
                    {
                        _bingoService.SendChannel.Join(this.PlayerProfile);
                        _bingoService.SendChannel.StartGame(this.PlayerProfile.Name,_buzzwords);
                        this.IsStarted = true;
                    }
            };
        }

 
       

        void OnlineStatus_Online(object sender, EventArgs e)
        {
            OnPropertyChanged("IsAlone");
            //if (this.IsHost)
            //    _bingoService.Send().StartGame(_buzzwords);

        }

        void OnlineStatus_Offline(object sender, EventArgs e)
        {
            this.IsHost = false;
            this.IsStarted = false;
            OnPropertyChanged("IsAlone");
        }
       

        private void ConfigureNewGame()
        {

            IOpenFile openFile = this.ServiceLocator.Resolve<IOpenFile>();
            openFile.Filter.Add("Text", "*.txt");

            openFile.ShowDialog(false);
            string file = openFile.FileName;

            TextReader  reader = new StreamReader(file);

            for (int i=0; i < _buzzwords.Length; i++)
                _buzzwords[i] = reader.ReadLine();

            this.IsHost = true;
           
        }
     



  
    }
}
