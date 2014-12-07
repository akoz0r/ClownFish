using System;
using System.Runtime.Serialization;
using GameServerInterfaces.Enums;

namespace GameServerInterfaces
{
    [DataContract]
    public class ChessGameDTO
    {
        [DataMember]
        public string GameID { get; set; }

        [DataMember]
        public PlayerDTO WhitePlayer { get; set; }
        [DataMember]
        public PlayerDTO BlackPlayer { get; set; }

        [DataMember]
        public TimeSpan WhiteTimeLeft { get; set; }
        [DataMember]
        public TimeSpan BlackTimeLeft { get; set; }

        [DataMember]
        public TimeSpan ExtraTimePerMove { get; set; }

        [DataMember]
        public int CurrentMoveCount { get; set; }

        [DataMember]
        public GameState GameState { get; set; }
    }
}
