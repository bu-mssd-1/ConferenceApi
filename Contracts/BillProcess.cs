using DataModels;

namespace Contracts
{
    /// <summary>
    /// A base class for bill process
    /// This class is used for COR pattern
    /// </summary>
    public abstract class BillProcess
    {
        /// <summary>
        /// A placeholder for next processor
        /// </summary>
        private BillProcess successor;

        /// <summary>
        /// Gets or sets the successor
        /// </summary>
        public BillProcess Successor
        {
            get => successor;
            set => successor = value;
        }

        /// <summary>
        /// Sets the successor 
        /// </summary>
        /// <param name="successor">A bill process class</param>
        public void SetSuccessor(BillProcess successor)
        {
            this.Successor = successor;
        }

        /// <summary>
        /// Processes a conference billing
        /// </summary>
        /// <param name="conferenceId">A conference</param>
        public abstract void Process(Conference conference);
    }
}
