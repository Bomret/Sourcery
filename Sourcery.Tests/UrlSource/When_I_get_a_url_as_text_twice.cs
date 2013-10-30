using System;
using Machine.Specifications;

namespace Sourcery.Tests.UrlSource
{
    [Subject(typeof (Sources.UrlSource), "GetAsText")]
    public class When_I_get_a_url_as_text_twice
    {
        private static Uri _testUrl;
        private static ISource _sut;
        private static string _text1;
        private static string _text2;

        private Establish context = () =>
        {
            _testUrl = new Uri("http://httpbin.org/");

            _sut = Source.FromUri(_testUrl);
        };

        private Because of = () =>
        {
            _text1 = _sut.GetAsText();
            _text2 = _sut.GetAsText();
        };

        private It should_return_all_lines_the_first_time = () => _text1.ShouldContain("httpbin");

        private It should_return_all_lines_the_second_time = () => _text2.ShouldContain("httpbin");
    }
}