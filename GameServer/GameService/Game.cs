using System;
using System.Collections.Generic;
using GameServerInterfaces;
using GameServerInterfaces.Enums;

namespace GameServer.GameService
{
    public class Game
    {
        public Game(string playerName, ColorEnum ownColorEnum, TimeSpan startTimePerPlayer, TimeSpan extraTimePerMove)
        {
            Listeners = new List<IClientCallbackInterface>();

            Moves = new List<GameMoveDTO>();

            GameID = Guid.NewGuid().ToString();

            if (ownColorEnum == ColorEnum.Black)
            {
                BlackPlayer = new Player {DisplayName = playerName};
            }
            else
            {
                WhitePlayer = new Player {DisplayName = playerName};
            }

            WhiteTimeLeft = startTimePerPlayer;
            BlackTimeLeft = startTimePerPlayer;
            ExtraTimePerMove = extraTimePerMove;
            CurrentMoveCount = 0;
        }

        public List<IClientCallbackInterface> Listeners { get; set; }

        public List<GameMoveDTO> Moves { get; set; }

        public string GameID { get; set; }

        public Player WhitePlayer { get; set; }
        public Player BlackPlayer { get; set; }

        public TimeSpan WhiteTimeLeft { get; set; }
        public TimeSpan BlackTimeLeft { get; set; }

        public TimeSpan ExtraTimePerMove { get; set; }

        public int CurrentMoveCount { get; set; }

        public GameState GameState { get; set; }

        public ChessGameDTO MapToDTO()
        {
            return new ChessGameDTO
            {
                BlackPlayer = new PlayerDTO {DisplayName = BlackPlayer != null ? BlackPlayer.DisplayName : null},
                WhitePlayer = new PlayerDTO {DisplayName = WhitePlayer != null ? WhitePlayer.DisplayName : null},
                BlackTimeLeft = BlackTimeLeft,
                WhiteTimeLeft = WhiteTimeLeft,
                CurrentMoveCount = CurrentMoveCount,
                ExtraTimePerMove = ExtraTimePerMove,
                GameID = GameID,
                GameState = GameState
            };
        }

        public void PlayerJoining(string playerName)
        {
            if (BlackPlayer == null)
                BlackPlayer = new Player {DisplayName = playerName};
            else
                WhitePlayer = new Player {DisplayName = playerName};
        }

        public void MakeMove(GameMoveDTO move)
        {
            Moves.Add(move);
            //todo apply move
        }
    }
}
