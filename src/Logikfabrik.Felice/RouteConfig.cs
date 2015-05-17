using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Logikfabrik.Felice
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Custom HTTP routes.
            RouteTable.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            
            // Custom MVC routes.
            RouteTable.Routes.MapRoute("ViewLunchMenu", "at-med-oss/{year}/{week}",
                new { controller = "EatWithUsPage", action = "ViewLunchMenu" }, new { year = @"\d+", week = @"\d+" });
        }
    }
}