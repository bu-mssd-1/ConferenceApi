using System;
using System.Runtime.Serialization;

namespace DataModels
{
    /// <summary>
    /// Defines a User object.
    /// </summary>
	[DataContract]
    public partial class User : BaseModel
    {
        /// <summary>
        /// An identification of the object
        /// </summary>
        public override string Id
        {
            get
            {
                return this.UserId;
            }
        }

        /// <summary>
        /// Gets or sets the value of UserId.
        /// </summary>
        [DataMember]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the value of DevicePhoneNumber.
        /// </summary>
        [DataMember]
        public string DevicePhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the value of Pin.
        /// </summary>
        [DataMember]
        public string Pin { get; set; }

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
    }
}
