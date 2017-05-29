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
        /// Makes a call 
        /// </summary>
        /// <param name="userId">A user Id</param>
        /// <param name="from">A phone number</param>
        /// <param name="to">A phone number</param>
        public override void PlaceCall(string userId, string from, string to)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends a text message
        /// </summary>
        /// <param name="userId">A user Id</param>
        /// <param name="from">A phone number</param>
        /// <param name="to">A phone number</param>
        /// <param name="message">A text message</param>
        public override void SendSms(string userId, string from, string to, string message)
        {
            throw new NotImplementedException();
        }
    }
}
