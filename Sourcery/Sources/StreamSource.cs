using System;
using System.Collections.Generic;
using System.IO;

namespace Sourcery.Sources
{
    public class StreamSource : ISource
    {
        private readonly Stream _stream;

        public StreamSource(Stream stream)
        {
            _stream = stream;
        }

        public IEnumerable<string> ReadLines()
        {
            using (var reader = new StreamReader(_stream))
            {
                while (!reader.EndOfStream)
                {
                    yield return reader.ReadLine();
                }
            }
        }

        public IEnumerable<T> ReadAllLinesAs<T>(Func<byte, T> converter)
        {
            using (var reader = new StreamReader(_stream))
            {
                while (!reader.EndOfStream)
                {
                    var b = Convert.ToByte(reader.Read());
                    yield return converter(b);
                }
            }
        }
    }
}