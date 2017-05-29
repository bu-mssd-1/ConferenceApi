using System.Runtime.Serialization;

namespace DataModels
{
    [DataContract]
    public class AvailablePhoneNumber
    {
        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public string FriendlyName { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public bool IsSmsSupported { get; set; }

        [DataMember]
        public bool IsMmsSupported { get; set; }

        [DataMember]
        public bool IsVoiceSupported { get; set; }

        [DataMember]
        public bool IsAddressRequired { get; set; }

        [DataMember]
        public string PhoneNumberType { get; set; }

        [DataMember]
        public string PostalCode { get; set; }

        [DataMember]
        public string Region { get; set; }

        [DataMember]
        public string Location
        {
            get
            {
                var loc = string.Empty;

                if (!string.IsNullOrEmpty(this.Region))
                {
                    loc += this.Region;
                }

                if (!string.IsNullOrEmpty(loc))
                {
                    if (!string.IsNullOrEmpty(this.PostalCode) || !string.IsNullOrEmpty(this.CountryCode))
                    {
                        loc += ", ";
                    }
                }

                if (!string.IsNullOrEmpty(this.PostalCode))
                {
                    loc += this.PostalCode;
                }

                if (!string.IsNullOrEmpty(this.CountryCode))
                {
                    loc += " " + this.CountryCode;
                }

                return loc.Trim();
            }
        }
    }
}