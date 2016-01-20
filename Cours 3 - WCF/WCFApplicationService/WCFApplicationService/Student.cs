using System.Runtime.Serialization;

namespace WCFApplicationService
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public int IdBooster { get; set; }

        [DataMember]
        public string Firstname { get; set; }

        [DataMember]
        public string Lastname { get; set; }

        [DataMember]
        public int Age { get; set; }
    }
}
