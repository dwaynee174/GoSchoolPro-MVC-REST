using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GoSchoolProMVC
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
                name: "Home",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "BeachVoice",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "BeachVoice", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Apartment",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Apartment", action = "Create", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Roommate",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Roommate", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "KnowBeach",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "KnowBeach", action = "Create", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "AirportPckUp",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "AirportPckUp", action = "Create", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "GoTour",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "GoTour", action = "Create", id = UrlParameter.Optional }
          );



        }
    }
}
