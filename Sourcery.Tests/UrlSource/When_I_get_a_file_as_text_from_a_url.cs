using System;
using System.IO;
using Machine.Specifications;

namespace Sourcery.Tests.UrlSource
{
    [Subject(typeof (Sources.UrlSource), "GetAsText")]
    public class When_I_get_a_file_as_text_from_a_url
    {
        private static string _testFile;
        private static ISource _sut;
        private static string _text;
        private static string _testContent;
        private static Uri _testUri;

        private Establish context = () =>
        {
            _testFile = Path.GetTempFileName();
            _testUri = new Uri(_testFile);
            _testContent = "This is some example content";

            File.WriteAllText(_testFile, _testContent);

            _sut = Source.FromUri(_testUri);
        };

        private Because of = () => _text = _sut.GetAsText();

        private It should_return_all_lines = () => _text.ShouldEqual(_testContent);

        private Cleanup stuff = () => File.Delete(_testFile);
    }
}