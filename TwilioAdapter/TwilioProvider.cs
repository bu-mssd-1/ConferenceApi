using DataModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Api.V2010.Account.AvailablePhoneNumberCountry;

namespace TwilioExternalAdapter
{
    public class TwilioProvider
    {
        /// <summary>
        /// Retrives a list of available phone numbers
        /// </summary>
        /// <param name="countryCode">A country code in 2 digit ISO format</param>
        /// <param name="region">A region (such as state/province)</param>
        /// <param name="areaCode">An area code</param>
        /// <returns>A collection of available phone numbers</returns>
        public async Task<ICollection<AvailablePhoneNumber>> GetAvailablePhoneNumbers(string country = "US", string region = null, int? areaCode = null)
        {
            var results = new Collection<AvailablePhoneNumber>();

            TwilioClient.Init(ProviderConstant.TwilioAccountSid, ProviderConstant.TwilioAuthToken);

            var localOptions = new ReadLocalOptions(country);
            localOptions.Limit = 50;
            localOptions.PageSize = 50;

            if (!string.IsNullOrEmpty(region))
            {
                localOptions.InRegion = region;
            }

            if (areaCode != null)
            {
                localOptions.AreaCode = areaCode;
            }

            var availableLocalNumbers = await LocalResource.ReadAsync(localOptions);

            if (availableLocalNumbers != null)
            {
                foreach (var p in availableLocalNumbers)
                {
                    results.Add(
                    new AvailablePhoneNumber()
                    {
                        CountryCode = p.IsoCountry,
                        FriendlyName = p.FriendlyName.ToString(),
                        PhoneNumber = p.PhoneNumber.ToString(),
                        IsSmsSupported = p.Capabilities.Sms,
                        IsMmsSupported = p.Capabilities.Mms,
                        IsVoiceSupported = p.Capabilities.Voice,
                        PostalCode = p.PostalCode,
                        Region = p.Region,
                        PhoneNumberType = "Local"
                    });

                }
            }
                
            return results;
        }

        /// <summary>
        /// Purchases a phone number
        /// </summary>
        /// <param name="phone">The phone number to buy</param>
        /// <returns>A phone number sid as supplied by 3rd party provider</returns>
        public async Task<string> PurchasePhoneNumber(string phoneNumber)
        {
            var sid = string.Empty;

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                TwilioClient.Init(ProviderConstant.TwilioAccountSid, ProviderConstant.TwilioAuthToken);

                var incomingResource = await IncomingPhoneNumberResource.CreateAsync(phoneNumber: new Twilio.Types.PhoneNumber(phoneNumber));

                if (incomingResource != null)
                {
                    sid = incomingResource.Sid;
                }
            }

            return sid;
        }
    }
}
