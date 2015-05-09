﻿using Logikfabrik.Felice.DataTypes;
using Logikfabrik.Felice.Helpers;
using Logikfabrik.Felice.Utilities;
using Logikfabrik.Umbraco.Jet.Mappings;
using Logikfabrik.Umbraco.Jet.Web.Data.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web.Optimization;
using System.Web.Routing;
using Umbraco.Web;

namespace Logikfabrik.Felice
{
    public class Global : UmbracoApplication
    {
        protected override void OnApplicationStarting(object sender, EventArgs e)
        {
            DataTypeDefinitionMappings.Mappings.Add(typeof(IEnumerable<Models.OpeningHours>), new OpeningHoursDataTypeDefinitionMapping());
            PropertyValueConverters.Converters.Add(typeof(JArray), new[] { new OpeningHoursConverter() });
        }

        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            base.OnApplicationStarted(sender, e);

            MapConfig.RegisterMaps(new SettingsHelper(new PageHelper()));
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Context.IsDebuggingEnabled)
                return;

            var url = Request.Url.ToString();
            var ssl = Request.IsSecureConnection;

            if (!UrlUtility.ShouldRedirectPermanent(url, ssl))
                return;

            Response.RedirectPermanent(UrlUtility.GetRedirectUrl(url, ssl));
        }
    }
}