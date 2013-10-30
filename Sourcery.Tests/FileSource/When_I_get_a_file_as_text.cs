using System.IO;
using Machine.Specifications;

namespace Sourcery.Tests.FileSource
{
    [Subject(typeof (Sources.FileSource), "GetAsText")]
    public class When_I_get_a_file_as_text
    {
        private static string _testFile;
        private static ISource _sut;
        private static string _text;
        private static string _testContent;

        private Establish context = () =>
        {
            _testFile = Path.GetTempFileName();
            _testContent = "This is some example content";

            File.WriteAllText(_testFile, _testContent);

            _sut = Source.FromFile(_testFile);
        };

        private Because of = () => _text = _sut.GetAsText();

        private It should_return_all_lines = () => _text.ShouldEqual(_testContent);

        private Cleanup stuff = () => File.Delete(_testFile);
    }
}