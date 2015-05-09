using System.Web.Http;
using System.Web.Routing;

namespace Logikfabrik.Felice
{
    public static class RouteConfig 
    {
        public static void RegisterRoutes(RouteCollection routes)  
        {
            RouteTable.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional});
        }
    }
}