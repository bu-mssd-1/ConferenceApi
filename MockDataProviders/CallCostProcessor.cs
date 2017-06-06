using Contracts;
using DataModels;
using System.Linq;

namespace MockDataProviders
{
    public class CallCostProcessor : BillProcess
    {
        public override void Process(Conference conference)
        {
            if (conference != null && ConferenceTestMockDataProvider.MockConferenceHistory != null)
            {
                // Locate the conference in conference history
                var historyItems = ConferenceTestMockDataProvider.MockConferenceHistory.Where(o => o.ConferenceId == conference.ConferenceId).ToList();
                var billRates = ConferenceTestMockDataProvider.GetBillRates();
                decimal runningTotal = 0;

                if (historyItems != null)
                {
                    foreach (var p in historyItems)
                    {
                        var rate = billRates.Where(a => a.Key == p.ParticipantPhoneNumber.Substring(0, 3)).FirstOrDefault().Value;
                        decimal duration = 0;

                        duration = p.CallDuration / 60;

                        if (p.CallDuration > 0 && p.CallDuration < 60)
                        {
                            duration = duration + 1;
                        }

                        runningTotal += duration * rate;
                    }
                }

                conference.Cost = decimal.Parse(runningTotal.ToString());
            }
        }
    }
}
