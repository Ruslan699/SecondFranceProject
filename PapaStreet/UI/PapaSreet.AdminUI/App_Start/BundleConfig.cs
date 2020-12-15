using System.Web;
using System.Web.Optimization;

namespace PapaSreet.AdminUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryUnobtrusive").Include(
                       "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                         "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/template").Include(
                       "~/Scripts/theme/main/bootstrap.bundle.min.js",
                       "~/Scripts/theme/plugins/loaders/blockui.min.js",
                       "~/Scripts/theme/plugins/ui/ripple.min.js",
                       "~/Scripts/theme/plugins/visualization/d3/d3.min.js",
                       "~/Scripts/theme/plugins/ui/moment/moment.min.js",
                       "~/Scripts/theme/app.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                         "~/Scripts/application.js"));

            bundles.Add(new StyleBundle("~/Content/template").Include(
                      "~/Content/css/animate.min.css",
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/bootstrap_limitless.min.css",
                      "~/Content/css/colors.min.css",
                      "~/Content/css/components.min.css",
                      "~/Content/css/fontawesome_icons.min.css",
                      "~/Content/css/icomoon_icons.css",
                      "~/Content/css/layout.min.css",
                      "~/Content/css/material_icons.css",
                      "~/Content/alertify/alertify.min.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/site").Include(
                      "~/Content/Site.css"
                      ));

            //#if !DEBUG
            BundleTable.EnableOptimizations = false;
                
//#endif
        }
    }
}
