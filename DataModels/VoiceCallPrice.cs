namespace DataModels
{
    public class VoiceCallPrice
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Description { get; set; }
        public string PricePerMinute { get; set; }
        public string OriginationPrefixes { get;set;}
        public string DestinationPrefixes { get; set; }
    }
}
