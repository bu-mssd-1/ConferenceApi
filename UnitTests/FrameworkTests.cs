using ConferenceWebApi.Controllers;
using Contracts;
using DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using TwilioExternalAdapter;

namespace UnitTests
{
    [TestClass]
    public class FrameworkTests
    {
        [TestMethod]
        public void CommonDataModelInheritanceTest()
        {
            // Validate that the 'User' object is a subclass of a framework abstract class named BaseModel
            Assert.IsTrue(new User().GetType().IsSubclassOf(typeof(BaseModel)));

            // Validate that the 'Conference' object is a subclass of a framework abstract class named BaseModel
            Assert.IsTrue(new Conference().GetType().IsSubclassOf(typeof(BaseModel)));

            // Validate that the 'VirtualPhoneNumber' object is a subclass of a framework abstract class named BaseModel
            Assert.IsTrue(new VirtualPhoneNumber().GetType().IsSubclassOf(typeof(BaseModel)));
        }

        [TestMethod]
        public void CommonAdapterInheritanceTest()
        {
            var adapter = new TwilioAdapter();

            // Validate that the 'TwilioAdapter' type object is a subclass of a framework abstract class named CommonAdapter
            Assert.IsTrue(adapter.GetType().IsSubclassOf(typeof(CommonAdapter)));
        }

        [TestMethod]
        public void WebApiInheritanceTest()
        {
            var userController = new UserController();

            // Validate that the 'UserController' type object is a subclass of a ASP.Net framework abstract class named ApiController
            Assert.IsTrue(userController.GetType().IsSubclassOf(typeof(ApiController)));
        }
    }
}
