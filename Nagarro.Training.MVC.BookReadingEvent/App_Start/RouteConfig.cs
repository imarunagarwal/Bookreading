using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Nagarro.Training.MVC.BookReadingEvent
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Custom Route",
                url: "customer-support",
                defaults: new { controller = "NagarroHelpDesk", action = "Home", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Events", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
