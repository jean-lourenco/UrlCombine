﻿namespace UrlCombineLib
{
    public static class StringExtension
    {
        /// <summary>
        /// Combines the url base and the relative url into one, consolidating the '/' between them
        /// </summary>
        /// <param name="urlBase">Base url that will be combined</param>
        /// <param name="relativeUrl">The relative path to combine</param>
        /// <returns>The merged url</returns>
        public static string CombineUrl(
            this string urlBase, 
            string relativeUrl) =>
            UrlCombine.Combine(urlBase, relativeUrl);

        /// <summary>
        /// Combines the url base and the array of relative urls into one, consolidating the '/' between them
        /// </summary>
        /// <param name="urlBase">Base url that will be combined</param>
        /// <param name="relativeUrls">The array of relative paths to combine</param>
        /// <returns>The merged url</returns>
        public static string CombineUrl(
            this string urlBase, 
            params string[] relativeUrls) =>
            UrlCombine.Combine(urlBase, relativeUrls);
    }
}