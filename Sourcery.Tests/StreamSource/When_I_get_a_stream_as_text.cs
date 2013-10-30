using System.IO;
using System.Text;
using Machine.Specifications;

namespace Sourcery.Tests.StreamSource
{
    [Subject(typeof (Sources.StreamSource), "GetAsText")]
    public class When_I_get_a_stream_as_text
    {
        private static ISource _sut;
        private static string _testContent;
        private static string _text;

        private Establish context = () =>
        {
            _testContent = "This is some example content";

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(_testContent));

            _sut = Source.FromStream(stream);
        };

        private Because of = () => _text = _sut.GetAsText();

        private It should_return_all_lines = () => _text.ShouldEqual(_testContent);
    }
}