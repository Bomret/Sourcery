using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Machine.Specifications;
using Sourcery.Sources;

namespace Sourcery.Tests
{
    [Subject(typeof (FileSource), "ReadAllLinesAs")]
    public class When_I_read_all_from_a_text_file_as_integers
    {
        private static string _testFile;
        private static ISource _sut;
        private static IEnumerable<char> _lines;
        private static IEnumerable<char> _expectedContent;

        private Establish context = () =>
        {
            _testFile = Path.GetTempFileName();
            var testContent = new[]
            {
                "This",
                "is",
                "",
                "some",
                "example",
                "content"
            };

            File.WriteAllLines(_testFile, testContent);

            _expectedContent = File.ReadAllBytes(_testFile)
                                   .Select(Convert.ToChar);

            _sut = Source.FromFile(_testFile);
        };

        private Because of = () => _lines = _sut.ReadAllLinesAs(Convert.ToChar);

        private It should_return_all_lines = () => _lines.ShouldEqual(_expectedContent);
    }
}