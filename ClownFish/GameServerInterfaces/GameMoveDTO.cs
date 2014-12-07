using System.Runtime.Serialization;

namespace GameServerInterfaces
{
    [DataContract]
    public class GameMoveDTO
    {
        [DataMember]
        public BoardPosition From { get; set; }
        [DataMember]
        public BoardPosition To { get; set; }
    }
}
