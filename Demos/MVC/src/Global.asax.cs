using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using GroupDocs.Search.MVC.AppDomainGenerator;

namespace GroupDocs.Search.MVC
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Fix required to use several GroupDocs products in one project.
            // Set GroupDocs products assemblies names
            string SearchAssemblyName = "GroupDocs.Search.dll";
            // set GroupDocs.Search license
            DomainGenerator SearchDomainGenerator = new DomainGenerator(SearchAssemblyName, "GroupDocs.Search.License");
            SearchDomainGenerator.SetSearchLicense();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
