using System.Web.Mvc;
using Twilio.TwiML;

namespace ConferenceWebApi.Controllers
{
    public class IncomingCallController : Controller
    {
        public ActionResult Index(string from, string to)
        {
            var response = new VoiceResponse();

            var gather = new Gather(action:
                string.Format("{0}/verifyparticipant?to={1}", AppConstant.ExternalServiceUrlPrefix, to),
                method: "GET");
            gather.Say("Welcome to the conference center. Please enter your pass code followed by the pound sign.");
            response.Gather(gather);
            response.Say("We didn't receive any input. Goodbye!");

            return Content(response.ToString(), "text/xml");
        }
    }
}
