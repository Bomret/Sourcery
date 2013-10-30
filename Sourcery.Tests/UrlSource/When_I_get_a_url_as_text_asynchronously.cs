using System;
using System.Threading.Tasks;
using Machine.Specifications;

namespace Sourcery.Tests.UrlSource
{
    [Subject(typeof (Sources.UrlSource), "GetAsTextAsync")]
    public class When_I_get_a_url_as_text_asynchronously
    {
        private static Uri _testUrl;
        private static ISource _sut;
        private static Task<string> _text;

        private Establish context = () =>
        {
            _testUrl = new Uri("http://httpbin.org/");

            _sut = Source.FromUri(_testUrl);
        };

        private Because of = () => _text = _sut.GetAsTextAsync();

        private It should_return_all_lines = () => _text.Result.ShouldContain("httpbin");
    }
}