using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Diagnostics;

namespace UnitTests
{
    [TestClass]
    public class FacadeTest
    {
        [TestMethod]
        public void GetUserViaWebService()
        {
            var client = new RestClient(TestConstant.ServiceUrl);
            var request = new RestRequest("user", Method.GET);
            request.Parameters.Add(new Parameter() { Name = "id", Value = "E18A9A29-49E0-4D8D-8528-AB70AA4BA56D" });

            var result = client.Execute(request);

            Assert.IsNotNull(result);

            Debug.WriteLine(string.Format("Get User By Id ~ Status Code : {0}, Content : {1}", result.StatusCode, result.Content));
        }
    }
}
