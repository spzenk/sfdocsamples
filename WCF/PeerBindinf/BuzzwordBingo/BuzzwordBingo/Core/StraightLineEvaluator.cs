using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuzzwordBingo.Interfaces;

namespace BuzzwordBingo.Core
{
    class StraightLineEvaluator : IBingoEvaluator
    {
        #region IBingoEvaluator Members

        public bool CheckForBingo(IBingoCard card)
        {
            for (int i = 0; i < 5; i++)
                if (card.Squares[(i * 5)].IsConfirmed &&
                    card.Squares[(i * 5) + 1].IsConfirmed &&
                    card.Squares[(i * 5) + 2].IsConfirmed &&
                    card.Squares[(i * 5) + 3].IsConfirmed &&
                    card.Squares[(i * 5) + 4].IsConfirmed)
                    return true;

            for (int i = 0; i < 5; i++)
                if (card.Squares[i].IsConfirmed &&
                    card.Squares[i+5].IsConfirmed &&
                    card.Squares[i+10].IsConfirmed &&
                    card.Squares[i+15].IsConfirmed &&
                    card.Squares[i+20].IsConfirmed)
                    return true;

            if (card.Squares[0].IsConfirmed &&
                card.Squares[6].IsConfirmed &&
                card.Squares[12].IsConfirmed &&
                card.Squares[18].IsConfirmed &&
                card.Squares[24].IsConfirmed)
                return true;

            if (card.Squares[4].IsConfirmed &&
               card.Squares[8].IsConfirmed &&
               card.Squares[12].IsConfirmed &&
               card.Squares[16].IsConfirmed &&
               card.Squares[20].IsConfirmed)
                return true;


            return false;
        }

        public string[] BingoBuzzwords
        {
            get { throw new NotImplementedException(); }
        }


        #endregion
    }
}
