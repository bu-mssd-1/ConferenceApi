using DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    /// <summary>
    /// This class contains scenario tests for CS665 final assignment
    /// </summary>
    [TestClass]
    public class CS665ScenarioTests
    {
        #region Test Variables

        /// <summary>
        /// A placeholder for an new users device phone number
        /// </summary>
        private string newUserDevicePhoneNumber = "+12064881199";

        /// <summary>
        /// A placeholder for an new user Id
        /// </summary>
        private string newUserId = Guid.NewGuid().ToString();

        /// <summary>
        /// A placeholder for an existing users device phone number
        /// </summary>
        private string existingDevicePhoneNumber = "+12064881199";

        /// <summary>
        /// A placeholder for an existing user Id
        /// </summary>
        private string existingUserId = "3ECA30F8-88FF-4BA8-9BA5-DC8684050A4C";

        /// <summary>
        /// A conference number that is owned by an existing user.
        /// </summary>
        private string conferenePhoneNumber = "+12064880022";

        #endregion

        #region Scenario Tests

        /// <summary>
        /// In this test we will create a new user.
        /// </summary>
        [TestMethod]
        public void NewUserRegistrationTest()
        {
            var client = new RestClient(TestConstant.ServiceUrl);
            var request = new RestRequest("user/getbyphone?phone=" + newUserDevicePhoneNumber, Method.GET);
            var getUserByPhoneResponse = client.Execute(request);

            if (getUserByPhoneResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var userExist = bool.Parse(getUserByPhoneResponse.Content);

                // If user does not exist create a new user
                if (!userExist)
                {
                    var user = new User()
                    {
                        UserId = newUserId,
                        DevicePhoneNumber = newUserDevicePhoneNumber,
                        DateCreated = DateTime.UtcNow,
                        Pin = "123456",
                        IsActive = true
                    };

                    request = new RestRequest("user", Method.POST);
                    request.AddJsonBody(user);

                    var createUserResponse = client.Execute(request);

                    if (createUserResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Assert.IsNotNull(createUserResponse.Content);

                        // Verification: Retrieve the new user and 
                        // make sure that it has the same User Id 
                        // as the one that we just created.
                        request = new RestRequest("user/{id}", Method.GET);
                        request.AddParameter("id", newUserId);

                        var verifyUserResponse = client.Execute<User>(request);

                        if (verifyUserResponse.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            Assert.IsTrue(newUserId == verifyUserResponse.Data.UserId);
                        }
                        else
                        {
                            Assert.Fail("Error in web service! Unable to verify new user creation");
                        }
                    }
                    else
                    {
                        Assert.Fail("Error in web service! Unable to create a new user.");
                    }
                }
                else
                {
                    Assert.Fail("User already exist! Try a different phone number.");
                }
            }
            else
            {
                Assert.Fail("Error in web service! Unable to retrive results for 'get user by phone' request");
            }
        }

        /// <summary>
        /// In this test, we will retrive a list of available phone numbers.
        /// Then we will select a phone number to reserve for our user.
        /// </summary>
        [TestMethod]
        public void GetNewPhoneNumberTest()
        {
            var client = new RestClient(TestConstant.ServiceUrl);
            var request = new RestRequest("availablenumber", Method.GET);
            request.AddQueryParameter("country", "US");
            request.AddQueryParameter("areacode", "617");

            var getAvailablePhoneNumbersResponse = client.Execute<List<AvailablePhoneNumber>>(request);

            if (getAvailablePhoneNumbersResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var availableNumbers = getAvailablePhoneNumbersResponse.Data;

                if (availableNumbers != null && availableNumbers.Count > 0)
                {
                    // Take the first number in the list
                    var firstAvailableNumber = availableNumbers.FirstOrDefault();
                    var newPhoneNumberId = Guid.NewGuid().ToString();

                    var virtualPhoneNumber = new VirtualPhoneNumber()
                    {
                        VirtualPhoneNumberId = newPhoneNumberId,
                        DateCreated = DateTime.UtcNow,
                        IsActive = true,
                        UserId = existingUserId,
                        PhoneNumber = firstAvailableNumber.PhoneNumber
                    };

                    request = new RestRequest("virtualphonenumber", Method.POST);
                    var createPhoneNumberResponse = client.Execute(request);

                    if (createPhoneNumberResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Assert.IsNotNull(createPhoneNumberResponse.Content);

                        // Retrive the phone number we just created
                        request = new RestRequest("virtualphonenumber/{id}", Method.GET);
                        request.AddParameter("id", newPhoneNumberId);

                        var verifyPhoneNumberResponse = client.Execute<VirtualPhoneNumber>(request);

                        var newPhoneNumber = verifyPhoneNumberResponse.Data;

                        // Verify that this is the same phone number that we created above
                        Assert.IsTrue(newPhoneNumber.VirtualPhoneNumberId == newPhoneNumberId);
                    }
                    else
                    {
                        Assert.Fail("Error in web service! Unable to create a new phone number!");
                    }
                }
                else
                {
                    Assert.Fail("No number available for the given area code!");
                }
            }
            else
            {
                Assert.Fail("Error in web service! Unable to retrive a list of available phone numbers!");
            }
        }

        /// <summary>
        /// In this test we will create a new conference.
        /// </summary>
        [TestMethod]
        public void CreateNewConferenceTest()
        {
            // Generate a 6 digit conference pass code
            int min = 197310;
            var r = new Random();
            var code = r.Next(min + 1, 207310);

            var newConferenceId = Guid.NewGuid().ToString();

            // Create a conference entity
            var conference = new Conference()
            {
                ConferenceId = newConferenceId,
                ConferenceName = "CS 665 Conference Test",
                ConferencePhoneNumber = conferenePhoneNumber,
                ConferencePassCode = code.ToString(),
                WelcomeMessage = "Welcome to C S 6 6 5",
                DateCreated = DateTime.UtcNow,
                UserId = existingUserId,
                Status = "Ready",
                Cost = 1,
                ProviderId = "0",
                TotalDuration = 1,
            };

            // Add initial participants. 
            // By default add users device phone number.
            conference.Participants = existingDevicePhoneNumber;

            var request = new RestRequest("conference", Method.POST);
            request.AddJsonBody(conference);

            var client = new RestClient(TestConstant.ServiceUrl);
            var createConferenceResponse = client.Execute(request);

            if (createConferenceResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Assert.IsNotNull(createConferenceResponse.Content);

                // Verification: Retrieve the new conference entity and 
                // make sure that it has the same Conference Id 
                // as the one that we just created.
                request = new RestRequest("conference/{id}", Method.GET);
                request.AddParameter("id", newConferenceId);

                var verifyConferenceResponse = client.Execute<Conference>(request);

                if (verifyConferenceResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Assert.IsTrue(newConferenceId == verifyConferenceResponse.Data.ConferenceId);
                }
                else
                {
                    Assert.Fail("Error in web service! Unable to verify new conference creation");
                }
            }
            else
            {
                Assert.Fail("Error in web service! Unable to create a new conference");
            }
        }

        #endregion
    }
}
