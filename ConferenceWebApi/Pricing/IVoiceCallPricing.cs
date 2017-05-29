using DataModels;
using System.Collections.Generic;

namespace ConferenceWebApi
{
    /// <summary>
    /// An interface for proxy example
    /// </summary>
    public interface IVoiceCallPricing
    {
        /// <summary>
        /// Loads pricing from a CSV file.
        /// </summary>
        /// <returns>A collection of voice call pricing</returns>
        ICollection<VoiceCallPrice> GetPricing();
    }
}