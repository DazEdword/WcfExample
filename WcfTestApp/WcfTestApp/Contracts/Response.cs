using System.Runtime.Serialization;

namespace WcfTestApp
{
    [DataContract]
    public class Response
    {
        [DataMember]
        public bool success;
        [DataMember]
        public int? result;
    }
}