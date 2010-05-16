using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuzzwordBingo.Interfaces
{
    public interface IBingoEvaluator
    {
        bool CheckForBingo(IBingoCard card);
        string[] BingoBuzzwords { get; }
        
    }
}
