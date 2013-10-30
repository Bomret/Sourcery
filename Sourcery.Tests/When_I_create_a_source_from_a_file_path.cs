using System.IO;
using Machine.Specifications;

namespace Sourcery.Tests
{
    [Subject(typeof (Source), "From")]
    public class When_I_create_a_source_from_a_file_path
    {
        private static string _testFile;
        private static ISource _sut;

        private Establish context = () => _testFile = Path.GetTempFileName();

        private Because of = () => _sut = Source.FromFile(_testFile);

        private It should_return_a_source = () => _sut.ShouldNotBeNull();

        private Cleanup stuff = () => File.Delete(_testFile);
    }
}