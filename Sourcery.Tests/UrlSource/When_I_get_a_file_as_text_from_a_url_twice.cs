using System;
using System.IO;
using Machine.Specifications;

namespace Sourcery.Tests.UrlSource
{
    [Subject(typeof (Sources.UrlSource), "GetAsText")]
    public class When_I_get_a_file_as_text_from_a_url_twice
    {
        private static string _testFile;
        private static ISource _sut;
        private static string _text1;
        private static string _testContent;
        private static Uri _testUri;
        private static string _text2;

        private Establish context = () =>
        {
            _testFile = Path.GetTempFileName();
            _testUri = new Uri(_testFile);
            _testContent = "This is some example content";

            File.WriteAllText(_testFile, _testContent);

            _sut = Source.FromUri(_testUri);
        };

        private Because of = () =>
        {
            _text1 = _sut.GetAsText();
            _text2 = _sut.GetAsText();
        };

        private It should_return_all_lines_the_first_time = () => _text1.ShouldEqual(_testContent);

        private It should_return_all_lines_the_second_time = () => _text2.ShouldEqual(_testContent);

        private Cleanup stuff = () => File.Delete(_testFile);
    }
}