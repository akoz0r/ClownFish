using System.Runtime.Serialization;

namespace GameServerInterfaces.Enums
{
    [DataContract]
    public enum ColorEnum
    {
        [EnumMember]
        White,
        [EnumMember]
        Black
    }
}