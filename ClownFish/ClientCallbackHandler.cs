using ClownFish.ServiceReference1;
using GameServerInterfaces;

namespace ClownFish
{
    class ClientCallbackHandler : IChessGameServiceCallback
    {
        public void GameStateChanged(GameMoveDTO latestMove, ChessGameDTO gameState)
        {
            //todo
        }
    }
}
