﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Practice6
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            Route route = new Route(
              "{controller}/{action}",
              new RouteValueDictionary(new { Controller = "Home", Action = "Index" }),
              new MvcRouteHandler());
            routes.Add("Default", route);
        }
    }
}
