using System.Threading.Tasks;
using System.Web.Mvc;
using Twilio.TwiML;

namespace ConferenceWebApi.Controllers
{
    public class VerifyParticipantController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index(string to, string digits)
        {
            var response = new VoiceResponse();

            if (!string.IsNullOrEmpty(digits))
            {
                // Find the conference by the phone number and pass code
                var conferenceDataProvider = new DataProviderFactory().GetConferenceDataProvider(AppConstant.DataProviderType);

                if (conferenceDataProvider != null)
                {
                    var conference = await conferenceDataProvider.GetByPhoneAndPassCode(to, digits);

                    if (conference != null)
                    {
                        response.Say(conference.WelcomeMessage);
                        response.Say("You are now connected to the conference.");
                        var dial = new Dial();
                        dial.Conference(
                            name: conference.ConferencePhoneNumber + conference.ConferencePassCode,
                            startConferenceOnEnter: true,
                            endConferenceOnExit: true,
                            beep: "true");
                        response.Dial(dial);
                    }
                    else
                    {
                        response.Say("We are sorry! Your pass code did not work! Good bye!");
                    }
                }
            }

            return Content(response.ToString(), "text/xml");
        }
    }
}