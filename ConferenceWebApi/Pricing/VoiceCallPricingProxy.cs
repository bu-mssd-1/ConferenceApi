using DataModels;
using System.Collections.Generic;

namespace ConferenceWebApi
{
    /// <summary>
    /// A proxy for voice call prices
    /// </summary>
    public class VoiceCallPricingProxy : IVoiceCallPricing
    {
        /// <summary>
        /// A placeholder
        /// </summary>
        private VoiceCallPricing voiceCallPricing;

        /// <summary>
        /// Loads pricing from a CSV file.
        /// </summary>
        /// <returns>A collection of voice call pricing</returns>
        public ICollection<VoiceCallPrice> GetPricing()
        {
            if (voiceCallPricing == null)
            {
                voiceCallPricing = new VoiceCallPricing();
            }

            return voiceCallPricing.GetPricing();
        }
    }
}