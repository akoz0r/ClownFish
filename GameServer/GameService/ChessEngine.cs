using System.Collections.Generic;
using System.Linq;
using GameServerInterfaces;
using GameServerInterfaces.Enums;

namespace GameServer.GameService
{
    public static class ChessEngine
    {
        public static List<ChessPieceDTO> GetStartingPositions()
        {
            return new List<ChessPieceDTO>
            {
                new ChessPieceDTO { PieceColorEnum = ColorEnum.White, TypeEnum = PieceTypeEnum.Pawn, BoardPosition = new BoardPosition { X = 0, Y = 1}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.White, TypeEnum = PieceTypeEnum.Pawn, BoardPosition = new BoardPosition { X = 1, Y = 1}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.White, TypeEnum = PieceTypeEnum.Pawn, BoardPosition = new BoardPosition { X = 2, Y = 1}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.White, TypeEnum = PieceTypeEnum.Pawn, BoardPosition = new BoardPosition { X = 3, Y = 1}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.White, TypeEnum = PieceTypeEnum.Pawn, BoardPosition = new BoardPosition { X = 4, Y = 1}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.White, TypeEnum = PieceTypeEnum.Pawn, BoardPosition = new BoardPosition { X = 5, Y = 1}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.White, TypeEnum = PieceTypeEnum.Pawn, BoardPosition = new BoardPosition { X = 6, Y = 1}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.White, TypeEnum = PieceTypeEnum.Pawn, BoardPosition = new BoardPosition { X = 7, Y = 1}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.White, TypeEnum = PieceTypeEnum.Rook, BoardPosition = new BoardPosition { X = 0, Y = 0}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.White, TypeEnum = PieceTypeEnum.Knight, BoardPosition = new BoardPosition { X = 1, Y = 0}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.White, TypeEnum = PieceTypeEnum.Bishop, BoardPosition = new BoardPosition { X = 2, Y = 0}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.White, TypeEnum = PieceTypeEnum.Queen, BoardPosition = new BoardPosition { X = 3, Y = 0}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.White, TypeEnum = PieceTypeEnum.King, BoardPosition = new BoardPosition { X = 4, Y = 0}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.White, TypeEnum = PieceTypeEnum.Bishop, BoardPosition = new BoardPosition { X = 5, Y = 0}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.White, TypeEnum = PieceTypeEnum.Knight, BoardPosition = new BoardPosition { X = 6, Y = 0}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.White, TypeEnum = PieceTypeEnum.Rook, BoardPosition = new BoardPosition { X = 7, Y = 0}},
                
                new ChessPieceDTO { PieceColorEnum = ColorEnum.Black, TypeEnum = PieceTypeEnum.Pawn, BoardPosition = new BoardPosition { X = 0, Y = 6}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.Black, TypeEnum = PieceTypeEnum.Pawn, BoardPosition = new BoardPosition { X = 1, Y = 6}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.Black, TypeEnum = PieceTypeEnum.Pawn, BoardPosition = new BoardPosition { X = 2, Y = 6}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.Black, TypeEnum = PieceTypeEnum.Pawn, BoardPosition = new BoardPosition { X = 3, Y = 6}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.Black, TypeEnum = PieceTypeEnum.Pawn, BoardPosition = new BoardPosition { X = 4, Y = 6}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.Black, TypeEnum = PieceTypeEnum.Pawn, BoardPosition = new BoardPosition { X = 5, Y = 6}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.Black, TypeEnum = PieceTypeEnum.Pawn, BoardPosition = new BoardPosition { X = 6, Y = 6}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.Black, TypeEnum = PieceTypeEnum.Pawn, BoardPosition = new BoardPosition { X = 7, Y = 6}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.Black, TypeEnum = PieceTypeEnum.Rook, BoardPosition = new BoardPosition { X = 0, Y = 7}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.Black, TypeEnum = PieceTypeEnum.Knight, BoardPosition = new BoardPosition { X = 1, Y = 7}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.Black, TypeEnum = PieceTypeEnum.Bishop, BoardPosition = new BoardPosition { X = 2, Y = 7}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.Black, TypeEnum = PieceTypeEnum.Queen, BoardPosition = new BoardPosition { X = 3, Y = 7}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.Black, TypeEnum = PieceTypeEnum.King, BoardPosition = new BoardPosition { X = 4, Y = 7}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.Black, TypeEnum = PieceTypeEnum.Bishop, BoardPosition = new BoardPosition { X = 5, Y = 7}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.Black, TypeEnum = PieceTypeEnum.Knight, BoardPosition = new BoardPosition { X = 6, Y = 7}},
                new ChessPieceDTO { PieceColorEnum = ColorEnum.Black, TypeEnum = PieceTypeEnum.Rook, BoardPosition = new BoardPosition { X = 7, Y = 7}},
            };
        }

        public static List<ChessPieceDTO> GetNewState(List<ChessPieceDTO> currentState, GameMoveDTO move)
        {
            var piece = currentState.SingleOrDefault(p => p.BoardPosition.X == move.From.X && p.BoardPosition.Y == move.From.Y);
            
            //todo : Check validity of move
            
            var targetPiece = currentState.SingleOrDefault(c => c.BoardPosition.X == move.To.X && c.BoardPosition.Y == move.To.Y);

            if (targetPiece != null)
                currentState.Remove(targetPiece);

            piece.BoardPosition = move.To;

            return currentState;
        }
    }
}