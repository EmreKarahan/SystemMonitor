using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SystemMonitor.Helper;
using SystemMonitor.Models;

namespace SystemMonitor
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AppConfig.CoreCount = Environment.ProcessorCount;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            HostingEnvironment.RegisterObject(new TimerHelper());
            HostingEnvironment.RegisterObject(new RedisSubscribeHelper());
        }
    }
}
