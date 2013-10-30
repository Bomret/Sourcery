using System;
using Machine.Specifications;

namespace Sourcery.Tests
{
    [Subject(typeof (Source), "From")]
    public class When_I_create_a_source_from_a_uri
    {
        private static ISource _sut;
        private static Uri _uri;

        private Establish context = () => _uri = new Uri("http://httpbin.org/");

        private Because of = () => _sut = Source.FromUri(_uri);

        private It should_return_a_source = () => _sut.ShouldNotBeNull();
    }
}