using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LaendiStore.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "Product",
                 url: "{alias}.p-{productId}.html",
                 defaults: new { controller = "Home", action = "Detail", productId = UrlParameter.Optional },
                   namespaces: new string[] { "LaendiStore.Web.Controllers" }
             );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "LaendiStore.Web.Controllers" }
            );
        }
    }
}
