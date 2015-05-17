using System.Web.Optimization;
using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Transformers;

namespace Logikfabrik.Felice
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            bundles.Add(GetCssBundle());
            bundles.Add(GetJsBundle());
        }

        private static Bundle GetCssBundle()
        {
            var commonCss = new Bundle("~/Assets/CommonCss");

            commonCss.IncludeDirectory("~/Assets/css/vendor", "*.css", true);
            commonCss.IncludeDirectory("~/Assets/css/app", "*.less", true);
            
            commonCss.Builder = new NullBuilder();
            commonCss.Transforms.Add(new CssTransformer());
            commonCss.Orderer = new NullOrderer();

            return commonCss;
        }

        private static Bundle GetJsBundle()
        {
            var commonJs = new Bundle("~/Assets/CommonJs");

            commonJs.IncludeDirectory("~/Assets/js/vendor", "*.js", true);
            commonJs.IncludeDirectory("~/Assets/js/app", "*.js");
            commonJs.IncludeDirectory("~/Assets/js/app/factories", "*.js");
            commonJs.IncludeDirectory("~/Assets/js/app/components", "*.js", true);
            
            commonJs.Builder = new NullBuilder();
            commonJs.Transforms.Add(new JsTransformer());
            commonJs.Orderer = new NullOrderer();

            return commonJs;
        }
    }
}