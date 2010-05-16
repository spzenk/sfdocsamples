using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Slickthought.MVP;
using BuzzwordBingo.Core;
using BuzzwordBingo.Interfaces;
using BuzzwordBingo.Services;

namespace BuzzwordBingo.Presenters
{
    public class MainPresenter : PresenterBase
    {
        private IBingoManager  _bingoService;

        private BingoGamePresenter _gamePresenter;
        public BingoGamePresenter BingoGame {
            get { return _gamePresenter; }
            private set
            {
                if (value == null)
                    throw new ArgumentException("Cannot set BingoGame to null.");

                _gamePresenter = value;
                OnPropertyChanged("BingoGame");
            }
        }

        private BingoCardPresenter _bingoCardPresenter;
        public BingoCardPresenter BingoCard
        {
            get { return _bingoCardPresenter; }
            private set
            {
                if (value == null)
                    throw new ArgumentException("Cannot set BingoCard to Null.");
                _bingoCardPresenter = value;
                OnPropertyChanged("BingoCard");
            }
        }

        public PlayersPresenter Players { get; private set; }



        public MainPresenter()
        {
            _bingoService = new BingoService();
            InitializeChildPresenters();
        }


        private void InitializeChildPresenters()
        {
            this.BingoGame = new BingoGamePresenter(_bingoService);

            this.BingoCard = new BingoCardPresenter(new BingoCard(new StraightLineEvaluator()), _bingoService);

            this.Players = new PlayersPresenter(_bingoService.Received);

            
        }


    }
}
