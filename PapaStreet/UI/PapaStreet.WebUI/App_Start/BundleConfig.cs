using System.Web;
using System.Web.Optimization;

namespace PapaStreet.WebUI
{
    public class BundleConfig
    {
       
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryUnobtrusiveAjax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
                        "~/Scripts/js/bootstrap.bundle.min.js",
                        //"~/Scripts/js/contact_me.js",
                        "~/Scripts/js/select2.min.js",
                        "~/Scripts/alertify/alertify.min.js",
                        "~/Scripts/Site.js",
                        "~/Scripts/js/custom.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                      "~/Scripts/Site.js"));

            bundles.Add(new StyleBundle("~/Content/theme").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/materialdesignicons.min.css",
                      "~/Content/css/select2-bootstrap.css",
                      "~/Content/css/select2.min.css",
                      "~/Content/css/samar.css",
                      "~/Content/alertify/alertify.min.css",
                      "~/Content/Site.css"
                      ));
        }
    }
}
