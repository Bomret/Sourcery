using System.IO;
using Machine.Specifications;

namespace Sourcery.Tests.FileSource
{
    [Subject(typeof (Sources.FileSource), "GetAsText")]
    public class When_I_get_a_file_as_text_twice
    {
        private static string _testFile;
        private static ISource _sut;
        private static string _text1;
        private static string _testContent;
        private static string _text2;

        private Establish context = () =>
        {
            _testFile = Path.GetTempFileName();
            _testContent = "This is some example content";

            File.WriteAllText(_testFile, _testContent);

            _sut = Source.FromFile(_testFile);
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