using System;
using System.Web;
using System.Web.Routing;
using System.Web.Http;
using GroupDocs.Search.WebForms.AppDomainGenerator;

namespace GroupDocs.Search.WebForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Fix required to use several GroupDocs products in one project.
            // Set GroupDocs products assemblies names          
            string searchAssemblyName = "GroupDocs.Search.dll";          
            // set GroupDocs.Search license
            DomainGenerator searchDomainGenerator = new DomainGenerator(searchAssemblyName, "GroupDocs.Search.License");
            searchDomainGenerator.SetSearchLicense();

            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}