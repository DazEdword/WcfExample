using System.Runtime.Serialization;

namespace WcfTestApp
{
    [DataContract]
    public class Request
    {
        [DataMember]
        public string operation;
        [DataMember]
        public int a;
        [DataMember]
        public int b;
    }
}