using System.Runtime.Serialization;

namespace GameServerInterfaces
{
    [DataContract]
    public class PlayerDTO
    {
        [DataMember]
        public string DisplayName { get; set; }
    }
}
