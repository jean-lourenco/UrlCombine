using System;

namespace UrlCombine
{
    public static class UriExtension
    {
        /// <summary>
        /// Combines the Uri with a base path and the relative url into one, consolidating the '/' between them
        /// </summary>
        /// <param name="urlBase">Base Uri that will be combined</param>
        /// <param name="relativeUrl">The relative path to combine</param>
        /// <returns>The merged Uri</returns>
        public static Uri Combine(this Uri baseUri, string relativeUrl)
        {
            return new Uri(UrlCombine.Combine(baseUri.AbsoluteUri, relativeUrl));
        }
    }
}