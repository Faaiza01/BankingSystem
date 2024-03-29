﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BankingSystemWebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
              routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
                routes.MapRoute(
                name: "Post a BankingSystem",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "PostBankingSystem", action = "Index", id = UrlParameter.Optional }
            );
                routes.MapRoute(
                name: "Register",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Register", action = "Index", id = UrlParameter.Optional }
            );
                routes.MapRoute(
                name: "BankingSystem Search",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Search", action = "Index", id = UrlParameter.Optional }
            );
                   routes.MapRoute(
                name: "Profile",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Profile", action = "Index", id = UrlParameter.Optional }
            );
                   routes.MapRoute(
                name: "Admin",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
