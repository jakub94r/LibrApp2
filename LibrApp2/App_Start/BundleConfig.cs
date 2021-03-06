﻿using System.Web;
using System.Web.Optimization;

namespace LibrApp2
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/datatables/jquery.datatables.js",
                "~/Scripts/jquery-ui-1.12.1.js",
                "~/Scripts/jquery-ui-1.12.1.min.js",
                "~/Scripts/datatables/datatables.bootstrap.js",
                "~/Scripts/noty/jquery.noty.js",
                "~/Scripts/noty/layouts/topRight.js",
                "~/Scripts/noty/themes/relax.js",
                "~/Scripts/noty/themes/relax2.js",
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/libra-bootstrap.css",
                      "~/Content/animate.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
