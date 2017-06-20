using Contracts;
using DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TwilioExternalAdapter;

namespace ConferenceWebApi.Controllers
{
    /// <summary>
    /// A controller to manage available number resource.
    /// </summary>
    public partial class AvailableNumberController : ApiController
    {
        /// <summary>
        /// Retrieves a list of available phone number
        /// </summary>
        /// <returns>A collection of available phone number</returns>
        [HttpGet]
        [Route("~/api/availablenumber")]
        public async Task<ICollection<AvailablePhoneNumber>> Get(string country = "US", string region = null, int? areaCode = null)
        {
            CommonAdapter adapter = new TwilioAdapter();

            return await adapter.GetAvailablePhoneNumbers("US", areaCode);
        }
    }
}
