using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlCombine
{
    public static class UrlCombine
    {
        /// <summary>
        /// Combines the url base and the relative url into one, consolidating the '/' between them
        /// </summary>
        /// <param name="urlBase">Base url that will be combined</param>
        /// <param name="relativeUrl">The relative path to combine</param>
        /// <returns>The merged url</returns>
        public static string Combine(string baseUrl, string relativeUrl)
        {
            if (baseUrl.Length == 0)
                return relativeUrl;

            if (relativeUrl.Length == 0)
                return baseUrl;

            baseUrl = baseUrl.TrimEnd('/');
            relativeUrl = relativeUrl.TrimStart('/');

            return $"{baseUrl}/{relativeUrl}";
        }
    }
}