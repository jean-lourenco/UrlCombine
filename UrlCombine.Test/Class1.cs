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
    }
}