using System.ServiceModel;

namespace GameServerInterfaces
{
    public interface IClientCallbackInterface
    {
        [OperationContract]
        void Ping();

        [OperationContract]
        void GameStateChanged(GameMoveDTO latestMove, ChessGameDTO gameState);
    }
}
