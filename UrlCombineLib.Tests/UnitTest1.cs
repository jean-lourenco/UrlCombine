using System;
using Xunit;

namespace UrlCombineLib.Tests
{
    public class Tests
    {
        [Theory]
        [InlineData("http://www.salem.com.br", "/john/hathorne", "http://www.salem.com.br/john/hathorne")]
        [InlineData("http://www.salem.com.br", "john/hathorne", "http://www.salem.com.br/john/hathorne")]
        [InlineData("http://www.salem.com.br/", "/john/hathorne", "http://www.salem.com.br/john/hathorne")]
        [InlineData("http://www.salem.com.br/", "john/hathorne", "http://www.salem.com.br/john/hathorne")]
        [InlineData("http://www.salem.com.br/john", "/hathorne", "http://www.salem.com.br/john/hathorne")]
        [InlineData("http://www.salem.com.br/john", "hathorne", "http://www.salem.com.br/john/hathorne")]
        [InlineData("http://www.salem.com.br/john/", "/hathorne", "http://www.salem.com.br/john/hathorne")]
        [InlineData("http://www.salem.com.br/john/", "hathorne", "http://www.salem.com.br/john/hathorne")]
        public void One_Base_Path_Should_Be_Combined_With_Relative_Path(string url1, string url2, string expected)
        {
            var actualStatic = UrlCombine.Combine(url1, url2);
            var actualUriExtension = new Uri(url1).Combine(url2).ToString();
            var actualStringExtension = url1.CombineUrl(url2);

            Assert.Equal(expected, actualStatic);
            Assert.Equal(expected, actualUriExtension);
            Assert.Equal(expected, actualStringExtension);
        }

        [Fact]
        public void Base_Path_With_No_Relative_Should_Return_Base_Path()
        {
            string nullString = null;
            var expected = "http://www.google.com.br/";

            var actualStatic = UrlCombine.Combine(expected, nullString);
            var actualUriExtension = new Uri(expected).Combine(nullString).ToString();
            var actualStringExtension = expected.CombineUrl(nullString);

            Assert.Equal(expected, actualStatic);
            Assert.Equal(expected, actualUriExtension);
            Assert.Equal(expected, actualStringExtension);
        }

        [Fact]
        public void Base_Path_Null_Should_Throw_Exception()
        {
            string basePath = null;
            Uri baseUri = null;

            Assert.Throws<ArgumentNullException>(() => UrlCombine.Combine(basePath, "relative/path"));
            Assert.Throws<ArgumentNullException>(() => basePath.CombineUrl("relative/path"));
            Assert.Throws<ArgumentNullException>(() => baseUri.Combine("relative/path"));
        }

        [Fact]
        public void Base_Path_Null_Should_Throw_Exception_At_Combine_With_Params()
        {
            var relativePaths = new string[] { "john", "hathorne" };
            string basePath = null;
            Uri baseUri = null;

            Assert.Throws<ArgumentNullException>(() => UrlCombine.Combine(basePath, relativePaths));
            Assert.Throws<ArgumentNullException>(() => basePath.CombineUrl(relativePaths));
            Assert.Throws<ArgumentNullException>(() => baseUri.Combine(relativePaths));
        }

        [Theory]
        [InlineData("http://www.salem.com.br", "john#hathorne#magistrate", "http://www.salem.com.br/john/hathorne/magistrate")]
        [InlineData("http://www.salem.com.br", "/john/#/hathorne/#/magistrate", "http://www.salem.com.br/john/hathorne/magistrate")]
        [InlineData("http://www.salem.com.br", "/john#/hathorne#magistrate", "http://www.salem.com.br/john/hathorne/magistrate")]
        [InlineData("http://www.salem.com.br", "john#/hathorne#/magistrate", "http://www.salem.com.br/john/hathorne/magistrate")]
        [InlineData("http://www.salem.com.br/", "/john#/hathorne/#magistrate", "http://www.salem.com.br/john/hathorne/magistrate")]
        [InlineData("http://www.salem.com.br/", "john#/hathorne/#/magistrate", "http://www.salem.com.br/john/hathorne/magistrate")]
        [InlineData("http://www.salem.com.br", "/john#/hathorne", "http://www.salem.com.br/john/hathorne")]
        [InlineData("http://www.salem.com.br", "john#/hathorne", "http://www.salem.com.br/john/hathorne")]
        [InlineData("http://www.salem.com.br/", "/john#/hathorne", "http://www.salem.com.br/john/hathorne")]
        [InlineData("http://www.salem.com.br/", "john#/hathorne", "http://www.salem.com.br/john/hathorne")]
        [InlineData("http://www.salem.com.br/john", "/hathorne", "http://www.salem.com.br/john/hathorne")]
        [InlineData("http://www.salem.com.br/john", "hathorne", "http://www.salem.com.br/john/hathorne")]
        [InlineData("http://www.salem.com.br/john/", "/hathorne", "http://www.salem.com.br/john/hathorne")]
        [InlineData("http://www.salem.com.br/john/", "hathorne", "http://www.salem.com.br/john/hathorne")]
        public void Combine_With_Params_Should_Merge_Urls_Correctly(string baseUrl, string relativePathsRaw, string expected)
        {
            var relativePaths = relativePathsRaw.Split('#');

            var urlStatic = UrlCombine.Combine(baseUrl, relativePaths);
            var urlUriExtension = new Uri(baseUrl).Combine(relativePaths).ToString();
            var urlStringExtesion = baseUrl.CombineUrl(relativePaths);

            Assert.Equal(urlStatic, expected);
            Assert.Equal(urlUriExtension, expected);
            Assert.Equal(urlStringExtesion, expected);
        }

        [Theory]
        [InlineData("http://www.salem.com.br", "john#/#hathorne/#/#/magistrate", "http://www.salem.com.br/john/hathorne/magistrate")]
        [InlineData("http://www.salem.com.br", "/john/##/hathorne/##/magistrate", "http://www.salem.com.br/john/hathorne/magistrate")]
        [InlineData("http://www.salem.com.br", "/john##/hathorne/#/#/magistrate", "http://www.salem.com.br/john/hathorne/magistrate")]
        public void Combine_Should_Ignore_Empty_Spaces_And_Empty_Slashes(string baseUrl, string relativePathsRaw, string expected)
        {
            var relativePaths = relativePathsRaw.Split('#');

            var urlStatic = UrlCombine.Combine(baseUrl, relativePaths);
            var urlUriExtension = new Uri(baseUrl).Combine(relativePaths).ToString();
            var urlStringExtesion = baseUrl.CombineUrl(relativePaths);

            Assert.Equal(urlStatic, expected);
            Assert.Equal(urlUriExtension, expected);
            Assert.Equal(urlStringExtesion, expected);
        }
    }
}
