using System;
using System.Runtime.Serialization;

namespace DataModels
{
    [DataContract]
    public partial class VirtualPhoneNumber : BaseModel
    {
        /// <summary>
        /// Gets or sets the value of VirtualPhoneNumberId.
        /// </summary>
        [DataMember]
        public string VirtualPhoneNumberId { get; set; }

        /// <summary>
        /// Gets or sets the value of UserId.
        /// </summary>
        [DataMember]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the value of PhoneNumber.
        /// </summary>
        [DataMember]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the value of DateCreated.
        /// </summary>
        [DataMember]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the value of IsActive.
        /// </summary>
        [DataMember]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the value of ProviderId.
        /// </summary>
        [DataMember]
        public string ProviderId { get; set; }
    }
}
