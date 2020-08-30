using System.Runtime.Serialization;

namespace iloHealthChecker.Contracts
{
    [DataContract]
    public enum StatusTypes
    {
        OP_STATUS_OK,
        OP_STATUS_ABSENT,
        NOT_APPLICABLE,
        ON,
        AMS_UNAVAILABLE
    }
}