using Contracts;
using DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConferenceWebApi.Controllers
{
    public class UserController : ApiController
    {
        /// <summary>
        /// A user data provider
        /// </summary>
        private UserDataProvider userDataProvider;

        /// <summary>
        /// Creates a new instance of the user controller class;
        /// </summary>
        public UserController()
        {
            this.userDataProvider = new DataProviderFactory().GetUserDataProvider(AppConstant.DataProviderType);
        }

        [HttpGet]
        [Route("~/api/user")]
        public async Task<ICollection<User>> Get()
        {
            return await this.userDataProvider.Get();
        }

        [HttpGet]
        [Route("~/api/user/{id}")]
        public async Task<User> Get(string id)
        {
            return await this.userDataProvider.GetById(id);
        }

        [HttpGet]
        [Route("~/api/user/getbyphone")]
        public async Task<bool> GetByPhone(string phone)
        {
            return await this.userDataProvider.DoesUserExits(phone);
        }

        [HttpPost]
        [Route("~/api/user")]
        public async Task<User> Insert([FromBody] User user)
        {
            return await this.userDataProvider.CreateUser(user);
        }

        [HttpPut]
        [Route("~/api/user")]
        public async Task<User> Update([FromBody] User user)
        {
            return await this.userDataProvider.UpdateUser(user);
        }

        [HttpDelete]
        [Route("~/api/user/{id}")]
        public async Task<bool> Delete(string id)
        {
            return await this.userDataProvider.DeleteUser(id);
        }
    }
}
