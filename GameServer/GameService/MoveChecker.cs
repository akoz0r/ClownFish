using System.Collections.Generic;
using GameServerInterfaces;

namespace GameServer.GameService
{
    public static class MoveChecker
    {
        public static List<ChessPieceDTO> GetNewState(List<ChessPieceDTO> currentState, GameMoveDTO move)
        {
            //todo : Check valid move
            //todo : Apply move
            return currentState;
        }
    }
}
