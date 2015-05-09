using Logikfabrik.Felice.ViewModels;
using System;
using System.Text;
using System.Web.Mvc;

namespace Logikfabrik.Felice.Html
{
    public static class HeadHtmlHelperExtensions
    {
        public static MvcHtmlString HeadFor<TModel>(this HtmlHelper<TModel> htmlHelper, TModel model)
            where TModel : BasePageViewModel
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var builder = new StringBuilder();

            builder.AppendLine(GetMetadata(model));
            builder.AppendLine(GetFacebookMetadata(htmlHelper, model));
            builder.AppendLine(GetTwitterMetadata(model));

            if (!htmlHelper.ViewContext.HttpContext.IsDebuggingEnabled)
                builder.AppendLine(GetCanonicalLink(model.Url, htmlHelper.ViewContext.HttpContext.Request.IsSecureConnection));

            return new MvcHtmlString(builder.ToString());
        }

        private static string GetMetadata<TModel>(TModel model) where TModel : BasePageViewModel
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var builder = new StringBuilder();

            builder.AppendLine("<meta charset=\"utf-8\">");
            builder.AppendLine(GetMetadataTag("viewport", "width=device-width,initial-scale=1.0"));
            builder.AppendLine(GetMetadataTag("description", model.MetaDescription));
            builder.AppendLine(GetMetadataTag("keywords", model.MetaKeywords));
            builder.AppendLine(GetMetadataTag("author", "Restaurang Felicé"));
            builder.AppendLine(GetMetadataTag("application-name", "Restaurang Felicé"));

            return builder.ToString();
        }

        private static string GetFacebookMetadata<TModel>(this HtmlHelper htmlHelper, TModel model)
            where TModel : BasePageViewModel
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var builder = new StringBuilder();

            builder.AppendLine(GetOpenGraphMetadataTag("og:site_name", "Restaurang Felicé"));
            builder.AppendLine(GetOpenGraphMetadataTag("og:type", "website"));
            builder.AppendLine(GetOpenGraphMetadataTag("og:title", model.Name));
            builder.AppendLine(GetOpenGraphMetadataTag("og:description", model.MetaDescription));

            if (!htmlHelper.ViewContext.HttpContext.IsDebuggingEnabled)
                builder.AppendLine(GetOpenGraphMetadataTag("og:url",
                    GetCanonicalUrl(model.Url, htmlHelper.ViewContext.HttpContext.Request.IsSecureConnection)));

            return builder.ToString();
        }

        private static string GetTwitterMetadata<TModel>(TModel model)
            where TModel : BasePageViewModel
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var builder = new StringBuilder();

            builder.AppendLine(GetOpenGraphMetadataTag("twitter:card", "summary"));
            builder.AppendLine(GetOpenGraphMetadataTag("twitter:title", model.Name));
            builder.AppendLine(GetOpenGraphMetadataTag("twitter:description", model.MetaDescription));

            return builder.ToString();
        }

        private static string GetOpenGraphMetadataTag(string property, string content)
        {
            if (string.IsNullOrWhiteSpace(property))
                throw new ArgumentException("Property cannot be null or white space.", "property");

            return string.Format("<meta property=\"{0}\" content=\"{1}\" />", property, content);
        }

        private static string GetMetadataTag(string name, string content)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or white space.", "name");

            return string.Format("<meta name=\"{0}\" content=\"{1}\" />", name, content);
        }

        private static string GetCanonicalLink(string url, bool ssl)
        {
            return string.IsNullOrWhiteSpace(url)
                ? null
                : string.Format("<link rel=\"canonical\" href=\"{0}\" />", GetCanonicalUrl(url, ssl));
        }

        private static string GetCanonicalUrl(string url, bool ssl)
        {
            if (string.IsNullOrWhiteSpace(url))
                return null;

            var protocol = ssl ? "https" : "http";

            return string.Concat(protocol, "://www.restaurangfelice.se", url);
        }
    }
}