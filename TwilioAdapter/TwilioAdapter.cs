using Contracts;
using DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwilioExternalAdapter
{
    /// <summary>
    /// An adapter for twilio provider
    /// </summary>
    public class TwilioAdapter : CommonAdapter
    {
        /// <summary>
        /// A placeholder for twilio adapter
        /// </summary>
        private TwilioProvider provider;

        public TwilioAdapter()
        {
            this.provider = new TwilioProvider();
        }

        /// <summary>
        /// Retrives a list of available phone numbers
        /// </summary>
        /// <param name="countryCode">A country code in 2 digit ISO format</param>
        /// <param name="areaCode">An area code</param>
        /// <returns>A collection of available phone numbers</returns>
        public override async Task<ICollection<AvailablePhoneNumber>> GetAvailablePhoneNumbers(string countryCode, int? areaCode)
        {
            return await this.provider.GetAvailablePhoneNumbers(country: countryCode, areaCode: areaCode);
        }

        /// <summary>
        /// Purchases a phone number
        /// </summary>
        /// <param name="phoneNumber">The phone number to buy</param>
        /// <returns>A phone number sid as supplied by 3rd party provider</returns>
        public override async Task<string> PurchasePhoneNumber(string phoneNumber)
        {
            return await this.provider.PurchasePhoneNumber(phoneNumber);
        }
    }
}
