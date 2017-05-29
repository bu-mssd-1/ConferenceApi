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
        public abstract Task<ICollection<AvailablePhoneNumber>> GetAvailablePhoneNumbers(string countryCode, string areaCode);

        /// <summary>
        /// Makes a call 
        /// </summary>
        /// <param name="userId">A user Id</param>
        /// <param name="from">A phone number</param>
        /// <param name="to">A phone number</param>
        public abstract void PlaceCall(string userId, string from, string to);

        /// <summary>
        /// Sends a text message
        /// </summary>
        /// <param name="userId">A user Id</param>
        /// <param name="from">A phone number</param>
        /// <param name="to">A phone number</param>
        /// <param name="message">A text message</param>
        public abstract void SendSms(string userId, string from, string to, string message);
    }
}
