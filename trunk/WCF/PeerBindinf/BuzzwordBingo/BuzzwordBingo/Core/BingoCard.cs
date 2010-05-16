using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using BuzzwordBingo.Interfaces;
using BuzzwordBingo.Core;
using System.Collections.ObjectModel;


namespace BuzzwordBingo.Core
{


    public class BingoCard : IBingoCard
    {
        private const int CENTER_SQUARE = 12;
        private const string DEFAULT_TEXT = "Empty";

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        //public event EventHandler<BingoEventArgs> Bingo;
        public event EventHandler<SquareCheckedEventArgs> SquareChecked;

        public ObservableCollection<BingoSquare> Squares { get; private set; }

        //private IBingoEvaluator _evaluator;
        //public IBingoEvaluator Evaluator {
        //    get { return _evaluator; }
        //    set
        //    {
        //        if (value == null)
        //            throw new ArgumentException("Cannot set Evalutor to null.");

        //        _evaluator = value;
        //    }
        //}

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

        //private bool _isBingo = false;
        //public bool IsBingo
        //{
        //    get { return _isBingo; }
        //    private set
        //    {
        //        if (_isBingo == value)
        //            return;

        //        _isBingo = value;
        //        OnPropertyChanged("IsBingo");
        //        OnBingo();
        //    }
        //}

        public BingoCard(IBingoEvaluator evaluator)
        {
            this.BingoEvaluator = evaluator;
            this.Squares = new ObservableCollection<BingoSquare>();

            SetupSquares();
        }

        //public BuzzwordBingoCard(IBingoEvaluator evaluator)
        //    : this()
        //{
        //    this.BingoEvaluator = evaluator;
        //}



        public void BuildCard(string[] buzzwords)
        {
            if (buzzwords == null)
                throw new ArgumentException("Buzzwords array cannot be null.");

            SetupSquares();
            Random rng = new Random(DateTime.Now.Millisecond);
            int numWords = buzzwords.Length;

            foreach (BingoSquare square in this.Squares)
            {
                square.CheckChanged += new EventHandler<SquareCheckedEventArgs>(BingoCard_CheckChanged);

                if (square.Buzzword.ToUpper() == "BINGO")
                {
                    square.IsConfirmed = true; ;
                    continue;
                }
          
                string buzzword = string.Empty;
                int delta = 0;
                int word = rng.Next(numWords);
                int position = word;

                while (string.IsNullOrEmpty(buzzword = buzzwords[position]))
                {
                    if (delta <= 0)
                    {
                        delta = Math.Abs(delta) + 1;
                    }
                    else
                    {
                        //delta++;
                        delta *= -1;
                    }

                    position = word + delta;
                    if (position  < 0)
                       position = 0;

                    if (position >= buzzwords.Length)
                        position = buzzwords.Length - 1;
                }

                buzzwords[position] = string.Empty;
                square.Buzzword = buzzword;
                square.IsChecked = false;
            }

            OnPropertyChanged("Squares");

        }

        public void ConfirmSquare(string buzzword)
        {
            var square = (from s in this.Squares where s.Buzzword == buzzword select s).FirstOrDefault();

            if (square != null)
                square.IsConfirmed = true;
        }

        public bool UpdateSquare(string buzzword)
        {
            var square = (from s in this.Squares where s.Buzzword == buzzword select s).FirstOrDefault();

            if (square != null)
            {
                if (square.IsChecked.HasValue && square.IsChecked.Value)
                    square.IsConfirmed = true;

                return square.IsConfirmed;
            }

            return false;
        }

        private void SetupSquares()
        {
            this.Squares.Clear();
            for (int i = 0; i < 25; i++)
            {
                BingoSquare square = new BingoSquare(DEFAULT_TEXT, i);

                if (i == CENTER_SQUARE)
                {
                    square.Buzzword = "BINGO";
                    square.IsConfirmed = true;
                }

                this.Squares.Add(square);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



        private void BingoCard_CheckChanged(object sender, SquareCheckedEventArgs e)
        {
            
            EventHandler<SquareCheckedEventArgs> handler = this.SquareChecked;

            if (handler != null)
                SquareChecked(this, e);
        }


    }
}
