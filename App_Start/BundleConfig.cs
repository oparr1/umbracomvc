using System.Web;
using System.Web.Optimization;

namespace MvcUmbraco
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/_layouthead").Include(
                        "~/Scripts/jquery-1.11.1.min.js",
                        "~/Scripts/jquery.validate.min.js", 
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/jquery.cookie.js",
                        "~/Scripts/html5shiv.js",
                        "~/Scripts/respond.min.js" ));

            bundles.Add(new ScriptBundle("~/bundles/_layoutbody").Include(
                        "~/Scripts/selectivizr.min.js" ));

            bundles.Add(new ScriptBundle("~/bundles/index").Include(
                        "~/Scripts/Responsive/owl.carousel.min.js",
                        "~/Scripts/Responsive/slideandprogressbar.min.js",
                        "~/Scripts/Responsive/equalheight.min.js" ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                        "~/Content/css/*.css" ));
            
            bundles.Add(new ScriptBundle("~/bundles/staticjs").Include(
                        "~/Scripts/Static/jquery.jscrollpane.min.js",
                        "~/Scripts/Static/jquery.mousewheel.min.js",
                        "~/Scripts/Static/owl.carousel.min.js",
                        "~/Scripts/Static/slidesyncandprogressbar.min.js" ));

            bundles.Add(new StyleBundle("~/bundles/staticcss").Include(
                        "~/Content/Static/css/*.css"));

            //Comment this out to control this setting via web.config compilation debug attribute
            // BundleTable.EnableOptimizations = true; 
        }
    }
}
