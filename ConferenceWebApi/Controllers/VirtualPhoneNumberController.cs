using Contracts;
using DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TwilioExternalAdapter;

namespace ConferenceWebApi.Controllers
{
    public class VirtualPhoneNumberController : ApiController
    {
        /// <summary>
        /// A virtualPhoneNumber data provider
        /// </summary>
        private VirtualPhoneNumberDataProvider virtualPhoneNumberDataProvider;

        /// <summary>
        /// Creates a new instance of the virtualPhoneNumber controller class;
        /// </summary>
        public VirtualPhoneNumberController()
        {
            this.virtualPhoneNumberDataProvider = new DataProviderFactory().GetVirtualPhoneNumberDataProvider(AppConstant.DataProviderType);
        }

        [HttpGet]
        [Route("~/api/virtualPhoneNumber")]
        public async Task<ICollection<VirtualPhoneNumber>> Get()
        {
            return await this.virtualPhoneNumberDataProvider.Get();
        }

        [HttpGet]
        [Route("~/api/virtualPhoneNumber/{id}")]
        public async Task<VirtualPhoneNumber> Get(string id)
        {
            return await this.virtualPhoneNumberDataProvider.GetById(id);
        }

        [HttpGet]
        [Route("~/api/virtualPhoneNumber/")]
        public async Task<VirtualPhoneNumber> GetByPhone(string phoneNumber)
        {
            return await this.virtualPhoneNumberDataProvider.GetByVirtualPhoneNumber(phoneNumber);
        }

        [HttpGet]
        [Route("~/api/{userid}/virtualPhoneNumber")]
        public async Task<ICollection<VirtualPhoneNumber>> GetByUserId(string userid)
        {
            return await this.virtualPhoneNumberDataProvider.GetByUserId(userid);
        }

        [HttpPost]
        [Route("~/api/virtualPhoneNumber")]
        public async Task<VirtualPhoneNumber> Insert([FromBody] VirtualPhoneNumber virtualPhoneNumber)
        {
            CommonAdapter adapter = new TwilioAdapter();
            var providerId = await adapter.PurchasePhoneNumber(virtualPhoneNumber.PhoneNumber);

            // Update provider Id
            virtualPhoneNumber.ProviderId = providerId;

            // TODO: Modify the resource in provider to include url/etc

            return await this.virtualPhoneNumberDataProvider.CreateVirtualPhoneNumber(virtualPhoneNumber);
        }

        [HttpPut]
        [Route("~/api/virtualPhoneNumber")]
        public async Task<VirtualPhoneNumber> Update([FromBody] VirtualPhoneNumber virtualPhoneNumber)
        {
            return await this.virtualPhoneNumberDataProvider.UpdateVirtualPhoneNumber(virtualPhoneNumber);
        }

        [HttpDelete]
        [Route("~/api/virtualPhoneNumber/{id}")]
        public async Task<bool> Delete(string id)
        {
            return await this.virtualPhoneNumberDataProvider.DeleteVirtualPhoneNumber(id);
        }
    }
}
