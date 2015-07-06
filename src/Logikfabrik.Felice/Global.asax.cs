//----------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice
{
    using System;
    using System.Web.Routing;
    using DataTypes;
    using Umbraco.Jet.Mappings;
    using Umbraco.Jet.Web.Data.Converters;
    using global::Umbraco.Web;
    using Utilities;
    
    public class Global : UmbracoApplication
    {
        protected override void OnApplicationStarting(object sender, EventArgs e)
        {
            DataTypeDefinitionMappings.Mappings.Add(typeof(OpeningHours), new OpeningHoursDataTypeDefinitionMapping());
            PropertyValueConverters.Converters.Add(typeof(OpeningHours), new[] { new OpeningHoursPropertyValueConverter() });
        }

        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            base.OnApplicationStarted(sender, e);

            MapConfig.RegisterMaps();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Context.IsDebuggingEnabled)
            {
                return;
            }

            var url = Request.Url.ToString();
            var ssl = Request.IsSecureConnection;

            if (!UrlUtility.ShouldRedirectPermanent(url, ssl))
            {
                return;
            }

            Response.RedirectPermanent(UrlUtility.GetRedirectUrl(url, ssl));
        }
    }
}