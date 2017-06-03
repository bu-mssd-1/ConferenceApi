using DataModels;
using System;

namespace Contracts
{
    /// <summary>
    /// An abstract class for a client module
    /// </summary>
    public abstract class ModuleBase
    {
        /// <summary>
        /// Gets or sets the module id
        /// </summary>
        public string ModuleId { get; set; }

        /// <summary>
        /// Reacts to phone number changed
        /// </summary>
        /// <param name="phoneNumber">A phone number</param>
        public abstract void OnPhoneNumberChanged(string phoneNumber);

        /// <summary>
        /// An event 
        /// </summary>
        public abstract event EventHandler<EventArgs<string>> PhoneNumberChanged;
    }
}
