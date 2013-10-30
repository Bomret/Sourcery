using System;
using Machine.Specifications;

namespace Sourcery.Tests.UrlSource
{
    [Subject(typeof (Sources.UrlSource), "GetAsText")]
    public class When_I_get_a_url_as_text
    {
        private static Uri _testUrl;
        private static ISource _sut;
        private static string _text;

        private Establish context = () =>
        {
            _testUrl = new Uri("http://httpbin.org/");

            _sut = Source.FromUri(_testUrl);
        };

        private Because of = () => _text = _sut.GetAsText();

        private It should_return_all_lines = () => _text.ShouldContain("httpbin");
    }
}