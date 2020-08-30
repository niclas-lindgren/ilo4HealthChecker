using System.Runtime.Serialization;

namespace iloHealthChecker.Contracts
{
    [DataContract]
    enum StatusTypes
    {
        OP_STATUS_OK,
        OP_STATUS_ABSENT,
        NOT_APPLICABLE,
        ON,
        AMS_UNAVAILABLE
    }
}