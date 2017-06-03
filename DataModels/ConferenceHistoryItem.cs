using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class ConferenceHistoryItem
    {
        public string ConferenceId { get; set; }
        public string ConferencePhoneNumber { get; set; }
        public string ParticipantPhoneNumber { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
