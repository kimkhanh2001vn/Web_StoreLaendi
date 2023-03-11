using System.Web;
using System.Web.Optimization;

namespace LaendiStore.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/assets/js/jquery-3.6.0.min.js",
                        "~/assests/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/assets/js").Include(
                      "~/assets/js/plugins.js",
                      "~/assets/js/main.js"));

            bundles.Add(new StyleBundle("~/assets/css").Include(
                      "~/assets/css/bootstrap.min.css",
                      "~/assets/css/plugins.css",
                      "~/assets/css/style.css",
                      "~/assets/css/responsive.css"));
        }
    }
}
