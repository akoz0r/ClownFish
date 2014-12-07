using System;
using System.Collections.Generic;
using System.ServiceModel;
using GameServerInterfaces.Enums;

namespace GameServerInterfaces
{
    [ServiceContract(CallbackContract = typeof(IClientCallbackInterface))]
    public interface IChessGameService
    {
        [OperationContract]
        List<ChessGameDTO> GetGames();

        [OperationContract]
        ChessGameDTO CreateGame(string playerName, ColorEnum ownColorEnum, TimeSpan startTimePerPlayer, TimeSpan extraTimePerMove);

        [OperationContract]
        void Subscribe(string gameID);

        [OperationContract]
        bool JoinGame(string gameID, string playerName);

        [OperationContract]
        bool MakeMove(string gameID, GameMoveDTO moveDTO);
    }
}
