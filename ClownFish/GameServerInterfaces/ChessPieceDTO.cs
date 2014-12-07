using System.Runtime.Serialization;
using GameServerInterfaces.Enums;

namespace GameServerInterfaces
{
    [DataContract]
    public class ChessPieceDTO
    {
        [DataMember]
        public PieceTypeEnum TypeEnum { get; set; }
        [DataMember]
        public ColorEnum PieceColorEnum { get; set; }
        [DataMember]
        public BoardPosition BoardPosition { get; set; }
    }
}
