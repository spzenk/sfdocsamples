using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using BuzzwordBingo.Core;

namespace BuzzwordBingo.Interfaces
{
    [ServiceContract(Namespace="http://slickthought.net/buzzwordbingo",CallbackContract=typeof(IBingoGame))]
    public interface IBingoGame
    {
        [OperationContract(IsOneWay=true)]
        void Join(Profile profile);

        [OperationContract(IsOneWay = true)]
        void Depart(string player);

        [OperationContract(IsOneWay = true)]
        void StartGame(string player, string[] buzzwords);

        [OperationContract(IsOneWay = true)]
        void EndGame();

        [OperationContract(IsOneWay = true)]
        void Update(string player, string buzzword, bool isConfirmed);

        [OperationContract(IsOneWay = true)]
        void Bingo(string player);

        //IOnlineStatus OnlineStatus { get; }
     

    }

    public interface IBingoSendChannel : IBingoGame, IClientChannel {
    }
}
