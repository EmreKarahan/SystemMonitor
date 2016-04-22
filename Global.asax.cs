﻿using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using OpenShift.Models;

namespace OpenShift
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AppConfig.CoreCount = Environment.ProcessorCount;
        }
    }
}