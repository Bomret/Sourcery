using System.IO;
using Machine.Specifications;

namespace Sourcery.Tests
{
    [Subject(typeof (Source), "From")]
    public class When_I_create_a_source_from_a_stream
    {
        private static ISource _sut;
        private static MemoryStream _stream;

        private Establish context = () => _stream = new MemoryStream();

        private Because of = () => _sut = Source.FromStream(_stream);

        private It should_return_a_source = () => _sut.ShouldNotBeNull();

        private Cleanup stuff = () => _stream.Close();
    }
}