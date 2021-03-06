﻿using System.Web;
using System.Web.Optimization;

namespace SystemMonitor
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

     

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.css",
                  "~/Content/bootflat/bootflat.css",
                  "~/Content/font-awesome.css",
                  "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/react").Include(
                "~/Scripts/react/react.js",
                "~/Scripts/react/react-with-addons.js",
                "~/Scripts/react/react-dom.min.js"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
