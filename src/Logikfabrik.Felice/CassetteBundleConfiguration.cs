//----------------------------------------------------------------------------------
// <copyright file="CassetteBundleConfiguration.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice
{
    using Cassette;
    using Cassette.Scripts;
    using Cassette.Stylesheets;

    public class CassetteBundleConfiguration : IConfiguration<BundleCollection>
    {
        public void Configure(BundleCollection bundles)
        {
            var cssPaths = new[]
            {
                "~/Assets/packages/leaflet-0.7.3/leaflet.css",
                "~/Assets/css/vendor/normalize-2.1.3.1/normalize.css",
                "~/Assets/css/app/felice.less"
            };

            var scriptPaths = new[]
            {
                "~/Assets/packages/leaflet-0.7.3/leaflet.js",
                "~/Assets/js/vendor/angularjs-1.2.22/angular.js",
                "~/Assets/js/vendor/esri-leaflet-1.0.0-rc.6/esri-leaflet.js",
                "~/Assets/js/vendor/lodash-2.4.1/lodash.js",
                "~/Assets/js/app/app.js",
                "~/Assets/js/app/factories/leaflet.js",
                "~/Assets/js/app/factories/lodash.js",
                "~/Assets/js/app/components/dishOfTheDay/dishOfTheDayFactory.js",
                "~/Assets/js/app/components/dishOfTheDay/dishOfTheDayController.js",
                "~/Assets/js/app/components/findUsOnTheMap/findUsOnTheMapController.js",
                "~/Assets/js/app/components/openingHoursOfTheDay/openingHoursOfTheDayFactory.js",
                "~/Assets/js/app/components/openingHoursOfTheDay/openingHoursOfTheDayController.js",
                "~/Assets/js/app/ga.js"
            };

            // CSS bundle.
            bundles.Add<StylesheetBundle>(
                "~/Assets/CommonCss",
                cssPaths);

            // JS bundle.
            bundles.Add<ScriptBundle>(
                "~/Assets/CommonJs",
                scriptPaths);
        }
    }
}