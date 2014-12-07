using ClownFishClient.ServiceReference1;
using GameServerInterfaces;

namespace ClownFishClient
{
    public class ClientCallbackHandler : IChessGameServiceCallback
    {
        public void Ping()
        {
            
        }

        public void GameStateChanged(GameMoveDTO latestMove, ChessGameDTO gameState)
        {
            //todo
        }
    }
}
