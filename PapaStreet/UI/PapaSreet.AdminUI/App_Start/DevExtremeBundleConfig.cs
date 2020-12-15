using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace PapaSreet.AdminUI {

    public class DevExtremeBundleConfig {

        public static void RegisterBundles(BundleCollection bundles) {

            var scriptBundle = new ScriptBundle("~/Scripts/DevExtremeBundle");
            var styleBundle = new StyleBundle("~/Content/DevExtremeBundle");

            // CLDR scripts
            scriptBundle
                .Include("~/Scripts/cldr.js")
                .Include("~/Scripts/cldr/event.js")
                .Include("~/Scripts/cldr/supplemental.js")
                .Include("~/Scripts/cldr/unresolved.js");

            // Globalize 1.x
            scriptBundle
                .Include("~/Scripts/globalize.min.js")
                .Include("~/Scripts/globalize/message.js")
                .Include("~/Scripts/globalize/number.js")
                .Include("~/Scripts/globalize/currency.js")
                .Include("~/Scripts/globalize/date.js");

            scriptBundle
                .Include("~/Scripts/jszip.js");

            // DevExtreme + extensions
            scriptBundle
                .Include("~/Scripts/dx.all.js")
                .Include("~/Scripts/aspnet/dx.aspnet.data.js")
                .Include("~/Scripts/aspnet/dx.aspnet.mvc.js");

            //scriptBundle
            //    .Include("~/Scripts/vectormap-data/africa.js")
            //    .Include("~/Scripts/vectormap-data/canada.js")
            //    .Include("~/Scripts/vectormap-data/eurasia.js")
            //    .Include("~/Scripts/vectormap-data/europe.js")
            //    .Include("~/Scripts/vectormap-data/usa.js")
            //    .Include("~/Scripts/vectormap-data/world.js");

                   
            styleBundle
                .Include("~/Content/dx.common.css")
                .Include("~/Content/dx.light.css");


            bundles.Add(scriptBundle);
            bundles.Add(styleBundle);

        }
    }
}