using System;
using System.Collections.Generic;
using Machine.Specifications;
using Sourcery.Sources;

namespace Sourcery.Tests
{
    [Subject(typeof (UrlSource), "ReadLines")]
    public class When_I_read_all_lines_from_a_url
    {
        private static Uri _testUrl;
        private static ISource _sut;
        private static IEnumerable<string> _lines;

        private Establish context = () =>
        {
            _testUrl = new Uri("http://google.com/");

            _sut = Source.FromUrl(_testUrl);
        };

        private Because of = () => _lines = _sut.ReadLines();

        private It should_return_all_lines = () => _lines.ShouldContain(l => l.Contains("google"));
    }
}