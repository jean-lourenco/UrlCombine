namespace UrlCombine
{
    public static class StringExtension
    {
        /// <summary>
        /// Combines the url base and the relative url into one, consolidating the '/' between them
        /// </summary>
        /// <param name="urlBase">Base url that will be combined</param>
        /// <param name="relativeUrl">The relative path to combine</param>
        /// <returns>The merged url</returns>
        public static string CombineUrl(this string urlBase, string relativeUrl)
        {
            return UrlCombine.Combine(urlBase, relativeUrl);
        }
    }
}