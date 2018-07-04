using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MealTimeOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // 认证路由
            routes.MapRoute(
                name: "Auth",
                url: "Auth/{controller}/{action}/{id}"
            );
            routes.MapRoute(
                name: "Account",
                url: "Account/{controller}/{action}/{id}"
            );

            routes.MapRoute(
                name: "Image Placeholder",
                url: "Image/{action}/{width}x{height}/{text}",
                defaults: new { controller = "Image", action = "Placeholder", text = UrlParameter.Optional },
                namespaces: new[] { "MealTimeOnline.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new []{ "MealTimeOnline.Controllers" }
            );
        }
    }
}
