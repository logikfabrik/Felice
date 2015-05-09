using System;

namespace Logikfabrik.Felice.Utilities
{
    public static class UrlUtility
    {
        private static string GetProtocol(bool ssl)
        {
            return ssl ? "https" : "http";
        }

        public static bool ShouldRedirectPermanent(string url, bool ssl)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Url cannot be null or white space.", "url");

            return !url.StartsWith(string.Concat(GetProtocol(ssl), "://www."));
        }

        public static string GetRedirectUrl(string url, bool ssl)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Url cannot be null or white space.", "url");

            if (!ShouldRedirectPermanent(url, ssl))
                return url;

            var protocol = GetProtocol(ssl);

            return string.Concat(protocol, "://www.", url.Remove(0, string.Concat(protocol, "://").Length));
        }
    }
}