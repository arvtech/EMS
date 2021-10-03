using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmpMngSys
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
           name: "Default1",
           url: "{controller}/{action}/{id}",
           defaults: new { controller = "Employee", action = "Create", id = UrlParameter.Optional });


            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
           name: "Default3",
           url: "{controller}/{action}/{id}",
           defaults: new { controller = "Depart", action = "Index", id = UrlParameter.Optional });


        

            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
         );
        }
    }
}
