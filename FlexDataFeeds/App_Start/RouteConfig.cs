using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FlexDataFeeds
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ManualCategory", action = "List", id = UrlParameter.Optional }
            );

            routes.MapRoute("ManualCategoryList",
                "ManualCategory/List",
                new { controller = "ManualCategory", action = "List" },
                new[] { "FlexDataFeeds.Controllers" }
            );

            routes.MapRoute("ManualCategoryDelete",
                "ManualCategory/MarkDirty",
                new { controller = "ManualCategory", action = "MarkDirty" },
                new[] { "FlexDataFeeds.Controllers" }
            );

            routes.MapRoute("ManualCategoryUpdate",
               "ManualCategory/Update",
               new { controller = "ManualCategory", action = "ManualUpdate" },
               new[] { "FlexDataFeeds.Controllers" }
           );

        }
    }
}
