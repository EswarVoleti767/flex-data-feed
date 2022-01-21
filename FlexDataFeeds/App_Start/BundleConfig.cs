using System.Web;
using System.Web.Optimization;

namespace FlexDataFeeds
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     "~/Scripts/jquery-3.4.1.min.js",
                     "~/Scripts/Kendo/kendo.all.min.js",
                     "~/Scripts/bootstrap.js",
                     "~/Scripts/bootstrap.min.js",
                     "~/Scripts/main.js"
                       ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/bootstrap.min.css",
                     "~/Content/Kendo/kendo.common.min.css",
                    "~/Content/Kendo/kendo.default-v2.min.css",
                    "~/Content/Kendo/kendo.default.min.css",
                    "~/Content/css/main.css"
                       ));
        }
    }
}
