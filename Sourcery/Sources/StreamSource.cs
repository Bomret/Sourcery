using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sourcery.Sources
{
    public sealed class StreamSource : ISource
    {
        private readonly Stream _stream;

        public StreamSource(Stream stream)
        {
            _stream = stream;
        }

        public string GetAsText()
        {
            return GetAsText(Encoding.UTF8);
        }

        public string GetAsText(Encoding encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }

            var data = _stream.ReadToArray();

            return encoding.GetString(data);
        }

        public Task<string> GetAsTextAsync()
        {
            return GetAsTextAsync(Encoding.UTF8);
        }

        public Task<string> GetAsTextAsync(Encoding encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }

            return Task.Factory.StartNew(() =>
            {
                var data = _stream.ReadToArray();

                return encoding.GetString(data);
            });
        }

        public byte[] GetAsByteArray()
        {
            var data = _stream.ReadToArray();

            return data;
        }

        public Task<byte[]> GetAsByteArrayAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                var data = _stream.ReadToArray();

                return data;
            });
        }

        public Stream GetAsStream()
        {
            var returnStream = new MemoryStream();
            _stream.CopyTo(returnStream);

            return returnStream;
        }

        public Task<Stream> GetAsStreamAsync()
        {
            Stream returnStream = new MemoryStream();

            return _stream.CopyToAsync(returnStream)
                          .ContinueWith(_ => returnStream);
        }
    }
}