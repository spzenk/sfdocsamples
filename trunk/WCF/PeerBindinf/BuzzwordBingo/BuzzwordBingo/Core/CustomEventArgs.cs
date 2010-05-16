using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuzzwordBingo.Core
{
    public class SquareCheckedEventArgs : EventArgs
    {
        public BingoSquare Square { get; set; }
        public bool? IsChecked { get; set; }

        public SquareCheckedEventArgs(BingoSquare square, bool? state)
        {
            this.Square = square;
            this.IsChecked = state;
        }
    }

    public class BingoEventArgs : EventArgs
    {
        public IEnumerable<string> Buzzwords { get; set; }
    }

    public class PlayerEventArgs : EventArgs
    {
        public Profile PlayerProfile { get; set; }
    }

    public class UpdateEventArgs : EventArgs
    {
        public string Player { get; set; }
        public string Buzzword { get; set; }
        public IEnumerable<string> Buzzwords { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
