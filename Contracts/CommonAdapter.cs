using DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    /// <summary>
    /// A common abstract class for adapter pattern
    /// </summary>
    public abstract class CommonAdapter
    {
        /// <summary>
        /// Retrives a list of available phone numbers
        /// </summary>
        /// <param name="countryCode">A country code in 2 digit ISO format</param>
        /// <param name="areaCode">An area code</param>
        /// <returns>A collection of available phone numbers</returns>
        public abstract Task<ICollection<AvailablePhoneNumber>> GetAvailablePhoneNumbers(string countryCode, int? areaCode);

        /// <summary>
        /// Purchases a phone number
        /// </summary>
        /// <param name="phoneNumber">The phone number to buy</param>
        /// <returns>A phone number sid as supplied by 3rd party provider</returns>
        public abstract Task<string> PurchasePhoneNumber(string phoneNumber);

        /// <summary>
        /// Updates a phone number
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="incomingCallUrl"></param>
        /// <param name="statusCallbackUrl"></param>
        /// <returns></returns>
        public abstract Task<bool> UpatePhoneNumber(string sid, string incomingCallUrl, string statusCallbackUrl);
    }
}
