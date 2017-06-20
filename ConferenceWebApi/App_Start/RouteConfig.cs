using System.Web.Mvc;
using System.Web.Routing;

namespace ConferenceWebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "IncomingCall",
                 url: "incomingcall",
                 defaults: new { controller = "IncomingCall", action = "Index" }
             );

            routes.MapRoute(
                 name: "VerifyParticipant",
                 url: "verifyparticipant",
                 defaults: new { controller = "VerifyParticipant", action = "Index" }
             );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}"
            );
        }
    }
}
