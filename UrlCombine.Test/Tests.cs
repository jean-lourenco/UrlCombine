using System;
using Xunit;

namespace UrlCombine.Test
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
            var expected = "http://www.google.com.br/";

            var actualStatic = UrlCombine.Combine(expected, null);
            var actualUriExtension = new Uri(expected).Combine(null).ToString();
            var actualStringExtension = expected.CombineUrl(null);

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
    }
}