using System.Web.Optimization;

namespace UserInterfaceExample
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/ThirdParty/jquery-{version}.js", "~/Scripts/ThirdParty/jquery.blockUI.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include("~/Scripts/ThirdParty/knockout-{version}.js", "~/Scripts/ThirdParty/knockout.validation.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/ThirdParty/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/ThirdParty/bootstrap.js", "~/Scripts/ThirdParty/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/spin").Include("~/Scripts/ThirdParty/spin.js"));
            bundles.Add(new ScriptBundle("~/bundles/sweetalert").Include("~/Scripts/ThirdParty/sweetalert2.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/Site.css", "~/Content/sweetalert2.min.css"));
        }
    }
}
