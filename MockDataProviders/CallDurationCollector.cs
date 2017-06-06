using Contracts;
using DataModels;
using System;
using System.Linq;

namespace MockDataProviders
{
    /// <summary>
    /// This class collects the duration of each call in a conference
    /// </summary>
    public class CallDurationCollector : BillProcess
    {
        /// <summary>
        /// This method calculates total duration of all calls in a conference
        /// Then passes it to the next processor 
        /// </summary>
        /// <param name="conference">A conference object</param>
        public override void Process(Conference conference)
        {
            if (conference != null && ConferenceTestMockDataProvider.MockConferenceHistory != null)
            {
                // Locate the conference in conference history
                var historyItems = ConferenceTestMockDataProvider.MockConferenceHistory.Where(o => o.ConferenceId == conference.ConferenceId).ToList();

                if (historyItems != null)
                {
                    double totalDurationInSeconds = 0;

                    for (int i = 0; i < historyItems.Count; i++)
                    {
                        var p = historyItems[i];
                        var d = (p.End - p.Start).TotalSeconds;
                        
                        // Update the current item
                        p.CallDuration = decimal.Parse(d.ToString());

                        // Update running total
                        totalDurationInSeconds += d;
                    }
                    
                    // Update total duration of the conf call
                    conference.TotalDuration = totalDurationInSeconds;
                }

                if (this.Successor != null)
                {
                    this.Successor.Process(conference);
                }
            }
        }
    }
}
