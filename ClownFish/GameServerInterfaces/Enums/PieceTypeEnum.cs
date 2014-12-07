using System.Runtime.Serialization;

namespace GameServerInterfaces.Enums
{
    [DataContract]
    public enum PieceTypeEnum
    {
        [EnumMember]
        Pawn,
        [EnumMember]
        Bishop,
        [EnumMember]
        Knight,
        [EnumMember]
        Rook,
        [EnumMember]
        Queen,
        [EnumMember]
        King
    }
}
