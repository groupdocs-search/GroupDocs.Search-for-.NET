using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace GroupDocs.Search.WebForms
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            routes.MapPageRoute(
             "Search",
             "",
             "~/Search.aspx"
         );
        }
    }
}
