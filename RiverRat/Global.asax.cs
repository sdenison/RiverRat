using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using FiftyOne.Foundation;

namespace RiverRat
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //The Android view
            //DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("android")
            //{
            //    ContextCondition = Context => Context.Request.Browser.Platform == "Android"
            //});
            //DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("iphone")
            //{
            //    ContextCondition = Context => Context.Request.Browser.MobileDeviceModel == "iPhone"
            //});
            //DisplayModeProvider.Instance.Modes.Insert(1, new DefaultDisplayMode("mobile")
            //{
            //    ContextCondition = Context => Context.Request.Browser.IsMobileDevice 
            //});

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}