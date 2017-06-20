namespace DataModels
{
    public class ConferenceReadyState : ConferenceState
    {
        /// <summary>
        /// Handles a state for a conference
        /// </summary>
        /// <param name="conference">The conference to modify</param>
        public override void Handle(Conference conference)
        {
            if (conference != null)
            {
                // For our school project we will just set a property of the conference
                conference.Status = DataModelConstant.ConferenceInProgress;
            }
        }
    }
}
