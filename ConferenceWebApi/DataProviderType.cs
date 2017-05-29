using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ConferenceWebApi
{
    [DataContract]
    public enum DataProviderType
    {
        [EnumMember]
        Sql = 0,

        [EnumMember]
        Mock = 1,

        [EnumMember]
        Json = 2
    }
}