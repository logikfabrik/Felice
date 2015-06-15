//----------------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice
{
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Custom HTTP routes.
            RouteTable.Routes.MapHttpRoute(
                "DefaultApi", 
                "api/{controller}/{id}", 
                new { id = RouteParameter.Optional });
            
            // Custom MVC routes.
            RouteTable.Routes.MapRoute(
                "ViewLunchMenu", 
                "at-med-oss/{year}/{week}",
                new { controller = "EatWithUsPage", action = "ViewLunchMenu" }, 
                new { year = @"\d+", week = @"\d+" });
        }
    }
}