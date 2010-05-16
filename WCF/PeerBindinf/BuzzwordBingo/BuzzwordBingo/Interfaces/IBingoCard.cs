using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BuzzwordBingo.Core;
using System.Collections.ObjectModel;

namespace BuzzwordBingo.Interfaces
{
    

    public interface IBingoCard : INotifyPropertyChanged
    {
        event EventHandler<SquareCheckedEventArgs> SquareChecked;
        ObservableCollection<BingoSquare> Squares { get;  }
        //IBingoEvaluator BingoEvaluator { get; set; }
        //bool IsBingo { get;  }

        void BuildCard(string[] buzzwords);
        void ConfirmSquare(string buzzword);
        bool UpdateSquare(string buzzword);
    }
}
