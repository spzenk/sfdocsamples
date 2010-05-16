using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Slickthought.MVP;
using BuzzwordBingo.Core;
using BuzzwordBingo.Interfaces;

namespace BuzzwordBingo.Presenters
{
    public class BingoCardPresenter : PresenterBase
    {

        private IBingoManager _bingoService;

        public PresenterCommand CheckSquareCommand { get; set; }

        private IBingoCard _bingoCard;
        public IBingoCard BingoCard
        {
            get { return _bingoCard; }
            set
            {
                _bingoCard = value;
                OnPropertyChanged("BingoCard");
            }
        }

        public IEnumerable<BingoSquare> Squares
        {
            get { return this.BingoCard.Squares; }
        }

        //public BingoCardPresenter(IBingoService bingoService) : this(new BingoCard(), bingoService) { }

        public BingoCardPresenter(IBingoCard bingoCard, IBingoManager bingoService) : base()
        {
            this.BingoCard = bingoCard;
            _bingoService = bingoService;

            _bingoService.Received.GameStarted += new EventHandler<UpdateEventArgs>(_bingoService_GameStarted);
            _bingoService.Received.UpdateReceived += new EventHandler<UpdateEventArgs>(_bingoService_UpdateReceived);

            this.BingoCard.SquareChecked += new EventHandler<SquareCheckedEventArgs>(BingoCard_SquareChecked);
        }

        void _bingoService_UpdateReceived(object sender, UpdateEventArgs e)
        {
            if (e.IsConfirmed)
            {
                this.BingoCard.ConfirmSquare(e.Buzzword);
                return;
            }

            if (this.BingoCard.UpdateSquare(e.Buzzword))
                _bingoService.SendChannel.Update(_bingoService.Player.Name, e.Buzzword, true);
        }

        void BingoCard_SquareChecked(object sender, SquareCheckedEventArgs e)
        {
            _bingoService.SendChannel.Update(_bingoService.Player.Name, e.Square.Buzzword, false);
        }

        void _bingoService_GameStarted(object sender, UpdateEventArgs e)
        {
            this.BingoCard.BuildCard(e.Buzzwords.ToArray());
        }

        protected override void InitializeCommands()
        {
            this.CheckSquareCommand = new PresenterCommand()
            {
                CanExecuteDelegate = ((o) => { return true; }),
                ExecuteDelegate = ((o) => {
                    BingoSquare square = o as BingoSquare;
                    if (square == null)
                        return;

                    square.IsChecked = !square.IsChecked;
                })
            };
        }
    }
}
