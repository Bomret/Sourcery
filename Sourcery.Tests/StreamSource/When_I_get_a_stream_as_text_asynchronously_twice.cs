using System.IO;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;

namespace Sourcery.Tests.StreamSource
{
    [Subject(typeof (Sources.StreamSource), "GetAsTextAsync")]
    public class When_I_get_a_stream_as_text_asynchronously_twice
    {
        private static ISource _sut;
        private static string _testContent;
        private static Task<string> _text1;
        private static Task<string> _text2;

        private Establish context = () =>
        {
            _testContent = "This is some example content";

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(_testContent));

            _sut = Source.FromStream(stream);
        };

        private Because of = () =>
        {
            _text1 = _sut.GetAsTextAsync();
            _text2 = _sut.GetAsTextAsync();
        };

        private It should_return_all_lines_the_first_time = () => _text1.Result.ShouldEqual(_testContent);

        private It should_return_all_lines_the_second_time = () => _text2.Result.ShouldEqual(_testContent);
    }
}