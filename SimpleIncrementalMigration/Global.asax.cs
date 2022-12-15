namespace SimpleIncrementalMigration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SystemWebAdapterConfiguration
                .AddSystemWebAdapters(this)
                .AddProxySupport(options => options.UseForwardedHeaders = true)
                .AddJsonSessionSerializer(options => TestLibrary.Class1.RegistrionSessionKeys(options.KnownKeys))
                .AddRemoteAppServer(options => options.ApiKey = "ea1949f0-7ce0-4f1d-b735-22a1305c8a02")
                .AddAuthenticationServer()
                .AddSessionServer();
        }
    }
}
