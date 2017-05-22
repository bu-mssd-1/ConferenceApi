using Contracts;
using DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConferenceWebApi.Controllers
{
    public class ConferenceController : ApiController
    {
        /// <summary>
        /// A conference data provider
        /// </summary>
        private ConferenceDataProvider conferenceDataProvider;

        /// <summary>
        /// Creates a new instance of the conference controller class;
        /// </summary>
        public ConferenceController()
        {
            this.conferenceDataProvider = new DataProviderFactory().GetConferenceDataProvider(AppConstant.DataProviderType);
        }

        [HttpGet]
        [Route("~/api/conference")]
        public async Task<ICollection<Conference>> Get()
        {
            return await this.conferenceDataProvider.Get();
        }

        [HttpGet]
        [Route("~/api/conference/{id}")]
        public async Task<Conference> Get(string id)
        {
            return await this.conferenceDataProvider.GetById(id);
        }

        [HttpGet]
        [Route("~/api/{userid}/conference")]
        public async Task<ICollection<Conference>> GetByUserId(string userid)
        {
            return await this.conferenceDataProvider.GetByUserId(userid);
        }

        [HttpPost]
        [Route("~/api/conference")]
        public async Task<Conference> Insert([FromBody] Conference conference)
        {
            return await this.conferenceDataProvider.CreateConference(conference);
        }

        [HttpPut]
        [Route("~/api/conference")]
        public async Task<Conference> Update([FromBody] Conference conference)
        {
            return await this.conferenceDataProvider.UpdateConference(conference);
        }

        [HttpDelete]
        [Route("~/api/conference/{id}")]
        public async Task<bool> Delete(string id)
        {
            return await this.conferenceDataProvider.DeleteConference(id);
        }
    }
}
