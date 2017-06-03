using System.Collections.Generic;

namespace Contracts
{
    public abstract class PublisherModule
    {
        /// <summary>
        /// A placeholder for currently selected phone number
        /// </summary>
        private string currentlySelectedItem = string.Empty;

        /// <summary>
        /// A list of modules that were attached to main module
        /// </summary>
        public List<ModuleBase> modules = new List<ModuleBase>();

        /// <summary>
        /// Gets or sets currently selected phone number
        /// </summary>
        public string CurrentlySelectedItem
        {
            get
            {
                return this.currentlySelectedItem;
            }

            set
            {
                this.currentlySelectedItem = value;

                // Notify the subscribers
                this.Notify(this.currentlySelectedItem);
            }
        }

        /// <summary>
        /// Attach a module to main module
        /// </summary>
        /// <param name="module">A module to attach</param>
        public void Attach(ModuleBase module)
        {
            if (!modules.Exists(m => m.ModuleId == module.ModuleId))
            {
                this.modules.Add(module);
            }
        }

        /// <summary>
        /// Detach a module from main module
        /// </summary>
        /// <param name="module">The module to detach</param>
        public void Detach(ModuleBase module)
        {
            if (modules.Exists(m=> m.ModuleId == module.ModuleId))
            {
                this.modules.Remove(this.modules.Find(m => m.ModuleId == module.ModuleId));
            }
        }

        /// <summary>
        /// Notify other module of phone number changed
        /// </summary>
        public void Notify(string phoneNumber)
        {
            if (this.modules != null && this.modules.Count > 0)
            {
                foreach (var module in this.modules)
                {
                    module.OnPhoneNumberChanged(phoneNumber);
                }
            }
        }
    }
}
