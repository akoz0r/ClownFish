using System.Runtime.Serialization;

namespace GameServerInterfaces
{
    /// <summary>
    /// All values must be in the range 0 - 7
    /// </summary>
    [DataContract]
    public class BoardPosition
    {
        [DataMember]
        public uint X { get; set; }
        [DataMember]
        public uint Y { get; set; }
    }
}