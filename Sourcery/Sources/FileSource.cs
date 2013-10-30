using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sourcery.Sources
{
    public sealed class FileSource : ISource
    {
        private readonly string _path;

        public FileSource(string path)
        {
            _path = path;
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

            using (var fs = File.Open(_path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var content = fs.ReadToArray();

                return encoding.GetString(content);
            }
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
                using (var fs = File.Open(_path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var content = fs.ReadToArray();

                    return encoding.GetString(content);
                }
            });
        }

        public byte[] GetAsByteArray()
        {
            using (var fs = File.Open(_path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return fs.ReadToArray();
            }
        }

        public Task<byte[]> GetAsByteArrayAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                using (var fs = File.Open(_path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return fs.ReadToArray();
                }
            });
        }

        public Stream GetAsStream()
        {
            return File.Open(_path, FileMode.Open, FileAccess.Read, FileShare.Read);
        }

        public Task<Stream> GetAsStreamAsync()
        {
            return
                Task.Factory.StartNew(() => File.Open(_path, FileMode.Open, FileAccess.Read, FileShare.Read) as Stream);
        }
    }
}