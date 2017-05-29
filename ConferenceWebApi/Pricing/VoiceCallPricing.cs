using CsvHelper;
using DataModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ConferenceWebApi
{
    /// <summary>
    /// An interface for proxy example
    /// </summary>
    public class VoiceCallPricing : IVoiceCallPricing
    {
        /// <summary>
        /// Loads pricing from a CSV file.
        /// </summary>
        /// <returns>A collection of voice call pricing</returns>
        public ICollection<VoiceCallPrice> GetPricing()
        {
            var results = new Collection<VoiceCallPrice>();

            var csvFilePath = @".\CSV\VoicePrices.csv";

            if (File.Exists(csvFilePath))
            {
                using (var textReader = File.OpenText(csvFilePath))
                {
                    using (var csv = new CsvReader(textReader))
                    {
                        while (csv.Read())
                        {
                            var v = new VoiceCallPrice()
                            {
                                CountryCode = csv.GetField<string>(0),
                                CountryName = csv.GetField<string>(1),
                                Description = csv.GetField<string>(2),
                                PricePerMinute = csv.GetField<string>(3),
                                OriginationPrefixes = csv.GetField<string>(4),
                                DestinationPrefixes = csv.GetField<string>(5)
                            };

                            results.Add(v);
                        }
                    }
                }
            }

            return results;
        }
    }
}