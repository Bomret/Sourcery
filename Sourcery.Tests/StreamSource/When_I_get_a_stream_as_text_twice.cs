using System.IO;
using System.Text;
using Machine.Specifications;

namespace Sourcery.Tests.StreamSource
{
    [Subject(typeof (Sources.StreamSource), "GetAsText")]
    public class When_I_get_a_stream_as_text_twice
    {
        private static ISource _sut;
        private static string _testContent;
        private static string _text1;
        private static string _text2;

        private Establish context = () =>
        {
            _testContent = "This is some example content";

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(_testContent));

            _sut = Source.FromStream(stream);
        };

        private Because of = () =>
        {
            _text1 = _sut.GetAsText();
            _text2 = _sut.GetAsText();
        };

        private It should_return_all_lines_the_first_time = () => _text1.ShouldEqual(_testContent);

        private It should_return_all_lines_the_second_time = () => _text2.ShouldEqual(_testContent);
    }
}