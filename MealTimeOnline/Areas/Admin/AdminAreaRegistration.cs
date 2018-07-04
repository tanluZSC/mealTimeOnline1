using System;
using System.Web.Mvc;

namespace MealTimeOnline.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Admin Images",
                url: "Admin/Image/{action}/{width}x{height}/{text}",
                defaults: new { controller = "Image", action = "Placeholder", text = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "Admin Placeholder",
                url: "Admin/Image/{action}/{setting}/{text}",
                defaults: new { controller = "Image", action = "Imgx", text = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "Canteen foods manager",
                url: "Admin/Canteens/{cid}/Foods/{action}/{id}",
                defaults: new { controller = "Foods", action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}