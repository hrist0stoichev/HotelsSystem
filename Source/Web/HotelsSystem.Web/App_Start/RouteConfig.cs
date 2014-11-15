namespace HotelsSystem.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name:"Hotel Details",
                url: "details/{hotelName}",
                defaults: new { controller = "HotelDetails", action = "GetDetails", hotelName = UrlParameter.Optional}
                );

            routes.MapRoute(
                name: "Add Hotel",
                url: "add",
                defaults: new { controller = "Hotel", action = "Add"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
