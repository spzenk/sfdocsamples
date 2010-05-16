using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BuzzwordBingo.Interfaces;

namespace BuzzwordBingo.Core
{
    public class BingoPlayer : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public event EventHandler<PlayerEventArgs> Bingo;

        private IBingoCard _bingoCard;
        public IBingoCard BingoCard {
            get { return _bingoCard; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Cannot set BingoCard to null");

                if (_bingoCard == value)
                    return;

                _bingoCard = value;
                _bingoCard.SquareChecked += new EventHandler<SquareCheckedEventArgs>(BingoCard_SquareChecked);
                OnPropertyChanged("BingoCard");
            }
        }

        private IBingoEvaluator _evaluator;
        public IBingoEvaluator BingoEvaluator
        {
            get { return _evaluator; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Cannot set BingoEvaluator to null.");

                _evaluator = value;
            }
        }

        private bool _isBingo = false;
        public bool HasBingo
        {
            get { return _isBingo; }
            private set
            {
                if (_isBingo == value)
                    return;

                _isBingo = value;
                OnPropertyChanged("HasBingo");
                OnBingo();
            }
        }

        

        public BingoPlayer(IBingoEvaluator bingoEvaluator, IBingoCard bingoCard)
        {
            this.BingoCard = bingoCard;
            this.BingoEvaluator = bingoEvaluator;

        }

       
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void BingoCard_SquareChecked(object sender, SquareCheckedEventArgs e)
        {
            if (this.BingoEvaluator.CheckForBingo(this.BingoCard))
                OnBingo();
        }

        private void OnBingo()
        {
            EventHandler<PlayerEventArgs> handler = this.Bingo;

            if (handler != null)
                Bingo(this, new PlayerEventArgs() 
                            { });
        }


    }
}
