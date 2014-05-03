using System.Web;
using System.Web.Optimization;

namespace SignalRBearerTokenSample
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/frameworks")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery.signalR-{version}.js")
                .Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js")
                .Include("~/Scripts/toastr.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-*")
                );


            bundles.Add(new StyleBundle("~/Content/css")
                .Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/toastr.css"));
        }
    }
}
