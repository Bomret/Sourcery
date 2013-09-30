using System.Collections.Generic;
using System.IO;
using Machine.Specifications;
using Sourcery.Sources;

namespace Sourcery.Tests
{
    [Subject(typeof (FileSource), "ReadLines")]
    public class When_I_read_all_lines_from_a_text_file
    {
        private static string _testFile;
        private static ISource _sut;
        private static IEnumerable<string> _lines;
        private static string[] _testContent;

        private Establish context = () =>
        {
            _testFile = Path.GetTempFileName();
            _testContent = new[]
            {
                "This",
                "is",
                "",
                "some",
                "example",
                "content"
            };

            File.WriteAllLines(_testFile, _testContent);

            _sut = Source.FromFile(_testFile);
        };

        private Because of = () => _lines = _sut.ReadLines();

        private It should_return_all_lines = () => _lines.ShouldEqual(_testContent);
    }
}