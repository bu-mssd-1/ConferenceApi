using System;
using System.Runtime.Serialization;

namespace DataModels
{
    /// <summary>
    /// Defines a Conference object.
    /// </summary>
	[DataContract]
    public partial class Conference : BaseModel
    {
        /// <summary>
        /// An identification of the object
        /// </summary>
        public override string Id
        {
            get
            {
                return this.ConferenceId;
            }
        }

        /// <summary>
        /// Gets or sets the value of ConferenceId.
        /// </summary>
        [DataMember]
        public string ConferenceId { get; set; }

        [DataMember]
        public string ConferencePhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the value of UserId.
        /// </summary>
        [DataMember]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the value of ConferenceName.
        /// </summary>
        [DataMember]
        public string ConferenceName { get; set; }

        /// <summary>
        /// Gets or sets the value of WelcomeMessage.
        /// </summary>
        [DataMember]
        public string WelcomeMessage { get; set; }

        /// <summary>
        /// Gets or sets the value of Participants.
        /// </summary>
        [DataMember]
        public string Participants { get; set; }

        /// <summary>
        /// Gets or sets the value of Cost.
        /// </summary>
        [DataMember]
        public decimal? Cost { get; set; }

        /// <summary>
        /// Gets or sets the value of DateCreated.
        /// </summary>
        [DataMember]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the value of Status.
        /// </summary>
        [DataMember]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the value of ProviderId.
        /// </summary>
        [DataMember]
        public string ProviderId { get; set; }

    }
}
